using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace SudokuSolver
{
    class NumberFieldsTable
    {
        private readonly int SIZE = 9;
        private NumberField[,] Fields;

        public NumberFieldsTable(Control.ControlCollection Controls, Point location)
        {
            Fields = new NumberField[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                {
                    Fields[i, j] = new NumberField(i, j, location);
                    Controls.Add(Fields[i, j]);
                }
        }

        public int[,] GetTable()
        {
            int[,] tab = new int[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    if (Fields[i, j].TextLength == 0)
                        tab[i, j] = 0;
                    else
                    {
                        tab[i, j] = Convert.ToInt32(Fields[i, j].Text);
                        Fields[i, j].BackColor = Color.LightGray;
                    }

            return tab;
        }

        public bool SetTable(int[,] NewTable)
        {
            if (NewTable == null || NewTable.Length != SIZE * SIZE)
                return false;
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    if (NewTable[i, j] > 9 || NewTable[i, j] < 1)
                        return false;

            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    this.Fields[i, j].Text = NewTable[i, j].ToString();

            return true;
        }

        public void Clear()
        {
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                {
                    Fields[i, j].Text = "";
                    Fields[i, j].BackColor = Color.White;
                }
        }
    }
}
