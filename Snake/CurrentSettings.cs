namespace Snake
{
    public class CurrentSettings
    {
        public int Speed { get; set; }        

        public int ElementSize { get; set; }

        public int WindowWidth { get; set; } = 1034;

        public int WindowHeight { get; set; } = 545;

        public int Offset { get; set; } = 1;

        public int SnakeLength { get; set; } = 15;

        public CurrentSettings()
        {
            Speed = 1;            
            ElementSize = 15;
        }

        public CurrentSettings(int speed, int elementSize)
        {
            this.Speed = speed;            
            this.ElementSize = elementSize;
        }
    }
}
