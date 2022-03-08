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

namespace MyTetris
{
    public partial class Form1 : Form
    {
        public int maxXpos = 0;
        public int maxYpos = 0;
        public bool Lmax = false;
        public bool Rmax = false;
        public bool Dmax = false;
        public bool Umax = false;
        int[,] TempArray = new int[16,26];
        int count = 0;

        List <Box> BlockList = new List<Box>();

        public int[,] GridArray = new int[16, 26]; //new int[Settings.windowWidth / Settings.pixelWidth, Settings.windowHeight / Settings.windowHeight, 8];
        Box Block = new Box();

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            new Settings();

                timer.Interval = 1000 / Settings.blockSpeed;
                timer.Tick += updateScreen;
                timer.Start();

            maxXpos = gameWindow.Size.Width / Settings.pixelWidth;
            maxYpos = gameWindow.Size.Height / Settings.pixelHeight;
            startGame();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            Input.Pressed(e.KeyCode, true);
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            Input.Pressed(e.KeyCode, false);
        }

            
        private void updateScreen(object sender, EventArgs e)
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
                    startGame();
                }
            }
            else
            {
                if (Input.Keyboard(Keys.Right) && !Rmax)
                {
                    Block.x = Block.x + Settings.pixelWidth;
                }
                else if (Input.Keyboard(Keys.Left) && !Lmax)
                {
                    Block.x = Block.x - Settings.pixelWidth;
                }
                else if (Input.Keyboard(Keys.Up))
                {
                    Block.Rotate();
                }
                moveBlock();

            }
            gameWindow.Invalidate();
        }

        private void startGame()
        {
            Total.Visible = true;
            GameOwer.Visible = false;
            Total.Text = "Total " + Settings.Total.ToString();
            Settings.gameOver = false;
            Array.Clear(GridArray,0, GridArray.Length);

            Lmax = false;
            Rmax = false;
            Dmax = false;
            Umax = false;

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
            newBlock();

        }

        private void newBlock()
        {
            Random random = new Random();
            switch (Settings.Total)
            {
                case var expression when (Settings.Total >= 0 && Settings.Total <= 10):
                    Block = BlockList[random.Next(0, 5)];
                    break;

                case var expression when (Settings.Total > 10 && Settings.Total <= 20):
                    Block = BlockList[random.Next(0, 8)];
                    break;

                case var expression when (Settings.Total > 20):
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
            Lmax = false;
            Rmax = false;
            Dmax = false;
            Umax = false;

            Array.Clear(TempArray,0,TempArray.Length);
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


            for (int i = 0; i < maxXpos; i++) //16
            {
                for (int j = 0; j < maxYpos; j++) //26
                {

                    if ((TempArray[0,j] > 0) || ((TempArray[i, j] > 0) && GridArray[i-1, j] > 0) || ((TempArray[i, j] > 0) && GridArray[i - 1, j+1] > 0) )
                    {
                        Lmax = true;
                    }
                    
                    if ((TempArray[maxXpos-1, j] > 0) || ((TempArray[i, j] > 0) && GridArray[i+1, j] > 0) || ((TempArray[i, j] > 0) && GridArray[i + 1, j+1] > 0)) //13
                    {
                        Rmax = true;
                    }

                    if ((TempArray[i, maxYpos - 1] > 0) || ((TempArray[i, j] > 0) && GridArray[i, j + 1] > 0)) //22
                    {
                        Dmax = true;
                        if (Block.y <=0) 
                        {
                            Collision();
                        }
                    }
                }
            }

            if (!Dmax) // till blocked
            {
                Block.y = Block.y + Settings.pixelHeight;
            }
            else
            {
                Memorize();
                ClearRow();
                newBlock();
            }
        }

        private void Memorize() 
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Block.BoxArray[i, j] > 0)
                    {
                        GridArray[(Block.x+(Settings.pixelWidth * j)) / Settings.pixelWidth, (Block.y+ (Settings.pixelWidth * i)) / Settings.pixelHeight] = Block.id;
                    }
                }
            }

        }
        private void ClearRow()
        {
            for (int j = maxYpos-1; j >= 0; j--) //16
            {
                List<bool> rowClear = new List<bool>();
                rowClear.Clear();
                for (int i = 0; i < maxXpos; i++) //26
                {
                    if (GridArray[i,j]!=0) 
                    {
                        rowClear.Add(true);
                    }
                    else 
                    {
                        rowClear.Add(false);
                    }
                }
                if (rowClear.All(x => x==true)) 
                {
                    MoveRow(j);
                    j = maxYpos;
                }

            }
        }

        private void MoveRow(int row)
        {
            for (int j = row; j >= 1; j--) //16
            {
                for (int i = 0; i < maxXpos; i++) //26
                {
                    GridArray[i, j] = GridArray[i, j - 1];
                }
            }
            Settings.Total++;
            Total.Text = "Total: " + Settings.Total.ToString();

        }

        private void Collision()
        {
           Settings.gameOver = true;
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
                for (int i = 0; i < maxXpos; i++) //15
                {
                    for (int j = 0; j < maxYpos; j++) //25
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
    