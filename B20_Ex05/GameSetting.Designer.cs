namespace B20_Ex05
{
    partial class GameSettings
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
            this.player1Name = new System.Windows.Forms.TextBox();
            this.player2Name = new System.Windows.Forms.TextBox();
            this.boardSize = new System.Windows.Forms.Button();
            this.playerVSComputer = new System.Windows.Forms.Button();
            this.labelFirstPlayerName = new System.Windows.Forms.Label();
            this.labelSecondPlayerName = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // player1Name
            // 
            this.player1Name.Location = new System.Drawing.Point(213, 29);
            this.player1Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(181, 26);
            this.player1Name.TabIndex = 0;
            this.player1Name.TextChanged += new System.EventHandler(this.player1Name_TextChanged);
            // 
            // player2Name
            // 
            this.player2Name.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.player2Name.Enabled = false;
            this.player2Name.Location = new System.Drawing.Point(213, 80);
            this.player2Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.player2Name.Name = "player2Name";
            this.player2Name.Size = new System.Drawing.Size(181, 26);
            this.player2Name.TabIndex = 1;
            this.player2Name.Text = "-Computer-";
            this.player2Name.TextChanged += new System.EventHandler(this.player2Name_TextChanged);
            // 
            // boardSize
            // 
            this.boardSize.BackColor = System.Drawing.Color.CornflowerBlue;
            this.boardSize.Location = new System.Drawing.Point(39, 168);
            this.boardSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.boardSize.Name = "boardSize";
            this.boardSize.Size = new System.Drawing.Size(165, 102);
            this.boardSize.TabIndex = 2;
            this.boardSize.Text = "4x4";
            this.boardSize.UseVisualStyleBackColor = false;
            this.boardSize.Click += new System.EventHandler(this.boardSize_Click);
            this.MaximizeBox = false;
            // 
            // playerVSComputer
            // 
            this.playerVSComputer.Location = new System.Drawing.Point(424, 80);
            this.playerVSComputer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.playerVSComputer.Name = "playerVSComputer";
            this.playerVSComputer.Size = new System.Drawing.Size(183, 35);
            this.playerVSComputer.TabIndex = 3;
            this.playerVSComputer.Text = "Against a Friend";
            this.playerVSComputer.UseVisualStyleBackColor = true;
            this.playerVSComputer.Click += new System.EventHandler(this.playerVSComputer_Click);
            // 
            // labelFirstPlayerName
            // 
            this.labelFirstPlayerName.AutoSize = true;
            this.labelFirstPlayerName.Location = new System.Drawing.Point(34, 29);
            this.labelFirstPlayerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFirstPlayerName.Name = "labelFirstPlayerName";
            this.labelFirstPlayerName.Size = new System.Drawing.Size(137, 20);
            this.labelFirstPlayerName.TabIndex = 4;
            this.labelFirstPlayerName.Text = "First Player Name:";
            this.labelFirstPlayerName.Click += new System.EventHandler(this.labelFirstPlayerName_Click);
            // 
            // labelSecondPlayerName
            // 
            this.labelSecondPlayerName.AutoSize = true;
            this.labelSecondPlayerName.Location = new System.Drawing.Point(34, 91);
            this.labelSecondPlayerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSecondPlayerName.Name = "labelSecondPlayerName";
            this.labelSecondPlayerName.Size = new System.Drawing.Size(161, 20);
            this.labelSecondPlayerName.TabIndex = 5;
            this.labelSecondPlayerName.Text = "Second Player Name:";
            this.labelSecondPlayerName.Click += new System.EventHandler(this.labelSecondPlayerName_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.LimeGreen;
            this.startButton.Location = new System.Drawing.Point(479, 232);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(128, 38);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(35, 143);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(91, 20);
            this.labelBoardSize.TabIndex = 7;
            this.labelBoardSize.Text = "Board Size:";
            this.labelBoardSize.Click += new System.EventHandler(this.labelBoardSize_Click);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 292);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.labelSecondPlayerName);
            this.Controls.Add(this.labelFirstPlayerName);
            this.Controls.Add(this.playerVSComputer);
            this.Controls.Add(this.boardSize);
            this.Controls.Add(this.player2Name);
            this.Controls.Add(this.player1Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(654, 348);
            this.MinimumSize = new System.Drawing.Size(654, 348);
            this.Name = "GameSettings";
            this.Text = "GameSettings";
            this.Load += new System.EventHandler(this.GameSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox player1Name;
        private System.Windows.Forms.TextBox player2Name;
        private System.Windows.Forms.Button boardSize;
        private System.Windows.Forms.Button playerVSComputer;
        private System.Windows.Forms.Label labelFirstPlayerName;
        private System.Windows.Forms.Label labelSecondPlayerName;
        private System.Windows.Forms.Button startButton;
        private readonly string[] m_BoardSizes = { "4x4", "4x5", "4x6", "5x4", "5x6", "6x4", "6x5", "6x6" };
        private static int m_BoardSizeNumberOfClicks = 0;
        private System.Windows.Forms.Label labelBoardSize;
    }
}