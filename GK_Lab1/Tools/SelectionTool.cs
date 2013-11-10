using GK_Lab1.Shapes;
using System.Windows.Forms;

namespace GK_Lab1
{
    public class SelectionTool : Tool
    {
        private DragInfo _dragInfo;
        private Shape _selectedShape;

        public override Cursor Cursor
        {
            get { return Cursors.Arrow; }
            set { base.Cursor = value; }
        }
        public Shape SelectedShape
        {
            get { return _selectedShape; }
            set
            {
                if (value != null && value != _selectedShape)
                {
                    if (_selectedShape != null)
                        _selectedShape.Selected = false;

                    _selectedShape = value;
                    _selectedShape.Selected = true;
                }
                else if (value == null)
                {
                    if (_selectedShape != null)
                    {
                        _selectedShape.Selected = false;
                        _selectedShape = null;
                    }
                    else _selectedShape = null;
                }
            }
        }

        public override void OnMouseDown(CanvasPanel canvasPanel, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectedShape = GetClickedShape(canvasPanel, e);
                if (this.SelectedShape != null)
                {
                    canvasPanel.Cursor = Cursors.SizeAll;
                    _dragInfo = new DragInfo(e, SelectedShape.GetHandlerAt(e.Location));
                }

            }

            canvasPanel.Refresh();
        }

        public override void OnMouseMove(CanvasPanel canvasPanel, MouseEventArgs e)
        {

            if (_selectedShape != null && _dragInfo != null)
            {
                _dragInfo.CurrentPosition = e.Location;
                if (_dragInfo.Button == MouseButtons.Left)
                {
                    if (_dragInfo.DraggedHandlerNumber>-1)
                    {
                        _selectedShape.MoveHandler(_dragInfo.DraggedHandlerNumber,_dragInfo.DragDelta.X,_dragInfo.DragDelta.Y);
                    }
                    else
                    {
                        _selectedShape.Move(_dragInfo.DragDelta.X, _dragInfo.DragDelta.Y);
                    }
                }
                canvasPanel.Refresh();
            }
            else if (_selectedShape!=null && _dragInfo==null && _selectedShape.GetHandlerAt(e.Location)>-1)
            {
                canvasPanel.Cursor = Cursors.Hand;
            }
            else
            {
                canvasPanel.Cursor = this.Cursor;
            }

        }

        public override void OnMouseUp(CanvasPanel canvasPanel, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                canvasPanel.Cursor = this.Cursor;
                _dragInfo = null;
            }
            else if (e.Button==MouseButtons.Right)
            {
                if (_selectedShape!=null)
                {
                    if (_selectedShape.GetType() == typeof(Polygon))
                    {
                        var poly = (Polygon) SelectedShape;
                        int clickedHandler = _selectedShape.GetHandlerAt(e.Location);
                        if (clickedHandler > -1)
                        {
                            poly.RemoveVertex(clickedHandler);
                        }
                        else
                        {
                            poly.AddVertex(e.Location);
                        }

                    }

                    canvasPanel.Refresh();
                }
            }
        }

        public override void OnMouseDoubleClick(CanvasPanel canvasPanel, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (SelectedShape != null)
                {
                    using (var editShapeDialog = new EditShapeDialog(SelectedShape))
                    {
                        editShapeDialog.ShowDialog();
                        canvasPanel.Refresh();
                    }
                }
            }
        }

        public override void OnKeyUp(CanvasPanel canvasPanel, KeyEventArgs e)
        {
           if (e.KeyCode==Keys.Delete && SelectedShape!=null)
           {
               DeleteSelectedShape(canvasPanel);
               canvasPanel.Refresh();
           }
        }

        public override void OnDeactivate(CanvasPanel canvasPanel)
        {
            this.SelectedShape = null;
        }

        private Shape GetClickedShape(CanvasPanel canvasPanel, MouseEventArgs e)
        {
            foreach (var shape in canvasPanel.Shapes)
            {
                if (shape.GetHandlerAt(e.Location) > -1)
                    return shape;

                if (shape.Contains(e.Location))
                    return shape;
            }
            return null;
        }

        private void DeleteSelectedShape(CanvasPanel canvasPanel)
        {
            canvasPanel.Shapes.Remove(SelectedShape);
            SelectedShape = null;
            
        }
    }
}
