using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreamReader
{
    public class ScreamReaderTray : Form
    {
        internal UdpWaveStreamPlayer udpPlayer = null;
        protected internal NotifyIcon trayIcon;
        protected ContextMenu trayMenu;
        private MainForm mainForm;
        private Task reconnectTask = null;
        
        protected bool _shouldReconnect = true;     // reconnect every 30 seconds
        protected bool _lastExitUnclean = false;    // only reconnect if we didn't manually stop the listener
         
        public bool shouldReconnect
        {
            get => _shouldReconnect;
            set
            {
                if(_shouldReconnect == value) return; 
                _shouldReconnect = value;
                StartReconnectTask();
            }
        }

        public void StartReconnectTask()
        {
            if(_shouldReconnect && reconnectTask == null)
                reconnectTask = Task.Run(async () =>
                {
                    // try to reconnect after 1 second for network hiccups, then every 30 seconds
                    while (_shouldReconnect && _lastExitUnclean)
                    {
                        await Task.Delay(1000);
                        if (!IsListening && _shouldReconnect)
                            StartListener();
                        await Task.Delay(29000);
                    }
                    reconnectTask = null;
                });
        }

        public ScreamReaderTray()
        {
            try
            { 
                trayIcon = new NotifyIcon();
                trayIcon.Text = "ScreamReader";
                trayIcon.Icon = Properties.Resources.speaker_mute;
                mainForm = new MainForm(this);
                trayMenu = new ContextMenu();

                StartListener();
                
                // Add menu to tray icon and show it.
                trayIcon.ContextMenu = trayMenu;
                trayIcon.Visible = true;
                trayIcon.DoubleClick += (object sender, EventArgs e) =>
                {
                    if (mainForm.Visible)
                    {
                        mainForm.Focus();
                        return;
                    }
                    mainForm.ShowDialog(this);
                }; 
                UpdateUI();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
         
        }

        public void ToggleActive(object sender, EventArgs e)
        {
            if (this.IsListening)
                this.StopListener();
            else
                this.StartListener();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            base.OnLoad(e);
        }

        public bool IsListening => udpPlayer != null;

        internal void StartListener()
        {
            StopListener();

            udpPlayer = new UdpWaveStreamPlayer();
            if (udpPlayer.Start())
            {
                udpPlayer.Volume = Math.Max(0, Math.Min(this.mainForm.loudnessFader.Value, 100));
                UpdateUI();
                return;
            }   

            // this calls updateUI
            StopListener();
        }

        // Update labels and such
        internal void UpdateUI()
        {
            trayMenu.MenuItems.Clear();
            trayMenu.MenuItems.Add(IsListening ? "Stop Listener" : "Start Listener", ToggleActive);
            trayIcon.Icon = IsListening ? Properties.Resources.speaker_active : Properties.Resources.speaker_mute;
            trayMenu.MenuItems.Add("Exit", OnExit);
            mainForm.loudnessFader.Enabled = IsListening;
            if (IsListening)
                mainForm.loudnessFader.Value = udpPlayer.Volume;
        }

        internal void StopListener()
        {
            if (udpPlayer != null)
            {
                _lastExitUnclean = udpPlayer.uncleanExit;
                udpPlayer.Stop();
                udpPlayer.Dispose();
            }
            udpPlayer = null;
            if (trayIcon != null)
                trayIcon.Icon = Properties.Resources.speaker_mute;
            UpdateUI();
            if(_lastExitUnclean && shouldReconnect)
                StartReconnectTask();
        }
        private void OnExit(object sender, EventArgs e)
        {
            _lastExitUnclean = false;
            shouldReconnect = false;
            StopListener();
            if(trayIcon != null)
            trayIcon.Visible = false;
            Environment.Exit(0);
        }

        public void SetAutoReconnect(bool state) => this.shouldReconnect = state;
       
    }

    static class Program
    {
        private static Mutex mutex = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            mutex = new Mutex(true, "ScreamReaderNet", out createdNew);

            if(!createdNew) // disallow multiple copies since they won't be able to grab the listen port anyways
                return;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScreamReaderTray());
        }
    }
}
