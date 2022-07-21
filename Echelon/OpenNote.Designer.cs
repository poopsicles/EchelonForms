namespace Echelon
{
    partial class OpenNote
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
            this.TitleTextbox = new System.Windows.Forms.TextBox();
            this.ScrollPanel = new System.Windows.Forms.Panel();
            this.BodyTextbox = new System.Windows.Forms.TextBox();
            this.HomeLabel = new System.Windows.Forms.Label();
            this.SaveLabel = new System.Windows.Forms.Label();
            this.ScrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleTextbox
            // 
            this.TitleTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TitleTextbox.Font = new System.Drawing.Font("SF Pro Display", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleTextbox.ForeColor = System.Drawing.Color.Black;
            this.TitleTextbox.Location = new System.Drawing.Point(51, 74);
            this.TitleTextbox.MaxLength = 40;
            this.TitleTextbox.Name = "TitleTextbox";
            this.TitleTextbox.PlaceholderText = "Title";
            this.TitleTextbox.Size = new System.Drawing.Size(688, 40);
            this.TitleTextbox.TabIndex = 4;
            this.TitleTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TitleTextbox_KeyDown);
            this.TitleTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TitleTextbox_KeyPress);
            // 
            // ScrollPanel
            // 
            this.ScrollPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScrollPanel.Controls.Add(this.BodyTextbox);
            this.ScrollPanel.Location = new System.Drawing.Point(-8, 121);
            this.ScrollPanel.Name = "ScrollPanel";
            this.ScrollPanel.Size = new System.Drawing.Size(827, 279);
            this.ScrollPanel.TabIndex = 6;
            // 
            // BodyTextbox
            // 
            this.BodyTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BodyTextbox.Font = new System.Drawing.Font("SF Pro Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BodyTextbox.Location = new System.Drawing.Point(58, 11);
            this.BodyTextbox.Multiline = true;
            this.BodyTextbox.Name = "BodyTextbox";
            this.BodyTextbox.PlaceholderText = "Type something magical...";
            this.BodyTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BodyTextbox.Size = new System.Drawing.Size(700, 244);
            this.BodyTextbox.TabIndex = 0;
            this.BodyTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BodyTextbox_KeyDown);
            this.BodyTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BodyTextbox_KeyPress);
            // 
            // HomeLabel
            // 
            this.HomeLabel.AutoSize = true;
            this.HomeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HomeLabel.Font = new System.Drawing.Font("SF Pro Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HomeLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.HomeLabel.Location = new System.Drawing.Point(33, 29);
            this.HomeLabel.Name = "HomeLabel";
            this.HomeLabel.Size = new System.Drawing.Size(29, 24);
            this.HomeLabel.TabIndex = 7;
            this.HomeLabel.Text = "←";
            this.HomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.HomeLabel.Click += new System.EventHandler(this.HomeLabel_Click);
            // 
            // SaveLabel
            // 
            this.SaveLabel.AutoSize = true;
            this.SaveLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveLabel.Font = new System.Drawing.Font("SF Pro Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SaveLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.SaveLabel.Location = new System.Drawing.Point(727, 29);
            this.SaveLabel.Name = "SaveLabel";
            this.SaveLabel.Size = new System.Drawing.Size(36, 24);
            this.SaveLabel.TabIndex = 8;
            this.SaveLabel.Text = "☁️ ";
            this.SaveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveLabel.Click += new System.EventHandler(this.SaveLabel_Click);
            // 
            // OpenNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.SaveLabel);
            this.Controls.Add(this.HomeLabel);
            this.Controls.Add(this.ScrollPanel);
            this.Controls.Add(this.TitleTextbox);
            this.Name = "OpenNote";
            this.Size = new System.Drawing.Size(800, 400);
            this.Load += new System.EventHandler(this.OpenNote_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OpenNote_KeyDown);
            this.ScrollPanel.ResumeLayout(false);
            this.ScrollPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TitleTextbox;
        private Panel ScrollPanel;
        private TextBox BodyTextbox;
        private Label HomeLabel;
        private Label SaveLabel;
    }
}
