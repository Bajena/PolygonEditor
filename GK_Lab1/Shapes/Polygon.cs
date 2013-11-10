using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_Lab1.Shapes
{

    public class Polygon : Shape
    {

        public static int DistanceToClose = 8 * 8;

        public List<Point> Vertices;
        public bool Created { get; set; }

        public Polygon(Color color, int lineWidth)
        {
            this.Color = color;
            this.LineWidth = lineWidth;
            Vertices = new List<Point>();

        }

        public override void Draw(Graphics g)
        {
            DrawPolygon(g);
            if (this.Selected)
                DrawBoundingRectangle(g);
        }
        public override void Move(int dx, int dy)
        {
            for (int i = 0; i < Vertices.Count; i++)
                MoveVertex(i, dx, dy);
        }
        public override Rectangle GetBoundingRectangle()
        {
            int minX = Vertices.Min(v => v.X);
            int minY = Vertices.Min(v => v.Y);
            int maxX = Vertices.Max(v => v.X);
            int maxY = Vertices.Max(v => v.Y);
            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }
        public override int GetHandlerAt(Point mousePosition)
        {
            int handlerNumber = 0;
            for (; handlerNumber < this.Vertices.Count; handlerNumber++)
            {
                Rectangle handlerRect = GetHandlerRectangle(this.Vertices[handlerNumber]);
                if (handlerRect.ContainsPoint(mousePosition))
                    return handlerNumber;
            }
            handlerNumber = -1;
            return handlerNumber;
        }
        public override void MoveHandler(int i, int dx, int dy)
        {
            MoveVertex(i, dx, dy);
        }
        public override bool Contains(Point p)
        {
            Point p1, p2;


            bool inside = false;


            if (Vertices.Count < 3)
            {
                return inside;
            }

            var oldPoint = new Point(Vertices[Vertices.Count - 1].X, Vertices[Vertices.Count - 1].Y);


            for (int i = 0; i < Vertices.Count; i++)
            {
                var newPoint = new Point(Vertices[i].X, Vertices[i].Y);


                if (newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;

                    p2 = newPoint;
                }

                else
                {
                    p1 = newPoint;

                    p2 = oldPoint;
                }


                if ((newPoint.X < p.X) == (p.X <= oldPoint.X)
                    && (p.Y - (long)p1.Y) * (p2.X - p1.X)
                    < (p2.Y - (long)p1.Y) * (p.X - p1.X))
                {
                    inside = !inside;
                }


                oldPoint = newPoint;
            }


            return inside;
        }

        public void MoveVertex(int i, int dx, int dy)
        {
            Vertices[i] = new Point(Vertices[i].X + dx, Vertices[i].Y + dy);
        }
        public void RemoveVertex(int i)
        {
            if (Vertices.Count > 3)
            {
                this.Vertices.RemoveAt(i);
            }
        }
        public void AddVertex(Point position)
        {
            if (CheckPolygonClose(position))
            {
                this.Created = true;
                this.Vertices.Remove(this.Vertices.Last());
                return;
            }

            if (this.Created)
            {
                Vertices.Insert(FindNearestEdge(position) + 1, position);
            }
            else
                Vertices.Add(position);

        }
        /// <summary>
        /// Zwraca numer wierzchołka rozpoczynającego bok wielokąta. Bok ten jest w najmniejszej odległości od punktu point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private int FindNearestEdge(Point point)
        {
            int closest = 0;
            int mindist = int.MaxValue;
            for (int i = 0; i < Vertices.Count; i++)
            {
                Point p1 = Vertices[i];
                Point p2 = Vertices[(i + 1) % Vertices.Count];
                Point mid = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                int dist = (mid.X - point.X) * (mid.X - point.X) + (mid.Y - point.Y) * (mid.Y - point.Y);
                if (dist < mindist)
                {
                    mindist = dist;
                    closest = i;
                }
            }
            return closest;
        }
        private void DrawBoundingRectangle(Graphics g)
        {
            Rectangle boundingRectangle = GetBoundingRectangle();
            boundingRectangle.X -= 10;
            boundingRectangle.Y -= 10;
            boundingRectangle.Width += 20;
            boundingRectangle.Height += 20;
            var pen = new Pen(Color.Black);
            pen.DashStyle = DashStyle.Dash;

            g.DrawRectangle(pen, boundingRectangle);
            pen.Dispose();
        }
        private void DrawPolygon(Graphics g)
        {
            using (var lineBrush = new SolidBrush(Color))
            {
                //Krawędzie
                if (this.Created)
                    g.DrawLine(lineBrush, this.LineWidth, Vertices.Last(), Vertices[0]);
                for (int i = 1; i < Vertices.Count; i++)
                {
                    g.DrawLine(lineBrush, this.LineWidth, Vertices[i - 1], Vertices[i]);
                }

                //Handlery
                if (!this.Created || this.Selected)
                {
                    Brush handlerBrush = new SolidBrush(Polygon.HandlerColor);

                    foreach (Point p in Vertices)
                        g.FillRectangle(handlerBrush, GetHandlerRectangle(p));
                    handlerBrush.Dispose();
                }


            }
        }
        private bool CheckPolygonClose(Point position)
        {
            return (Vertices.Count > 2 &&
                ((position.X - Vertices[0].X)*(position.X - Vertices[0].X) +((position.Y - Vertices[0].Y)*(position.Y - Vertices[0].Y)) ) <= Polygon.DistanceToClose);
        }
        private Rectangle GetHandlerRectangle(Point handlerPosition)
        {
            try
            {
                return new Rectangle(handlerPosition.X - Polygon.HandlerClickDistance,
                                     handlerPosition.Y - Polygon.HandlerClickDistance,
                                     2 * Polygon.HandlerClickDistance,
                                     2 * Polygon.HandlerClickDistance);

            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid vertex number!");
            }
        }

    }

}
