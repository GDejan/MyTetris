using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTetris
{
    /// <summary>
    /// helper class with game settings
    /// </summary>
    internal class Settings
    {
        public static int pixelWidth { get; private set; }
        public static int pixelHeight { get; private set; }
        public static int blockSpeed { get; private set; }
        public static int Total { get;  set; }
        public static bool gameOver { get; set; }
        public static int StartX { get; private set; }
        public static int StartY { get; private set; }
        public static int windowWidth { get; private set; }
        public static int windowHeight { get; private set; }
        public static int maxXpos  { get; set; }
        public static int maxYpos { get; set; }
        public static bool Lmax { get; set; }
        public static bool Rmax { get; set; }
        public static bool Dmax { get; set; }
        public static bool Umax { get; set; }

        public Settings()
        {
            pixelWidth = 25;
            pixelHeight = 25;
            blockSpeed = 5;
            Total = 0;
            StartX = 100;
            StartY= 0;
            gameOver = false;
            windowWidth = 325;
            windowHeight = 580;
            maxXpos = 0;
            maxYpos = 0;
            Lmax = false;
            Rmax = false;
            Dmax = false;
            Umax = false;
    }
    }
}
