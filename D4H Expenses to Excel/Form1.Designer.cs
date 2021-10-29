namespace D4H_Expenses_to_Excel
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ofdFiles = new System.Windows.Forms.OpenFileDialog();
            this.svdSaveLocation = new System.Windows.Forms.SaveFileDialog();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReimbursementItems = new System.Windows.Forms.DataGridView();
            this.colMember = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReimbursementItems)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdFiles
            // 
            this.ofdFiles.Filter = "CSV Files|*.csv";
            this.ofdFiles.Multiselect = true;
            this.ofdFiles.ReadOnlyChecked = true;
            this.ofdFiles.Title = "Select files to add";
            this.ofdFiles.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdFiles_FileOk);
            // 
            // svdSaveLocation
            // 
            this.svdSaveLocation.DefaultExt = "csv";
            this.svdSaveLocation.Filter = "CSV Files|*.csv";
            this.svdSaveLocation.Title = "Save the consolodated file";
            // 
            // lbFiles
            // 
            this.lbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.ItemHeight = 20;
            this.lbFiles.Location = new System.Drawing.Point(13, 34);
            this.lbFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.ScrollAlwaysVisible = true;
            this.lbFiles.Size = new System.Drawing.Size(758, 84);
            this.lbFiles.TabIndex = 0;
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Location = new System.Drawing.Point(13, 128);
            this.btnAddFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(112, 35);
            this.btnAddFiles.TabIndex = 1;
            this.btnAddFiles.Text = "Add Files";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Files Included";
            // 
            // dgvReimbursementItems
            // 
            this.dgvReimbursementItems.AllowUserToAddRows = false;
            this.dgvReimbursementItems.AllowUserToDeleteRows = false;
            this.dgvReimbursementItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReimbursementItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReimbursementItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMember,
            this.colDescription,
            this.colRef,
            this.colTotal});
            this.dgvReimbursementItems.Location = new System.Drawing.Point(13, 171);
            this.dgvReimbursementItems.Name = "dgvReimbursementItems";
            this.dgvReimbursementItems.RowHeadersVisible = false;
            this.dgvReimbursementItems.RowTemplate.Height = 25;
            this.dgvReimbursementItems.Size = new System.Drawing.Size(758, 231);
            this.dgvReimbursementItems.TabIndex = 3;
            // 
            // colMember
            // 
            this.colMember.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMember.HeaderText = "Member";
            this.colMember.Name = "colMember";
            this.colMember.Width = 73;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 114;
            // 
            // colRef
            // 
            this.colRef.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRef.DataPropertyName = "Ref";
            this.colRef.HeaderText = "Ref";
            this.colRef.Name = "colRef";
            this.colRef.ReadOnly = true;
            this.colRef.Width = 60;
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTotal.DataPropertyName = "TotalCostLessUsage";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 69;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFile.Location = new System.Drawing.Point(659, 410);
            this.btnSaveFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(112, 35);
            this.btnSaveFile.TabIndex = 4;
            this.btnSaveFile.Text = "Save File";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 456);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.dgvReimbursementItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddFiles);
            this.Controls.Add(this.lbFiles);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "D4H Task Expense Distribution";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReimbursementItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdFiles;
        private System.Windows.Forms.SaveFileDialog svdSaveLocation;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReimbursementItems;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}

