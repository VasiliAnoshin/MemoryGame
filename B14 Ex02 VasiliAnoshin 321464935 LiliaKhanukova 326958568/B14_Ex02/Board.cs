namespace B14_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Board
    {
           private int     m_NumberOfRows = 0;
           private int     m_NumberOfColumns = 0;
           private Cell[,] m_NumberOfCells   = null;
           private char[]  m_Letters  = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'Q', 'K', 'L', 'M',
                                            'N', 'O', 'P', 'R', 'S', 'W' };
           public Board(int i_Rows, int i_Columns)
           {
               m_NumberOfColumns = i_Columns;
               m_NumberOfRows = i_Rows;
               m_NumberOfCells = new Cell[m_NumberOfRows, m_NumberOfColumns];
               PositionsCells();
           }
           public Cell[ , ] GetCell 
            {
                get { return m_NumberOfCells; }            
            }
           public Cell RecieveCell(int i_Row, int i_Column) 
            {
                return m_NumberOfCells[i_Row, i_Column];
            } 
           public int GetRows
            {
                get { return m_NumberOfRows; }
            }
           public int GetColumns 
            {
                get { return m_NumberOfColumns; }
            }
           private List<char> fillArrayOfRequiredLetters(int i_NumberOfRequiredLetters)
            {
                List<char> usableLetters = new List<char>();

                for (int i = 0, j = 0; i < (GetColumns * GetRows) / 2; i++, j++)
                {
                    usableLetters.Add(m_Letters[j]);
                    usableLetters.Add(m_Letters[j]);
                }

                return usableLetters;
            }
           public void PositionsCells() {
                Random randNumberGenerator = new Random();
                List<Char> usableLetters = fillArrayOfRequiredLetters((GetColumns * GetRows) / 2);

                for (int i = 0; i < GetRows; i++)
                {
                    for (int j = 0; j < GetColumns; j++)
                    {
                        int index = randNumberGenerator.Next(0, usableLetters.Count);
                        GetCell[i, j] = new Cell(usableLetters[index], i, j);
                        usableLetters.Remove(usableLetters[index]);
                    }
                }
            }                
        }   
    }
