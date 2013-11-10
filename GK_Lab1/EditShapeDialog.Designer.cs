namespace GK_Lab1
{
    partial class EditShapeDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorPickerButton = new System.Windows.Forms.Button();
            this.lineThicknessLabel = new System.Windows.Forms.Label();
            this.lineThicknessNumber = new System.Windows.Forms.NumericUpDown();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.lineThicknessNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(34, 104);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(121, 104);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(38, 23);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(55, 13);
            this.colorLabel.TabIndex = 9;
            this.colorLabel.Text = "Kolor Linii:";
            // 
            // colorPickerButton
            // 
            this.colorPickerButton.BackColor = System.Drawing.Color.Black;
            this.colorPickerButton.Location = new System.Drawing.Point(119, 16);
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.Size = new System.Drawing.Size(27, 27);
            this.colorPickerButton.TabIndex = 7;
            this.colorPickerButton.UseVisualStyleBackColor = false;
            this.colorPickerButton.Click += new System.EventHandler(this.colorPickerButton_Click);
            // 
            // lineThicknessLabel
            // 
            this.lineThicknessLabel.AutoSize = true;
            this.lineThicknessLabel.Location = new System.Drawing.Point(38, 56);
            this.lineThicknessLabel.Name = "lineThicknessLabel";
            this.lineThicknessLabel.Size = new System.Drawing.Size(71, 13);
            this.lineThicknessLabel.TabIndex = 8;
            this.lineThicknessLabel.Text = "Grubość Linii:";
            // 
            // lineThicknessNumber
            // 
            this.lineThicknessNumber.Location = new System.Drawing.Point(121, 53);
            this.lineThicknessNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.lineThicknessNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineThicknessNumber.Name = "lineThicknessNumber";
            this.lineThicknessNumber.Size = new System.Drawing.Size(40, 20);
            this.lineThicknessNumber.TabIndex = 6;
            this.lineThicknessNumber.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.lineThicknessNumber.ValueChanged += new System.EventHandler(this.lineThicknessNumber_ValueChanged);
            // 
            // EditShapeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 157);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.colorPickerButton);
            this.Controls.Add(this.lineThicknessLabel);
            this.Controls.Add(this.lineThicknessNumber);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "EditShapeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edycja wielokąta...";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EditShapeDialog_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.lineThicknessNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Button colorPickerButton;
        private System.Windows.Forms.Label lineThicknessLabel;
        private System.Windows.Forms.NumericUpDown lineThicknessNumber;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}