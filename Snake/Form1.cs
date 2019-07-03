using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public partial class MainForm : Form
    {
        public Snake Snake { get; set; }

        public Apple Apple { get; set; }

        public Drawer Drawer { get; set; }

        public int EatenAppleCount { get; set; } = 0;

        public MainForm()
        {
            InitializeComponent();
            Drawer = new Drawer();
            GameEndLabel.Visible = false;            
            mainTimer.Tick += Tick;                        
            drawingPanel.Width = GameContext.CurrentSettings.WindowWidth;
            drawingPanel.Height = GameContext.CurrentSettings.WindowHeight;            
            Snake = new Snake(GameContext.CurrentSettings.SnakeLength);
            GameContext.FillField();
            //Tick(31, new EventArgs());
            mainTimer.Start();                 
        }

        public void Tick(object o, EventArgs eventArgs)
        {
            try
            {                
                mainTimer.Interval = 100 - GameContext.CurrentSettings.Speed;

                var bitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);
                var graphics = Graphics.FromImage(bitmap);                

                Snake.Tick(graphics);

                if (Apple == null)
                {
                    Apple = new Apple(Snake);
                }
                else
                {
                    if (Snake.Head.HasBlockCollision(Apple))
                    {
                        Snake.EatAppple();
                        EatenAppleCount++;

                        if (Levels.Level.Contains(EatenAppleCount))
                        {
                            GameContext.CurrentSettings.Speed += 5;
                        }

                        Apple = null;
                    }
                }

                Drawer.Draw(graphics, new ObjectPaint<IDrawable> { Object =  Snake, Brush = null }, 
                    new ObjectPaint<IDrawable> { Object = Apple, Brush = GameContext.AppleBrush});

                drawingPanel.Image = bitmap;
            }
            catch (CollisionException)
            {
                mainTimer.Stop();
                GameEndLabel.Text = $"GG. Apples {EatenAppleCount}\r\n{GameContext.Log}";
                GameEndLabel.Visible = true;
                GameContext.GameEnded = true;
            }        
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                {
                    if (GameContext.Direction != Direction.Bottom)
                    {
                        GameContext.Direction = Direction.Top;
                    }

                    break;
                }
                case Keys.Right:
                {
                    if (GameContext.Direction != Direction.Left)
                    {
                        GameContext.Direction = Direction.Right;
                    }

                        break;
                }
                case Keys.Down:
                {
                    if (GameContext.Direction != Direction.Top)
                    {
                        GameContext.Direction = Direction.Bottom;
                    }

                        break;
                }
                case Keys.Left:
                {
                    if (GameContext.Direction != Direction.Right)
                    {
                        GameContext.Direction = Direction.Left;
                    }

                        break;
                }
                case Keys.Enter:
                {
                    if (GameContext.GameEnded)
                    {
                        RestartGame();
                    }
                    
                    break;
                }
                case Keys.Escape:
                {
                    this.Close();
                    break;
                }                
            }
        }

        private void RestartGame()
        {
            GameContext.Direction = Direction.Top;
            Snake = new Snake(GameContext.CurrentSettings.SnakeLength);
            GameContext.GameEnded = false;
            mainTimer.Start();
            GameEndLabel.Visible = false;
        }
    }
}
