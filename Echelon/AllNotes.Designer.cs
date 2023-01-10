namespace Echelon
{
    partial class AllNotes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GreetingLabel = new System.Windows.Forms.Label();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.NotesGridView = new System.Windows.Forms.DataGridView();
            this.NoteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoteDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Export = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NotesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // GreetingLabel
            // 
            this.GreetingLabel.AutoSize = true;
            this.GreetingLabel.Font = new System.Drawing.Font("Inter Semi Bold", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GreetingLabel.Location = new System.Drawing.Point(66, 71);
            this.GreetingLabel.Name = "GreetingLabel";
            this.GreetingLabel.Size = new System.Drawing.Size(175, 40);
            this.GreetingLabel.TabIndex = 4;
            this.GreetingLabel.Text = "All notes:";
            this.GreetingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Font = new System.Drawing.Font("Inter", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TotalLabel.ForeColor = System.Drawing.Color.DimGray;
            this.TotalLabel.Location = new System.Drawing.Point(231, 83);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(113, 24);
            this.TotalLabel.TabIndex = 5;
            this.TotalLabel.Text = "{total} in total";
            this.TotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NotesGridView
            // 
            this.NotesGridView.AllowUserToAddRows = false;
            this.NotesGridView.AllowUserToDeleteRows = false;
            this.NotesGridView.AllowUserToResizeColumns = false;
            this.NotesGridView.AllowUserToResizeRows = false;
            this.NotesGridView.BackgroundColor = System.Drawing.Color.White;
            this.NotesGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NotesGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NotesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.NotesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NotesGridView.ColumnHeadersVisible = false;
            this.NotesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoteName,
            this.NoteDate,
            this.Export,
            this.Delete});
            this.NotesGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NotesGridView.Location = new System.Drawing.Point(60, 146);
            this.NotesGridView.MultiSelect = false;
            this.NotesGridView.Name = "NotesGridView";
            this.NotesGridView.ReadOnly = true;
            this.NotesGridView.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Inter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            this.NotesGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.NotesGridView.RowTemplate.Height = 30;
            this.NotesGridView.RowTemplate.ReadOnly = true;
            this.NotesGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NotesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.NotesGridView.Size = new System.Drawing.Size(673, 226);
            this.NotesGridView.TabIndex = 6;
            this.NotesGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NotesGridView_CellClick);
            // 
            // NoteName
            // 
            this.NoteName.HeaderText = "Name";
            this.NoteName.Name = "NoteName";
            this.NoteName.ReadOnly = true;
            this.NoteName.Width = 200;
            // 
            // NoteDate
            // 
            this.NoteDate.HeaderText = "Last Modified";
            this.NoteDate.Name = "NoteDate";
            this.NoteDate.ReadOnly = true;
            this.NoteDate.Width = 275;
            // 
            // Export
            // 
            this.Export.HeaderText = "Export";
            this.Export.Name = "Export";
            this.Export.ReadOnly = true;
            this.Export.Width = 90;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 90;
            // 
            // HomeLabel
            // 
            this.HomeLabel.AutoSize = true;
            this.HomeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HomeLabel.Font = new System.Drawing.Font("Inter", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HomeLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.HomeLabel.Location = new System.Drawing.Point(40, 40);
            this.HomeLabel.Name = "HomeLabel";
            this.HomeLabel.Size = new System.Drawing.Size(29, 23);
            this.HomeLabel.TabIndex = 8;
            this.HomeLabel.Text = "←";
            this.HomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.HomeLabel.Click += new System.EventHandler(this.HomeLabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(137, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(351, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Last Modified";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(598, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Actions";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AllNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HomeLabel);
            this.Controls.Add(this.NotesGridView);
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.GreetingLabel);
            this.Name = "AllNotes";
            this.Size = new System.Drawing.Size(800, 400);
            this.Load += new System.EventHandler(this.AllNotes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NotesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label GreetingLabel;
        private Label TotalLabel;
        private DataGridView NotesGridView;
        private Label HomeLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridViewTextBoxColumn NoteName;
        private DataGridViewTextBoxColumn NoteDate;
        private DataGridViewTextBoxColumn Export;
        private DataGridViewTextBoxColumn Delete;
    }
}
