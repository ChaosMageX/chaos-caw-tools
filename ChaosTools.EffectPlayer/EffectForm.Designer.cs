namespace ChaosTools.EffectPlayer
{
    partial class EffectForm
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
            this.renderPanelEx1 = new ChaosTools.Sims3Engine.RenderPanelEx();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closePackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLoadedSWBsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLoadedS3SAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAppDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLoadTimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getEffectNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printEffectNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printInstalledPackagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printLoadingTextsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpMemorySummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showEffectStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGeneralStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGameSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invalidateRenderPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getEffectStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setEffectStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getGeneralStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGeneralStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getCameraVectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setCameraVectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startEffectBtn = new System.Windows.Forms.Button();
            this.effectNameTxt = new System.Windows.Forms.TextBox();
            this.stopEffectBtn = new System.Windows.Forms.Button();
            this.gameSpeedGRP = new System.Windows.Forms.GroupBox();
            this.speedMultiplierTxt = new System.Windows.Forms.TextBox();
            this.playBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.lifeScaleGRP = new System.Windows.Forms.GroupBox();
            this.lifeScaleTXT = new System.Windows.Forms.TextBox();
            this.setLifeScaleBTN = new System.Windows.Forms.Button();
            this.effectTransGRP = new System.Windows.Forms.GroupBox();
            this.effectTransHardRAD = new System.Windows.Forms.RadioButton();
            this.effectTransSoftRAD = new System.Windows.Forms.RadioButton();
            this.printGameTipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.gameSpeedGRP.SuspendLayout();
            this.lifeScaleGRP.SuspendLayout();
            this.effectTransGRP.SuspendLayout();
            this.SuspendLayout();
            // 
            // renderPanelEx1
            // 
            this.renderPanelEx1.AllowDrop = true;
            this.renderPanelEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renderPanelEx1.AutoSize = true;
            this.renderPanelEx1.Location = new System.Drawing.Point(13, 32);
            this.renderPanelEx1.Name = "renderPanelEx1";
            this.renderPanelEx1.Size = new System.Drawing.Size(962, 512);
            this.renderPanelEx1.SizeUpdatesLocked = false;
            this.renderPanelEx1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.renderingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPackageToolStripMenuItem,
            this.closePackageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openPackageToolStripMenuItem
            // 
            this.openPackageToolStripMenuItem.Name = "openPackageToolStripMenuItem";
            this.openPackageToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.openPackageToolStripMenuItem.Text = "Open Package";
            this.openPackageToolStripMenuItem.Click += new System.EventHandler(this.openPackage_Click);
            // 
            // closePackageToolStripMenuItem
            // 
            this.closePackageToolStripMenuItem.Enabled = false;
            this.closePackageToolStripMenuItem.Name = "closePackageToolStripMenuItem";
            this.closePackageToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.closePackageToolStripMenuItem.Text = "Close Package";
            this.closePackageToolStripMenuItem.Click += new System.EventHandler(this.closePackage_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLoadedSWBsToolStripMenuItem,
            this.showLoadedS3SAsToolStripMenuItem,
            this.showAppDataToolStripMenuItem,
            this.showLoadTimesToolStripMenuItem,
            this.getEffectNameToolStripMenuItem,
            this.printEffectNamesToolStripMenuItem,
            this.printInstalledPackagesToolStripMenuItem,
            this.printLoadingTextsToolStripMenuItem,
            this.dumpMemorySummaryToolStripMenuItem,
            this.printGameTipsToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // showLoadedSWBsToolStripMenuItem
            // 
            this.showLoadedSWBsToolStripMenuItem.Name = "showLoadedSWBsToolStripMenuItem";
            this.showLoadedSWBsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.showLoadedSWBsToolStripMenuItem.Text = "Show Loaded SWBs";
            this.showLoadedSWBsToolStripMenuItem.Click += new System.EventHandler(this.showLoadedSWBs_Click);
            // 
            // showLoadedS3SAsToolStripMenuItem
            // 
            this.showLoadedS3SAsToolStripMenuItem.Name = "showLoadedS3SAsToolStripMenuItem";
            this.showLoadedS3SAsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.showLoadedS3SAsToolStripMenuItem.Text = "Show Loaded S3SAs";
            this.showLoadedS3SAsToolStripMenuItem.Click += new System.EventHandler(this.showLoadedS3SAs_Click);
            // 
            // showAppDataToolStripMenuItem
            // 
            this.showAppDataToolStripMenuItem.Name = "showAppDataToolStripMenuItem";
            this.showAppDataToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.showAppDataToolStripMenuItem.Text = "Show App Data";
            this.showAppDataToolStripMenuItem.Click += new System.EventHandler(this.showAppData_Click);
            // 
            // showLoadTimesToolStripMenuItem
            // 
            this.showLoadTimesToolStripMenuItem.Name = "showLoadTimesToolStripMenuItem";
            this.showLoadTimesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.showLoadTimesToolStripMenuItem.Text = "Show Load Times";
            this.showLoadTimesToolStripMenuItem.Click += new System.EventHandler(this.showLoadTimes_Click);
            // 
            // getEffectNameToolStripMenuItem
            // 
            this.getEffectNameToolStripMenuItem.Name = "getEffectNameToolStripMenuItem";
            this.getEffectNameToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.getEffectNameToolStripMenuItem.Text = "Get Effect Name";
            this.getEffectNameToolStripMenuItem.Click += new System.EventHandler(this.getEffectName_Click);
            // 
            // printEffectNamesToolStripMenuItem
            // 
            this.printEffectNamesToolStripMenuItem.Name = "printEffectNamesToolStripMenuItem";
            this.printEffectNamesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.printEffectNamesToolStripMenuItem.Text = "Print Effect Names";
            this.printEffectNamesToolStripMenuItem.Click += new System.EventHandler(this.printEffectNames_Click);
            // 
            // printInstalledPackagesToolStripMenuItem
            // 
            this.printInstalledPackagesToolStripMenuItem.Name = "printInstalledPackagesToolStripMenuItem";
            this.printInstalledPackagesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.printInstalledPackagesToolStripMenuItem.Text = "Print Installed Packages";
            this.printInstalledPackagesToolStripMenuItem.Click += new System.EventHandler(this.printInstalledPackages_Click);
            // 
            // printLoadingTextsToolStripMenuItem
            // 
            this.printLoadingTextsToolStripMenuItem.Name = "printLoadingTextsToolStripMenuItem";
            this.printLoadingTextsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.printLoadingTextsToolStripMenuItem.Text = "Print Loading Texts";
            this.printLoadingTextsToolStripMenuItem.Click += new System.EventHandler(this.printLoadingTexts_Click);
            // 
            // dumpMemorySummaryToolStripMenuItem
            // 
            this.dumpMemorySummaryToolStripMenuItem.Enabled = false;
            this.dumpMemorySummaryToolStripMenuItem.Name = "dumpMemorySummaryToolStripMenuItem";
            this.dumpMemorySummaryToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.dumpMemorySummaryToolStripMenuItem.Text = "Dump Memory Summary";
            this.dumpMemorySummaryToolStripMenuItem.Click += new System.EventHandler(this.dumpMemorySummary_Click);
            // 
            // renderingToolStripMenuItem
            // 
            this.renderingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showEffectStatsToolStripMenuItem,
            this.showGeneralStatsToolStripMenuItem,
            this.showCircleToolStripMenuItem,
            this.showGameSpeedToolStripMenuItem,
            this.invalidateRenderPanelToolStripMenuItem,
            this.getEffectStatsToolStripMenuItem,
            this.setEffectStatsToolStripMenuItem,
            this.getGeneralStatsToolStripMenuItem,
            this.setGeneralStatsToolStripMenuItem,
            this.getCameraVectorsToolStripMenuItem,
            this.setCameraVectorsToolStripMenuItem});
            this.renderingToolStripMenuItem.Name = "renderingToolStripMenuItem";
            this.renderingToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.renderingToolStripMenuItem.Text = "Rendering";
            // 
            // showEffectStatsToolStripMenuItem
            // 
            this.showEffectStatsToolStripMenuItem.Name = "showEffectStatsToolStripMenuItem";
            this.showEffectStatsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.showEffectStatsToolStripMenuItem.Text = "Show Effect Stats";
            this.showEffectStatsToolStripMenuItem.Click += new System.EventHandler(this.showEffectStats_Click);
            // 
            // showGeneralStatsToolStripMenuItem
            // 
            this.showGeneralStatsToolStripMenuItem.Name = "showGeneralStatsToolStripMenuItem";
            this.showGeneralStatsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.showGeneralStatsToolStripMenuItem.Text = "Show General Stats";
            this.showGeneralStatsToolStripMenuItem.Click += new System.EventHandler(this.showGeneralStats_Click);
            // 
            // showCircleToolStripMenuItem
            // 
            this.showCircleToolStripMenuItem.Name = "showCircleToolStripMenuItem";
            this.showCircleToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.showCircleToolStripMenuItem.Text = "Hide Circle";
            this.showCircleToolStripMenuItem.Click += new System.EventHandler(this.showCircle_Click);
            // 
            // showGameSpeedToolStripMenuItem
            // 
            this.showGameSpeedToolStripMenuItem.Name = "showGameSpeedToolStripMenuItem";
            this.showGameSpeedToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.showGameSpeedToolStripMenuItem.Text = "Show Game Speed";
            this.showGameSpeedToolStripMenuItem.Click += new System.EventHandler(this.showGameSpeed_Click);
            // 
            // invalidateRenderPanelToolStripMenuItem
            // 
            this.invalidateRenderPanelToolStripMenuItem.Name = "invalidateRenderPanelToolStripMenuItem";
            this.invalidateRenderPanelToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.invalidateRenderPanelToolStripMenuItem.Text = "Invalidate Render Panel";
            this.invalidateRenderPanelToolStripMenuItem.Click += new System.EventHandler(this.invalidateRenderPanel_Click);
            // 
            // getEffectStatsToolStripMenuItem
            // 
            this.getEffectStatsToolStripMenuItem.Name = "getEffectStatsToolStripMenuItem";
            this.getEffectStatsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.getEffectStatsToolStripMenuItem.Text = "Get Effect Stats Location";
            this.getEffectStatsToolStripMenuItem.Click += new System.EventHandler(this.getEffectStats_Click);
            // 
            // setEffectStatsToolStripMenuItem
            // 
            this.setEffectStatsToolStripMenuItem.Name = "setEffectStatsToolStripMenuItem";
            this.setEffectStatsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.setEffectStatsToolStripMenuItem.Text = "Set Effect Stats Location";
            this.setEffectStatsToolStripMenuItem.Click += new System.EventHandler(this.setEffectStats_Click);
            // 
            // getGeneralStatsToolStripMenuItem
            // 
            this.getGeneralStatsToolStripMenuItem.Name = "getGeneralStatsToolStripMenuItem";
            this.getGeneralStatsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.getGeneralStatsToolStripMenuItem.Text = "Get General Stats Location";
            this.getGeneralStatsToolStripMenuItem.Click += new System.EventHandler(this.getGeneralStats_Click);
            // 
            // setGeneralStatsToolStripMenuItem
            // 
            this.setGeneralStatsToolStripMenuItem.Name = "setGeneralStatsToolStripMenuItem";
            this.setGeneralStatsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.setGeneralStatsToolStripMenuItem.Text = "Set General Stats Location";
            this.setGeneralStatsToolStripMenuItem.Click += new System.EventHandler(this.setGeneralStats_Click);
            // 
            // getCameraVectorsToolStripMenuItem
            // 
            this.getCameraVectorsToolStripMenuItem.Name = "getCameraVectorsToolStripMenuItem";
            this.getCameraVectorsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.getCameraVectorsToolStripMenuItem.Text = "Get Camera Vectors";
            this.getCameraVectorsToolStripMenuItem.Click += new System.EventHandler(this.getCameraVectors_Click);
            // 
            // setCameraVectorsToolStripMenuItem
            // 
            this.setCameraVectorsToolStripMenuItem.Name = "setCameraVectorsToolStripMenuItem";
            this.setCameraVectorsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.setCameraVectorsToolStripMenuItem.Text = "Set Camera Vectors";
            this.setCameraVectorsToolStripMenuItem.Click += new System.EventHandler(this.setCameraVectors_Click);
            // 
            // startEffectBtn
            // 
            this.startEffectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startEffectBtn.Location = new System.Drawing.Point(13, 550);
            this.startEffectBtn.Name = "startEffectBtn";
            this.startEffectBtn.Size = new System.Drawing.Size(75, 23);
            this.startEffectBtn.TabIndex = 5;
            this.startEffectBtn.Text = "Start Effect";
            this.startEffectBtn.UseVisualStyleBackColor = true;
            this.startEffectBtn.Click += new System.EventHandler(this.startEffect_Click);
            // 
            // effectNameTxt
            // 
            this.effectNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.effectNameTxt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.effectNameTxt.Location = new System.Drawing.Point(94, 553);
            this.effectNameTxt.Name = "effectNameTxt";
            this.effectNameTxt.Size = new System.Drawing.Size(796, 20);
            this.effectNameTxt.TabIndex = 6;
            this.effectNameTxt.Text = "zzz";
            this.effectNameTxt.TextChanged += new System.EventHandler(this.effectName_TextChanged);
            // 
            // stopEffectBtn
            // 
            this.stopEffectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stopEffectBtn.Enabled = false;
            this.stopEffectBtn.Location = new System.Drawing.Point(900, 550);
            this.stopEffectBtn.Name = "stopEffectBtn";
            this.stopEffectBtn.Size = new System.Drawing.Size(75, 23);
            this.stopEffectBtn.TabIndex = 7;
            this.stopEffectBtn.Text = "Stop Effect";
            this.stopEffectBtn.UseVisualStyleBackColor = true;
            this.stopEffectBtn.Click += new System.EventHandler(this.stopEffect_Click);
            // 
            // gameSpeedGRP
            // 
            this.gameSpeedGRP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gameSpeedGRP.Controls.Add(this.speedMultiplierTxt);
            this.gameSpeedGRP.Controls.Add(this.playBtn);
            this.gameSpeedGRP.Controls.Add(this.pauseBtn);
            this.gameSpeedGRP.Location = new System.Drawing.Point(13, 580);
            this.gameSpeedGRP.Name = "gameSpeedGRP";
            this.gameSpeedGRP.Size = new System.Drawing.Size(200, 52);
            this.gameSpeedGRP.TabIndex = 8;
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
            this.playBtn.Image = global::ChaosTools.EffectPlayer.Properties.Resources.media_play;
            this.playBtn.Location = new System.Drawing.Point(41, 20);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(23, 23);
            this.playBtn.TabIndex = 1;
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.play_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Image = global::ChaosTools.EffectPlayer.Properties.Resources.media_pause;
            this.pauseBtn.Location = new System.Drawing.Point(7, 20);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(23, 23);
            this.pauseBtn.TabIndex = 0;
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pause_Click);
            // 
            // lifeScaleGRP
            // 
            this.lifeScaleGRP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lifeScaleGRP.Controls.Add(this.lifeScaleTXT);
            this.lifeScaleGRP.Controls.Add(this.setLifeScaleBTN);
            this.lifeScaleGRP.Location = new System.Drawing.Point(219, 580);
            this.lifeScaleGRP.Name = "lifeScaleGRP";
            this.lifeScaleGRP.Size = new System.Drawing.Size(188, 52);
            this.lifeScaleGRP.TabIndex = 11;
            this.lifeScaleGRP.TabStop = false;
            this.lifeScaleGRP.Text = "Effect Life Scale";
            // 
            // lifeScaleTXT
            // 
            this.lifeScaleTXT.Location = new System.Drawing.Point(46, 22);
            this.lifeScaleTXT.Name = "lifeScaleTXT";
            this.lifeScaleTXT.Size = new System.Drawing.Size(136, 20);
            this.lifeScaleTXT.TabIndex = 1;
            this.lifeScaleTXT.Text = "1";
            // 
            // setLifeScaleBTN
            // 
            this.setLifeScaleBTN.Location = new System.Drawing.Point(7, 20);
            this.setLifeScaleBTN.Name = "setLifeScaleBTN";
            this.setLifeScaleBTN.Size = new System.Drawing.Size(33, 23);
            this.setLifeScaleBTN.TabIndex = 0;
            this.setLifeScaleBTN.Text = "Set";
            this.setLifeScaleBTN.UseVisualStyleBackColor = true;
            this.setLifeScaleBTN.Click += new System.EventHandler(this.setLifeScale_Click);
            // 
            // effectTransGRP
            // 
            this.effectTransGRP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.effectTransGRP.Controls.Add(this.effectTransHardRAD);
            this.effectTransGRP.Controls.Add(this.effectTransSoftRAD);
            this.effectTransGRP.Location = new System.Drawing.Point(413, 580);
            this.effectTransGRP.Name = "effectTransGRP";
            this.effectTransGRP.Size = new System.Drawing.Size(109, 52);
            this.effectTransGRP.TabIndex = 12;
            this.effectTransGRP.TabStop = false;
            this.effectTransGRP.Text = "Effect Transition";
            // 
            // effectTransHardRAD
            // 
            this.effectTransHardRAD.AutoSize = true;
            this.effectTransHardRAD.Location = new System.Drawing.Point(56, 23);
            this.effectTransHardRAD.Name = "effectTransHardRAD";
            this.effectTransHardRAD.Size = new System.Drawing.Size(48, 17);
            this.effectTransHardRAD.TabIndex = 1;
            this.effectTransHardRAD.Text = "Hard";
            this.effectTransHardRAD.UseVisualStyleBackColor = true;
            this.effectTransHardRAD.CheckedChanged += new System.EventHandler(this.effectTransRAD_CheckedChanged);
            // 
            // effectTransSoftRAD
            // 
            this.effectTransSoftRAD.AutoSize = true;
            this.effectTransSoftRAD.Checked = true;
            this.effectTransSoftRAD.Location = new System.Drawing.Point(6, 23);
            this.effectTransSoftRAD.Name = "effectTransSoftRAD";
            this.effectTransSoftRAD.Size = new System.Drawing.Size(44, 17);
            this.effectTransSoftRAD.TabIndex = 0;
            this.effectTransSoftRAD.TabStop = true;
            this.effectTransSoftRAD.Text = "Soft";
            this.effectTransSoftRAD.UseVisualStyleBackColor = true;
            this.effectTransSoftRAD.CheckedChanged += new System.EventHandler(this.effectTransRAD_CheckedChanged);
            // 
            // printGameTipsToolStripMenuItem
            // 
            this.printGameTipsToolStripMenuItem.Name = "printGameTipsToolStripMenuItem";
            this.printGameTipsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.printGameTipsToolStripMenuItem.Text = "Print Game Tips";
            this.printGameTipsToolStripMenuItem.Click += new System.EventHandler(this.printGameTips_Click);
            // 
            // EffectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.effectTransGRP);
            this.Controls.Add(this.lifeScaleGRP);
            this.Controls.Add(this.gameSpeedGRP);
            this.Controls.Add(this.stopEffectBtn);
            this.Controls.Add(this.effectNameTxt);
            this.Controls.Add(this.startEffectBtn);
            this.Controls.Add(this.renderPanelEx1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(550, 700);
            this.Name = "EffectForm";
            this.Text = "Chaos Effect Player";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gameSpeedGRP.ResumeLayout(false);
            this.gameSpeedGRP.PerformLayout();
            this.lifeScaleGRP.ResumeLayout(false);
            this.lifeScaleGRP.PerformLayout();
            this.effectTransGRP.ResumeLayout(false);
            this.effectTransGRP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChaosTools.Sims3Engine.RenderPanelEx renderPanelEx1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPackageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closePackageToolStripMenuItem;
        private System.Windows.Forms.Button startEffectBtn;
        private System.Windows.Forms.TextBox effectNameTxt;
        private System.Windows.Forms.Button stopEffectBtn;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLoadedSWBsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLoadedS3SAsToolStripMenuItem;
        private System.Windows.Forms.GroupBox gameSpeedGRP;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.TextBox speedMultiplierTxt;
        private System.Windows.Forms.ToolStripMenuItem renderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invalidateRenderPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setEffectStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showEffectStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printEffectNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAppDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpMemorySummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGeneralStatsToolStripMenuItem;
        private System.Windows.Forms.GroupBox lifeScaleGRP;
        private System.Windows.Forms.TextBox lifeScaleTXT;
        private System.Windows.Forms.Button setLifeScaleBTN;
        private System.Windows.Forms.ToolStripMenuItem printInstalledPackagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setGeneralStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setCameraVectorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGameSpeedToolStripMenuItem;
        private System.Windows.Forms.GroupBox effectTransGRP;
        private System.Windows.Forms.RadioButton effectTransHardRAD;
        private System.Windows.Forms.RadioButton effectTransSoftRAD;
        private System.Windows.Forms.ToolStripMenuItem getEffectStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getGeneralStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getCameraVectorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getEffectNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLoadTimesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printLoadingTextsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printGameTipsToolStripMenuItem;
    }
}