using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using B14_Ex02;
using System.Threading;
using System.Collections;

namespace B14_Ex05
{
    public partial class MemoryGame : Form
    {
        private const int  k_FormHeight = 260;
        private const int  k_FormWidth  = 440;
        private const int  k_ButtonSize = 80;
        private int        m_RowsOFCells;
        private int        m_ColumnsOfCells;
        private Control[,] m_FormArrayOfControls;        
        Label              m_CurPlayer    = null;
        Label              m_FirstPlayer  = null;
        Label              m_SecondPlayer = null;
        Controll           m_Game;
        Cell               m_FirstCell  = null;
        Cell               m_SecondCell = null;
        eCellChoice        m_UserChoice;
        bool               m_isTurnChanged = false;
        bool               m_VersusComputer;
        private List<Cell> m_BufferForTimeCoordinates;
        private ArrayList  m_PoolOfCells;
        ArrayList          m_ListOfRandomCoordinates;
        Cell               m_CoordinateA;
        Cell               m_CoordinateB;
        private readonly Color k_DefaultControlColor = Color.Khaki;

        public MemoryGame(int i_Rows, int i_Columns, string i_FirstPlayer, 
            string i_SecondPlayer, bool i_VersusComputer)
        {
            m_RowsOFCells = i_Rows;
            m_ColumnsOfCells = i_Columns;
            m_UserChoice = eCellChoice.FirstChoice;
            this.Size = new Size(110 * i_Columns, 110 * i_Rows + 150);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.AutoSize = true;
            InitializeComponent();
            m_Game = new Controll(i_FirstPlayer, i_SecondPlayer, i_Rows, i_Columns, i_VersusComputer);
            CreateArrayOfCoordinates();
            m_FormArrayOfControls = new Control[m_RowsOFCells, m_ColumnsOfCells];
            m_VersusComputer = i_VersusComputer;
            ShowDialog();
        }
        private void memoryGame_Load(object sender, EventArgs e)
        {
            addControlsToTheForm();
        }
        private void addControlsToTheForm()
        {
            int startHeight = 20;
            int startWidthPosition;

            for (int i = 0; i < m_RowsOFCells; i++)
            {
                startWidthPosition = 10;
                for (int j = 0; j < m_ColumnsOfCells; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(k_ButtonSize, k_ButtonSize);
                    button.Location = new Point(startWidthPosition, startHeight);
                    button.AutoSize = true;
                    button.BackColor = k_DefaultControlColor;
                    startWidthPosition += 10 + button.Width;
                    m_FormArrayOfControls[i, j] = button;
                    this.Controls.Add(button);
                    button.Click += new EventHandler(button_Click);
                    m_Game.Board.GetCell[i, j].OpenCellInVisibleMode += DoVisiableCell;
                }

                startHeight += 10 + m_FormArrayOfControls[0, 0].Height;
            }

            startWidthPosition = 10;
            m_CurPlayer = new Label();
            m_FirstPlayer = new Label();
            m_SecondPlayer = new Label();
            labelFormLocation(m_CurPlayer, startWidthPosition, ref startHeight);
            this.Controls.Add(m_CurPlayer);
            labelFormLocation(m_FirstPlayer, startWidthPosition, ref startHeight);
            labelFormLocation(m_SecondPlayer, startWidthPosition, ref startHeight);
            UpdateLabels(m_Game.CurrentPlayer, m_Game.FirstPlayer, m_Game.SecondPlayer);
        }
        private void labelFormLocation(Label i_Label, int i_StartWidth, 
            ref int io_StartHeight)
        {
            i_Label.Location = new Point(i_StartWidth, io_StartHeight);
            i_Label.AutoSize = true;
            io_StartHeight += 20;
            this.Controls.Add(i_Label);
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (!m_Game.GameOver())
            {
                Cell cell = null;
                if (!m_Game.SecondPlayer.Turn)
                {
                    cell = getCell((Control)sender);
                }
                else if (m_Game.SecondPlayer.Turn && m_VersusComputer == true)
                {
                    m_ListOfRandomCoordinates = ChooseRandomCell();
                    m_CoordinateA = (Cell)m_ListOfRandomCoordinates[0];
                    cell = m_Game.Board.GetCell[m_CoordinateA.RowLocation, m_CoordinateA.ColumnLocation];
                }

                switch (m_UserChoice)
                {
                    case eCellChoice.FirstChoice:
                        if (m_Game.FirstPlayer.Turn)
                        {
                            m_FirstCell = cell;
                            m_FirstCell.IsVisible = true;
                        }
                        else if (m_Game.SecondPlayer.Turn && m_VersusComputer == false)
                        {
                            m_FirstCell = getCell((Control)sender);
                            m_FirstCell.IsVisible = true;
                        }
                        else
                        {
                            m_FirstCell = cell;
                            m_FirstCell.IsVisible = true;
                            m_FormArrayOfControls[m_FirstCell.RowLocation, m_FirstCell.ColumnLocation].Update();
                            Thread.Sleep(400);
                        }
                        m_UserChoice = eCellChoice.SecondChoice;
                        break;
                    case eCellChoice.SecondChoice:
                        if (m_Game.FirstPlayer.Turn)
                        {
                            m_SecondCell = getCell((Control)sender);
                            m_SecondCell.IsVisible = true;
                        }
                        else if (m_Game.SecondPlayer.Turn && m_VersusComputer == false)
                        {
                            m_SecondCell = getCell((Control)sender);
                            m_SecondCell.IsVisible = true;
                        }
                        else
                        {
                            m_CoordinateB = (Cell)m_ListOfRandomCoordinates[0];
                            m_SecondCell = m_Game.Board.GetCell[m_CoordinateB.RowLocation, m_CoordinateB.ColumnLocation];
                            m_SecondCell.IsVisible = true;
                        }

                        m_FormArrayOfControls[m_SecondCell.RowLocation, m_SecondCell.ColumnLocation].Update();
                        Thread.Sleep(400);
                        m_UserChoice = eCellChoice.FirstChoice;
                        if (m_Game.FirstPlayer.Turn)
                        {
                            m_isTurnChanged = m_Game.StartGame(m_Game.FirstPlayer, m_FirstCell, m_SecondCell);
                            changeButtonStatus(m_isTurnChanged);
                            UpdateArrayOfTimeCoordinatesChanged();
                        }
                        else
                        {
                            m_isTurnChanged = m_Game.StartGame(m_Game.SecondPlayer, m_FirstCell, m_SecondCell);
                            if (m_VersusComputer == true && m_isTurnChanged)
                            {
                                ComputerGuessWrong(m_Game.Board, m_CoordinateA, m_CoordinateB);
                                m_PoolOfCells.Add(m_FirstCell);
                                m_PoolOfCells.Add(m_SecondCell);
                            }
                            else
                            {
                                UpdateArrayOfTimeCoordinatesChanged();
                            }

                            changeButtonStatus(m_isTurnChanged);
                        }

                        m_FormArrayOfControls[m_SecondCell.RowLocation, m_SecondCell.ColumnLocation].Update();
                        break;
                }

                UpdateLabels(m_Game.CurrentPlayer, m_Game.FirstPlayer, m_Game.SecondPlayer);                
                if (m_Game.SecondPlayer.Turn && m_VersusComputer == true)
                {
                    m_CurPlayer.Update();
                    m_SecondPlayer.Update();
                    button_Click(sender, e);
                }
            }
        }
        public void UpdateArrayOfTimeCoordinatesChanged()
        {
            if (!m_isTurnChanged && m_VersusComputer == true)
            {
                while (m_PoolOfCells.Contains(m_FirstCell))
                {
                    if (m_Game.Board.RecieveCell(m_FirstCell.RowLocation, m_FirstCell.ColumnLocation).IsVisible)
                    {
                        m_PoolOfCells.Remove(m_FirstCell);
                        break;
                    }
                }

                while (m_PoolOfCells.Contains(m_SecondCell))
                {
                    if (m_Game.Board.RecieveCell(m_SecondCell.RowLocation, m_SecondCell.ColumnLocation).IsVisible)
                    {
                        m_PoolOfCells.Remove(m_SecondCell);
                        break;
                    }
                }
            }

        }    
        private void changeButtonStatus(bool i_Status)
        {
            Thread.Sleep(400);

            if (i_Status == true)
            {
                m_FormArrayOfControls[m_FirstCell.RowLocation, m_FirstCell.ColumnLocation].Text = "";
                m_FormArrayOfControls[m_SecondCell.RowLocation, m_SecondCell.ColumnLocation].Text = "";
                m_FormArrayOfControls[m_FirstCell.RowLocation, m_FirstCell.ColumnLocation].BackColor = k_DefaultControlColor;
                m_FormArrayOfControls[m_SecondCell.RowLocation, m_SecondCell.ColumnLocation].BackColor = k_DefaultControlColor;
                m_FormArrayOfControls[m_FirstCell.RowLocation, m_FirstCell.ColumnLocation].Enabled = true;
                m_FormArrayOfControls[m_SecondCell.RowLocation, m_SecondCell.ColumnLocation].Enabled = true;
                m_FirstCell.IsVisible = false;
                m_SecondCell.IsVisible = false;
            }
        }
        private Cell getCell(Control i_ChosedCell)
        {
            for (int row = 0; row < m_Game.Board.GetRows; row++)
            {
                for (int col = 0; col < m_Game.Board.GetColumns; col++)
                {
                    if (m_FormArrayOfControls[row, col].Equals(i_ChosedCell))
                    {
                        return m_Game.Board.GetCell[row, col];
                    }
                }
            }

            return null;
        }
        public void UpdateLabels(Player i_CurPlayer, Player i_FirstPlayer, 
            Player i_SecondPlayer)
        {
            Player curPlayer = i_CurPlayer;

            if (curPlayer == null)
            {
                curPlayer = i_FirstPlayer;
            }
            if (curPlayer == i_FirstPlayer)
            {
                m_CurPlayer.BackColor = Color.Blue;
            }
            else
            {
                m_CurPlayer.BackColor = Color.Green;
            }

            m_Game.CurrentPlayer = curPlayer;
            m_CurPlayer.Text = String.Format("Current player : {0}", curPlayer.GetPlayerName);
            m_FirstPlayer.Text = String.Format(@"{0} Score : {1}", i_FirstPlayer.GetPlayerName, i_FirstPlayer.Score);
            m_FirstPlayer.BackColor = Color.Blue;
            m_SecondPlayer.Text = String.Format(@"{0} Score : {1}", i_SecondPlayer.GetPlayerName, i_SecondPlayer.Score);
            m_SecondPlayer.BackColor = Color.Green;
        }
        public void DoVisiableCell(object sender, EventArgs e)
        {
            Cell cell = (Cell)sender;

            if (cell.IsVisible)
            {
                if (m_Game.FirstPlayer.Turn)
                {
                    m_FormArrayOfControls[cell.RowLocation, cell.ColumnLocation].Text = cell.GetLetter.ToString();
                    m_FormArrayOfControls[cell.RowLocation, cell.ColumnLocation].BackColor = Color.Blue;
                    m_FormArrayOfControls[cell.RowLocation, cell.ColumnLocation].Enabled = false;
                }
                if (m_Game.SecondPlayer.Turn)
                {
                    m_FormArrayOfControls[cell.RowLocation, cell.ColumnLocation].Text = cell.GetLetter.ToString();
                    m_FormArrayOfControls[cell.RowLocation, cell.ColumnLocation].BackColor = Color.Green;
                    m_FormArrayOfControls[cell.RowLocation, cell.ColumnLocation].Enabled = false;
                }

            }
        }
        public ArrayList ChooseRandomCell()
        {
            ArrayList list = new ArrayList();
            int indexOfRandomCoordinate = 0;
            m_BufferForTimeCoordinates = new List<Cell>();
            Random randNumberGenerator = new Random();
            Cell Coordinate = null;

            indexOfRandomCoordinate = randNumberGenerator.Next(0, m_PoolOfCells.Count);
            Coordinate = (Cell)m_PoolOfCells[indexOfRandomCoordinate];
            m_BufferForTimeCoordinates.Add(Coordinate);
            list.Add(Coordinate);
            m_PoolOfCells.Remove(Coordinate);
            
            return list;
        }
        public void CreateArrayOfCoordinates()
        {
            Cell boardCoordinates;
            m_PoolOfCells = new ArrayList();

            for (int i = 0; i < m_Game.Board.GetRows; i++)
            {
                for (int j = 0; j < m_Game.Board.GetColumns; j++)
                {
                    boardCoordinates = m_Game.Board.GetCell[i, j];
                    m_PoolOfCells.Add(boardCoordinates);
                }
            }
        }
        public void ComputerGuessWrong(Board io_Board, Cell io_CoordinateA, Cell io_CoordinateB)
        {
            io_Board.GetCell[io_CoordinateA.RowLocation, io_CoordinateB.ColumnLocation].CardFace = false;
            io_Board.GetCell[io_CoordinateB.RowLocation, io_CoordinateB.ColumnLocation].CardFace = false;
        }
    }
}