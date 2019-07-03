using System;
using System.Drawing;

namespace Snake
{
    public static class GameContext
    {
        public static FieldCell[][] Field { get; set; }

        public static CurrentSettings CurrentSettings { get; set; } = new CurrentSettings();

        public static Brush HeadBrush { get; set; } = Brushes.Black;

        public static Brush BodyBrush { get; set; } = Brushes.Orange;

        public static Brush AppleBrush { get; set; } = Brushes.Red;

        public static Direction Direction { get; set; } = Direction.Top;        

        public static bool GameEnded { get; set; } = false;

        public static string Log { get; set; }

        public static Random Random { get; set; } = new Random(0);

        public static void FillField()
        {
            int xCells = (int)Math.Floor((double)CurrentSettings.WindowWidth / CurrentSettings.ElementSize);
            int yCells = (int)Math.Floor((double)CurrentSettings.WindowHeight / CurrentSettings.ElementSize);
            Field = new FieldCell[xCells][];

            for (var i = 0; i < xCells; i++)
            {
                Field[i] = new FieldCell[yCells];
                for (var j = 0; j < yCells; j++)
                {
                    Field[i][j] = new FieldCell
                    {
                        Point = new Point(i * CurrentSettings.ElementSize, j * CurrentSettings.ElementSize),
                        IsFree = true
                    };
                }
            }
        }
    }
}
