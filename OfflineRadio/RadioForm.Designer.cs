namespace OfflineRadio
{
    partial class RadioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadioForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshStationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearStationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showStationTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showStationValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CbB_Stations = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_StartPlayback = new System.Windows.Forms.Button();
            this.BT_StopPlayback = new System.Windows.Forms.Button();
            this.TrB_Volume = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.LB_Volume = new System.Windows.Forms.Label();
            this.WMP_RadioPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrB_Volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WMP_RadioPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(244, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFolderToolStripMenuItem,
            this.refreshStationsToolStripMenuItem,
            this.clearStationsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.fileToolStripMenuItem.Text = "Stations";
            // 
            // selectFolderToolStripMenuItem
            // 
            this.selectFolderToolStripMenuItem.Name = "selectFolderToolStripMenuItem";
            this.selectFolderToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.selectFolderToolStripMenuItem.Text = "Select Folder";
            this.selectFolderToolStripMenuItem.Click += new System.EventHandler(this.selectFolderToolStripMenuItem_Click);
            // 
            // refreshStationsToolStripMenuItem
            // 
            this.refreshStationsToolStripMenuItem.Name = "refreshStationsToolStripMenuItem";
            this.refreshStationsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.refreshStationsToolStripMenuItem.Text = "Refresh Stations";
            this.refreshStationsToolStripMenuItem.Click += new System.EventHandler(this.refreshStationsToolStripMenuItem_Click);
            // 
            // clearStationsToolStripMenuItem
            // 
            this.clearStationsToolStripMenuItem.Name = "clearStationsToolStripMenuItem";
            this.clearStationsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.clearStationsToolStripMenuItem.Text = "Clear Stations";
            this.clearStationsToolStripMenuItem.Click += new System.EventHandler(this.clearStationsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showStationTimeToolStripMenuItem,
            this.showStationValuesToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // showStationTimeToolStripMenuItem
            // 
            this.showStationTimeToolStripMenuItem.Name = "showStationTimeToolStripMenuItem";
            this.showStationTimeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.showStationTimeToolStripMenuItem.Text = "Show Station Time";
            this.showStationTimeToolStripMenuItem.Click += new System.EventHandler(this.showStationTimeToolStripMenuItem_Click);
            // 
            // showStationValuesToolStripMenuItem
            // 
            this.showStationValuesToolStripMenuItem.Name = "showStationValuesToolStripMenuItem";
            this.showStationValuesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.showStationValuesToolStripMenuItem.Text = "Show Station Values";
            this.showStationValuesToolStripMenuItem.Click += new System.EventHandler(this.showStationValuesToolStripMenuItem_Click);
            // 
            // CbB_Stations
            // 
            this.CbB_Stations.FormattingEnabled = true;
            this.CbB_Stations.Location = new System.Drawing.Point(56, 23);
            this.CbB_Stations.Name = "CbB_Stations";
            this.CbB_Stations.Size = new System.Drawing.Size(181, 21);
            this.CbB_Stations.TabIndex = 1;
            this.CbB_Stations.SelectedIndexChanged += new System.EventHandler(this.CbB_Stations_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Station:";
            // 
            // BT_StartPlayback
            // 
            this.BT_StartPlayback.Location = new System.Drawing.Point(10, 49);
            this.BT_StartPlayback.Name = "BT_StartPlayback";
            this.BT_StartPlayback.Size = new System.Drawing.Size(111, 20);
            this.BT_StartPlayback.TabIndex = 3;
            this.BT_StartPlayback.Text = "&Play";
            this.BT_StartPlayback.UseVisualStyleBackColor = true;
            this.BT_StartPlayback.Click += new System.EventHandler(this.BT_StartPlayback_Click);
            // 
            // BT_StopPlayback
            // 
            this.BT_StopPlayback.Enabled = false;
            this.BT_StopPlayback.Location = new System.Drawing.Point(126, 49);
            this.BT_StopPlayback.Name = "BT_StopPlayback";
            this.BT_StopPlayback.Size = new System.Drawing.Size(111, 20);
            this.BT_StopPlayback.TabIndex = 4;
            this.BT_StopPlayback.Text = "&Stop";
            this.BT_StopPlayback.UseVisualStyleBackColor = true;
            this.BT_StopPlayback.Click += new System.EventHandler(this.BT_StopPlayback_Click);
            // 
            // TrB_Volume
            // 
            this.TrB_Volume.Location = new System.Drawing.Point(48, 74);
            this.TrB_Volume.Maximum = 100;
            this.TrB_Volume.Name = "TrB_Volume";
            this.TrB_Volume.Size = new System.Drawing.Size(186, 45);
            this.TrB_Volume.TabIndex = 5;
            this.TrB_Volume.TickFrequency = 5;
            this.TrB_Volume.Value = 100;
            this.TrB_Volume.Scroll += new System.EventHandler(this.TrB_Volume_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Volume:";
            // 
            // LB_Volume
            // 
            this.LB_Volume.AutoSize = true;
            this.LB_Volume.Location = new System.Drawing.Point(10, 87);
            this.LB_Volume.Name = "LB_Volume";
            this.LB_Volume.Size = new System.Drawing.Size(25, 13);
            this.LB_Volume.TabIndex = 7;
            this.LB_Volume.Text = "100";
            // 
            // WMP_RadioPlayer
            // 
            this.WMP_RadioPlayer.Enabled = true;
            this.WMP_RadioPlayer.Location = new System.Drawing.Point(151, 0);
            this.WMP_RadioPlayer.Name = "WMP_RadioPlayer";
            this.WMP_RadioPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMP_RadioPlayer.OcxState")));
            this.WMP_RadioPlayer.Size = new System.Drawing.Size(81, 24);
            this.WMP_RadioPlayer.TabIndex = 8;
            this.WMP_RadioPlayer.Visible = false;
            this.WMP_RadioPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.WMP_RadioPlayer_PlayStateChange);
            // 
            // RadioForm
            // 
            this.AnchorDistance = -7;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 106);
            this.Controls.Add(this.WMP_RadioPlayer);
            this.Controls.Add(this.LB_Volume);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TrB_Volume);
            this.Controls.Add(this.BT_StopPlayback);
            this.Controls.Add(this.BT_StartPlayback);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbB_Stations);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(260, 1450);
            this.MinimumSize = new System.Drawing.Size(260, 145);
            this.Name = "RadioForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Radio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RadioForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrB_Volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WMP_RadioPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showStationTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showStationValuesToolStripMenuItem;
        private System.Windows.Forms.ComboBox CbB_Stations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_StartPlayback;
        private System.Windows.Forms.Button BT_StopPlayback;
        private System.Windows.Forms.TrackBar TrB_Volume;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LB_Volume;
        private AxWMPLib.AxWindowsMediaPlayer WMP_RadioPlayer;
        private System.Windows.Forms.ToolStripMenuItem clearStationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshStationsToolStripMenuItem;
    }
}