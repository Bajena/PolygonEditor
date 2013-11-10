using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_Lab1
{
    public static class GraphicsExtensions
    {
        public enum DrawingAlgorithms
        {
            Wu,
            Bresenham,
            DDA
        }
        public static int PixelCount = 0;
        public static bool Antialiasing = true;
        public static DrawingAlgorithms DrawingAlgorithm = DrawingAlgorithms.Wu;
        public static void PutPixel(this Graphics g, SolidBrush brush, int x, int y, float brightness = 1)
        {
            if (Antialiasing && brightness < 1)
            {
                Color basicColor = brush.Color;
                if (brightness < 0)
                    brightness = 0;
                float tmp = 255 * (1 - brightness);
                Color newColor = Color.FromArgb(255, (int)((float)(basicColor.R) * brightness + tmp),
                                                (int)((float)(basicColor.G) * brightness + tmp),
                                                (int)((float)(basicColor.B) * brightness + tmp));
                brush.Color = newColor;

                g.FillRectangle(brush, x, y, 1, 1);
                brush.Color = basicColor;
            }
            else
                g.FillRectangle(brush, x, y, 1, 1);

            PixelCount++;
        }

        public static void PutPixel(this Graphics g, SolidBrush brush, Point point, float brightness = 1)
        {
            g.PutPixel(brush, point.X, point.Y, brightness);
        }

        public static void WuPutPixelGroupVert(this Graphics g, SolidBrush brush, int x, int y, int thickness,
                                               float brightness1 = 1, float brightness2 = 1)
        {
            int yStart = y - thickness / 2;
            g.PutPixel(brush, x, yStart++, brightness1);
            for (int i = 1; i <= thickness - 1; i++)
            {
                g.PutPixel(brush, x, yStart++);
            }

            g.PutPixel(brush, x, yStart, brightness2);

        }

        public static void WuPutPixelGroupHor(this Graphics g, SolidBrush brush, int x, int y, int thickness,
                                              float brightness1 = 1, float brightness2 = 1)
        {
            int xStart = x - thickness / 2;
            g.PutPixel(brush, xStart++, y, brightness1);
            for (int i = 1; i <= thickness - 1; i++)
            {
                g.PutPixel(brush, xStart++, y);
            }
            g.PutPixel(brush, xStart, y, brightness2);
        }

        private static float Frac(float x)
        {
            return x - (int)x;
        }

        private static float Invfrac(float x)
        {
            return 1 - Frac(x);
        }

        public static void DrawLine(this Graphics g, SolidBrush brush, int thickness, Point start, Point end)
        {
            switch (DrawingAlgorithm)
            {
                case DrawingAlgorithms.Wu:
                    g.DrawLineWu(brush, thickness, start, end);
                    break;
                case DrawingAlgorithms.DDA:
                    g.DrawLineDDA(brush, thickness, start, end);
                    break;
            }
        }
        public static void DrawLineWu(this Graphics g, SolidBrush brush, int thickness, Point start, Point end)
        {
            float grad;
            float brightness1, brightness2;
            int xm, ym;
            int x1 = start.X, x2 = end.X;
            int y1 = start.Y, y2 = end.Y;

            float xd = (x2 - x1);
            float yd = (y2 - y1);

            if (Math.Abs(xd) > Math.Abs(yd))
            {
                if (x1 > x2)
                {
                    xm = x1; x1 = x2; x2 = xm;
                    xd = (x2 - x1);
                    ym = y1; y1 = y2; y2 = ym;
                    yd = (y2 - y1);
                }


                if (xd != 0)
                    grad = yd / xd;
                else grad = 1;

                float yf1 = y1;
                float yf2 = y2;
                for (int xp1 = x1, xp2 = x2; xp1 <= xp2; xp1++, xp2--)
                {
                    brightness1 = Invfrac(yf1);
                    brightness2 = Frac(yf1);
                    g.WuPutPixelGroupVert(brush, xp1, (int)(yf1), thickness, brightness1, brightness2);

                    yf1 += grad;
                    brightness1 = Invfrac(yf2);
                    brightness2 = Frac(yf2);
                    g.WuPutPixelGroupVert(brush, xp2, (int)(yf2), thickness, brightness1, brightness2);

                    yf2 -= grad;
                }
            }
            else //if(Math.Abs(yd)>Math.Abs(xd))
            {
                if (y1 > y2)
                {
                    xm = x1; x1 = x2; x2 = xm;
                    ym = y1; y1 = y2; y2 = ym;
                    xd = (x2 - x1);
                    yd = (y2 - y1);
                }
                if (yd != 0)
                    grad = xd / yd;
                else grad = 1;

                float xf1 = x1, xf2 = x2;
                for (int yp1 = y1, yp2 = y2; yp1 <= yp2; yp1++, yp2--)
                {
                    brightness1 = Invfrac(xf1);
                    brightness2 = Frac(xf1);
                    g.WuPutPixelGroupHor(brush, (int)xf1, yp1, thickness, brightness1, brightness2);

                    brightness1 = Invfrac(xf2);
                    brightness2 = Frac(xf2);
                    g.WuPutPixelGroupHor(brush, (int)xf2, yp2, thickness, brightness1, brightness2);

                    xf1 += grad;
                    xf2 -= grad;
                }
            }

        }

        public static void DrawLineDDA(this Graphics g, SolidBrush brush, int thickness, Point start, Point end)
        {
            int x1 = start.X, x2 = end.X;
            int y1 = start.Y, y2 = end.Y;
            int steps;

            int dy = y2 - y1;
            int dx = x2 - x1;

            float x = x1, y = y1;
            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);

            float xinc = dx / (float)steps;
            float yinc = dy / (float)steps;
            int thicknesshalf = thickness / 2;
            using (Pen p = new Pen(brush.Color))
            {
                for (int k = 0; k < steps; k++)
                {
                    x += xinc;
                    y += yinc;
                    g.DrawRectangle(p, x - thicknesshalf, y - thicknesshalf, thickness, thickness);
                }
            }


        }

        public static void FillPolygon(this Graphics g, List<Point> vertices, Color color)
        {
            var polygonFillHelper = new PolygonFillHelper(vertices);
            var segments =  polygonFillHelper.FillPolygon(g, color);

            using (Pen pen = new Pen(color))
            {
                foreach (var segment in segments)
                {
                    g.DrawLine(pen, segment.p1,segment.p2);
                }
            }
        }

        


        //public static void FillPolygon(this Graphics g, List<Point> vertices, Color color)
        //{
        //    var ET = Edge.CreateEdges(vertices);
        //    var AET = new List<Edge>();
        //    ET.Sort(Edge.CompareEdges);
        //    //ET.AddRange(ET.OrderBy(e => e.ymin));
        //    List<int> list = new List<int>();
        //    int scanline = ET[0].ymin;
        //    int scanlineEnd = ET[ET.Count - 1].ymax;
        //    using (var pen = new Pen(Color.Red))
        //    {
        //        for (; scanline <= scanlineEnd; scanline++)
        //        {
        //            list.Clear();
        //            foreach (Edge edge in ET)
        //            {
        //                // here the scanline intersects the smaller vertice
        //                if (scanline == edge.ymin)
        //                {
        //                    if (scanline == edge.ymax)
        //                    {
        //                        // the current edge is horizontal, so we add both vertices
        //                        edge.Deactivate();
        //                        list.Add((int)edge.xval);
        //                    }
        //                    else
        //                    {
        //                        edge.Activate();
        //                        // we don't insert it in the list cause this vertice is also
        //                        // the (bigger) vertice of another edge and already handled
        //                    }
        //                }

        //                // here the scanline intersects the bigger vertice
        //                if (scanline == edge.ymax)
        //                {
        //                    edge.Deactivate();
        //                    list.Add((int)edge.xval);
        //                }

        //                // here the scanline intersects the edge, so calc intersection point
        //                if (scanline > edge.ymin && scanline < edge.ymax)
        //                {
        //                    edge.Update();
        //                    list.Add((int)edge.xval);
        //                }
        //            }
        //            list.Sort();
        //            for (int i = 0; i < list.Count; i += 2)
        //            {
        //                g.DrawLine(pen, list[i], scanline, list[i + 1], scanline);
        //                //list.get(i), scanline,list.get(i + 1), scanline);
        //            }

        //        }
        //    }
        //}

        //public class Edge
        //{
        //    public Point p1, p2;

        //    public int ymin;
        //    public int ymax;
        //    public float xval;
        //    public float invm;
        //    private float m;

        //    public Edge(Point a, Point b)
        //    {
        //        this.p1 = a;
        //        this.p2 = b;
        //        if (p1.Y > p2.Y)
        //        {
        //            Point tmp = p1;
        //            p1 = p2;
        //            p2 = tmp;
        //        }
        //        ymin = p1.Y;
        //        ymax = p2.Y;
        //        //xval = p1.X;
        //        //m = (float)((float)(p2.Y - p1.Y) / (float)(p2.X - p1.X));
        //        invm = ((float)(p1.X - p2.X) / (float)(p1.Y - p2.Y));
        //    }


        //    /*
        //     * Called when scanline intersects the first vertice of this edge.
        //     * That simply means that the intersection point is this vertice.
        //     */
        //    public void Activate()
        //    {
        //        xval = p1.X;
        //    }

        //    /*
        //     * Update the intersection point from the scanline and this edge.
        //     * Instead of explicitly calculate it we just increment with 1/m every time
        //     * it is intersected by the scanline.
        //     */
        //    public void Update()
        //    {
        //        //xval += (float)((float)1 / (float)m);
        //        xval += invm;
        //    }

        //    /*
        //     * Called when scanline intersects the second vertice, 
        //     * so the intersection point is exactly this vertice and from now on 
        //     * we are done with this edge
        //     */
        //    public void Deactivate()
        //    {
        //        xval = p2.X;
        //    }

        //    public static List<Edge> CreateEdges(List<Point> vertices)
        //    {
        //        var edges = new List<Edge>();
        //        for (int i = 0; i < vertices.Count; i++)
        //        {
        //            Point p1 = vertices[i];
        //            Point p2 = vertices[(i + 1) % vertices.Count];
        //            if (p1.Y != p2.Y)
        //                edges.Add(new Edge(p1, p2));

        //        }
        //        return edges;
        //    }
        //    public static int CompareEdges(Edge e1, Edge e2)
        //    {
        //        if (e1.ymin < e2.ymin)
        //            return -1;
        //        else if (e2.ymin < e1.ymin)
        //            return 1;
        //        else
        //        {
        //            if (e1.xval < e2.xval)
        //                return -1;
        //            else if (e2.xval < e2.xval)
        //                return 1;
        //        }
        //        return 0;
        //    }
        //}

    }
}
