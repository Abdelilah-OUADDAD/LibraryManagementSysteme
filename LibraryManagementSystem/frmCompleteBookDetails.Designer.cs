namespace LibraryManagementSystem
{
    partial class frmCompleteBookDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompleteBookDetails));
            this.dgvIssueBook = new System.Windows.Forms.DataGridView();
            this.dgvReturnBook = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssueBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnBook)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIssueBook
            // 
            this.dgvIssueBook.AllowUserToAddRows = false;
            this.dgvIssueBook.AllowUserToDeleteRows = false;
            this.dgvIssueBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssueBook.Location = new System.Drawing.Point(12, 223);
            this.dgvIssueBook.Name = "dgvIssueBook";
            this.dgvIssueBook.ReadOnly = true;
            this.dgvIssueBook.RowHeadersWidth = 62;
            this.dgvIssueBook.RowTemplate.Height = 28;
            this.dgvIssueBook.Size = new System.Drawing.Size(1325, 357);
            this.dgvIssueBook.TabIndex = 0;
            // 
            // dgvReturnBook
            // 
            this.dgvReturnBook.AllowUserToAddRows = false;
            this.dgvReturnBook.AllowUserToDeleteRows = false;
            this.dgvReturnBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnBook.Location = new System.Drawing.Point(12, 677);
            this.dgvReturnBook.Name = "dgvReturnBook";
            this.dgvReturnBook.ReadOnly = true;
            this.dgvReturnBook.RowHeadersWidth = 62;
            this.dgvReturnBook.RowTemplate.Height = 28;
            this.dgvReturnBook.Size = new System.Drawing.Size(1325, 318);
            this.dgvReturnBook.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1349, 134);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(176, 110);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(493, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Complete Book Detail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(659, 621);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Return Book";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(649, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Issue Book";
            // 
            // frmCompleteBookDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1349, 1050);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvReturnBook);
            this.Controls.Add(this.dgvIssueBook);
            this.Name = "frmCompleteBookDetails";
            this.Text = "frmCompleteBookDetails";
            this.Load += new System.EventHandler(this.frmCompleteBookDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssueBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnBook)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIssueBook;
        private System.Windows.Forms.DataGridView dgvReturnBook;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}