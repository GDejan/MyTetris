using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris
{
    public class IBlock : Box
    {
        public int[,] ArrayBox() 
        {
            BoxArray[0, 0] = 0;
            BoxArray[0, 1] = 1;
            BoxArray[0, 2] = 0;
            BoxArray[1, 0] = 0;
            BoxArray[1, 1] = 1;
            BoxArray[1, 2] = 0;
            BoxArray[2, 0] = 0;
            BoxArray[2, 1] = 1;
            BoxArray[2, 2] = 0;
            return BoxArray;
        }
        public int Id()
            { return id=1; }
    }

    public class JBlock : Box
    {
        public int[,] ArrayBox()
        {
            BoxArray[0, 0] = 0;
            BoxArray[0, 1] = 1;
            BoxArray[0, 2] = 0;
            BoxArray[1, 0] = 0;
            BoxArray[1, 1] = 1;
            BoxArray[1, 2] = 0;
            BoxArray[2, 0] = 1;
            BoxArray[2, 1] = 1;
            BoxArray[2, 2] = 0;
            return BoxArray;
        }
        public int Id()
        { return id = 2; }
    }
    public class LBlock : Box
    {
        public int[,] ArrayBox()
        {
            BoxArray[0, 0] = 0;
            BoxArray[0, 1] = 1;
            BoxArray[0, 2] = 0;
            BoxArray[1, 0] = 0;
            BoxArray[1, 1] = 1;
            BoxArray[1, 2] = 0;
            BoxArray[2, 0] = 0;
            BoxArray[2, 1] = 1;
            BoxArray[2, 2] = 1;
            return BoxArray;
        }
        public int Id()
        { return id = 3; }
    }
    public class TBlock : Box
    {
        public int[,] ArrayBox()
        {
            BoxArray[0, 0] = 0;
            BoxArray[0, 1] = 0;
            BoxArray[0, 2] = 0;
            BoxArray[1, 0] = 0;
            BoxArray[1, 1] = 1;
            BoxArray[1, 2] = 0;
            BoxArray[2, 0] = 1;
            BoxArray[2, 1] = 1;
            BoxArray[2, 2] = 1;
            return BoxArray;
        }
        public int Id()
        { return id = 4; }
    }
    public class OBlock : Box
    {
        public int[,] ArrayBox()
        {
            BoxArray[0, 0] = 0;
            BoxArray[0, 1] = 1;
            BoxArray[0, 2] = 1;
            BoxArray[1, 0] = 0;
            BoxArray[1, 1] = 1;
            BoxArray[1, 2] = 1;
            BoxArray[2, 0] = 0;
            BoxArray[2, 1] = 0;
            BoxArray[2, 2] = 0;
            return BoxArray;
        }
        public int Id()
        { return id = 5; }

        public override int[,] Rotate() 
        {
            return BoxArray;
        }
    }
    public class SBlock : Box
    {
        public int[,] ArrayBox()
        {
            BoxArray[0, 0] = 0;
            BoxArray[0, 1] = 1;
            BoxArray[0, 2] = 1;
            BoxArray[1, 0] = 0;
            BoxArray[1, 1] = 1;
            BoxArray[1, 2] = 0;
            BoxArray[2, 0] = 1;
            BoxArray[2, 1] = 1;
            BoxArray[2, 2] = 0;
            return BoxArray;
        }
        public int Id()
        { return id = 6; }
    }
    public class ZBlock : Box
    {
        public int[,] ArrayBox()
        {
            BoxArray[0, 0] = 1;
            BoxArray[0, 1] = 1;
            BoxArray[0, 2] = 0;
            BoxArray[1, 0] = 0;
            BoxArray[1, 1] = 1;
            BoxArray[1, 2] = 0;
            BoxArray[2, 0] = 0;
            BoxArray[2, 1] = 1;
            BoxArray[2, 2] = 1;
            return BoxArray;
        }
        public int Id()
        { return id = 7; }
    }
    public class XBlock : Box
    {
        public int[,] ArrayBox()
        {
            BoxArray[0, 0] = 0;
            BoxArray[0, 1] = 1;
            BoxArray[0, 2] = 0;
            BoxArray[1, 0] = 1;
            BoxArray[1, 1] = 1;
            BoxArray[1, 2] = 1;
            BoxArray[2, 0] = 0;
            BoxArray[2, 1] = 1;
            BoxArray[2, 2] = 0;
            return BoxArray;
        }
        public int Id()
        { return id = 8; }
    }
}