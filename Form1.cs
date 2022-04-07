using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using MyTetris.Blocks;

namespace MyTetris
{
    public partial class Form1 : Form
    {

        int count = 0;

        int[,] GridArray = new int[16, 26];
        int[,] TempArray = new int[16, 26];

        List<Box> BlockList = new List<Box>();
        Box Block = new Box();
        gameState gameState=new gameState();
        Grid Grid = new Grid();

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            new Settings();

            timer.Interval = 500 / Settings.blockSpeed;
            timer.Tick += readInput;
            timer.Tick += moveBlockTick;
            timer.Start();

            Settings.maxXpos = gameWindow.Size.Width / Settings.pixelWidth;
            Settings.maxYpos = gameWindow.Size.Height / Settings.pixelHeight;
            gameState.startGame(BlockList,GridArray);
            newBlock();

            Total.Visible = true;
            GameOwer.Visible = false;
            
        }

        private void moveBlockTick(object sender, EventArgs e)
        {
            count++;
            if (count == 2)
            {
                count = 0;
                moveBlock();
            }

        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            Input.Pressed(e.KeyCode, true);

        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            Input.Pressed(e.KeyCode, false);
        }


        private void readInput(object sender, EventArgs e)
        {
            if (Input.Keyboard(Keys.Escape))
            {
                Close();
            }
            if (Settings.gameOver == true)
            {

                string gameOver = "Game Over\n" + "Total is: " + Settings.Total + "\nEnter to Restart";
                GameOwer.Text = gameOver;
                GameOwer.Visible = true;
                Total.Visible = false;

                if (Input.Keyboard(Keys.Enter))
                {
                    gameState.startGame(BlockList, GridArray);
                    Total.Visible = true;
                    GameOwer.Visible = false;
                }
            }
            else
            {
                if (Input.Keyboard(Keys.Right) && !Settings.Rmax)
                {
                    Block.x = Block.x + Settings.pixelWidth;
                }
                if (Input.Keyboard(Keys.Left) && !Settings.Lmax)
                {
                    Block.x = Block.x - Settings.pixelWidth;
                }

                if (Input.Keyboard(Keys.Up))
                {
                    Block.Rotate();
                }

            }
            Total.Text = "Total " + Settings.Total.ToString();

            gameWindow.Invalidate();
        }

        private void newBlock()
        {
            Random random = new Random();
            switch (Settings.Total)
            {
                case int expression when (Settings.Total >= 0 && Settings.Total <= 10):
                    Block = BlockList[random.Next(0, 5)];
                    break;

                case int expression when (Settings.Total > 10 && Settings.Total <= 20):
                    Block = BlockList[random.Next(0, 8)];
                    break;

                case int expression when (Settings.Total > 20):
                    Block = BlockList[random.Next(5, 8)];
                    break;

                default:
                    Block = BlockList[0];
                    break;
            }

            Block.x = Settings.StartX;
            Block.y = Settings.StartY;
            Block.Rotate(); //back to initial position

        }

