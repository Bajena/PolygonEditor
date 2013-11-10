using System;
using System.Drawing;
using System.Windows.Forms;

namespace GK_Lab1
{
    public class ShapeEventArgs : EventArgs
    {
        public Shape Shape { get; set; }

        public ShapeEventArgs(Shape createdShape)
        {
            Shape = createdShape;
        }
    }

    public abstract class Tool
    {
        public virtual Cursor Cursor { get; set; }
        public virtual void OnMouseDown(CanvasPanel canvasPanel, MouseEventArgs e){}
        public virtual void OnMouseMove(CanvasPanel canvasPanel, MouseEventArgs e){}
        public virtual void OnMouseUp(CanvasPanel canvasPanel, MouseEventArgs e){}
        public virtual void OnMouseDoubleClick(CanvasPanel canvasPanel, MouseEventArgs e){}
        public virtual void OnKeyUp(CanvasPanel canvasPanel,KeyEventArgs e){}
        public virtual void OnActivate(CanvasPanel canvasPanel){ }
        public virtual void OnDeactivate(CanvasPanel canvasPanel){ }
    }
}
