using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris.Blocks
{
    /// <summary>
    /// Z block
    /// </summary>
    public class Z_block:Box
    {
        public int Id()
        { return id = 7; }

        public Z_block()
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
            Id();
        }
    }
    
}
