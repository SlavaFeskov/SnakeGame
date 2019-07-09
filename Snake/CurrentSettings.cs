using System;
using System.Drawing;

namespace Snake
{
    public class CurrentSettings
    {        
        public int Speed { get; set; }

        public int ElementSize { get; set; } = 15;

        public int ScreenSize { get; set; } = 21;

        public int WindowWidth { get; set; }

        public int WindowHeight { get; set; }

        public int Offset { get; set; } = 1;

        public int SnakeLength { get; set; } = 3;

        public CurrentSettings()
        {
            Speed = 10;
            WindowWidth = ElementSize * ScreenSize;
            WindowHeight = ElementSize * ScreenSize;
        }

        public CurrentSettings(int speed, int elementSize)
        {
            this.Speed = speed;            
            this.ElementSize = elementSize;
        }        
    }
}
