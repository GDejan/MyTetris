using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris
{
    internal class Grid
    {
        public Grid()
        {

        }

        private void MoveRow(int[,] GridArray, int row)
        {
            for (int j = row; j >= 1; j--)
            {
                for (int i = 0; i < Settings.maxXpos; i++)
                {
                    GridArray[i, j] = GridArray[i, j - 1];
                }
            }
            Settings.Total++;
        }

        public void ClearRow(int[,] GridArray)
        {
            for (int j = Settings.maxYpos - 1; j >= 0; j--) 
            {
                List<bool> rowClear = new List<bool>();
                rowClear.Clear();
                for (int i = 0; i < Settings.maxXpos; i++) 
                {
                    if (GridArray[i, j] != 0)
                    {
                        rowClear.Add(true);
                    }
                    else
                    {
                        rowClear.Add(false);
                    }
                }
                if (rowClear.All(x => x == true))
                {
                    MoveRow(GridArray, j);
                    j = Settings.maxYpos;
                }
            }
        }
    }
}
