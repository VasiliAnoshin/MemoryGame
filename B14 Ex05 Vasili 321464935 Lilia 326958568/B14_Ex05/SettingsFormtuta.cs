using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace B14_Ex05
{
    public partial class SettingsFormtuta : Form
    {
        private const int k_Width = 114;
        private const int k_Height = 14;
        private readonly List<String> m_SizesOfBoard = new List<String>(new String[] { "4x4", "4x5", "4x6", "5x4", "5x6", "6x4", "6x5", "6x6" });
        int indexInBoardSizesList = 0;
        Label m_LabelFirstPlayerName = new Label();
        Label m_LabelSecondPlayerName = new Label();
        Label m_LabelBoardSize = new Label();
        TextBox m_TextBoxFirstPlayerName = new TextBox();
        TextBox m_TextBoxSecondPlayerName = new TextBox();
        Button m_ButtonStart = new Button();
        Button m_ButtonChooseBoardSize = new Button();
        Button m_buttonAgainstFriend = new Button();

        public SettingsFormtuta()
        {
            this.Size = new Size(355, 200);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.InitControls();
        }

        private void InitControls()
        {
            m_LabelFirstPlayerName.Text = "First Player Name:";
            m_LabelFirstPlayerName.Location = new Point(10, 10);
            m_LabelFirstPlayerName.Size = new Size(k_Width, k_Height);

            int TextBoxFirstPlayerNameTop = m_LabelFirstPlayerName.Top + m_LabelFirstPlayerName.Height / 2;
            TextBoxFirstPlayerNameTop -= m_TextBoxFirstPlayerName.Height / 2;

            m_TextBoxFirstPlayerName.Location = new Point(m_LabelFirstPlayerName.Right + 8, TextBoxFirstPlayerNameTop);

            m_LabelSecondPlayerName.Text = "Second Player Name:";
            m_LabelSecondPlayerName.Location = new Point(10, 40);
            m_LabelSecondPlayerName.Size = new Size(k_Width, k_Height);

            int TextBoxSecondPlayerNameTop = m_LabelSecondPlayerName.Top + m_LabelSecondPlayerName.Height / 2;
            TextBoxSecondPlayerNameTop -= m_TextBoxSecondPlayerName.Height / 2;

            m_TextBoxSecondPlayerName.Location = new Point(m_LabelSecondPlayerName.Right + 8, TextBoxSecondPlayerNameTop);
            m_TextBoxSecondPlayerName.Text = "-computer-";
            m_TextBoxSecondPlayerName.Enabled = false;

            m_LabelBoardSize.Text = "Board Size:";
            m_LabelBoardSize.Location = new Point(10, 73);
            m_LabelBoardSize.Size = new Size(k_Width, k_Height);

            m_ButtonChooseBoardSize.Location = new Point(10, m_LabelBoardSize.Bottom + 5);
            m_ButtonChooseBoardSize.Size = new Size(k_Width, m_LabelBoardSize.Bottom - m_LabelFirstPlayerName.Top);
            m_ButtonChooseBoardSize.BackColor = System.Drawing.Color.Aqua;
            m_ButtonChooseBoardSize.Text = "4x4";
            m_ButtonChooseBoardSize.Click += new EventHandler(m_ButtonChooseBoardSize_Click);

            m_buttonAgainstFriend.Location = new Point(m_TextBoxSecondPlayerName.Right + 5, TextBoxSecondPlayerNameTop);
            m_buttonAgainstFriend.Size = new Size(m_TextBoxSecondPlayerName.Width, m_TextBoxSecondPlayerName.Height);
            m_buttonAgainstFriend.Text = "Against a Friend";
            m_buttonAgainstFriend.Click += new EventHandler(m_TextBoxSecondPlayerName_Click);

            m_ButtonStart.Size = new Size(m_TextBoxSecondPlayerName.Width - 20, m_TextBoxSecondPlayerName.Height);
            m_ButtonStart.Location = new Point(m_buttonAgainstFriend.Right - m_ButtonStart.Width, m_ButtonChooseBoardSize.Bottom - m_ButtonStart.Height);
            m_ButtonStart.Text = "Start!";
            m_ButtonStart.BackColor = System.Drawing.Color.GreenYellow;
            m_ButtonStart.Click += new EventHandler(m_ButtonStart_Click);

            this.Controls.AddRange(new Control[] { this.m_LabelFirstPlayerName, this.m_LabelSecondPlayerName,
                                                   this.m_LabelBoardSize, this.m_TextBoxFirstPlayerName,
                                                   this.m_TextBoxSecondPlayerName, this.m_ButtonChooseBoardSize,
                                                   this. m_buttonAgainstFriend, m_ButtonStart });
            this.ShowDialog();
        }

        void m_TextBoxSecondPlayerName_Click(object sender, EventArgs e)
        {
            if (m_TextBoxSecondPlayerName.Enabled == false)
            {
                m_TextBoxSecondPlayerName.Enabled = true;
            }
            else
            {
                m_TextBoxSecondPlayerName.Text = "-computer-";
                m_TextBoxSecondPlayerName.Enabled = false;
            }
        }


        void m_ButtonChooseBoardSize_Click(object sender, EventArgs e)
        {
            if (indexInBoardSizesList < m_SizesOfBoard.Count - 1)
            {
                m_ButtonChooseBoardSize.Text = m_SizesOfBoard[++indexInBoardSizesList];
            }
            else
            {
                indexInBoardSizesList = 0;
                m_ButtonChooseBoardSize.Text = m_SizesOfBoard[indexInBoardSizesList];
            }
        }

        void m_ButtonStart_Click(object sender, EventArgs e)
        {
            MemoryGame newMemoryGame;
            this.Visible = false;
            switch (m_ButtonChooseBoardSize.Text)
            {
                case "4x4":
                    break;
                case "4x5":
                    break;
                case "4x6":
                    break;
                case "5x4":
                    break;
                case "5x6":
                    break;
                case "6x4":
                    break;
                case "6x5":
                    break;
                case "6x6":
                    break;
            }
          // newMemoryGame.ShowDialog();
        }
    }
}

