namespace Analogy.LogViewer.WordsSearch
{
    partial class WordsSearchSettings
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
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.lblLength = new System.Windows.Forms.Label();
            this.lstCharPositions = new System.Windows.Forms.ListBox();
            this.lblAddChar = new System.Windows.Forms.Label();
            this.txtbChr = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.nudPosition = new System.Windows.Forms.NumericUpDown();
            this.btnDeleteSelection = new System.Windows.Forms.Button();
            this.btnAddOrReplace = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilesLocation = new System.Windows.Forms.TextBox();
            this.btnFolderSelection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // nudLength
            // 
            this.nudLength.Location = new System.Drawing.Point(183, 44);
            this.nudLength.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLength.Name = "nudLength";
            this.nudLength.Size = new System.Drawing.Size(185, 27);
            this.nudLength.TabIndex = 0;
            this.nudLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLength.ValueChanged += new System.EventHandler(this.nudLength_ValueChanged);
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(15, 46);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(57, 20);
            this.lblLength.TabIndex = 1;
            this.lblLength.Text = "Length:";
            // 
            // lstCharPositions
            // 
            this.lstCharPositions.ItemHeight = 20;
            this.lstCharPositions.Location = new System.Drawing.Point(3, 77);
            this.lstCharPositions.Name = "lstCharPositions";
            this.lstCharPositions.Size = new System.Drawing.Size(365, 304);
            this.lstCharPositions.TabIndex = 3;
            // 
            // lblAddChar
            // 
            this.lblAddChar.AutoSize = true;
            this.lblAddChar.Location = new System.Drawing.Point(473, 114);
            this.lblAddChar.Name = "lblAddChar";
            this.lblAddChar.Size = new System.Drawing.Size(74, 20);
            this.lblAddChar.TabIndex = 4;
            this.lblAddChar.Text = "Add Char:";
            // 
            // txtbChr
            // 
            this.txtbChr.Location = new System.Drawing.Point(631, 111);
            this.txtbChr.MaxLength = 1;
            this.txtbChr.Name = "txtbChr";
            this.txtbChr.Size = new System.Drawing.Size(185, 27);
            this.txtbChr.TabIndex = 5;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(473, 146);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(151, 20);
            this.lblPosition.TabIndex = 7;
            this.lblPosition.Text = "Position (zero based):";
            // 
            // nudPosition
            // 
            this.nudPosition.Location = new System.Drawing.Point(631, 144);
            this.nudPosition.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPosition.Name = "nudPosition";
            this.nudPosition.Size = new System.Drawing.Size(185, 27);
            this.nudPosition.TabIndex = 6;
            this.nudPosition.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnDeleteSelection
            // 
            this.btnDeleteSelection.Location = new System.Drawing.Point(3, 387);
            this.btnDeleteSelection.Name = "btnDeleteSelection";
            this.btnDeleteSelection.Size = new System.Drawing.Size(365, 37);
            this.btnDeleteSelection.TabIndex = 8;
            this.btnDeleteSelection.Text = "Delete Selection";
            this.btnDeleteSelection.UseVisualStyleBackColor = true;
            this.btnDeleteSelection.Click += new System.EventHandler(this.btnDeleteSelection_Click);
            // 
            // btnAddOrReplace
            // 
            this.btnAddOrReplace.Location = new System.Drawing.Point(473, 182);
            this.btnAddOrReplace.Name = "btnAddOrReplace";
            this.btnAddOrReplace.Size = new System.Drawing.Size(343, 37);
            this.btnAddOrReplace.TabIndex = 9;
            this.btnAddOrReplace.Text = "Add or Replace";
            this.btnAddOrReplace.UseVisualStyleBackColor = true;
            this.btnAddOrReplace.Click += new System.EventHandler(this.btnAddOrReplace_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Words*.txt files location:";
            // 
            // txtFilesLocation
            // 
            this.txtFilesLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilesLocation.Location = new System.Drawing.Point(183, 9);
            this.txtFilesLocation.MaxLength = 1;
            this.txtFilesLocation.Name = "txtFilesLocation";
            this.txtFilesLocation.Size = new System.Drawing.Size(585, 27);
            this.txtFilesLocation.TabIndex = 11;
            // 
            // btnFolderSelection
            // 
            this.btnFolderSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolderSelection.Location = new System.Drawing.Point(774, 4);
            this.btnFolderSelection.Name = "btnFolderSelection";
            this.btnFolderSelection.Size = new System.Drawing.Size(42, 37);
            this.btnFolderSelection.TabIndex = 12;
            this.btnFolderSelection.Text = "..";
            this.btnFolderSelection.UseVisualStyleBackColor = true;
            this.btnFolderSelection.Click += new System.EventHandler(this.btnFolderSelection_Click);
            // 
            // WordsSearchSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFolderSelection);
            this.Controls.Add(this.txtFilesLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddOrReplace);
            this.Controls.Add(this.btnDeleteSelection);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.nudPosition);
            this.Controls.Add(this.txtbChr);
            this.Controls.Add(this.lblAddChar);
            this.Controls.Add(this.lstCharPositions);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.nudLength);
            this.Name = "WordsSearchSettings";
            this.Size = new System.Drawing.Size(834, 435);
            this.Load += new System.EventHandler(this.WordsSearchSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.ListBox lstCharPositions;
        private System.Windows.Forms.Label lblAddChar;
        private System.Windows.Forms.TextBox txtbChr;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.NumericUpDown nudPosition;
        private System.Windows.Forms.Button btnDeleteSelection;
        private System.Windows.Forms.Button btnAddOrReplace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilesLocation;
        private System.Windows.Forms.Button btnFolderSelection;
    }
}
