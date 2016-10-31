
namespace B14_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public delegate void ChechWhenCellIsVisibleEventHandler(object sender, EventArgs e);
    public class Cell
    {
        private char m_Letter;
        private bool m_CardOnFace;        
        int          m_RowLocation;        
        int          m_ColumnLocation;     
        private bool m_Visible;
        public event ChechWhenCellIsVisibleEventHandler OpenCellInVisibleMode;
        
        public Cell(char i_Letter, int i_Row, int i_Column) 
        {
            m_RowLocation     = i_Row;
            m_ColumnLocation  = i_Column;
            this.m_CardOnFace = false;
            m_Letter          = i_Letter;
        }
        public bool IsVisible
        {
            get 
            {
                return m_Visible;
            }
            set 
            {
                m_Visible = value;
                OpenCellValue();
            }
        }        
        public char GetLetter 
        {
            get { return this.m_Letter; }
        }
        public bool CardFace
        {
            get { return m_CardOnFace; }
            set { m_CardOnFace = value; }
        }
        private void OpenCellValue()
        {
            if (OpenCellInVisibleMode != null)
            {
                OpenCellInVisibleMode.Invoke(this, null);
            }
        }
        public bool CardOnFace
        {
            get { return m_CardOnFace; }
            set { m_CardOnFace = value; }
        }
        public int ColumnLocation
        {
            get { return m_ColumnLocation; }
            set { m_ColumnLocation = value; }
        }
        public int RowLocation
        {
            get { return m_RowLocation; }
            set { m_RowLocation = value; }
        }
    }
}

