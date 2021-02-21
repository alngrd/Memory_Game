using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace B20_Ex05
{
    internal class CardButton : Button
    {
        int m_X;
        int m_Y;
        bool m_IsOpen;

        public CardButton(int i_X, int i_Y) : base()
        {
            this.m_IsOpen = false;
            this.m_X = i_X;
            this.m_Y = i_Y;
        }

        public bool IsOpen
        {
            get
            {
                return this.m_IsOpen;
            }
        }
        public int X
        {
            get
            {
                return this.m_X;
            }
        }

        public int Y
        {
            get
            {
                return this.m_Y;
            }
        }

    }

    public partial class GameBoard : Form
    {
        private CardButton[,] m_CardButtons;
        private Game m_CurrentGame;
        private int m_AmountOfTotalClicks;
        private CardIndex m_FirstChosenCard;
        private Player m_CurrentPlayer;
        private Player m_NextPlayer;
        private bool m_GameIncludesComputerPlayer;
        private bool m_WantsAnotherGame = true;
        private Dictionary<char, Image> m_ImagesDictionary;
        private PictureBox m_PictureBox;
        private const string k_Url = "https://picsum.photos/80";

        internal bool WantsAnotherGame
        {
            get
            {
                return this.m_WantsAnotherGame;
            }
        }

        public GameBoard(GameSettings i_Settings)
        {
            int numberOfRows = 0;
            int numberOfColumns = 0;

            initGame(i_Settings);
            numberOfRows = m_CurrentGame.CurrentBoard.NumberOfRows;
            numberOfColumns = m_CurrentGame.CurrentBoard.NumberOfColumns;
            m_CardButtons = new CardButton[numberOfRows, numberOfColumns];
            this.m_AmountOfTotalClicks = 0;
            this.m_CurrentPlayer = this.m_CurrentGame.Players[0];
            this.m_NextPlayer = this.m_CurrentGame.Players[1];
            this.m_PictureBox = new PictureBox();
            getImagesAndInitializeImageDictionary(numberOfRows * numberOfColumns / 2);

            initializeComponent(i_Settings);
            this.ShowDialog();
            endGameSequence();
        }

        private void initGame(GameSettings i_SettingsForm)
        {
            int numberOfRowsInBoard = 0;
            int numberOfColumnsInBoard = 0;

            parseBoardSize(i_SettingsForm.BoardSize, out numberOfRowsInBoard, out numberOfColumnsInBoard);
            if (i_SettingsForm.SecondPlayerName.Equals("-Computer-"))
            {
                this.m_CurrentGame = new Game(numberOfRowsInBoard, numberOfColumnsInBoard, i_SettingsForm.FirstPlayerName);
                this.m_GameIncludesComputerPlayer = true;
            }
            else
            {
                this.m_CurrentGame = new Game(numberOfRowsInBoard, numberOfColumnsInBoard, i_SettingsForm.FirstPlayerName, i_SettingsForm.SecondPlayerName);
                this.m_GameIncludesComputerPlayer = false;
            }
        }

        private void parseBoardSize(string i_BoardSizeInput, out int o_NumberOfRows, out int o_NumberOfColumns)
        {
            o_NumberOfRows = i_BoardSizeInput[0] - 48;
            o_NumberOfColumns = i_BoardSizeInput[2] - 48;
        }

        private void getImagesAndInitializeImageDictionary(int i_AmountOfImagesToGet)
        {
            this.m_ImagesDictionary = new Dictionary<char, Image>();
            Image tempImage;

            while (i_AmountOfImagesToGet > 0)
            {
                tempImage = downloadImage();
                while (this.m_ImagesDictionary.ContainsValue(tempImage))
                {
                    tempImage = downloadImage();
                }

                this.m_ImagesDictionary.Add((char)(i_AmountOfImagesToGet + 64), tempImage);
                i_AmountOfImagesToGet--;
            }
        }

        private Image downloadImage()
        {
            this.m_PictureBox.Load(k_Url);
            return (Bitmap)m_PictureBox.Image;
        }

        private void onButtonClick(object sender, EventArgs e)
        {
            if (this.m_CurrentPlayer.IsHuman && (sender as CardButton).Text.Equals(""))
            {
                CardIndex currentCardIndex = new CardIndex((sender as CardButton).X, (sender as CardButton).Y);
                char valueOnCard = this.m_CurrentGame.FlipUpCard(currentCardIndex);

                showValueOnButton(sender as CardButton, valueOnCard);
                this.m_AmountOfTotalClicks++;
                syncDataToCompterLogic(currentCardIndex, valueOnCard);
                //Enters only if first chosen card of pair
                if (this.m_AmountOfTotalClicks % 2 == 1)
                {
                    this.m_FirstChosenCard = currentCardIndex;
                }
                else
                {
                    secondCardChosenSequence(currentCardIndex, valueOnCard);
                }
            }
        }

        private void showValueOnButton(CardButton i_CurrentButton, char i_ValueOnCard)
        {
            i_CurrentButton.Enabled = false;
            this.m_ImagesDictionary.TryGetValue(i_ValueOnCard, out Image tempImage);
            i_CurrentButton.BackgroundImage = tempImage;
            changeButtonBackColorByPlayer(i_CurrentButton);
        }

        private void changeButtonBackColorByPlayer(CardButton i_CurrentCardButton)
        {
            i_CurrentCardButton.FlatAppearance.BorderColor = this.m_CurrentPlayer.Equals(this.m_CurrentGame.Players[0]) ? this.r_Player1Color : this.r_Player2Color;
            Application.DoEvents();
        }

        private void secondCardChosenSequence(CardIndex i_CurrentCardIndex, char i_ValueOnCard)
        {
            Image valueOnFirstCard = valueOnFirstCard = (this.m_CardButtons[this.m_FirstChosenCard.Row, this.m_FirstChosenCard.Column]).BackgroundImage;
            Image valueOnSecondCard = valueOnFirstCard = (this.m_CardButtons[i_CurrentCardIndex.Row, i_CurrentCardIndex.Column]).BackgroundImage; ;

            valueOnFirstCard = (this.m_CardButtons[this.m_FirstChosenCard.Row, this.m_FirstChosenCard.Column]).BackgroundImage;
            if (!valueOnSecondCard.Equals(valueOnFirstCard))
            {
                swapCurrentPlayer();
                System.Threading.Thread.Sleep(500);
                flipBothCardsDownSequence(i_CurrentCardIndex);
                playComputerTurnIfHisTurn();
            }
            else
            {
                if (this.m_GameIncludesComputerPlayer)
                {
                    this.m_CurrentGame.Computer.RemovePairFromStack(i_ValueOnCard);
                }

                this.m_CurrentPlayer.Score++;
                updateScores();
            }

            if (this.m_CurrentGame.CurrentBoard.IsFull())
            {
                System.Threading.Thread.Sleep(400);
                this.Close();
            }
        }

        private void endGameSequence()
        {
            int player1Score = this.m_CurrentGame.Players[0].Score;
            int player2Score = this.m_CurrentGame.Players[1].Score;
            string player1Name = this.m_CurrentGame.Players[0].Name;
            string player2Name = this.m_CurrentGame.Players[1].Name;
            StringBuilder endMessage = new StringBuilder();
            DialogResult dialogResult;
            const bool v_WantAnotherGame = true;

            if (this.m_CurrentGame.CurrentBoard.IsFull())
            {
                if (player1Score > player2Score)
                {
                    endMessage.Append(String.Format("The winner is {0} with {1} pairs", player1Name, player1Score) + System.Environment.NewLine);
                    endMessage.Append(String.Format("The sore loser is {0} with {1} pairs", player2Name, player2Score) + System.Environment.NewLine);
                }
                else if (player1Score < player2Score)
                {
                    endMessage.Append(String.Format("The winner is {0} with {1} pairs", player2Name, player2Score) + System.Environment.NewLine);
                    endMessage.Append(String.Format("The sore loser is {0} with {1} pairs", player1Name, player1Score) + System.Environment.NewLine);
                }
                else
                {
                    endMessage.Append(String.Format("It's a tie so everyone wins with {0} pairs", player2Score) + System.Environment.NewLine);
                }

                endMessage.Append(System.Environment.NewLine + "Would you like to play again?");
                dialogResult = MessageBox.Show(endMessage.ToString(), "The Memory Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                this.m_WantsAnotherGame = (dialogResult == DialogResult.Yes) ? v_WantAnotherGame : !v_WantAnotherGame;
            }
            else
            {
                this.m_WantsAnotherGame = !v_WantAnotherGame;
            }

            this.Close();
        }

        private void flipBothCardsDownSequence(CardIndex i_CurrentCardIndex)
        {
            this.m_CurrentGame.FlipDownCard(i_CurrentCardIndex);
            this.m_CurrentGame.FlipDownCard(this.m_FirstChosenCard);
            this.m_CardButtons[this.m_FirstChosenCard.Row, this.m_FirstChosenCard.Column].Enabled = true;
            this.m_CardButtons[this.m_FirstChosenCard.Row, this.m_FirstChosenCard.Column].BackgroundImage = null;
            this.m_CardButtons[this.m_FirstChosenCard.Row, this.m_FirstChosenCard.Column].FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            this.m_CardButtons[i_CurrentCardIndex.Row, i_CurrentCardIndex.Column].Enabled = true;
            this.m_CardButtons[i_CurrentCardIndex.Row, i_CurrentCardIndex.Column].BackgroundImage = null;
            this.m_CardButtons[i_CurrentCardIndex.Row, i_CurrentCardIndex.Column].FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            Application.DoEvents();
        }

        private void swapCurrentPlayer()
        {
            Player tempPlayer = this.m_NextPlayer;

            this.m_NextPlayer = this.m_CurrentPlayer;
            this.m_CurrentPlayer = tempPlayer;
            updateCurrentPlayerLabel();
        }

        private void playComputerTurnIfHisTurn()
        {
            while (!this.m_CurrentPlayer.IsHuman && !this.m_CurrentGame.CurrentBoard.IsFull())
            {
                computerTurn();
            }
        }

        /**
        * If needed, activates the update of the computer player's memory.
        **/
        private void syncDataToCompterLogic(CardIndex i_ChosenCard, char i_OnChosenCard)
        {
            if (this.m_GameIncludesComputerPlayer)
            {
                this.m_CurrentGame.Computer.SyncDataToCompterLogic(i_ChosenCard, i_OnChosenCard);
            }
        }

        private void computerTurn()
        {
            CardIndex secondChosenCardIndex;
            char onFirstCard;
            char onSecondCard;
            //Computer chooses first card
            CardIndex firstChosenCardIndex = this.m_CurrentGame.Computer.ChooseFirstCard(this.m_CurrentGame.CurrentBoard);

            onFirstCard = computerChoseSequence(firstChosenCardIndex);
            syncDataToCompterLogic(firstChosenCardIndex, onFirstCard);
            this.m_CurrentGame.Computer.UpdateFirstCardValue(onFirstCard);
            this.m_FirstChosenCard = firstChosenCardIndex;

            //Computer chooses second card
            secondChosenCardIndex = this.m_CurrentGame.Computer.ChooseSecondCard(this.m_CurrentGame.CurrentBoard);
            onSecondCard = computerChoseSequence(secondChosenCardIndex);

            secondCardChosenSequence(secondChosenCardIndex, onSecondCard);
        }

        /*
         * Shows the card on button and syncs with the computer memory
         */
        private char computerChoseSequence(CardIndex i_CardChosen)
        {
            char onCard = this.m_CurrentGame.FlipUpCard(i_CardChosen);

            showValueOnButton(this.m_CardButtons[i_CardChosen.Row, i_CardChosen.Column], onCard);
            syncDataToCompterLogic(i_CardChosen, onCard);
            System.Threading.Thread.Sleep(500);
            return onCard;
        }
    }
}