namespace Echelon
{
    partial class Reset
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.EmojiLabel = new System.Windows.Forms.Label();
            this.InfoLabel1 = new System.Windows.Forms.Label();
            this.NextLabel = new System.Windows.Forms.Label();
            this.InfoLabel2 = new System.Windows.Forms.Label();
            this.BackLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Inter Semi Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NameLabel.Location = new System.Drawing.Point(53, 85);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(329, 58);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Danger Zone";
            // 
            // EmojiLabel
            // 
            this.EmojiLabel.AutoSize = true;
            this.EmojiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EmojiLabel.ForeColor = System.Drawing.Color.Red;
            this.EmojiLabel.Location = new System.Drawing.Point(607, 24);
            this.EmojiLabel.Name = "EmojiLabel";
            this.EmojiLabel.Size = new System.Drawing.Size(155, 108);
            this.EmojiLabel.TabIndex = 3;
            this.EmojiLabel.Text = "⚠️";
            // 
            // InfoLabel1
            // 
            this.InfoLabel1.AutoSize = true;
            this.InfoLabel1.Font = new System.Drawing.Font("Inter", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InfoLabel1.Location = new System.Drawing.Point(59, 152);
            this.InfoLabel1.Name = "InfoLabel1";
            this.InfoLabel1.Size = new System.Drawing.Size(505, 30);
            this.InfoLabel1.TabIndex = 4;
            this.InfoLabel1.Text = "Oh no! All data will be deleted, permanently";
            // 
            // NextLabel
            // 
            this.NextLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextLabel.Font = new System.Drawing.Font("Inter Semi Bold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NextLabel.ForeColor = System.Drawing.Color.Red;
            this.NextLabel.Location = new System.Drawing.Point(219, 277);
            this.NextLabel.Name = "NextLabel";
            this.NextLabel.Size = new System.Drawing.Size(515, 44);
            this.NextLabel.TabIndex = 5;
            this.NextLabel.Text = "I acknowledge the risks →";
            this.NextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NextLabel.Click += new System.EventHandler(this.NextLabel_Click);
            this.NextLabel.MouseEnter += new System.EventHandler(this.NextLabel_MouseEnter);
            this.NextLabel.MouseLeave += new System.EventHandler(this.NextLabel_MouseLeave);
            // 
            // InfoLabel2
            // 
            this.InfoLabel2.AutoSize = true;
            this.InfoLabel2.Font = new System.Drawing.Font("Inter", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InfoLabel2.Location = new System.Drawing.Point(59, 184);
            this.InfoLabel2.Name = "InfoLabel2";
            this.InfoLabel2.Size = new System.Drawing.Size(177, 30);
            this.InfoLabel2.TabIndex = 6;
            this.InfoLabel2.Text = "(...a long time)";
            // 
            // BackLabel
            // 
            this.BackLabel.AutoSize = true;
            this.BackLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackLabel.Font = new System.Drawing.Font("Inter", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackLabel.ForeColor = System.Drawing.Color.Red;
            this.BackLabel.Location = new System.Drawing.Point(40, 40);
            this.BackLabel.Name = "BackLabel";
            this.BackLabel.Size = new System.Drawing.Size(29, 23);
            this.BackLabel.TabIndex = 7;
            this.BackLabel.Text = "←";
            this.BackLabel.Click += new System.EventHandler(this.BackLabel_Click);
            this.BackLabel.MouseEnter += new System.EventHandler(this.BackLabel_MouseEnter);
            this.BackLabel.MouseLeave += new System.EventHandler(this.BackLabel_MouseLeave);
            // 
            // Reset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BackLabel);
            this.Controls.Add(this.InfoLabel2);
            this.Controls.Add(this.NextLabel);
            this.Controls.Add(this.InfoLabel1);
            this.Controls.Add(this.EmojiLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "Reset";
            this.Size = new System.Drawing.Size(800, 400);
            this.Load += new System.EventHandler(this.Reset_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Reset_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label NameLabel;
        private Label EmojiLabel;
        private Label InfoLabel1;
        private Label NextLabel;
        private Label InfoLabel2;
        private Label BackLabel;
    }
}
