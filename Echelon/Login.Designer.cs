namespace Echelon
{
    partial class Login
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
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.inputTextbox = new System.Windows.Forms.TextBox();
            this.BorderLabel = new System.Windows.Forms.Label();
            this.NextLabel = new System.Windows.Forms.Label();
            this.ValidationLabel = new System.Windows.Forms.Label();
            this.ForgotLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Inter Semi Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NameLabel.Location = new System.Drawing.Point(64, 52);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(560, 58);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Welcome back, {name}";
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.Font = new System.Drawing.Font("Inter Semi Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.QuestionLabel.Location = new System.Drawing.Point(65, 105);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(536, 58);
            this.QuestionLabel.TabIndex = 2;
            this.QuestionLabel.Text = "What\'s the password?";
            // 
            // inputTextbox
            // 
            this.inputTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputTextbox.Font = new System.Drawing.Font("Inter", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputTextbox.ForeColor = System.Drawing.Color.Black;
            this.inputTextbox.Location = new System.Drawing.Point(74, 197);
            this.inputTextbox.MaxLength = 15;
            this.inputTextbox.Name = "inputTextbox";
            this.inputTextbox.Size = new System.Drawing.Size(345, 40);
            this.inputTextbox.TabIndex = 3;
            this.inputTextbox.UseSystemPasswordChar = true;
            this.inputTextbox.Enter += new System.EventHandler(this.inputTextbox_Enter);
            this.inputTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTextbox_KeyDown);
            this.inputTextbox.Leave += new System.EventHandler(this.inputTextbox_Leave);
            // 
            // BorderLabel
            // 
            this.BorderLabel.AutoSize = true;
            this.BorderLabel.Font = new System.Drawing.Font("Inter", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BorderLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BorderLabel.Location = new System.Drawing.Point(65, 193);
            this.BorderLabel.Name = "BorderLabel";
            this.BorderLabel.Size = new System.Drawing.Size(370, 58);
            this.BorderLabel.TabIndex = 4;
            this.BorderLabel.Text = "_______________";
            // 
            // NextLabel
            // 
            this.NextLabel.AutoSize = true;
            this.NextLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextLabel.Font = new System.Drawing.Font("Inter", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NextLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.NextLabel.Location = new System.Drawing.Point(441, 183);
            this.NextLabel.Name = "NextLabel";
            this.NextLabel.Size = new System.Drawing.Size(76, 58);
            this.NextLabel.TabIndex = 5;
            this.NextLabel.Text = "→";
            this.NextLabel.Click += new System.EventHandler(this.NextLabel_Click);
            this.NextLabel.MouseEnter += new System.EventHandler(this.NextLabel_MouseEnter);
            this.NextLabel.MouseLeave += new System.EventHandler(this.NextLabel_MouseLeave);
            // 
            // ValidationLabel
            // 
            this.ValidationLabel.AutoSize = true;
            this.ValidationLabel.Font = new System.Drawing.Font("Inter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ValidationLabel.ForeColor = System.Drawing.Color.Red;
            this.ValidationLabel.Location = new System.Drawing.Point(73, 251);
            this.ValidationLabel.Name = "ValidationLabel";
            this.ValidationLabel.Size = new System.Drawing.Size(121, 18);
            this.ValidationLabel.TabIndex = 6;
            this.ValidationLabel.Text = "Invalid password.";
            this.ValidationLabel.Visible = false;
            // 
            // ForgotLabel
            // 
            this.ForgotLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForgotLabel.Font = new System.Drawing.Font("Inter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForgotLabel.ForeColor = System.Drawing.Color.DimGray;
            this.ForgotLabel.Location = new System.Drawing.Point(458, 307);
            this.ForgotLabel.Name = "ForgotLabel";
            this.ForgotLabel.Size = new System.Drawing.Size(267, 18);
            this.ForgotLabel.TabIndex = 7;
            this.ForgotLabel.Text = "Forgot password or not {name}?";
            this.ForgotLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ForgotLabel.Click += new System.EventHandler(this.ForgotLabel_Click);
            this.ForgotLabel.MouseEnter += new System.EventHandler(this.ForgotLabel_MouseEnter);
            this.ForgotLabel.MouseLeave += new System.EventHandler(this.ForgotLabel_MouseLeave);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ForgotLabel);
            this.Controls.Add(this.ValidationLabel);
            this.Controls.Add(this.inputTextbox);
            this.Controls.Add(this.BorderLabel);
            this.Controls.Add(this.NextLabel);
            this.Controls.Add(this.QuestionLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "Login";
            this.Size = new System.Drawing.Size(800, 400);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label NameLabel;
        private Label QuestionLabel;
        private TextBox inputTextbox;
        private Label BorderLabel;
        private Label NextLabel;
        private Label ValidationLabel;
        private Label ForgotLabel;
    }
}
