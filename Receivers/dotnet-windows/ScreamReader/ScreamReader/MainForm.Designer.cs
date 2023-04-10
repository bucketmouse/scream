using System.Windows.Forms;

namespace ScreamReader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.loudnessFader = new System.Windows.Forms.TrackBar();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoReconnect = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.loudnessFader)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loudness:";
            // 
            // loudnessFader
            // 
            this.loudnessFader.LargeChange = 20;
            this.loudnessFader.Location = new System.Drawing.Point(13, 139);
            this.loudnessFader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loudnessFader.Maximum = 100;
            this.loudnessFader.Name = "loudnessFader";
            this.loudnessFader.Size = new System.Drawing.Size(322, 69);
            this.loudnessFader.SmallChange = 10;
            this.loudnessFader.TabIndex = 1;
            this.loudnessFader.TickFrequency = 10;
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(342, 153);
            this.volumeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(54, 20);
            this.volumeLabel.TabIndex = 3;
            this.volumeLabel.Text = "100 %";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(423, 35);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleActiveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toggleActiveToolStripMenuItem
            // 
            this.toggleActiveToolStripMenuItem.Name = "toggleActiveToolStripMenuItem";
            this.toggleActiveToolStripMenuItem.Size = new System.Drawing.Size(217, 34);
            this.toggleActiveToolStripMenuItem.Text = "Toggle active";
            this.toggleActiveToolStripMenuItem.Click += new System.EventHandler(this.ToggleActive);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(217, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.FileOnExitClick);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // autoReconnect
            // 
            this.autoReconnect.AutoSize = true;
            this.autoReconnect.Location = new System.Drawing.Point(13, 49);
            this.autoReconnect.Name = "autoReconnect";
            this.autoReconnect.Size = new System.Drawing.Size(299, 24);
            this.autoReconnect.TabIndex = 5;
            this.autoReconnect.Text = "Auto Reconnect When Disconnected";
            this.autoReconnect.UseVisualStyleBackColor = true;
            this.autoReconnect.CheckState = CheckState.Checked;
            this.autoReconnect.CheckedChanged += new System.EventHandler(this.autoReconnect_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 236);
            this.Controls.Add(this.autoReconnect);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.loudnessFader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "ScreamReader";
            ((System.ComponentModel.ISupportInitialize)(this.loudnessFader)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TrackBar loudnessFader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleActiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox autoReconnect;
    }
}