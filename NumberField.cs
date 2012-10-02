using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace SudokuSolver
{
    class NumberField : TextBox
    {
        private int _X, _Y;
        private System.Text.RegularExpressions.Regex Regex = new System.Text.RegularExpressions.Regex("^[1-9]?$");

        public int X
        {
            get { return _X; }
            set { _X = value; }
        }
        public int Y
        {
            get { return _Y; }
            set { _Y = value; }
        }

        public NumberField(int y, int x, Point location) : base()
        {
            _X = x;
            _Y = y;
            Size = new Size(20, 20);

            int X_POS = 23 * x + location.X;
            int Y_POS = 23 * y + location.Y;
            if (x >= 3)
                X_POS += 10;
            if (x >= 6)
                X_POS += 10;
            if (y >= 3)
                Y_POS += 10;
            if (y >= 6)
                Y_POS += 10;
            Location = new Point(X_POS, Y_POS);
            TextAlign = HorizontalAlignment.Center;
            Validating += ValidateInput;
        }

        private void ValidateInput(object sender, CancelEventArgs arg)
        {
            if (!Regex.IsMatch(this.Text))
            {
                arg.Cancel = true;
                MessageBox.Show("Only [1-9] digit can be written here!");
            }
        }
    }
}
