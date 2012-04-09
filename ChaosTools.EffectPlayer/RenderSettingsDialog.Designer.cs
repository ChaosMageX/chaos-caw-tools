namespace ChaosTools.EffectPlayer
{
    partial class RenderSettingsDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.effectStatsLbl = new System.Windows.Forms.Label();
            this.effectStatsXtxt = new System.Windows.Forms.TextBox();
            this.generalStatsLbl = new System.Windows.Forms.Label();
            this.effectStatsYtxt = new System.Windows.Forms.TextBox();
            this.effectStatsIncrTxt = new System.Windows.Forms.TextBox();
            this.generalStatsXtxt = new System.Windows.Forms.TextBox();
            this.generalStatsYtxt = new System.Windows.Forms.TextBox();
            this.yStatsLbl = new System.Windows.Forms.Label();
            this.xStatsLbl = new System.Windows.Forms.Label();
            this.lineSpacingLbl = new System.Windows.Forms.Label();
            this.statsLocationLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.eyePosLbl = new System.Windows.Forms.Label();
            this.upDirLbl = new System.Windows.Forms.Label();
            this.targetPosLbl = new System.Windows.Forms.Label();
            this.xVectorLbl = new System.Windows.Forms.Label();
            this.yVectorLbl = new System.Windows.Forms.Label();
            this.zVectorLbl = new System.Windows.Forms.Label();
            this.eyePosXtxt = new System.Windows.Forms.TextBox();
            this.eyePosYtxt = new System.Windows.Forms.TextBox();
            this.eyePosZtxt = new System.Windows.Forms.TextBox();
            this.upDirXtxt = new System.Windows.Forms.TextBox();
            this.upDirYtxt = new System.Windows.Forms.TextBox();
            this.upDirZtxt = new System.Windows.Forms.TextBox();
            this.targetPosXtxt = new System.Windows.Forms.TextBox();
            this.targetPosYtxt = new System.Windows.Forms.TextBox();
            this.targetPosZtxt = new System.Windows.Forms.TextBox();
            this.cameraVectorsLbl = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.effectStatsLbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.effectStatsXtxt, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.generalStatsLbl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.effectStatsYtxt, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.effectStatsIncrTxt, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.generalStatsXtxt, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.generalStatsYtxt, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.yStatsLbl, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.xStatsLbl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lineSpacingLbl, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(359, 75);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // effectStatsLbl
            // 
            this.effectStatsLbl.AutoSize = true;
            this.effectStatsLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.effectStatsLbl.Location = new System.Drawing.Point(3, 25);
            this.effectStatsLbl.Name = "effectStatsLbl";
            this.effectStatsLbl.Size = new System.Drawing.Size(44, 25);
            this.effectStatsLbl.TabIndex = 0;
            this.effectStatsLbl.Text = "Effect";
            this.effectStatsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // effectStatsXtxt
            // 
            this.effectStatsXtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.effectStatsXtxt.Location = new System.Drawing.Point(53, 28);
            this.effectStatsXtxt.Name = "effectStatsXtxt";
            this.effectStatsXtxt.Size = new System.Drawing.Size(97, 20);
            this.effectStatsXtxt.TabIndex = 2;
            this.effectStatsXtxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // generalStatsLbl
            // 
            this.generalStatsLbl.AutoSize = true;
            this.generalStatsLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalStatsLbl.Location = new System.Drawing.Point(3, 50);
            this.generalStatsLbl.Name = "generalStatsLbl";
            this.generalStatsLbl.Size = new System.Drawing.Size(44, 25);
            this.generalStatsLbl.TabIndex = 3;
            this.generalStatsLbl.Text = "General";
            this.generalStatsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // effectStatsYtxt
            // 
            this.effectStatsYtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.effectStatsYtxt.Location = new System.Drawing.Point(156, 28);
            this.effectStatsYtxt.Name = "effectStatsYtxt";
            this.effectStatsYtxt.Size = new System.Drawing.Size(97, 20);
            this.effectStatsYtxt.TabIndex = 4;
            this.effectStatsYtxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // effectStatsIncrTxt
            // 
            this.effectStatsIncrTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.effectStatsIncrTxt.Location = new System.Drawing.Point(259, 28);
            this.effectStatsIncrTxt.Name = "effectStatsIncrTxt";
            this.effectStatsIncrTxt.Size = new System.Drawing.Size(97, 20);
            this.effectStatsIncrTxt.TabIndex = 5;
            this.effectStatsIncrTxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // generalStatsXtxt
            // 
            this.generalStatsXtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalStatsXtxt.Location = new System.Drawing.Point(53, 53);
            this.generalStatsXtxt.Name = "generalStatsXtxt";
            this.generalStatsXtxt.Size = new System.Drawing.Size(97, 20);
            this.generalStatsXtxt.TabIndex = 6;
            this.generalStatsXtxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // generalStatsYtxt
            // 
            this.generalStatsYtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalStatsYtxt.Location = new System.Drawing.Point(156, 53);
            this.generalStatsYtxt.Name = "generalStatsYtxt";
            this.generalStatsYtxt.Size = new System.Drawing.Size(97, 20);
            this.generalStatsYtxt.TabIndex = 7;
            this.generalStatsYtxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // yStatsLbl
            // 
            this.yStatsLbl.AutoSize = true;
            this.yStatsLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yStatsLbl.Location = new System.Drawing.Point(156, 0);
            this.yStatsLbl.Name = "yStatsLbl";
            this.yStatsLbl.Size = new System.Drawing.Size(97, 25);
            this.yStatsLbl.TabIndex = 8;
            this.yStatsLbl.Text = "Y";
            this.yStatsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xStatsLbl
            // 
            this.xStatsLbl.AutoSize = true;
            this.xStatsLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xStatsLbl.Location = new System.Drawing.Point(53, 0);
            this.xStatsLbl.Name = "xStatsLbl";
            this.xStatsLbl.Size = new System.Drawing.Size(97, 25);
            this.xStatsLbl.TabIndex = 9;
            this.xStatsLbl.Text = "X";
            this.xStatsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lineSpacingLbl
            // 
            this.lineSpacingLbl.AutoSize = true;
            this.lineSpacingLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineSpacingLbl.Location = new System.Drawing.Point(259, 0);
            this.lineSpacingLbl.Name = "lineSpacingLbl";
            this.lineSpacingLbl.Size = new System.Drawing.Size(97, 25);
            this.lineSpacingLbl.TabIndex = 10;
            this.lineSpacingLbl.Text = "Line Spacing";
            this.lineSpacingLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statsLocationLbl
            // 
            this.statsLocationLbl.AutoSize = true;
            this.statsLocationLbl.Location = new System.Drawing.Point(16, 9);
            this.statsLocationLbl.Name = "statsLocationLbl";
            this.statsLocationLbl.Size = new System.Drawing.Size(132, 13);
            this.statsLocationLbl.TabIndex = 1;
            this.statsLocationLbl.Text = "Stats Location On Screen:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.eyePosLbl, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.upDirLbl, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.targetPosLbl, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.xVectorLbl, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.yVectorLbl, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.zVectorLbl, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.eyePosXtxt, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.eyePosYtxt, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.eyePosZtxt, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.upDirXtxt, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.upDirYtxt, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.upDirZtxt, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.targetPosXtxt, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.targetPosYtxt, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.targetPosZtxt, 3, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 123);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(359, 100);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // eyePosLbl
            // 
            this.eyePosLbl.AutoSize = true;
            this.eyePosLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eyePosLbl.Location = new System.Drawing.Point(3, 25);
            this.eyePosLbl.Name = "eyePosLbl";
            this.eyePosLbl.Size = new System.Drawing.Size(84, 25);
            this.eyePosLbl.TabIndex = 0;
            this.eyePosLbl.Text = "Camera Position";
            this.eyePosLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // upDirLbl
            // 
            this.upDirLbl.AutoSize = true;
            this.upDirLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upDirLbl.Location = new System.Drawing.Point(3, 50);
            this.upDirLbl.Name = "upDirLbl";
            this.upDirLbl.Size = new System.Drawing.Size(84, 25);
            this.upDirLbl.TabIndex = 1;
            this.upDirLbl.Text = "Up Direction";
            this.upDirLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // targetPosLbl
            // 
            this.targetPosLbl.AutoSize = true;
            this.targetPosLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetPosLbl.Location = new System.Drawing.Point(3, 75);
            this.targetPosLbl.Name = "targetPosLbl";
            this.targetPosLbl.Size = new System.Drawing.Size(84, 25);
            this.targetPosLbl.TabIndex = 2;
            this.targetPosLbl.Text = "Target Position";
            this.targetPosLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // xVectorLbl
            // 
            this.xVectorLbl.AutoSize = true;
            this.xVectorLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xVectorLbl.Location = new System.Drawing.Point(93, 0);
            this.xVectorLbl.Name = "xVectorLbl";
            this.xVectorLbl.Size = new System.Drawing.Size(83, 25);
            this.xVectorLbl.TabIndex = 3;
            this.xVectorLbl.Text = "X";
            this.xVectorLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yVectorLbl
            // 
            this.yVectorLbl.AutoSize = true;
            this.yVectorLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yVectorLbl.Location = new System.Drawing.Point(182, 0);
            this.yVectorLbl.Name = "yVectorLbl";
            this.yVectorLbl.Size = new System.Drawing.Size(83, 25);
            this.yVectorLbl.TabIndex = 4;
            this.yVectorLbl.Text = "Y";
            this.yVectorLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zVectorLbl
            // 
            this.zVectorLbl.AutoSize = true;
            this.zVectorLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zVectorLbl.Location = new System.Drawing.Point(271, 0);
            this.zVectorLbl.Name = "zVectorLbl";
            this.zVectorLbl.Size = new System.Drawing.Size(85, 25);
            this.zVectorLbl.TabIndex = 5;
            this.zVectorLbl.Text = "Z";
            this.zVectorLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eyePosXtxt
            // 
            this.eyePosXtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eyePosXtxt.Location = new System.Drawing.Point(93, 28);
            this.eyePosXtxt.Name = "eyePosXtxt";
            this.eyePosXtxt.Size = new System.Drawing.Size(83, 20);
            this.eyePosXtxt.TabIndex = 6;
            this.eyePosXtxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // eyePosYtxt
            // 
            this.eyePosYtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eyePosYtxt.Location = new System.Drawing.Point(182, 28);
            this.eyePosYtxt.Name = "eyePosYtxt";
            this.eyePosYtxt.Size = new System.Drawing.Size(83, 20);
            this.eyePosYtxt.TabIndex = 7;
            this.eyePosYtxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // eyePosZtxt
            // 
            this.eyePosZtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eyePosZtxt.Location = new System.Drawing.Point(271, 28);
            this.eyePosZtxt.Name = "eyePosZtxt";
            this.eyePosZtxt.Size = new System.Drawing.Size(85, 20);
            this.eyePosZtxt.TabIndex = 8;
            this.eyePosZtxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // upDirXtxt
            // 
            this.upDirXtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upDirXtxt.Location = new System.Drawing.Point(93, 53);
            this.upDirXtxt.Name = "upDirXtxt";
            this.upDirXtxt.Size = new System.Drawing.Size(83, 20);
            this.upDirXtxt.TabIndex = 9;
            this.upDirXtxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // upDirYtxt
            // 
            this.upDirYtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upDirYtxt.Location = new System.Drawing.Point(182, 53);
            this.upDirYtxt.Name = "upDirYtxt";
            this.upDirYtxt.Size = new System.Drawing.Size(83, 20);
            this.upDirYtxt.TabIndex = 10;
            this.upDirYtxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // upDirZtxt
            // 
            this.upDirZtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upDirZtxt.Location = new System.Drawing.Point(271, 53);
            this.upDirZtxt.Name = "upDirZtxt";
            this.upDirZtxt.Size = new System.Drawing.Size(85, 20);
            this.upDirZtxt.TabIndex = 11;
            this.upDirZtxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // targetPosXtxt
            // 
            this.targetPosXtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetPosXtxt.Location = new System.Drawing.Point(93, 78);
            this.targetPosXtxt.Name = "targetPosXtxt";
            this.targetPosXtxt.Size = new System.Drawing.Size(83, 20);
            this.targetPosXtxt.TabIndex = 12;
            this.targetPosXtxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // targetPosYtxt
            // 
            this.targetPosYtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetPosYtxt.Location = new System.Drawing.Point(182, 78);
            this.targetPosYtxt.Name = "targetPosYtxt";
            this.targetPosYtxt.Size = new System.Drawing.Size(83, 20);
            this.targetPosYtxt.TabIndex = 13;
            this.targetPosYtxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // targetPosZtxt
            // 
            this.targetPosZtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetPosZtxt.Location = new System.Drawing.Point(271, 78);
            this.targetPosZtxt.Name = "targetPosZtxt";
            this.targetPosZtxt.Size = new System.Drawing.Size(85, 20);
            this.targetPosZtxt.TabIndex = 14;
            this.targetPosZtxt.TextChanged += new System.EventHandler(this.floatTextBox_TextChanged);
            // 
            // cameraVectorsLbl
            // 
            this.cameraVectorsLbl.AutoSize = true;
            this.cameraVectorsLbl.Location = new System.Drawing.Point(19, 107);
            this.cameraVectorsLbl.Name = "cameraVectorsLbl";
            this.cameraVectorsLbl.Size = new System.Drawing.Size(85, 13);
            this.cameraVectorsLbl.TabIndex = 3;
            this.cameraVectorsLbl.Text = "Camera Vectors:";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(297, 227);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(216, 227);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // RenderSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 266);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.cameraVectorsLbl);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.statsLocationLbl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "RenderSettingsDialog";
            this.Text = "Render Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label effectStatsLbl;
        private System.Windows.Forms.TextBox effectStatsXtxt;
        private System.Windows.Forms.Label generalStatsLbl;
        private System.Windows.Forms.TextBox effectStatsYtxt;
        private System.Windows.Forms.TextBox effectStatsIncrTxt;
        private System.Windows.Forms.TextBox generalStatsXtxt;
        private System.Windows.Forms.TextBox generalStatsYtxt;
        private System.Windows.Forms.Label yStatsLbl;
        private System.Windows.Forms.Label xStatsLbl;
        private System.Windows.Forms.Label lineSpacingLbl;
        private System.Windows.Forms.Label statsLocationLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label eyePosLbl;
        private System.Windows.Forms.Label upDirLbl;
        private System.Windows.Forms.Label targetPosLbl;
        private System.Windows.Forms.Label xVectorLbl;
        private System.Windows.Forms.Label yVectorLbl;
        private System.Windows.Forms.Label zVectorLbl;
        private System.Windows.Forms.TextBox eyePosXtxt;
        private System.Windows.Forms.TextBox eyePosYtxt;
        private System.Windows.Forms.TextBox eyePosZtxt;
        private System.Windows.Forms.TextBox upDirXtxt;
        private System.Windows.Forms.TextBox upDirYtxt;
        private System.Windows.Forms.TextBox upDirZtxt;
        private System.Windows.Forms.TextBox targetPosXtxt;
        private System.Windows.Forms.TextBox targetPosYtxt;
        private System.Windows.Forms.TextBox targetPosZtxt;
        private System.Windows.Forms.Label cameraVectorsLbl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
    }
}