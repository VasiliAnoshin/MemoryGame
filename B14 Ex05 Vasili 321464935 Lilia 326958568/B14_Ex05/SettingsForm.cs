using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace B14_Ex05
{
    public partial class SettingsForm : Form
    {
        private readonly List<string> m_BoardSizes = new List<string>() {"4x4", "4x5", "4x6", "5x4", "5x6", "6x4", "6x5", "6x6"};
        private int m_Index = 1;
        public SettingsForm()
        {
            InitializeComponent();
            ShowDialog();
        }
        private void againstFriendButton_Click(object sender, EventArgs e)
        {
            if (SecondPlayerNameTextBox.Text == "- computer -")
            {
                SecondPlayerNameTextBox.Enabled = true;
                SecondPlayerNameTextBox.Text = "";
            }
            else
            {
                SecondPlayerNameTextBox.Text = "- computer -";
                SecondPlayerNameTextBox.Enabled = false;
            }
        }
        private void boardSizeButton_Click(object sender, EventArgs e)
        {
            if (m_Index < m_BoardSizes.Count)
            {
                BoardSizeButton.Text = m_BoardSizes[m_Index];
                m_Index++;
            }
            else
            {
                m_Index = 0;
                BoardSizeButton.Text = m_BoardSizes[m_Index];
                m_Index++;
            }
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MemoryGame Game = new MemoryGame(GetNumOfRows(), GetNumOfColumns(), FirstPlayerNameTextBox.Text, SecondPlayerNameTextBox.Text, !SecondPlayerNameTextBox.Enabled);
            this.Show();
        }
        protected int GetNumOfRows()
        {
            int Rows = Convert.ToInt32(BoardSizeButton.Text[0]-48);

            return Rows;
        }
        protected int GetNumOfColumns()
        {
            int Columns = Convert.ToInt32(BoardSizeButton.Text[2]-48);

            return Columns;
        }
    }
}
