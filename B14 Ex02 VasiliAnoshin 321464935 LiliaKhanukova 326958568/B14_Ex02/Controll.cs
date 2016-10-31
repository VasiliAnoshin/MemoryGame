using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace B14_Ex02
{
    public class Controll
    {
        private Player m_FirstPlayer = null;
        private Player m_SecondPlayer = null;
        private Board  m_Board = null;
        private bool   m_VersusComputer;
        private Player m_CurrentPlayer;
        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
            set { m_CurrentPlayer = value; }
        }
        public Controll(string i_PlayerOne, string i_PlayerTwo, int i_NumberOfRows, 
            int NumberOfColumns, bool ComputerIsRiver)
        {
            this.m_FirstPlayer  = new Player(i_PlayerOne);
            m_FirstPlayer.Turn  = true;
            this.m_SecondPlayer = new Player(i_PlayerTwo);
            m_SecondPlayer.Turn = false;
            m_Board             = new Board(i_NumberOfRows, NumberOfColumns);
            m_VersusComputer    = ComputerIsRiver;          
        }
        public Board Board
        {
            get { return m_Board; }
            set { m_Board = value; }
        }
        public Player FirstPlayer
        {
            get { return m_FirstPlayer; }
            set { m_FirstPlayer = value; }
        }
        public Player SecondPlayer
        {
            get { return m_SecondPlayer; }
            set { m_SecondPlayer = value; }
        }
        public bool GameOver()
        {
            bool boardComplete = true;

            for (int i = 0; i < Board.GetRows; i++)
            {
                if (!boardComplete)
                {
                    break;
                }
                else
                {
                    for (int j = 0; j < Board.GetColumns; j++)
                    {
                        if (Board.GetCell[i, j].CardFace == false)
                        {
                            boardComplete = false;
                            break;
                        }
                    }
                }
            }

            return boardComplete;
        }
        public void RightGuess(Player io_CurrentPlayer, Board io_Board)
        {
            io_CurrentPlayer.Score += 1;
        }
        public Player NextPlayer(Player io_Next)
        {
            if (io_Next == FirstPlayer)
            {
                io_Next = SecondPlayer;
            }
            else
            {
                io_Next = FirstPlayer;
            }
            return io_Next;
        }
        public void SwitchCurrnetPlayerTurn(Player i_CurPlayer)
        {
            i_CurPlayer.Turn = false;
        }
        public Player WrongGuessForPlayer(Board io_Board, Player io_CurrentPlayer, 
            Cell i_FirstCell, Cell i_SecondCell)
        {
            SwitchCurrnetPlayerTurn(io_CurrentPlayer);
            io_CurrentPlayer = NextPlayer(io_CurrentPlayer);
            io_CurrentPlayer.Turn = true;
            Board.GetCell[i_FirstCell.RowLocation, i_FirstCell.ColumnLocation].CardFace = false;
            Board.GetCell[i_SecondCell.RowLocation, i_SecondCell.ColumnLocation].CardFace = false;
            return io_CurrentPlayer;
        }
        public void UserMove(Board io_Board, Cell i_Cell)
        {
            io_Board.GetCell[i_Cell.RowLocation, i_Cell.ColumnLocation].CardFace = true;
        }
        public bool StartGame(Player i_CurrentPlayer, Cell i_FirstChoiceCell, 
            Cell i_SecondChoice)
        {
            bool PlayerTurnchanged = false;
            m_CurrentPlayer = i_CurrentPlayer;

            if (!GameOver())
            {
                UserMove(m_Board, i_FirstChoiceCell);
                UserMove(m_Board, i_SecondChoice);
                if (Board.GetCell[i_FirstChoiceCell.RowLocation, i_FirstChoiceCell.ColumnLocation].GetLetter.Equals
                     (Board.GetCell[i_SecondChoice.RowLocation, i_SecondChoice.ColumnLocation].GetLetter))
                {
                    RightGuess(m_CurrentPlayer, m_Board);
                }
                else
                {
                    if (m_VersusComputer)
                    {
                        m_CurrentPlayer = WrongGuessForPlayer(m_Board, m_CurrentPlayer, i_FirstChoiceCell, i_SecondChoice);
                    }
                    else
                    {
                        m_CurrentPlayer = WrongGuessForPlayer(m_Board, m_CurrentPlayer, i_FirstChoiceCell, i_SecondChoice);
                    }

                    PlayerTurnchanged = true;
                }
            }
           
            return PlayerTurnchanged;
        }
        
    }
}

