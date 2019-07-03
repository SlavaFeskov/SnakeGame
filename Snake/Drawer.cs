using System.Drawing;

namespace Snake
{
    public class Drawer
    {
        public void Draw(Graphics graphics, params object[] items)
        {
            graphics.Clear(Color.White);

            foreach (var item in items)
            {
                if (item is ObjectPaint<IDrawable> drawableItem)
                {
                    drawableItem.Object?.Draw(graphics, drawableItem.Brush);
                }             
            }
        }
    }
}
