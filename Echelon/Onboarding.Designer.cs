namespace Echelon
{
    partial class Onboarding
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
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.inputTextbox = new System.Windows.Forms.TextBox();
            this.borderLabel = new System.Windows.Forms.Label();
            this.NextLabel = new System.Windows.Forms.Label();
            this.ValidationLabel = new System.Windows.Forms.Label();
            this.GagTimer = new System.Windows.Forms.Timer(this.components);
            this.BackLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.Font = new System.Drawing.Font("SF Pro Display", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.QuestionLabel.Location = new System.Drawing.Point(39, 116);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(593, 57);
            this.QuestionLabel.TabIndex = 0;
            this.QuestionLabel.Text = "We\'ll need a name, please.";
            // 
            // inputTextbox
            // 
            this.inputTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputTextbox.Font = new System.Drawing.Font("SF Pro Display", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.inputTextbox.Location = new System.Drawing.Point(57, 202);
            this.inputTextbox.MaxLength = 15;
            this.inputTextbox.Name = "inputTextbox";
            this.inputTextbox.PlaceholderText = "Alexander";
            this.inputTextbox.Size = new System.Drawing.Size(365, 40);
            this.inputTextbox.TabIndex = 1;
            this.inputTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // borderLabel
            // 
            this.borderLabel.AutoSize = true;
            this.borderLabel.Font = new System.Drawing.Font("SF Pro Display", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.borderLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.borderLabel.Location = new System.Drawing.Point(39, 202);
            this.borderLabel.Name = "borderLabel";
            this.borderLabel.Size = new System.Drawing.Size(431, 57);
            this.borderLabel.TabIndex = 1;
            this.borderLabel.Text = "_______________";
            // 
            // NextLabel
            // 
            this.NextLabel.AutoSize = true;
            this.NextLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextLabel.Font = new System.Drawing.Font("SF Pro Display", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NextLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.NextLabel.Location = new System.Drawing.Point(466, 202);
            this.NextLabel.Name = "NextLabel";
            this.NextLabel.Size = new System.Drawing.Size(70, 57);
            this.NextLabel.TabIndex = 2;
            this.NextLabel.Text = "→";
            this.NextLabel.Click += new System.EventHandler(this.NextLabel_Click);
            // 
            // ValidationLabel
            // 
            this.ValidationLabel.AutoSize = true;
            this.ValidationLabel.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ValidationLabel.ForeColor = System.Drawing.Color.Red;
            this.ValidationLabel.Location = new System.Drawing.Point(57, 268);
            this.ValidationLabel.Name = "ValidationLabel";
            this.ValidationLabel.Size = new System.Drawing.Size(115, 18);
            this.ValidationLabel.TabIndex = 3;
            this.ValidationLabel.Text = "Enter something.";
            this.ValidationLabel.Visible = false;
            // 
            // GagTimer
            // 
            this.GagTimer.Enabled = true;
            this.GagTimer.Interval = 2000;
            this.GagTimer.Tick += new System.EventHandler(this.GagTimer_Tick);
            // 
            // BackLabel
            // 
            this.BackLabel.AutoSize = true;
            this.BackLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackLabel.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BackLabel.Location = new System.Drawing.Point(40, 40);
            this.BackLabel.Name = "BackLabel";
            this.BackLabel.Size = new System.Drawing.Size(28, 23);
            this.BackLabel.TabIndex = 4;
            this.BackLabel.Text = "←";
            this.BackLabel.Click += new System.EventHandler(this.BackLabel_Click);
            // 
            // Onboarding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BackLabel);
            this.Controls.Add(this.ValidationLabel);
            this.Controls.Add(this.inputTextbox);
            this.Controls.Add(this.borderLabel);
            this.Controls.Add(this.QuestionLabel);
            this.Controls.Add(this.NextLabel);
            this.Name = "Onboarding";
            this.Size = new System.Drawing.Size(800, 400);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label QuestionLabel;
        private TextBox inputTextbox;
        private Label borderLabel;
        private Label NextLabel;
        private Label ValidationLabel;
        private System.Windows.Forms.Timer GagTimer;
        private Label BackLabel;
    }
}
