using System.Drawing;

namespace Snake
{
    public class ObjectPaint<T> 
        where T : IDrawable
    {
        public T Object { get; set; }

        public Brush Brush { get; set; }
    }
}
