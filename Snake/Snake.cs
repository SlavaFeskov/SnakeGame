using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Snake
{
    public class Snake : IDrawable
    {        
        public SnakeElement Head { get; set; }

        public List<SnakeElement> Body { get; set; }

        public Snake(int bodyCount = 3)
        {
            var headCoords = new Point((int) Math.Floor((double) (GameContext.CurrentSettings.WindowWidth - GameContext.CurrentSettings.ElementSize) / 2),
                (int) Math.Floor((double) (GameContext.CurrentSettings.WindowHeight - GameContext.CurrentSettings.ElementSize) / 2));
            Head = new SnakeElement(headCoords);
            Body = new List<SnakeElement>();

            for (var i = 1; i <= bodyCount; i++)
            {
                Body.Add(new SnakeElement(new Point(headCoords.X, headCoords.Y + GameContext.CurrentSettings.ElementSize * i)));    
            }            
        }

        public void Draw(Graphics graphics, Brush brush)
        {            
            Head.Draw(graphics, GameContext.HeadBrush);

            foreach (var element in Body)
            {
                element.Draw(graphics, GameContext.BodyBrush);
            }
        }

        public bool HasCollision()
        {
            if (Head.HasBorderCollision())
            {
                return true;
            }

            foreach (var element in Body)
            {
                if (Head.HasBlockCollision(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Move()
        {
            var oldHeadCoords = new Point(Head.Coords.X, Head.Coords.Y);

            switch (GameContext.Direction)
            {
                case Direction.Top:
                {
                    Head.Coords = new Point(Head.Coords.X, Head.Coords.Y - GameContext.CurrentSettings.ElementSize);
                    break;
                }
                case Direction.Right:
                {
                    Head.Coords = new Point(Head.Coords.X + GameContext.CurrentSettings.ElementSize, Head.Coords.Y);
                    break;
                }
                case Direction.Bottom:
                {
                    Head.Coords = new Point(Head.Coords.X, Head.Coords.Y + GameContext.CurrentSettings.ElementSize);
                    break;
                }
                case Direction.Left:
                {
                    Head.Coords = new Point(Head.Coords.X - GameContext.CurrentSettings.ElementSize, Head.Coords.Y);
                    break;
                }
            }

            for (var j = Body.Count - 1; j >= 1; j--)
            {
                Body[j].Coords = new Point(Body[j - 1].Coords.X, Body[j - 1].Coords.Y);
            }

            Body.First().Coords = oldHeadCoords;
        }

        public void Tick(Graphics graphics)
        {
            Move();

            if (HasCollision())
            {
                throw new CollisionException();
            }                                    
        }

        public void EatAppple()
        {
            var lastCoords = Body.Last().Coords;
            var prevCoords = Body[Body.Count - 2].Coords;
            var xDiff = lastCoords.X - prevCoords.X;

            if (xDiff > 0)
            {
                Body.Add(new SnakeElement(new Point(lastCoords.X + GameContext.CurrentSettings.ElementSize, lastCoords.Y)));
            }
            else if (xDiff < 0)
            {
                Body.Add(new SnakeElement(new Point(lastCoords.X - GameContext.CurrentSettings.ElementSize, lastCoords.Y)));
            }
            else
            {
                var yDiff = lastCoords.Y - prevCoords.Y;

                if (yDiff > 0)
                {
                    Body.Add(new SnakeElement(new Point(lastCoords.X, lastCoords.Y + GameContext.CurrentSettings.ElementSize)));
                }
                else
                {
                    Body.Add(new SnakeElement(new Point(lastCoords.X, lastCoords.Y - GameContext.CurrentSettings.ElementSize)));
                }
            }
        }
    }
}
