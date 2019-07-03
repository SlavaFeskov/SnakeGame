using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public partial class MainForm : Form
    {
        public Snake Snake { get; set; }

        public MainForm()
        {
            InitializeComponent();
            GameEndLabel.Visible = false;            
            mainTimer.Tick += Tick;
            Snake = new Snake(GameContext.CurrentSettings.SnakeLength);
            //Tick(31, new EventArgs());
            mainTimer.Start();            
        }

        public void Tick(object o, EventArgs eventArgs)
        {
            try
            {
                var bitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);
                var graphics = Graphics.FromImage(bitmap);
                Snake.Tick(graphics);
                drawingPanel.Image = bitmap;
            }
            catch (CollisionException)
            {
                mainTimer.Stop();
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
