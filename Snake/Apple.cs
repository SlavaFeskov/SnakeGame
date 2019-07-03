using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace Snake
{
    public class Apple : IDrawable
    {
        public Point Coords { get; set; }

        public void Draw(Graphics graphics, Brush brush)
        {
            graphics.FillEllipse(brush, Coords.X, Coords.Y, GameContext.CurrentSettings.ElementSize, GameContext.CurrentSettings.ElementSize);
        }

        public Apple(Snake snake)
        {
            Coords = GetSpawnPoint(snake);
        }

        private Point GetSpawnPoint(Snake snake)
        {
            return new Point();
        }
    }
}
