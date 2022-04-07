using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris.Blocks
{
    /// <summary>
    /// X block
    /// </summary>
    public class X_block:Box
    {
        public int Id()
        { return id = 8; }

        public X_block()
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
            Id();
        }
    }
}
