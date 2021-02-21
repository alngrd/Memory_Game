using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace B20_Ex05
{
    public partial class GameSettings : Form
    {
        public GameSettings()
        {
            InitializeComponent();
        }

        internal String FirstPlayerName
        {
            get
            {
                return this.player1Name.Text;
            }
        }

        internal String SecondPlayerName
        {
            get
            {
                return this.player2Name.Text;
            }
        }

        internal String BoardSize
        {
            get
            {
                return this.boardSize.Text;
            }
        }

        private void boardSize_Click(object sender, EventArgs e)
        {
            m_BoardSizeNumberOfClicks++;
            this.boardSize.Text = m_BoardSizes[m_BoardSizeNumberOfClicks % 8];
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {

        }

        private void player2Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelFirstPlayerName_Click(object sender, EventArgs e)
        {

        }

        private void player1Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void playerVSComputer_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text.Equals("Against a Friend"))
            {
                (sender as Button).Text = ("Against Computer");
                player2Name.Enabled = true;
                player2Name.Text = "";
                player2Name.BackColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                (sender as Button).Text = ("Against a Friend");
                player2Name.Enabled = false;
                player2Name.Text = "-Computer-";
                player2Name.BackColor = Color.FromArgb(200, 200, 200);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelSecondPlayerName_Click(object sender, EventArgs e)
        {

        }

        private void labelBoardSize_Click(object sender, EventArgs e)
        {

        }
    }
}
