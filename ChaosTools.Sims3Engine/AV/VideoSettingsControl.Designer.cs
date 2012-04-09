namespace ChaosTools.Sims3Engine.AV
{
    partial class VideoSettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.soundCaptureCHK = new System.Windows.Forms.CheckBox();
            this.maxRecordTimeNUM = new System.Windows.Forms.NumericUpDown();
            this.secondsLBL = new System.Windows.Forms.Label();
            this.maxRecordTimeGRP = new System.Windows.Forms.GroupBox();
            this.hideUiCHK = new System.Windows.Forms.CheckBox();
            this.frameSizeGRP = new System.Windows.Forms.GroupBox();
            this.qualityGRP = new System.Windows.Forms.GroupBox();
            this.formatGRP = new System.Windows.Forms.GroupBox();
            this.formatAVIrad = new System.Windows.Forms.RadioButton();
            this.formatFLVrad = new System.Windows.Forms.RadioButton();
            this.qualityLowRad = new System.Windows.Forms.RadioButton();
            this.qualityMediumRad = new System.Windows.Forms.RadioButton();
            this.qualityHighRad = new System.Windows.Forms.RadioButton();
            this.qualityMaxRad = new System.Windows.Forms.RadioButton();
            this.frameSizeSmallRad = new System.Windows.Forms.RadioButton();
            this.frameSizeMediumRad = new System.Windows.Forms.RadioButton();
            this.frameSizeLargeRad = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.maxRecordTimeNUM)).BeginInit();
            this.maxRecordTimeGRP.SuspendLayout();
            this.frameSizeGRP.SuspendLayout();
            this.qualityGRP.SuspendLayout();
            this.formatGRP.SuspendLayout();
            this.SuspendLayout();
            // 
            // soundCaptureCHK
            // 
            this.soundCaptureCHK.AutoSize = true;
            this.soundCaptureCHK.Location = new System.Drawing.Point(3, 326);
            this.soundCaptureCHK.Name = "soundCaptureCHK";
            this.soundCaptureCHK.Size = new System.Drawing.Size(127, 17);
            this.soundCaptureCHK.TabIndex = 0;
            this.soundCaptureCHK.Text = "Video Sound Capture";
            this.soundCaptureCHK.UseVisualStyleBackColor = true;
            this.soundCaptureCHK.CheckedChanged += new System.EventHandler(this.soundCapture_CheckedChanged);
            // 
            // maxRecordTimeNUM
            // 
            this.maxRecordTimeNUM.Location = new System.Drawing.Point(6, 19);
            this.maxRecordTimeNUM.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.maxRecordTimeNUM.Name = "maxRecordTimeNUM";
            this.maxRecordTimeNUM.Size = new System.Drawing.Size(46, 20);
            this.maxRecordTimeNUM.TabIndex = 1;
            this.maxRecordTimeNUM.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxRecordTimeNUM.ValueChanged += new System.EventHandler(this.maxRecordTime_ValueChanged);
            // 
            // secondsLBL
            // 
            this.secondsLBL.AutoSize = true;
            this.secondsLBL.Location = new System.Drawing.Point(58, 21);
            this.secondsLBL.Name = "secondsLBL";
            this.secondsLBL.Size = new System.Drawing.Size(47, 13);
            this.secondsLBL.TabIndex = 2;
            this.secondsLBL.Text = "seconds";
            // 
            // maxRecordTimeGRP
            // 
            this.maxRecordTimeGRP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maxRecordTimeGRP.Controls.Add(this.maxRecordTimeNUM);
            this.maxRecordTimeGRP.Controls.Add(this.secondsLBL);
            this.maxRecordTimeGRP.Location = new System.Drawing.Point(3, 349);
            this.maxRecordTimeGRP.Name = "maxRecordTimeGRP";
            this.maxRecordTimeGRP.Size = new System.Drawing.Size(219, 48);
            this.maxRecordTimeGRP.TabIndex = 3;
            this.maxRecordTimeGRP.TabStop = false;
            this.maxRecordTimeGRP.Text = "Maximum Video Recording Time";
            // 
            // hideUiCHK
            // 
            this.hideUiCHK.AutoSize = true;
            this.hideUiCHK.Location = new System.Drawing.Point(3, 303);
            this.hideUiCHK.Name = "hideUiCHK";
            this.hideUiCHK.Size = new System.Drawing.Size(222, 17);
            this.hideUiCHK.TabIndex = 4;
            this.hideUiCHK.Text = "Hide User Interface During Video Capture";
            this.hideUiCHK.UseVisualStyleBackColor = true;
            this.hideUiCHK.CheckedChanged += new System.EventHandler(this.hideUi_CheckedChanged);
            // 
            // frameSizeGRP
            // 
            this.frameSizeGRP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frameSizeGRP.Controls.Add(this.frameSizeLargeRad);
            this.frameSizeGRP.Controls.Add(this.frameSizeMediumRad);
            this.frameSizeGRP.Controls.Add(this.frameSizeSmallRad);
            this.frameSizeGRP.Location = new System.Drawing.Point(3, 201);
            this.frameSizeGRP.Name = "frameSizeGRP";
            this.frameSizeGRP.Size = new System.Drawing.Size(219, 96);
            this.frameSizeGRP.TabIndex = 5;
            this.frameSizeGRP.TabStop = false;
            this.frameSizeGRP.Text = "Video Capture Size";
            // 
            // qualityGRP
            // 
            this.qualityGRP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qualityGRP.Controls.Add(this.qualityMaxRad);
            this.qualityGRP.Controls.Add(this.qualityHighRad);
            this.qualityGRP.Controls.Add(this.qualityMediumRad);
            this.qualityGRP.Controls.Add(this.qualityLowRad);
            this.qualityGRP.Location = new System.Drawing.Point(3, 78);
            this.qualityGRP.Name = "qualityGRP";
            this.qualityGRP.Size = new System.Drawing.Size(219, 117);
            this.qualityGRP.TabIndex = 6;
            this.qualityGRP.TabStop = false;
            this.qualityGRP.Text = "Video Capture Quality";
            // 
            // formatGRP
            // 
            this.formatGRP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formatGRP.Controls.Add(this.formatFLVrad);
            this.formatGRP.Controls.Add(this.formatAVIrad);
            this.formatGRP.Location = new System.Drawing.Point(4, 4);
            this.formatGRP.Name = "formatGRP";
            this.formatGRP.Size = new System.Drawing.Size(218, 68);
            this.formatGRP.TabIndex = 7;
            this.formatGRP.TabStop = false;
            this.formatGRP.Text = "Format";
            // 
            // formatAVIrad
            // 
            this.formatAVIrad.AutoSize = true;
            this.formatAVIrad.Checked = true;
            this.formatAVIrad.Location = new System.Drawing.Point(6, 19);
            this.formatAVIrad.Name = "formatAVIrad";
            this.formatAVIrad.Size = new System.Drawing.Size(42, 17);
            this.formatAVIrad.TabIndex = 0;
            this.formatAVIrad.TabStop = true;
            this.formatAVIrad.Text = "AVI";
            this.formatAVIrad.UseVisualStyleBackColor = true;
            this.formatAVIrad.CheckedChanged += new System.EventHandler(this.format_CheckedChanged);
            // 
            // formatFLVrad
            // 
            this.formatFLVrad.AutoSize = true;
            this.formatFLVrad.Location = new System.Drawing.Point(6, 42);
            this.formatFLVrad.Name = "formatFLVrad";
            this.formatFLVrad.Size = new System.Drawing.Size(44, 17);
            this.formatFLVrad.TabIndex = 1;
            this.formatFLVrad.Text = "FLV";
            this.formatFLVrad.UseVisualStyleBackColor = true;
            this.formatFLVrad.CheckedChanged += new System.EventHandler(this.format_CheckedChanged);
            // 
            // qualityLowRad
            // 
            this.qualityLowRad.AutoSize = true;
            this.qualityLowRad.Location = new System.Drawing.Point(7, 20);
            this.qualityLowRad.Name = "qualityLowRad";
            this.qualityLowRad.Size = new System.Drawing.Size(45, 17);
            this.qualityLowRad.TabIndex = 0;
            this.qualityLowRad.Text = "Low";
            this.qualityLowRad.UseVisualStyleBackColor = true;
            this.qualityLowRad.CheckedChanged += new System.EventHandler(this.quality_CheckedChanged);
            // 
            // qualityMediumRad
            // 
            this.qualityMediumRad.AutoSize = true;
            this.qualityMediumRad.Checked = true;
            this.qualityMediumRad.Location = new System.Drawing.Point(7, 44);
            this.qualityMediumRad.Name = "qualityMediumRad";
            this.qualityMediumRad.Size = new System.Drawing.Size(62, 17);
            this.qualityMediumRad.TabIndex = 1;
            this.qualityMediumRad.TabStop = true;
            this.qualityMediumRad.Text = "Medium";
            this.qualityMediumRad.UseVisualStyleBackColor = true;
            this.qualityMediumRad.CheckedChanged += new System.EventHandler(this.quality_CheckedChanged);
            // 
            // qualityHighRad
            // 
            this.qualityHighRad.AutoSize = true;
            this.qualityHighRad.Location = new System.Drawing.Point(7, 68);
            this.qualityHighRad.Name = "qualityHighRad";
            this.qualityHighRad.Size = new System.Drawing.Size(47, 17);
            this.qualityHighRad.TabIndex = 2;
            this.qualityHighRad.Text = "High";
            this.qualityHighRad.UseVisualStyleBackColor = true;
            this.qualityHighRad.CheckedChanged += new System.EventHandler(this.quality_CheckedChanged);
            // 
            // qualityMaxRad
            // 
            this.qualityMaxRad.AutoSize = true;
            this.qualityMaxRad.Location = new System.Drawing.Point(7, 92);
            this.qualityMaxRad.Name = "qualityMaxRad";
            this.qualityMaxRad.Size = new System.Drawing.Size(96, 17);
            this.qualityMaxRad.TabIndex = 3;
            this.qualityMaxRad.Text = "Uncompressed";
            this.qualityMaxRad.UseVisualStyleBackColor = true;
            this.qualityMaxRad.CheckedChanged += new System.EventHandler(this.quality_CheckedChanged);
            // 
            // frameSizeSmallRad
            // 
            this.frameSizeSmallRad.AutoSize = true;
            this.frameSizeSmallRad.Location = new System.Drawing.Point(7, 20);
            this.frameSizeSmallRad.Name = "frameSizeSmallRad";
            this.frameSizeSmallRad.Size = new System.Drawing.Size(50, 17);
            this.frameSizeSmallRad.TabIndex = 0;
            this.frameSizeSmallRad.Text = "Small";
            this.frameSizeSmallRad.UseVisualStyleBackColor = true;
            this.frameSizeSmallRad.CheckedChanged += new System.EventHandler(this.frameSize_CheckedChanged);
            // 
            // frameSizeMediumRad
            // 
            this.frameSizeMediumRad.AutoSize = true;
            this.frameSizeMediumRad.Checked = true;
            this.frameSizeMediumRad.Location = new System.Drawing.Point(7, 43);
            this.frameSizeMediumRad.Name = "frameSizeMediumRad";
            this.frameSizeMediumRad.Size = new System.Drawing.Size(62, 17);
            this.frameSizeMediumRad.TabIndex = 1;
            this.frameSizeMediumRad.TabStop = true;
            this.frameSizeMediumRad.Text = "Medium";
            this.frameSizeMediumRad.UseVisualStyleBackColor = true;
            this.frameSizeMediumRad.CheckedChanged += new System.EventHandler(this.frameSize_CheckedChanged);
            // 
            // frameSizeLargeRad
            // 
            this.frameSizeLargeRad.AutoSize = true;
            this.frameSizeLargeRad.Location = new System.Drawing.Point(7, 67);
            this.frameSizeLargeRad.Name = "frameSizeLargeRad";
            this.frameSizeLargeRad.Size = new System.Drawing.Size(52, 17);
            this.frameSizeLargeRad.TabIndex = 2;
            this.frameSizeLargeRad.Text = "Large";
            this.frameSizeLargeRad.UseVisualStyleBackColor = true;
            this.frameSizeLargeRad.CheckedChanged += new System.EventHandler(this.frameSize_CheckedChanged);
            // 
            // VideoSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.formatGRP);
            this.Controls.Add(this.qualityGRP);
            this.Controls.Add(this.frameSizeGRP);
            this.Controls.Add(this.hideUiCHK);
            this.Controls.Add(this.maxRecordTimeGRP);
            this.Controls.Add(this.soundCaptureCHK);
            this.MinimumSize = new System.Drawing.Size(225, 400);
            this.Name = "VideoSettingsControl";
            this.Size = new System.Drawing.Size(225, 400);
            ((System.ComponentModel.ISupportInitialize)(this.maxRecordTimeNUM)).EndInit();
            this.maxRecordTimeGRP.ResumeLayout(false);
            this.maxRecordTimeGRP.PerformLayout();
            this.frameSizeGRP.ResumeLayout(false);
            this.frameSizeGRP.PerformLayout();
            this.qualityGRP.ResumeLayout(false);
            this.qualityGRP.PerformLayout();
            this.formatGRP.ResumeLayout(false);
            this.formatGRP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox soundCaptureCHK;
        private System.Windows.Forms.NumericUpDown maxRecordTimeNUM;
        private System.Windows.Forms.Label secondsLBL;
        private System.Windows.Forms.GroupBox maxRecordTimeGRP;
        private System.Windows.Forms.CheckBox hideUiCHK;
        private System.Windows.Forms.GroupBox frameSizeGRP;
        private System.Windows.Forms.GroupBox qualityGRP;
        private System.Windows.Forms.GroupBox formatGRP;
        private System.Windows.Forms.RadioButton formatFLVrad;
        private System.Windows.Forms.RadioButton formatAVIrad;
        private System.Windows.Forms.RadioButton frameSizeSmallRad;
        private System.Windows.Forms.RadioButton qualityMaxRad;
        private System.Windows.Forms.RadioButton qualityHighRad;
        private System.Windows.Forms.RadioButton qualityMediumRad;
        private System.Windows.Forms.RadioButton qualityLowRad;
        private System.Windows.Forms.RadioButton frameSizeLargeRad;
        private System.Windows.Forms.RadioButton frameSizeMediumRad;
    }
}
