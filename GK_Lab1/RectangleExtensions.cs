using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Lab1
{
    public static class RectangleExtensions
    {
        public static bool ContainsPoint(this Rectangle rectangle,Point point)
        {
            Rectangle pointRectangle = new Rectangle(point.X, point.Y, 1, 1);

            return (rectangle.IntersectsWith(pointRectangle));
        }
    }
}
