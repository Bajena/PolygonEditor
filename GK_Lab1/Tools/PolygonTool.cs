using GK_Lab1.Shapes;
using System;
using System.Windows.Forms;

namespace GK_Lab1
{
    public class PolygonTool : Tool
    {
        private Polygon _activePolygon;
        public event EventHandler<ShapeEventArgs> ShapeCreatedEvent;
        public event EventHandler<ShapeEventArgs> ShapeCancelledEvent;

        public override Cursor Cursor
        {
            get
            {
                return Cursors.Cross;
            }
            set
            {
                base.Cursor = value;
            }
        }
        public override void OnMouseDown(CanvasPanel canvasPanel, MouseEventArgs e)
        {
            if (_activePolygon == null)
            {
                _activePolygon = new Polygon(canvasPanel.CurrentColor, canvasPanel.CurrentLineWidth);
                canvasPanel.Shapes.Insert(0,_activePolygon);
                _activePolygon.AddVertex(e.Location);
            }

            //Wierzchołek, którym będziemy poruszać
            _activePolygon.AddVertex(e.Location);

            if (_activePolygon.Created)
                ShapeCreatedEvent.Invoke(this,new ShapeEventArgs(_activePolygon));

            canvasPanel.Refresh();
        }

        public override void OnMouseMove(CanvasPanel canvasPanel, MouseEventArgs e)
        {

            if (_activePolygon != null)
            {
                _activePolygon.Vertices[_activePolygon.Vertices.Count - 1] = e.Location;
            }

            canvasPanel.Refresh();
            
        }

        public override void OnMouseUp(CanvasPanel canvasPanel, MouseEventArgs e)
        {
        }

        public override void OnKeyUp(CanvasPanel canvasPanel, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && _activePolygon!=null)
            {
                ShapeCancelledEvent.Invoke(this,new ShapeEventArgs(_activePolygon));
                this._activePolygon = null;
                canvasPanel.Refresh();
            }
        }

        public override void OnActivate(CanvasPanel canvasPanel)
        {
            base.OnActivate(canvasPanel);
        }

        public override void OnDeactivate(CanvasPanel canvasPanel)
        {
            if (this._activePolygon!=null)
            {
                if (!_activePolygon.Created)
                {
                    if (_activePolygon.Vertices.Count >= 3)
                        _activePolygon.Created = true;
                    else
                        canvasPanel.Shapes.Remove(_activePolygon);
                }
                
                _activePolygon = null;
                canvasPanel.Refresh();
            }
        }
    }

}
