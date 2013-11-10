using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_Lab1
{
    public class ToolChangedEventArgs : EventArgs
    {
        public Tool NewTool;
        public Tool OldTool;

        public ToolChangedEventArgs(Tool oldTool,Tool newTool)
        {
            this.NewTool = newTool;
            this.OldTool = oldTool;
        }
    }

    public class CanvasPanel : Panel
    {
        public enum ToolTypes
        {
            SelectionTool,
            PolygonTool,
            EllipseTool,
            ToolsCount
        }

        public event EventHandler<ToolChangedEventArgs> ToolChangedEvent;
        public Dictionary<ToolTypes, Tool> Tools;
        private Tool _activeTool;

        public List<Shape> Shapes { get; set; }
        public Color CurrentColor { get; set; }
        public int CurrentLineWidth { get; set; }

        public Tool ActiveTool
        {
            get { return _activeTool; }
            set
            {
                if (_activeTool!=null)
                    _activeTool.OnDeactivate(this);

                if (value != _activeTool && ToolChangedEvent != null)
                {
                    ToolChangedEvent.Invoke(this, new ToolChangedEventArgs(_activeTool, value));
                }
                _activeTool = value;
                if (_activeTool != null)
                {
                    _activeTool.OnActivate(this);
                    this.Cursor = _activeTool.Cursor;
                }
            }
        }

        public CanvasPanel()
        {
            Init();
        }

        void Init()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.Cursor = Cursors.Cross;
            this.CurrentColor = Color.Black;
            this.CurrentLineWidth = 3;
            this.Shapes = new List<Shape>();

            this.Paint += CanvasPanel_Paint;
            this.MouseMove += CanvasPanel_MouseMove;
            this.MouseDown += CanvasPanel_MouseDown;
            this.MouseUp += CanvasPanel_MouseUp;
            this.KeyUp += CanvasPanel_KeyUp;
            this.MouseDoubleClick += CanvasPanel_MouseDoubleClick;
            Tools = new Dictionary<ToolTypes, Tool>();
            Tools.Add(ToolTypes.SelectionTool, new SelectionTool());
            Tools.Add(ToolTypes.PolygonTool, new PolygonTool());
            (Tools[ToolTypes.PolygonTool] as PolygonTool).ShapeCreatedEvent += CanvasPanel_ShapeCreatedEvent;
            (Tools[ToolTypes.PolygonTool] as PolygonTool).ShapeCancelledEvent+=CanvasPanel_ShapeCancelledEvent;
            ActiveTool = Tools[ToolTypes.PolygonTool];
        }

        void CanvasPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ActiveTool.OnMouseDoubleClick(this,e);
        }

        private void CanvasPanel_ShapeCancelledEvent(object sender, ShapeEventArgs e)
        {
            this.Shapes.Remove(e.Shape);
        }

        private void CanvasPanel_ShapeCreatedEvent(object sender, ShapeEventArgs e)
        {
            (Tools[ToolTypes.SelectionTool] as SelectionTool).SelectedShape = e.Shape;
            this.ActiveTool = Tools[ToolTypes.SelectionTool];
        }

        public void CanvasPanel_KeyUp(object sender, KeyEventArgs e)
        {
            ActiveTool.OnKeyUp(this, e);
        }

        void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {

            GraphicsExtensions.PixelCount = 0;
            
            using (var brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            foreach (Shape s in Shapes)
            {
                s.Draw(e.Graphics);
            }
        }

        void CanvasPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ActiveTool.OnMouseUp(this,e);
        }

        void CanvasPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ActiveTool.OnMouseDown(this,e);
        }

        void CanvasPanel_MouseMove(object sender, MouseEventArgs e)
        {

            ActiveTool.OnMouseMove(this,e);
        }
    }

}
