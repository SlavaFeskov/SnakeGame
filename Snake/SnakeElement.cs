using System;
using System.Drawing;

namespace Snake
{
    public class SnakeElement : Block, IDrawable
    {
        public Color Color { get; set; }                

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
            switch (GameContext.Shape)
            {
                case Shape.Circle:
                {
                    graphics.FillEllipse(brush, Coords.X, Coords.Y, GameContext.CurrentSettings.ElementSize - GameContext.CurrentSettings.Offset, GameContext.CurrentSettings.ElementSize - GameContext.CurrentSettings.Offset);
                    break;
                }
                case Shape.Square:
                {
                    graphics.FillRectangle(brush, Coords.X - GameContext.CurrentSettings.Offset, Coords.Y - GameContext.CurrentSettings.Offset, GameContext.CurrentSettings.ElementSize - GameContext.CurrentSettings.Offset * 2, GameContext.CurrentSettings.ElementSize - GameContext.CurrentSettings.Offset * 2);
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

        public bool HasBlockCollision(Block element)
        {
            if (Coords.X == element.Coords.X && Coords.Y == element.Coords.Y)
            {
                return true;
            }           

            return false;
        }        
    }
}
