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

            IBlock Block1 = new IBlock();
            Block1.ArrayBox();
            Block1.Id();
            BlockList.Add(Block1);
            JBlock Block2 = new JBlock();
            Block2.ArrayBox();
            Block2.Id();
            BlockList.Add(Block2);
            LBlock Block3 = new LBlock();
            Block3.ArrayBox();
            Block3.Id();
            BlockList.Add(Block3);
            TBlock Block4 = new TBlock();
            Block4.ArrayBox();
            Block4.Id();
            BlockList.Add(Block4);
            OBlock Block5 = new OBlock();
            Block5.ArrayBox();
            Block5.Id();
            BlockList.Add(Block5);
            SBlock Block6 = new SBlock();
            Block6.ArrayBox();
            Block6.Id();
            BlockList.Add(Block6);
            ZBlock Block7 = new ZBlock();
            Block7.ArrayBox();
            Block7.Id();
            BlockList.Add(Block7);
            XBlock Block8 = new XBlock();
            Block8.ArrayBox();
            Block8.Id();
            BlockList.Add(Block8);

        }



        public void Collision()
        {
            Settings.gameOver = true;
        }

    }
}
