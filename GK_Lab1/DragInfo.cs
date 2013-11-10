using System.Drawing;
using System.Windows.Forms;

namespace GK_Lab1
{
    public class DragInfo
    {
        private Point _currentPosition;
        public int DraggedHandlerNumber;

        public bool IsDragging { get; set; }
        public Point DragStartPosition { get; set; }
        public Point LastPosition { get; set; }
        public Point CurrentPosition
        {
            get { return _currentPosition; }
            set
            {
                LastPosition = _currentPosition;
                _currentPosition = value;
            }
        }
        public Point DragDelta { get { return new Point(CurrentPosition.X - LastPosition.X, CurrentPosition.Y - LastPosition.Y); } }
        public MouseButtons Button { get; set; }

        public DragInfo(MouseEventArgs e, int handlerNumber = -1)
        {
            IsDragging = true;
            DragStartPosition = e.Location;
            Button = e.Button;
            LastPosition = e.Location;
            CurrentPosition = e.Location;
            DraggedHandlerNumber = handlerNumber;
        }

    }
}
