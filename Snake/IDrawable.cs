using System.Drawing;

namespace Snake
{
    public interface IDrawable
    {
        void Draw(Graphics graphics, Brush brush);
    }
}
