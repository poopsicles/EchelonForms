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
            this.components = new System.ComponentModel.Container();
            this.TitleTextbox = new System.Windows.Forms.TextBox();
            this.ScrollPanel = new System.Windows.Forms.Panel();
            this.BodyTextbox = new System.Windows.Forms.TextBox();
            this.HomeLabel = new System.Windows.Forms.Label();
            this.modifiedLabel = new System.Windows.Forms.Label();
            this.modifiedTimer = new System.Windows.Forms.Timer(this.components);
            this.ScrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleTextbox
            // 
            this.TitleTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TitleTextbox.Font = new System.Drawing.Font("Inter Semi Bold", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleTextbox.ForeColor = System.Drawing.Color.Black;
            this.TitleTextbox.Location = new System.Drawing.Point(69, 77);
            this.TitleTextbox.MaxLength = 40;
            this.TitleTextbox.Name = "TitleTextbox";
            this.TitleTextbox.PlaceholderText = "Title";
            this.TitleTextbox.Size = new System.Drawing.Size(669, 40);
            this.TitleTextbox.TabIndex = 4;
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
            this.BodyTextbox.Font = new System.Drawing.Font("Inter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BodyTextbox.Location = new System.Drawing.Point(78, 5);
            this.BodyTextbox.Multiline = true;
            this.BodyTextbox.Name = "BodyTextbox";
            this.BodyTextbox.PlaceholderText = "Type something magical...";
            this.BodyTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BodyTextbox.Size = new System.Drawing.Size(676, 230);
            this.BodyTextbox.TabIndex = 0;
            this.BodyTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BodyTextbox_KeyPress);
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
            this.HomeLabel.TabIndex = 7;
            this.HomeLabel.Text = "←";
            this.HomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.HomeLabel.Click += new System.EventHandler(this.HomeLabel_Click);
            this.HomeLabel.MouseEnter += new System.EventHandler(this.HomeLabel_MouseEnter);
            this.HomeLabel.MouseLeave += new System.EventHandler(this.HomeLabel_MouseLeave);
            // 
            // modifiedLabel
            // 
            this.modifiedLabel.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modifiedLabel.ForeColor = System.Drawing.Color.DimGray;
            this.modifiedLabel.Location = new System.Drawing.Point(444, 40);
            this.modifiedLabel.Name = "modifiedLabel";
            this.modifiedLabel.Size = new System.Drawing.Size(303, 23);
            this.modifiedLabel.TabIndex = 8;
            this.modifiedLabel.Text = "Saved {time} ago";
            this.modifiedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // modifiedTimer
            // 
            this.modifiedTimer.Enabled = true;
            this.modifiedTimer.Interval = 1000;
            this.modifiedTimer.Tick += new System.EventHandler(this.modifiedTimer_Tick);
            // 
            // OpenNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.modifiedLabel);
            this.Controls.Add(this.HomeLabel);
            this.Controls.Add(this.ScrollPanel);
            this.Controls.Add(this.TitleTextbox);
            this.Name = "OpenNote";
            this.Size = new System.Drawing.Size(800, 400);
            this.Load += new System.EventHandler(this.OpenNote_Load);
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
        private Label modifiedLabel;
        private System.Windows.Forms.Timer modifiedTimer;
    }
}
