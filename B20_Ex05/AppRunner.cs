using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B20_Ex05
{
    class AppRunner
    {
        private GameBoard m_CurrentBoardDialog;
        private GameSettings m_Settings;

        internal void RunGame()
        {
            setGame();
            this.m_CurrentBoardDialog = new GameBoard(this.m_Settings);
            while (this.m_CurrentBoardDialog.WantsAnotherGame)
            {
                this.m_CurrentBoardDialog = new GameBoard(this.m_Settings);
            }
        }

        private void setGame()
        {
            this.m_Settings = new GameSettings();
            this.m_Settings.ShowDialog();
        }
    }
}