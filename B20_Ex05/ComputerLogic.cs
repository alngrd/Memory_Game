using System;
using System.Collections.Generic;

namespace B20_Ex05
{
    internal class ComputerLogic
    {
        private Dictionary<char, CardIndex[]> m_BoardMemory;
        public Stack<char> m_KnownPairs;
        private CardIndex m_PrevChoseCardIndex;
        private CardIndex m_CardToChooseNext;
        private char m_OnPrevChosenCard;

        internal ComputerLogic()
        {
            m_BoardMemory = new Dictionary<Char, CardIndex[]>();
            m_KnownPairs = new Stack<char>();
            m_PrevChoseCardIndex = null;
            m_CardToChooseNext = null;
        }

        /**
        * Updates class data structures to contain the info of the last flipped card.
        **/
        internal void SyncDataToCompterLogic(CardIndex i_ChosenCardLocation, char i_OnCard)
        {
            CardIndex[] locationsOnBoard = new CardIndex[2];

            if (m_BoardMemory.ContainsKey(i_OnCard))
            {
                if (m_BoardMemory.TryGetValue(i_OnCard, out locationsOnBoard))
                {
                    if (!locationsOnBoard[0].Equals(i_ChosenCardLocation))
                    {
                        locationsOnBoard[1] = i_ChosenCardLocation;
                        m_KnownPairs.Push(i_OnCard);
                    }
                }
            }
            else
            {
                locationsOnBoard[0] = i_ChosenCardLocation;
                m_BoardMemory.Add(i_OnCard, locationsOnBoard);
            }
        }

        internal void RemovePairFromStack(char i_PairValueToRemove)
        {
            Stack<char> tempStack = new Stack<char>();
            char tempValue;

            while (this.m_KnownPairs.Count != 0)
            {
                tempValue = this.m_KnownPairs.Pop();
                if (tempValue != i_PairValueToRemove)
                {
                    tempStack.Push(tempValue);
                }
            }

            while (tempStack.Count != 0)
            {
                this.m_KnownPairs.Push(tempStack.Pop());
            }
        }

        /**
       * Chooses first card according to the current info in data structures:
       * if there is a known pair in the stack- flips the first card in the pair.
       * else- flips the first card on the board that hasn't been flipped yet.
       **/
        internal CardIndex ChooseFirstCard(Board i_CurrentBoard)
        {
            CardIndex chosenCardIndex = null;

            if (m_KnownPairs.Count == 0)
            {
                for (int row = 0; row < i_CurrentBoard.NumberOfRows; row++)
                {
                    for (int column = 0; column < i_CurrentBoard.NumberOfColumns; column++)
                    {
                        if (i_CurrentBoard.IsLegalCardIndex(row, column) && CheckIfCardWasPrevioslyFlipped(row, column))
                        {
                            chosenCardIndex = new CardIndex(row, column);
                            m_PrevChoseCardIndex = chosenCardIndex;
                            break;
                        }
                    }

                    if (chosenCardIndex != null)
                    {
                        break;
                    }
                }
            }
            else
            {
                char charValueToFlip = m_KnownPairs.Pop();
                CardIndex[] cardLocations;

                m_BoardMemory.TryGetValue(charValueToFlip, out cardLocations);
                m_CardToChooseNext = cardLocations[1];
                chosenCardIndex = cardLocations[0];
            }

            return chosenCardIndex;
        }

        /**
        * Chooses second card according to the current info in the data structures including info of first card's flip.
        **/
        internal CardIndex ChooseSecondCard(Board i_CurrentBoard)
        {
            CardIndex secondCardChoise = null;
            CardIndex[] locationsOnBoard = new CardIndex[2];

            if (m_CardToChooseNext != null)
            {
                secondCardChoise = m_CardToChooseNext;
                m_CardToChooseNext = null;
            }
            else if (m_BoardMemory.TryGetValue(m_OnPrevChosenCard, out locationsOnBoard) && (locationsOnBoard[1] != null))
            {
                if (!locationsOnBoard[0].Equals(m_PrevChoseCardIndex))
                {
                    secondCardChoise = locationsOnBoard[0];
                    m_KnownPairs.Pop();
                }
            }

            return (secondCardChoise == null) ? ChooseFirstCard(i_CurrentBoard) : secondCardChoise;
        }

        /**
        * Checks if a specific card is already known to copmuter memory
        **/
        internal bool CheckIfCardWasPrevioslyFlipped(int i_Row, int i_Column)
        {
            CardIndex toCheckIfWasFlipped = new CardIndex(i_Row, i_Column);
            bool answer = true;

            foreach (KeyValuePair<char, CardIndex[]> cardUnit in m_BoardMemory)
            {
                answer &= !(cardUnit.Value[0].Equals(toCheckIfWasFlipped) || (cardUnit.Value[1] != null && cardUnit.Value[1].Equals(toCheckIfWasFlipped)));
            }

            return answer;
        }

        internal void UpdateFirstCardValue(char i_ValueOnCard)
        {
            m_OnPrevChosenCard = i_ValueOnCard;
        }
    }
}