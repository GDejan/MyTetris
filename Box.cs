using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris
{
    public class Box
    {
        public int x { get; set; }
        public int y { get; set; }
        public virtual int id { get; set; }
        public int[,] BoxArray = new int[3, 3];
        public Box NextBlock { get; private set; }

        public virtual int[,] Rotate()
        {
            int[,] result = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[j, i] = BoxArray[i, j];
                }
            }

            for (int k = 0; k < 3; k++)
            {
                BoxArray[k, 0] = result[k, 2];
                BoxArray[k, 1] = result[k, 1];
                BoxArray[k, 2] = result[k, 0];
            }

            return BoxArray;
        }

       
    }
}
