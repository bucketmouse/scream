using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ScreamReader
{
    public partial class MainForm : Form
    {
        private ScreamReaderTray screamReaderTray;

        public MainForm(ScreamReaderTray screamReaderTray)
        {
            InitializeComponent();

            this.screamReaderTray = screamReaderTray; 

            this.FormClosing += (object sender, FormClosingEventArgs e) =>
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    this.Hide();
                }
            };

            this.loudnessFader.ValueChanged += (object sender, EventArgs e) =>
            {
                if(this.screamReaderTray.udpPlayer != null)
                    this.screamReaderTray.udpPlayer.Volume = this.loudnessFader.Value;
                this.volumeLabel.Text = this.loudnessFader.Value.ToString() + "%";
            };

            if(this.screamReaderTray.udpPlayer != null)
                this.loudnessFader.Value = this.screamReaderTray.udpPlayer.Volume; 
        }

        private void FileOnExitClick(object sender, EventArgs e)
        {
            this.screamReaderTray.udpPlayer.Dispose();
            Environment.Exit(0);
        }

        private void ToggleActive(object sender, EventArgs e)
        {
            this.screamReaderTray.ToggleActive(sender,e);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog(this);
        }

        private void autoReconnect_CheckedChanged(object sender, EventArgs e)
        {
            this.screamReaderTray.shouldReconnect = (sender as CheckBox).Checked;
        }
    }
}
