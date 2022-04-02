using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris
{
    /// <summary>
    /// I block
    /// </summary>
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

    /// <summary>
    /// J block
    /// </summary>
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

    /// <summary>
    /// L block
    /// </summary>
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

    /// <summary>
    /// T block
    /// </summary>
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

    /// <summary>
    /// O block
    /// </summary>
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

    /// <summary>
    /// S block
    /// </summary>
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

    /// <summary>
    /// Z block
    /// </summary>
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

    /// <summary>
    /// X block
    /// </summary>
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