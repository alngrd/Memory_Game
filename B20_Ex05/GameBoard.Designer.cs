using System.Drawing;
using System.Windows.Forms;

namespace B20_Ex05
{
    partial class GameBoard
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
        private void initializeComponent(GameSettings i_Settings)
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "GameBoard";
            this.Text = "GameBoard";
            this.ResumeLayout(false);
            this.Controls.Add(CurrentPlayerLabel);
            this.Controls.Add(Player1Label);
            this.Controls.Add(Player2Label);
            setFormStartPosition();
            initializeButtons();
            initializeScoresAndCurrentPlayer(i_Settings);
            this.Player1Label.AutoSize = true;
            this.Player2Label.AutoSize = true;
            this.CurrentPlayerLabel.AutoSize = true;
            setAndLockFormSize();
        }

        private void setFormStartPosition()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Left = 10;
            this.Top = 10;
        }

        private void setAndLockFormSize()
        {
            this.Width = (this.m_CardButtons.GetLength(1) * k_CardEdgeLength) + ((this.m_CardButtons.GetLength(1) + 2) * k_CardMargin);
            this.Height = (this.m_CardButtons.GetLength(0) * k_CardEdgeLength) + ((this.m_CardButtons.GetLength(0) + 8) * k_CardMargin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void initializeButtons()
        {
            int leftPosition = k_CardMargin;
            int topPosition = k_CardMargin;
            CardButton newCard;

            for (int i = 0; i < this.m_CardButtons.GetLength(0); i++)
            {
                for (int j = 0; j < this.m_CardButtons.GetLength(1); j++)
                {
                    newCard = new CardButton(i, j);
                    newCard.Click += onButtonClick;
                    newCard.TabStop = false;
                    newCard.Width = k_CardEdgeLength;
                    newCard.Height = k_CardEdgeLength;
                    newCard.Left = leftPosition;
                    newCard.Top = topPosition;
                    newCard.FlatAppearance.BorderSize = 3;
                    newCard.FlatStyle = FlatStyle.Flat;
                    newCard.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
                    newCard.BackColor = SystemColors.ControlLight;
                    newCard.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
                    m_CardButtons[i, j] = newCard;
                    this.Controls.Add(newCard);
                    leftPosition += k_CardMargin + k_CardEdgeLength;
                }

                leftPosition = k_CardMargin;
                topPosition += k_CardMargin + k_CardEdgeLength;
            }
        }

        private void initializeScoresAndCurrentPlayer(GameSettings i_Settings)
        {
            CurrentPlayerLabel.Width += 100;
            Player1Label.Width += 100;
            Player2Label.Width += 100;
            CurrentPlayerLabel.Top = (this.m_CardButtons.GetLength(0) * k_CardEdgeLength) + ((this.m_CardButtons.GetLength(0) + 1) * k_CardMargin);
            updateCurrentPlayerLabel();
            Player1Label.Top = CurrentPlayerLabel.Bottom + 5;
            Player2Label.Top = Player1Label.Bottom + 5;
            updateScores();
            Player1Label.BackColor = this.r_Player1Color;
            Player2Label.BackColor = this.r_Player2Color;
        }

        private void updateScores()
        {
            if (this.m_CurrentGame.Players[0].Score == 1)
            {
                Player1Label.Text = this.m_CurrentGame.Players[0].Name + ": " + this.m_CurrentGame.Players[0].Score + " Pair";
            }
            else
            {
                Player1Label.Text = this.m_CurrentGame.Players[0].Name + ": " + this.m_CurrentGame.Players[0].Score + " Pairs";
            }

            if (this.m_CurrentGame.Players[1].Score == 1)
            {
                Player2Label.Text = this.m_CurrentGame.Players[1].Name + ": " + this.m_CurrentGame.Players[1].Score + " Pair";
            }
            else
            {
                Player2Label.Text = this.m_CurrentGame.Players[1].Name + ": " + this.m_CurrentGame.Players[1].Score + " Pairs";
            }

            Application.DoEvents();
        }

        private void updateCurrentPlayerLabel()
        {
            CurrentPlayerLabel.Text = "Current Player: " + this.m_CurrentPlayer.Name;
            if (this.m_CurrentPlayer.Equals(this.m_CurrentGame.Players[0]))
            {
                CurrentPlayerLabel.BackColor = this.r_Player1Color;
            }
            else
            {
                CurrentPlayerLabel.BackColor = this.r_Player2Color;
            }

            Application.DoEvents();
        }
        #endregion

        private System.Windows.Forms.Label CurrentPlayerLabel = new Label();
        private System.Windows.Forms.Label Player1Label = new Label();
        private System.Windows.Forms.Label Player2Label = new Label();
        private const int k_CardEdgeLength = 70;
        private const int k_CardMargin = 20;
        private readonly Color r_Player1Color = Color.PaleGreen;
        private readonly Color r_Player2Color = Color.MediumPurple;
    }
}