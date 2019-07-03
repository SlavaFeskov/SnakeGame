using System;
using System.Drawing;

namespace Snake
{
    public static class GameContext
    {
        public static Point[][] Field { get; set; }

        public static CurrentSettings CurrentSettings { get; set; } = new CurrentSettings();

        public static Brush HeadBrush { get; set; } = Brushes.Black;

        public static Brush BodyBrush { get; set; } = Brushes.Orange;

        public static Direction Direction { get; set; } = Direction.Top;        

        public static bool GameEnded { get; set; } = false;

        static GameContext()
        {
            int xCells = (int) Math.Floor((double)CurrentSettings.WindowWidth / CurrentSettings.ElementSize); 
            int yCells = (int) Math.Floor((double)CurrentSettings.WindowHeight / CurrentSettings.ElementSize);
            Field = new Point[xCells][];
        }
    }
}
