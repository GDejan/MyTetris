using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris.Blocks
{
    /// <summary>
    /// T block
    /// </summary>
    public class T_block:Box
    {
        public int Id()
        { return id = 4; }

        public T_block()
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
            Id();
        }
    }
}
