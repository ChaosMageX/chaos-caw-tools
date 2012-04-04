namespace ChaosTools.AudioPlayer
{
    partial class AudioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioForm));
            this.startSoundBTN = new System.Windows.Forms.Button();
            this.stopSoundBTN = new System.Windows.Forms.Button();
            this.soundNameTXT = new System.Windows.Forms.TextBox();
            this.soundPropGRP = new System.Windows.Forms.GroupBox();
            this.soundPropValueTXT = new System.Windows.Forms.TextBox();
            this.setSoundPropBTN = new System.Windows.Forms.Button();
            this.soundPropCMB = new System.Windows.Forms.ComboBox();
            this.gameSpeedGRP = new System.Windows.Forms.GroupBox();
            this.speedMultiplierTxt = new System.Windows.Forms.TextBox();
            this.playBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundPropGRP.SuspendLayout();
            this.gameSpeedGRP.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startSoundBTN
            // 
            this.startSoundBTN.Location = new System.Drawing.Point(13, 27);
            this.startSoundBTN.Name = "startSoundBTN";
            this.startSoundBTN.Size = new System.Drawing.Size(75, 23);
            this.startSoundBTN.TabIndex = 0;
            this.startSoundBTN.Text = "Start Sound";
            this.startSoundBTN.UseVisualStyleBackColor = true;
            this.startSoundBTN.Click += new System.EventHandler(this.startSound_Click);
            // 
            // stopSoundBTN
            // 
            this.stopSoundBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopSoundBTN.Enabled = false;
            this.stopSoundBTN.Location = new System.Drawing.Point(497, 24);
            this.stopSoundBTN.Name = "stopSoundBTN";
            this.stopSoundBTN.Size = new System.Drawing.Size(75, 23);
            this.stopSoundBTN.TabIndex = 1;
            this.stopSoundBTN.Text = "Stop Sound";
            this.stopSoundBTN.UseVisualStyleBackColor = true;
            this.stopSoundBTN.Click += new System.EventHandler(this.stopSound_Click);
            // 
            // soundNameTXT
            // 
            this.soundNameTXT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soundNameTXT.Location = new System.Drawing.Point(94, 27);
            this.soundNameTXT.Name = "soundNameTXT";
            this.soundNameTXT.Size = new System.Drawing.Size(397, 20);
            this.soundNameTXT.TabIndex = 2;
            // 
            // soundPropGRP
            // 
            this.soundPropGRP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.soundPropGRP.Controls.Add(this.soundPropValueTXT);
            this.soundPropGRP.Controls.Add(this.setSoundPropBTN);
            this.soundPropGRP.Controls.Add(this.soundPropCMB);
            this.soundPropGRP.Location = new System.Drawing.Point(219, 53);
            this.soundPropGRP.Name = "soundPropGRP";
            this.soundPropGRP.Size = new System.Drawing.Size(353, 57);
            this.soundPropGRP.TabIndex = 3;
            this.soundPropGRP.TabStop = false;
            this.soundPropGRP.Text = "Sound Property";
            // 
            // soundPropValueTXT
            // 
            this.soundPropValueTXT.Location = new System.Drawing.Point(202, 20);
            this.soundPropValueTXT.Name = "soundPropValueTXT";
            this.soundPropValueTXT.Size = new System.Drawing.Size(104, 20);
            this.soundPropValueTXT.TabIndex = 2;
            this.soundPropValueTXT.TextChanged += new System.EventHandler(this.soundPropValue_TextChanged);
            // 
            // setSoundPropBTN
            // 
            this.setSoundPropBTN.Location = new System.Drawing.Point(312, 18);
            this.setSoundPropBTN.Name = "setSoundPropBTN";
            this.setSoundPropBTN.Size = new System.Drawing.Size(35, 23);
            this.setSoundPropBTN.TabIndex = 1;
            this.setSoundPropBTN.Text = "Set";
            this.setSoundPropBTN.UseVisualStyleBackColor = true;
            this.setSoundPropBTN.Click += new System.EventHandler(this.setSoundProp_Click);
            // 
            // soundPropCMB
            // 
            this.soundPropCMB.FormattingEnabled = true;
            this.soundPropCMB.Location = new System.Drawing.Point(7, 20);
            this.soundPropCMB.Name = "soundPropCMB";
            this.soundPropCMB.Size = new System.Drawing.Size(189, 21);
            this.soundPropCMB.TabIndex = 0;
            // 
            // gameSpeedGRP
            // 
            this.gameSpeedGRP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gameSpeedGRP.Controls.Add(this.speedMultiplierTxt);
            this.gameSpeedGRP.Controls.Add(this.playBtn);
            this.gameSpeedGRP.Controls.Add(this.pauseBtn);
            this.gameSpeedGRP.Location = new System.Drawing.Point(13, 58);
            this.gameSpeedGRP.Name = "gameSpeedGRP";
            this.gameSpeedGRP.Size = new System.Drawing.Size(200, 52);
            this.gameSpeedGRP.TabIndex = 9;
            this.gameSpeedGRP.TabStop = false;
            this.gameSpeedGRP.Text = "Game Speed";
            // 
            // speedMultiplierTxt
            // 
            this.speedMultiplierTxt.Location = new System.Drawing.Point(72, 22);
            this.speedMultiplierTxt.Name = "speedMultiplierTxt";
            this.speedMultiplierTxt.Size = new System.Drawing.Size(122, 20);
            this.speedMultiplierTxt.TabIndex = 2;
            this.speedMultiplierTxt.Text = "1";
            this.speedMultiplierTxt.TextChanged += new System.EventHandler(this.speedMultiplier_TextChanged);
            // 
            // playBtn
            // 
            this.playBtn.Enabled = false;
            this.playBtn.Image = ((System.Drawing.Image)(resources.GetObject("playBtn.Image")));
            this.playBtn.Location = new System.Drawing.Point(41, 20);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(23, 23);
            this.playBtn.TabIndex = 1;
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.play_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Image = ((System.Drawing.Image)(resources.GetObject("pauseBtn.Image")));
            this.pauseBtn.Location = new System.Drawing.Point(7, 20);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(23, 23);
            this.pauseBtn.TabIndex = 0;
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pause_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectSongToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectSongToolStripMenuItem
            // 
            this.selectSongToolStripMenuItem.Name = "selectSongToolStripMenuItem";
            this.selectSongToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.selectSongToolStripMenuItem.Text = "Select Song";
            this.selectSongToolStripMenuItem.Click += new System.EventHandler(this.selectSong_Click);
            // 
            // AudioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 122);
            this.Controls.Add(this.gameSpeedGRP);
            this.Controls.Add(this.soundPropGRP);
            this.Controls.Add(this.soundNameTXT);
            this.Controls.Add(this.stopSoundBTN);
            this.Controls.Add(this.startSoundBTN);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 160);
            this.Name = "AudioForm";
            this.Text = "Chaos Audio Player";
            this.soundPropGRP.ResumeLayout(false);
            this.soundPropGRP.PerformLayout();
            this.gameSpeedGRP.ResumeLayout(false);
            this.gameSpeedGRP.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startSoundBTN;
        private System.Windows.Forms.Button stopSoundBTN;
        private System.Windows.Forms.TextBox soundNameTXT;
        private System.Windows.Forms.GroupBox soundPropGRP;
        private System.Windows.Forms.ComboBox soundPropCMB;
        private System.Windows.Forms.Button setSoundPropBTN;
        private System.Windows.Forms.TextBox soundPropValueTXT;
        private System.Windows.Forms.GroupBox gameSpeedGRP;
        private System.Windows.Forms.TextBox speedMultiplierTxt;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectSongToolStripMenuItem;
    }
}

