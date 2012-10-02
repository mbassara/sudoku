using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class MainWindow : Form
    {
        private Button StartButton;
        private Button ClearButton;
        private NumberFieldsTable table;

        public MainWindow()
        {
            InitializeComponent();
            MyInitialization();
        }
        public void MyInitialization()
        {
            Size = new Size(400, 300);
            table = new NumberFieldsTable(Controls, new Point(25, 25));

            StartButton = new Button();
            StartButton.Text = "START";
            StartButton.Location = new Point(275, 50);
            StartButton.Click += StartButtonClicked;
            
            ClearButton = new Button();
            ClearButton.Text = "CLEAR";
            ClearButton.Location = new Point(275, 90);
            ClearButton.Click += ClearButtonClicked;

            Controls.Add(StartButton);
            Controls.Add(ClearButton);
        }

        public static void Main()
        {
            Application.Run(new MainWindow());
        }

        private void StartButtonClicked(object sender, EventArgs arg)
        {
            if (table != null)
            {
                if (table.SetTable(SolvingUtilities.Solve(table.GetTable())))
                    MessageBox.Show("success!!!");
                else
                    MessageBox.Show("failure!!!");
            }
        }

        private void ClearButtonClicked(object sender, EventArgs arg)
        {
            if (table != null)
                table.Clear();
        }
    }
}
