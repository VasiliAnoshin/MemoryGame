namespace B14_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Text;
   
    public class Player
    {
        private string m_Name;
        private int    m_Score;
        private bool   m_Turn;
        public bool Turn
        {
            get { return m_Turn; }
            set { m_Turn = value; }
        }    
        public Player(string i_name) 
        {
            this.m_Name = i_name;
            this.m_Score = 0;
        }
        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
        public string GetPlayerName 
        {
            get { return this.m_Name; }
        }
    }  
}