        private void moveBlock()
        {
            Settings.Lmax = false;
            Settings.Rmax = false;
            Settings.Dmax = false;
            Settings.Umax = false;


            Array.Clear(TempArray, 0, TempArray.Length);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Block.BoxArray[i, j] > 0)
                    {
                        int TempArrayX = (Block.x + (Settings.pixelWidth * j)) / Settings.pixelWidth;
                        int TempArrayY = (Block.y + (Settings.pixelWidth * i)) / Settings.pixelHeight;

                        if (TempArrayX <= 0) TempArrayX = 0;
                        if (TempArrayY <= 0) TempArrayY = 0;
                        TempArray[TempArrayX, TempArrayY] = Block.id;
                    }
                }
            }


            for (int i = 0; i < Settings.maxXpos; i++) 
            {
                for (int j = 0; j < Settings.maxYpos; j++) 
                {

                    if ((TempArray[0, j] > 0) || ((TempArray[i, j] > 0) && GridArray[i - 1, j] > 0) || ((TempArray[i, j] > 0) && GridArray[i - 1, j + 1] > 0))
                    {
                        Settings.Lmax = true;
                    }

                    if ((TempArray[Settings.maxXpos - 1, j] > 0) || ((TempArray[i, j] > 0) && GridArray[i + 1, j] > 0) || ((TempArray[i, j] > 0) && GridArray[i + 1, j + 1] > 0)) 
                    {
                        Settings.Rmax = true;
                    }

                    if ((TempArray[i, Settings.maxYpos - 1] > 0) || ((TempArray[i, j] > 0) && GridArray[i, j + 1] > 0)) //22
                    {
                        Settings.Dmax = true;
                        if (Block.y <= 0)
                        {
                            gameState.Collision();
                        }
                    }
                }
            }

            if (!Settings.Dmax) // till blocked
            {
                Block.y = Block.y + Settings.pixelHeight;
            }
            else
            {
                Memorize();
                Grid.ClearRow(GridArray);
                newBlock();
            }
        }

        public void Memorize()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Block.BoxArray[i, j] > 0)
                    {
                        GridArray[(Block.x + (Settings.pixelWidth * j)) / Settings.pixelWidth, (Block.y + (Settings.pixelWidth * i)) / Settings.pixelHeight] = Block.id;
                    }
                }
            }

        }


        private void paintGraphics(object sender, PaintEventArgs e)
        {
            Graphics gameWindow = e.Graphics;

            if (Settings.gameOver == false)
            {
                //paiting curent block
                Brush Item;
                switch (Block.id)
                {
                    case 1:
                        Item = Brushes.Red;
                        break;
                    case 2:
                        Item = Brushes.Blue;
                        break;
                    case 3:
                        Item = Brushes.Yellow;
                        break;
                    case 4:
                        Item = Brushes.Green;
                        break;
                    case 5:
                        Item = Brushes.White;
                        break;
                    case 6:
                        Item = Brushes.Black;
                        break;
                    case 7:
                        Item = Brushes.Orange;
                        break;
                    case 8:
                        Item = Brushes.Pink;
                        break;
                    default:
                        Item = Brushes.Silver;
                        break;
                }

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Block.BoxArray[i, j] > 0)
                        {
                            gameWindow.FillRectangle(Item,
                            new Rectangle(Block.x + (Settings.pixelWidth * j) * Block.BoxArray[i, j],
                                          Block.y + (Settings.pixelWidth * i) * Block.BoxArray[i, j],
                                          Settings.pixelWidth, Settings.pixelHeight));
                        }
                    }
                }

                // pinting game grid
                for (int i = 0; i < Settings.maxXpos; i++) //15
                {
                    for (int j = 0; j < Settings.maxYpos; j++) //25
                    {
                        if (GridArray[i, j] > 0)
                        {
                            Brush Item1;
                            switch (GridArray[i, j])
                            {
                                case 1:
                                    Item1 = Brushes.Red;
                                    break;
                                case 2:
                                    Item1 = Brushes.Blue;
                                    break;
                                case 3:
                                    Item1 = Brushes.Yellow;
                                    break;
                                case 4:
                                    Item1 = Brushes.Green;
                                    break;
                                case 5:
                                    Item1 = Brushes.White;
                                    break;
                                case 6:
                                    Item1 = Brushes.Black;
                                    break;
                                case 7:
                                    Item1 = Brushes.Orange;
                                    break;
                                case 8:
                                    Item1 = Brushes.Pink;
                                    break;
                                default:
                                    Item1 = Brushes.Silver;
                                    break;
                            }

                            gameWindow.FillRectangle(Item1,
                            new Rectangle((Settings.pixelWidth * i),
                                           (Settings.pixelWidth * j),
                                            Settings.pixelWidth, Settings.pixelHeight));
                            
                        }
                    }
                }
            }
        }
    }
}
    