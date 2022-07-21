namespace Echelon
{
    partial class Home
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.GreetingLabel = new System.Windows.Forms.Label();
            this.NewNoteButton = new System.Windows.Forms.Button();
            this.AllNotesButton = new System.Windows.Forms.Button();
            this.LockLabel = new System.Windows.Forms.Label();
            this.BackgroundLockTimer = new System.Windows.Forms.Timer(this.components);
            this.ManualLockTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Font = new System.Drawing.Font("SF Pro Display", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NameLabel.Location = new System.Drawing.Point(27, 59);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(721, 66);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "{greeting}, {name}";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GreetingLabel
            // 
            this.GreetingLabel.Font = new System.Drawing.Font("SF Pro Display", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GreetingLabel.Location = new System.Drawing.Point(111, 122);
            this.GreetingLabel.Name = "GreetingLabel";
            this.GreetingLabel.Size = new System.Drawing.Size(637, 48);
            this.GreetingLabel.TabIndex = 3;
            this.GreetingLabel.Text = "What are we creating today?";
            this.GreetingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NewNoteButton
            // 
            this.NewNoteButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.NewNoteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewNoteButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.NewNoteButton.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NewNoteButton.ForeColor = System.Drawing.Color.White;
            this.NewNoteButton.Location = new System.Drawing.Point(286, 270);
            this.NewNoteButton.Name = "NewNoteButton";
            this.NewNoteButton.Size = new System.Drawing.Size(237, 47);
            this.NewNoteButton.TabIndex = 4;
            this.NewNoteButton.Text = "Make a brand-new note";
            this.NewNoteButton.UseVisualStyleBackColor = false;
            this.NewNoteButton.Click += new System.EventHandler(this.NewNoteButton_Click);
            // 
            // AllNotesButton
            // 
            this.AllNotesButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.AllNotesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AllNotesButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AllNotesButton.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AllNotesButton.ForeColor = System.Drawing.Color.White;
            this.AllNotesButton.Location = new System.Drawing.Point(529, 270);
            this.AllNotesButton.Name = "AllNotesButton";
            this.AllNotesButton.Size = new System.Drawing.Size(219, 47);
            this.AllNotesButton.TabIndex = 5;
            this.AllNotesButton.Text = "Open existing notes  →";
            this.AllNotesButton.UseVisualStyleBackColor = false;
            this.AllNotesButton.Click += new System.EventHandler(this.AllNotesButton_Click);
            // 
            // LockLabel
            // 
            this.LockLabel.AutoSize = true;
            this.LockLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LockLabel.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LockLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LockLabel.Location = new System.Drawing.Point(27, 27);
            this.LockLabel.Name = "LockLabel";
            this.LockLabel.Size = new System.Drawing.Size(47, 32);
            this.LockLabel.TabIndex = 6;
            this.LockLabel.Text = "🔓";
            this.LockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LockLabel.Click += new System.EventHandler(this.LockLabel_Click);
            // 
            // BackgroundLockTimer
            // 
            this.BackgroundLockTimer.Enabled = true;
            this.BackgroundLockTimer.Interval = 30000;
            this.BackgroundLockTimer.Tick += new System.EventHandler(this.BackgroundLockTimer_Tick);
            // 
            // ManualLockTimer
            // 
            this.ManualLockTimer.Interval = 800;
            this.ManualLockTimer.Tick += new System.EventHandler(this.ManualLockTimer_Tick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.LockLabel);
            this.Controls.Add(this.AllNotesButton);
            this.Controls.Add(this.NewNoteButton);
            this.Controls.Add(this.GreetingLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(800, 400);
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label NameLabel;
        private Label GreetingLabel;
        private Button NewNoteButton;
        private Button AllNotesButton;
        private Label LockLabel;
        private System.Windows.Forms.Timer BackgroundLockTimer;
        private System.Windows.Forms.Timer ManualLockTimer;
    }
}
