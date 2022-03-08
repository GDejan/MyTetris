using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTetris
{
 
    class Settings
    {
        public static int pixelWidth { get; set; }
        public static int pixelHeight { get; set; }
        public static int blockSpeed { get; set; }
        public static int Total { get; set; }
        public static bool gameOver { get; set; }
        public static int StartX { get; set; }
        public static int StartY { get; set; }
        public static int windowWidth { get; set; }
        public static int windowHeight { get; set; }

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
        }
    }
    class Input
    {
        private static Hashtable keyTable = new Hashtable();
        public static bool Keyboard(Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }
            return (bool)keyTable[key];
        }
        public static void Pressed(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}
