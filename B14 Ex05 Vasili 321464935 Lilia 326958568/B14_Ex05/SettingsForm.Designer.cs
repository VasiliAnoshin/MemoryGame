namespace B14_Ex05
{
    partial class SettingsForm
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
            this.FirstPlayerNameLabel = new System.Windows.Forms.Label();
            this.SecondPlayerNameLabel = new System.Windows.Forms.Label();
            this.BoardSize = new System.Windows.Forms.Label();
            this.BoardSizeButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.FirstPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.SecondPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.AgainstAFriendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FirstPlayerNameLabel
            // 
            this.FirstPlayerNameLabel.AutoSize = true;
            this.FirstPlayerNameLabel.Location = new System.Drawing.Point(19, 23);
            this.FirstPlayerNameLabel.Name = "FirstPlayerNameLabel";
            this.FirstPlayerNameLabel.Size = new System.Drawing.Size(92, 13);
            this.FirstPlayerNameLabel.TabIndex = 0;
            this.FirstPlayerNameLabel.Text = "First Player Name:";
            // 
            // SecondPlayerNameLabel
            // 
            this.SecondPlayerNameLabel.AutoSize = true;
            this.SecondPlayerNameLabel.Location = new System.Drawing.Point(19, 51);
            this.SecondPlayerNameLabel.Name = "SecondPlayerNameLabel";
            this.SecondPlayerNameLabel.Size = new System.Drawing.Size(110, 13);
            this.SecondPlayerNameLabel.TabIndex = 1;
            this.SecondPlayerNameLabel.Text = "Second Player Name:";
            // 
            // BoardSize
            // 
            this.BoardSize.AutoSize = true;
            this.BoardSize.Location = new System.Drawing.Point(19, 94);
            this.BoardSize.Name = "BoardSize";
            this.BoardSize.Size = new System.Drawing.Size(61, 13);
            this.BoardSize.TabIndex = 2;
            this.BoardSize.Text = "Board Size:";
            // 
            // BoardSizeButton
            // 
            this.BoardSizeButton.BackColor = System.Drawing.Color.SlateBlue;
            this.BoardSizeButton.Location = new System.Drawing.Point(110, 94);
            this.BoardSizeButton.Name = "BoardSizeButton";
            this.BoardSizeButton.Size = new System.Drawing.Size(158, 68);
            this.BoardSizeButton.TabIndex = 3;
            this.BoardSizeButton.Text = "4x4";
            this.BoardSizeButton.UseVisualStyleBackColor = false;
            this.BoardSizeButton.Click += new System.EventHandler(this.boardSizeButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.LimeGreen;
            this.StartButton.Location = new System.Drawing.Point(307, 139);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(98, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // FirstPlayerNameTextBox
            // 
            this.FirstPlayerNameTextBox.Location = new System.Drawing.Point(147, 23);
            this.FirstPlayerNameTextBox.Name = "FirstPlayerNameTextBox";
            this.FirstPlayerNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.FirstPlayerNameTextBox.TabIndex = 5;
            // 
            // SecondPlayerNameTextBox
            // 
            this.SecondPlayerNameTextBox.Enabled = false;
            this.SecondPlayerNameTextBox.Location = new System.Drawing.Point(147, 48);
            this.SecondPlayerNameTextBox.Name = "SecondPlayerNameTextBox";
            this.SecondPlayerNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.SecondPlayerNameTextBox.TabIndex = 6;
            this.SecondPlayerNameTextBox.Text = "- computer -";
            // 
            // AgainstAFriendButton
            // 
            this.AgainstAFriendButton.Location = new System.Drawing.Point(290, 48);
            this.AgainstAFriendButton.Name = "AgainstAFriendButton";
            this.AgainstAFriendButton.Size = new System.Drawing.Size(115, 25);
            this.AgainstAFriendButton.TabIndex = 7;
            this.AgainstAFriendButton.Text = "Against a Friend";
            this.AgainstAFriendButton.UseVisualStyleBackColor = true;
            this.AgainstAFriendButton.Click += new System.EventHandler(this.againstFriendButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 178);
            this.Controls.Add(this.AgainstAFriendButton);
            this.Controls.Add(this.SecondPlayerNameTextBox);
            this.Controls.Add(this.FirstPlayerNameTextBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.BoardSizeButton);
            this.Controls.Add(this.BoardSize);
            this.Controls.Add(this.SecondPlayerNameLabel);
            this.Controls.Add(this.FirstPlayerNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FirstPlayerNameLabel;
        private System.Windows.Forms.Label SecondPlayerNameLabel;
        private System.Windows.Forms.Label BoardSize;
        private System.Windows.Forms.Button BoardSizeButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox FirstPlayerNameTextBox;
        private System.Windows.Forms.TextBox SecondPlayerNameTextBox;
        private System.Windows.Forms.Button AgainstAFriendButton;
    }
}