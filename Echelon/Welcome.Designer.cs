﻿namespace Echelon
{
    partial class Welcome
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
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.GreetingLabel = new System.Windows.Forms.Label();
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            this.EmojiLabel = new System.Windows.Forms.Label();
            this.NextLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Font = new System.Drawing.Font("SF Pro Display", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.WelcomeLabel.Location = new System.Drawing.Point(50, 100);
            this.WelcomeLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(281, 57);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "Welcome to";
            // 
            // GreetingLabel
            // 
            this.GreetingLabel.AutoSize = true;
            this.GreetingLabel.Font = new System.Drawing.Font("SF Pro Display", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GreetingLabel.Location = new System.Drawing.Point(50, 157);
            this.GreetingLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.GreetingLabel.Name = "GreetingLabel";
            this.GreetingLabel.Size = new System.Drawing.Size(315, 57);
            this.GreetingLabel.TabIndex = 1;
            this.GreetingLabel.Text = "simple notes.";
            // 
            // TickTimer
            // 
            this.TickTimer.Enabled = true;
            this.TickTimer.Interval = 1500;
            this.TickTimer.Tick += new System.EventHandler(this.TickTimer_Tick);
            // 
            // EmojiLabel
            // 
            this.EmojiLabel.AutoSize = true;
            this.EmojiLabel.Font = new System.Drawing.Font("SF Pro Display", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EmojiLabel.Location = new System.Drawing.Point(586, 110);
            this.EmojiLabel.Name = "EmojiLabel";
            this.EmojiLabel.Size = new System.Drawing.Size(165, 115);
            this.EmojiLabel.TabIndex = 2;
            this.EmojiLabel.Text = "👌";
            // 
            // NextLabel
            // 
            this.NextLabel.AutoSize = true;
            this.NextLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextLabel.Font = new System.Drawing.Font("SF Pro Display", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NextLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.NextLabel.Location = new System.Drawing.Point(50, 214);
            this.NextLabel.Name = "NextLabel";
            this.NextLabel.Size = new System.Drawing.Size(92, 76);
            this.NextLabel.TabIndex = 3;
            this.NextLabel.Text = "→";
            this.NextLabel.Click += new System.EventHandler(this.NextLabel_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.NextLabel);
            this.Controls.Add(this.EmojiLabel);
            this.Controls.Add(this.GreetingLabel);
            this.Controls.Add(this.WelcomeLabel);
            this.Font = new System.Drawing.Font("SF Pro Display", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "Welcome";
            this.Size = new System.Drawing.Size(800, 400);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Welcome_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label WelcomeLabel;
        private Label GreetingLabel;
        private System.Windows.Forms.Timer TickTimer;
        private Label EmojiLabel;
        private Label NextLabel;
    }
}
