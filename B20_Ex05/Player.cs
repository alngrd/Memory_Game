using System;

namespace B20_Ex05
{
    internal class Player
    {
        private readonly String r_Name;
        private int m_Score;
        private readonly bool rv_IsHuman;

        internal Player(String i_Name, bool i_IsHuman)
        {
            this.r_Name = i_Name;
            this.m_Score = 0;
            this.rv_IsHuman = i_IsHuman;
        }

        internal int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

        internal string Name
        {
            get
            {
                return r_Name;
            }
        }

        internal bool IsHuman
        {
            get
            {
                return rv_IsHuman;
            }
        }
    }
}