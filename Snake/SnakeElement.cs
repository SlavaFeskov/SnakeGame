using System;
using System.Drawing;

namespace Snake
{
    public class SnakeElement : IDrawable
    {
        public Color Color { get; set; }

        public Point Coords { get; set; }

        public Shape Shape { get; set; } = Shape.Square;

        public Point TopLeft => Coords;

        public Point TopRight => new Point(Coords.X + GameContext.CurrentSettings.ElementSize, Coords.Y);

        public Point BottomLeft => new Point(Coords.X, Coords.Y + GameContext.CurrentSettings.ElementSize);

        public Point BottomRight => new Point(Coords.X + GameContext.CurrentSettings.ElementSize, Coords.Y + GameContext.CurrentSettings.ElementSize);

        public SnakeElement(Point coords)
        {
            this.Coords = coords;
        }

        public void Draw(Graphics graphics, Brush brush)
        {
            switch (Shape)
            {
                case Shape.Circle:
                {
                    graphics.FillEllipse(brush, Coords.X, Coords.Y, GameContext.CurrentSettings.ElementSize - GameContext.CurrentSettings.Offset, GameContext.CurrentSettings.ElementSize - GameContext.CurrentSettings.Offset);
                    break;
                }
                case Shape.Square:
                {
                    graphics.FillRectangle(brush, Coords.X, Coords.Y, GameContext.CurrentSettings.ElementSize - GameContext.CurrentSettings.Offset, GameContext.CurrentSettings.ElementSize - GameContext.CurrentSettings.Offset);
                    break;
                }
                default:
                {
                    throw new Exception("Shape is not defined.");
                }
            }
        }

        public bool HasBorderCollision()
        {
            // left side collision
            if (this.TopLeft.X < 0)
            {
                return true;
            }

            // top side collision
            if (this.TopLeft.Y < 0)
            {
                return true;
            }

            // right side collision
            if (this.BottomRight.X > GameContext.CurrentSettings.WindowWidth)
            {
                return true;
            }

            // bottom side collision
            if (this.BottomRight.Y > GameContext.CurrentSettings.WindowHeight)
            {
                return true;
            }            

            return false;
        }

        public bool HasBlockCollision(SnakeElement element)
        {
            if (Coords.X == element.Coords.X && Coords.Y == element.Coords.Y)
            {
                return true;
            }

            // from the right side
            if (this.BottomRight.X > element.TopLeft.X && this.BottomRight.X < element.BottomRight.X)
            {
                return true;
            }

            // from the top side
            if (this.BottomRight.Y > element.TopLeft.Y && this.BottomRight.Y < element.BottomRight.Y)
            {
                return true;
            }

            // from the left side
            if (this.TopLeft.X < element.BottomRight.X && this.TopLeft.X > element.TopLeft.X)
            {
                return true;
            }

            // from the bottom side
            if (this.TopLeft.Y < element.BottomRight.Y && this.TopLeft.Y > element.TopLeft.Y)
            {
                return true;
            }

            return false;
        }
    }
}
