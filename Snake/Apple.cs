using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Snake
{
    public class Apple : Block, IDrawable
    {        
        public void Draw(Graphics graphics, Brush brush)
        {
            graphics.FillEllipse(brush, Coords.X - GameContext.CurrentSettings.Offset, Coords.Y - GameContext.CurrentSettings.Offset,
                GameContext.CurrentSettings.ElementSize - GameContext.CurrentSettings.Offset * 2, 
                GameContext.CurrentSettings.ElementSize - GameContext.CurrentSettings.Offset * 2);
        }

        public Apple(Snake snake)
        {
            Coords = GetSpawnPoint(snake);
        }

        private Point GetSpawnPoint(Snake snake)
        {
            var fullSnake = new List<SnakeElement>(snake.Body);
            fullSnake.Insert(0, snake.Head);            

            foreach (var snakeElement in fullSnake)
            {
                var i = snakeElement.TopLeft.X / GameContext.CurrentSettings.ElementSize;
                var j = snakeElement.TopLeft.Y / GameContext.CurrentSettings.ElementSize;
                GameContext.Field[i][j].IsFree = false;
            }

            var listOfFreePoints = new List<Point>();

            for (var i = 0; i < GameContext.Field.Length; i++)
            {
                for (var j = 0; j < GameContext.Field[i].Length; j++)
                {
                    if (GameContext.Field[i][j].IsFree)
                    {
                        listOfFreePoints.Add(GameContext.Field[i][j].Point);
                    }                    
                }
            }

            var randNumber = GameContext.Random.Next(listOfFreePoints.Count - 1);
            GameContext.Log = GameContext.Log + " " + randNumber;
            var spawnPoint = listOfFreePoints[randNumber];

            for (var i = 0; i < GameContext.Field.Length; i++)
            {
                for (var j = 0; j < GameContext.Field[i].Length; j++)
                {
                   GameContext.Field[i][j].IsFree = true;
                }
            }

            return spawnPoint;
        }        
    }
}
