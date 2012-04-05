namespace ChaosTools.AudioPlayer
{
    partial class MusicSelectionDialog
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
            this.musicTypeLBL = new System.Windows.Forms.Label();
            this.musicTypeCMB = new System.Windows.Forms.ComboBox();
            this.genreLBL = new System.Windows.Forms.Label();
            this.genreCMB = new System.Windows.Forms.ComboBox();
            this.songListView = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.artistColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.keyColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.okBTN = new System.Windows.Forms.Button();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // musicTypeLBL
            // 
            this.musicTypeLBL.AutoSize = true;
            this.musicTypeLBL.Location = new System.Drawing.Point(12, 16);
            this.musicTypeLBL.Name = "musicTypeLBL";
            this.musicTypeLBL.Size = new System.Drawing.Size(65, 13);
            this.musicTypeLBL.TabIndex = 0;
            this.musicTypeLBL.Text = "Music Type:";
            // 
            // musicTypeCMB
            // 
            this.musicTypeCMB.FormattingEnabled = true;
            this.musicTypeCMB.Location = new System.Drawing.Point(83, 13);
            this.musicTypeCMB.Name = "musicTypeCMB";
            this.musicTypeCMB.Size = new System.Drawing.Size(120, 21);
            this.musicTypeCMB.TabIndex = 1;
            this.musicTypeCMB.SelectionChangeCommitted += new System.EventHandler(this.musicTypeGenreSelectionChangeCommitted);
            // 
            // genreLBL
            // 
            this.genreLBL.AutoSize = true;
            this.genreLBL.Location = new System.Drawing.Point(209, 16);
            this.genreLBL.Name = "genreLBL";
            this.genreLBL.Size = new System.Drawing.Size(39, 13);
            this.genreLBL.TabIndex = 2;
            this.genreLBL.Text = "Genre:";
            // 
            // genreCMB
            // 
            this.genreCMB.FormattingEnabled = true;
            this.genreCMB.Location = new System.Drawing.Point(254, 12);
            this.genreCMB.Name = "genreCMB";
            this.genreCMB.Size = new System.Drawing.Size(218, 21);
            this.genreCMB.TabIndex = 3;
            this.genreCMB.SelectionChangeCommitted += new System.EventHandler(this.musicTypeGenreSelectionChangeCommitted);
            // 
            // songListView
            // 
            this.songListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.artistColumn,
            this.keyColumn});
            this.songListView.Location = new System.Drawing.Point(15, 44);
            this.songListView.MultiSelect = false;
            this.songListView.Name = "songListView";
            this.songListView.Size = new System.Drawing.Size(550, 180);
            this.songListView.TabIndex = 4;
            this.songListView.UseCompatibleStateImageBehavior = false;
            this.songListView.View = System.Windows.Forms.View.Details;
            this.songListView.SelectedIndexChanged += new System.EventHandler(this.songListView_SelectedIndexChanged);
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 200;
            // 
            // artistColumn
            // 
            this.artistColumn.Text = "Artist";
            this.artistColumn.Width = 200;
            // 
            // keyColumn
            // 
            this.keyColumn.Text = "AUDT";
            this.keyColumn.Width = 125;
            // 
            // okBTN
            // 
            this.okBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBTN.Location = new System.Drawing.Point(460, 230);
            this.okBTN.Name = "okBTN";
            this.okBTN.Size = new System.Drawing.Size(41, 23);
            this.okBTN.TabIndex = 5;
            this.okBTN.Text = "OK";
            this.okBTN.UseVisualStyleBackColor = true;
            // 
            // cancelBTN
            // 
            this.cancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBTN.Location = new System.Drawing.Point(507, 230);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(58, 23);
            this.cancelBTN.TabIndex = 6;
            this.cancelBTN.Text = "Cancel";
            this.cancelBTN.UseVisualStyleBackColor = true;
            // 
            // MusicSelectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.cancelBTN);
            this.Controls.Add(this.okBTN);
            this.Controls.Add(this.songListView);
            this.Controls.Add(this.genreCMB);
            this.Controls.Add(this.genreLBL);
            this.Controls.Add(this.musicTypeCMB);
            this.Controls.Add(this.musicTypeLBL);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MusicSelectionDialog";
            this.Text = "Select A Song";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label musicTypeLBL;
        private System.Windows.Forms.ComboBox musicTypeCMB;
        private System.Windows.Forms.Label genreLBL;
        private System.Windows.Forms.ComboBox genreCMB;
        private System.Windows.Forms.ListView songListView;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader artistColumn;
        private System.Windows.Forms.ColumnHeader keyColumn;
        private System.Windows.Forms.Button okBTN;
        private System.Windows.Forms.Button cancelBTN;
    }
}