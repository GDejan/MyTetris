using MyTetris.Blocks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTetris
{
    internal class gameState
    {
        public gameState()
        {

        }

        public void startGame (List<Box> BlockList, int[,] GridArray)
        {
            Settings.gameOver = false;
            Array.Clear(GridArray, 0, GridArray.Length);

            Settings.Lmax = false;
            Settings.Rmax = false;
            Settings.Dmax = false;
            Settings.Umax = false;

            BlockList.Add(new I_block());
            BlockList.Add(new J_block());
            BlockList.Add(new L_block());
            BlockList.Add(new O_block());
            BlockList.Add(new S_block());
            BlockList.Add(new T_block());
            BlockList.Add(new X_block());
            BlockList.Add(new Z_block());

        }

        public void Collision()
        {
            Settings.gameOver = true;
        }

    }
}
