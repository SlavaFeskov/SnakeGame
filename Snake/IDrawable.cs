using System.Drawing;

namespace Snake
{
    interface IDrawable
    {
        void Draw(Graphics graphics, Brush brush);
    }
}
