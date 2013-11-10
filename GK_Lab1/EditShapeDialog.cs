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
    public partial class EditShapeDialog : Form
    {
        private Shape _shape;
        public EditShapeDialog(Shape shape)
        {
            InitializeComponent();
            this.colorDialog.Color = shape.Color;
            this.lineThicknessNumber.Value = shape.LineWidth;
            this._shape = shape;
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            this.colorPickerButton.BackColor = colorDialog.Color;
            okButton.Focus();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _shape.Color = colorDialog.Color;
            _shape.LineWidth = (int)lineThicknessNumber.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EditShapeDialog_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                okButton.PerformClick();
            }
        }

        private void lineThicknessNumber_ValueChanged(object sender, EventArgs e)
        {

            okButton.Focus();
        }
    }
}
