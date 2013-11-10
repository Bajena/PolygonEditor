using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_Lab1
{
    public abstract class Shape
    {
        public static int HandlerClickDistance = 5;
        public static Color HandlerColor = Color.Black;

        public Color Color { get; set; }
        public int LineWidth { get; set; }
        public bool Selected { get; set; }
        public abstract void Draw(Graphics g);
        public abstract void Move(int dx, int dy);
        public abstract void MoveHandler(int i, int dx, int dy);
        public abstract int GetHandlerAt(Point mousePosition);
        public abstract Rectangle GetBoundingRectangle();
        public abstract bool Contains(Point p);

    }
}
