using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_Lab1
{
    public partial class MainForm : Form
    {
        private CanvasPanel _canvasPanel;
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            _canvasPanel = new CanvasPanel();
            mainWindowSplitContainer.Panel2.Controls.Add(_canvasPanel);
            mainWindowSplitContainer.FixedPanel = FixedPanel.Panel1;
            _canvasPanel.Location = new Point(3, 3);
            _canvasPanel.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right;
            _canvasPanel.Size = new Size(_canvasPanel.Parent.Width - 8, _canvasPanel.Parent.Height - 5);

            _canvasPanel.MouseMove += canvasPanel_MouseMove;
            _canvasPanel.ToolChangedEvent += canvasPanel_ToolChangedEvent;
            this.Resize += MainForm_Resize;
            _canvasPanel.Paint += canvasPanel_Paint;

            pixelCountLabel.Text = string.Format("Liczba pixeli: " + GraphicsExtensions.PixelCount);
            canvasSizeLabel.Text = string.Format("Rozmiar: " + _canvasPanel.Width + " x " + _canvasPanel.Height);
        }
        
        private void canvasPanel_Paint(object sender, PaintEventArgs e)
        {
            pixelCountLabel.Text = string.Format("Liczba pixeli: " + GraphicsExtensions.PixelCount);
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            canvasSizeLabel.Text = string.Format("Rozmiar: " + _canvasPanel.Width + " x " + _canvasPanel.Height);
        }
        private void canvasPanel_ToolChangedEvent(object sender, ToolChangedEventArgs e)
        {
            if (e.NewTool.GetType()==typeof(PolygonTool))
            {
                polygonToolRadio.Checked = true;
            }
            else if (e.NewTool.GetType()==typeof(SelectionTool))
            {
                selectToolRadio.Checked = true;
            }
        }
        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            colorPickerButton.BackColor = colorDialog.Color;
            _canvasPanel.CurrentColor = colorDialog.Color;
        }
        private void canvasPanel_MouseMove(object sender,MouseEventArgs e)
        {
            mousePosition.Text = string.Format("Pozycja kursora: "+e.Location.X+","+e.Location.Y);
        }
        private void lineThicknessNumber_ValueChanged(object sender, EventArgs e)
        {
            _canvasPanel.CurrentLineWidth = (int)lineThicknessNumber.Value;
        }
        private void selectToolRadio_CheckedChanged(object sender, EventArgs e)
        {
            _canvasPanel.ActiveTool = _canvasPanel.Tools[CanvasPanel.ToolTypes.SelectionTool];
        }
        private void polygonToolRadio_CheckedChanged(object sender, EventArgs e)
        {
            _canvasPanel.ActiveTool = _canvasPanel.Tools[CanvasPanel.ToolTypes.PolygonTool];
        }
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            _canvasPanel.CanvasPanel_KeyUp(this,e);
        }

        private void antialiasingCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            GraphicsExtensions.Antialiasing = antialiasingCheckbox.Checked;
            _canvasPanel.Refresh();
        }

        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,
                            "W trybie rysowania:\nKlikaj aby dodawać kolejne wierzchołki wielokąta. \nAby zakończyć rysowanie kliknij na początkowym wierzchołku.\nAby anulować rysowanie naciśnij Esc. \n\nW trybie edycji:\nAby przesunąć obiekt kliknij lewym przyciskiem myszki i przeciągnij\nKliknij dwa razy LPM na obiekcie aby edytować jego właściwości\nAby dodać wierzchołek zaznacz wielokąt i kliknij PPM w wybrane miejsce ", "Pomoc", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void wuDrawingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (wuDrawingRadioButton.Checked)
            {
                GraphicsExtensions.DrawingAlgorithm = GraphicsExtensions.DrawingAlgorithms.Wu;
                antialiasingCheckbox.Enabled = true;
                _canvasPanel.Refresh();
            }
        }


        private void DDADrawRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ddaDrawRadioButton.Checked)
            {
                GraphicsExtensions.DrawingAlgorithm = GraphicsExtensions.DrawingAlgorithms.DDA;
                antialiasingCheckbox.Enabled = false;
                _canvasPanel.Refresh();
            }
        }


    }
}
