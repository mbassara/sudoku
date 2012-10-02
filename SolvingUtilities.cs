using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    class SolvingUtilities
    {
        private static readonly int SIZE = 9;

        public static bool CheckIfSudokuOK(int[,] tab)
        {
            NumberChecker checker = new NumberChecker();

            // Checking rows
            for (int row = 0; row < SIZE; row++)
            {
                checker.Reset();
                for (int col = 0; col < SIZE; col++)
                    if (!checker.RegisterNumber(tab[row, col]))
                        return false;
            }

            // Checking cols
            for (int col = 0; col < SIZE; col++)
            {
                checker.Reset();
                for (int row = 0; row < SIZE; row++)
                    if (!checker.RegisterNumber(tab[row, col]))
                        return false;
            }

            // Checking squares
            for (int square = 0; square < SIZE; square++)
            {
                checker.Reset();
                for (int position = 0; position < SIZE; position++)
                    if (!checker.RegisterNumber(tab[(square / 3) * 3 + position / 3, (square % 3) * 3 + position % 3]))
                        return false;
            }


            return true;
        }

        public static bool IsNumberPossible(int[,] tab, int x, int y, int num)
        {
            // Checking row
            for (int i = 0; i < SIZE; i++)
                if (i != y && tab[x, i] == num)
                    return false;

            // Checking col
            for (int i = 0; i < SIZE; i++)
                if (i != x && tab[i, y] == num)
                    return false;

            // Checking square
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    int X = (x / 3) * 3 + i;
                    int Y = (y / 3) * 3 + j;
                    if (X != x && Y != y && tab[X, Y] == num)
                        return false;
                }

            return true;
        }

        public static int[,] Solve(int[,] tab)
        {
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    if(tab[i,j] > 0 && !IsNumberPossible(tab, i, j,tab[i,j]))
                        return null;

            if (SolveRecursive(tab, 0, 0))
                return tab;
            else
                return null;
        }

        private static bool SolveRecursive(int[,] tab, int x, int y)
        {
            if (x * 9 + y >= 9 * 9)
                return CheckIfSudokuOK(tab);

            if (tab[x, y] > 0)
                return SolveRecursive(tab, (y < 8) ? x : x + 1, (y + 1) % 9);

            bool result = false;
            bool ascending = new Random().Next(10000) % 2 == 0;
            if (ascending)
            {
                for (int i = 1; i < 10 && !result; i++)
                    if (IsNumberPossible(tab, x, y, i))
                    {
                        tab[x, y] = i;
                        result = SolveRecursive(tab, (y < 8) ? x : x + 1, (y + 1) % 9);
                    }

            }
            else
            {
                for (int i = 9; i > 0 && !result; i--)
                    if (IsNumberPossible(tab, x, y, i))
                    {
                        tab[x, y] = i;
                        result = SolveRecursive(tab, (y < 8) ? x : x + 1, (y + 1) % 9);
                    }
            }

            if (!result)
                tab[x, y] = 0;
            return result;
        }

        public static void Print(int[,] tab)
        {
            for (int col = 0; col < SIZE; col++)
            {
                String line = "";
                for (int row = 0; row < SIZE; row++)
                    line += tab[col, row] + ((row % 3 == 2) ? "    " : "  ");
                Console.WriteLine(line);
                if (col % 3 == 2)
                    Console.WriteLine();
            }

        }


        static void oldMain(string[] args)
        {
            int[,] tab1 = {
                             {0,1,0,0,0,8,4,0,7},
                             {9,5,0,0,0,0,0,3,0},
                             {0,0,8,0,1,0,0,0,0},
                             {0,8,2,0,0,0,0,0,0},
                             {7,0,0,4,0,6,0,0,8},
                             {0,0,0,0,0,0,6,2,0},
                             {0,0,0,0,5,0,7,0,0},
                             {0,0,0,0,0,0,0,8,2},
                             {5,0,3,2,0,0,0,1,0} };
            int[,] tab2 = {
                             {9,2,6,5,4,8,7,1,3},
                             {5,4,1,6,3,7,2,8,9},
                             {3,7,8,2,9,1,4,5,6},
                             {8,1,5,4,6,3,9,7,2},
                             {6,9,7,1,5,2,8,3,4},
                             {4,3,2,8,7,9,5,6,1},
                             {7,5,9,3,2,6,1,4,8},
                             {2,8,3,7,1,4,6,9,5},
                             {1,6,4,9,8,5,3,2,7} };

            if (Solve(tab1) != null)
                Print(tab1);
            else
                Console.WriteLine("nie da sie :(");

            Console.ReadLine();
        }
    }

    class NumberChecker
    {

        private bool[] tab;

        public NumberChecker()
        {
            tab = new bool[10];
            Reset();
        }

        public void Reset()
        {
            if (tab != null)
                for (int i = 0; i < tab.Length; i++)
                    tab[i] = true;
        }

        public bool RegisterNumber(int num)
        {
            bool result;
            if (num < tab.Length && num > 0)
            {
                result = tab[num];
                tab[num] = false;
            }
            else
                result = false;

            return result;
        }
    }
}
