namespace GK_Lab1
{
    partial class MainForm
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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.mainWindowSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ddaDrawRadioButton = new System.Windows.Forms.RadioButton();
            this.wuDrawingRadioButton = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.antialiasingCheckbox = new System.Windows.Forms.CheckBox();
            this.pixelCountLabel = new System.Windows.Forms.Label();
            this.canvasSizeLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorPickerButton = new System.Windows.Forms.Button();
            this.mousePosition = new System.Windows.Forms.Label();
            this.lineThicknessLabel = new System.Windows.Forms.Label();
            this.lineThicknessNumber = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectToolRadio = new System.Windows.Forms.RadioButton();
            this.polygonToolRadio = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainWindowSplitContainer)).BeginInit();
            this.mainWindowSplitContainer.Panel1.SuspendLayout();
            this.mainWindowSplitContainer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineThicknessNumber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainWindowSplitContainer
            // 
            this.mainWindowSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainWindowSplitContainer.IsSplitterFixed = true;
            this.mainWindowSplitContainer.Location = new System.Drawing.Point(0, 33);
            this.mainWindowSplitContainer.Name = "mainWindowSplitContainer";
            // 
            // mainWindowSplitContainer.Panel1
            // 
            this.mainWindowSplitContainer.Panel1.Controls.Add(this.groupBox2);
            this.mainWindowSplitContainer.Panel1.Controls.Add(this.groupBox1);
            this.mainWindowSplitContainer.Size = new System.Drawing.Size(830, 510);
            this.mainWindowSplitContainer.SplitterDistance = 174;
            this.mainWindowSplitContainer.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ddaDrawRadioButton);
            this.groupBox2.Controls.Add(this.wuDrawingRadioButton);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.antialiasingCheckbox);
            this.groupBox2.Controls.Add(this.pixelCountLabel);
            this.groupBox2.Controls.Add(this.canvasSizeLabel);
            this.groupBox2.Controls.Add(this.colorLabel);
            this.groupBox2.Controls.Add(this.colorPickerButton);
            this.groupBox2.Controls.Add(this.mousePosition);
            this.groupBox2.Controls.Add(this.lineThicknessLabel);
            this.groupBox2.Controls.Add(this.lineThicknessNumber);
            this.groupBox2.Location = new System.Drawing.Point(13, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 425);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ustawienia rysowania";
            // 
            // ddaDrawRadioButton
            // 
            this.ddaDrawRadioButton.AutoSize = true;
            this.ddaDrawRadioButton.Location = new System.Drawing.Point(5, 155);
            this.ddaDrawRadioButton.Name = "ddaDrawRadioButton";
            this.ddaDrawRadioButton.Size = new System.Drawing.Size(73, 17);
            this.ddaDrawRadioButton.TabIndex = 15;
            this.ddaDrawRadioButton.Text = "Linia DDA";
            this.ddaDrawRadioButton.UseVisualStyleBackColor = true;
            this.ddaDrawRadioButton.CheckedChanged += new System.EventHandler(this.DDADrawRadioButton_CheckedChanged);
            // 
            // wuDrawingRadioButton
            // 
            this.wuDrawingRadioButton.AutoSize = true;
            this.wuDrawingRadioButton.Checked = true;
            this.wuDrawingRadioButton.Location = new System.Drawing.Point(5, 132);
            this.wuDrawingRadioButton.Name = "wuDrawingRadioButton";
            this.wuDrawingRadioButton.Size = new System.Drawing.Size(67, 17);
            this.wuDrawingRadioButton.TabIndex = 13;
            this.wuDrawingRadioButton.TabStop = true;
            this.wuDrawingRadioButton.Text = "Linia Wu";
            this.wuDrawingRadioButton.UseVisualStyleBackColor = true;
            this.wuDrawingRadioButton.CheckedChanged += new System.EventHandler(this.wuDrawingRadioButton_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(4, 109);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Multisampling:  ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // antialiasingCheckbox
            // 
            this.antialiasingCheckbox.AutoSize = true;
            this.antialiasingCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.antialiasingCheckbox.Checked = true;
            this.antialiasingCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.antialiasingCheckbox.Location = new System.Drawing.Point(5, 86);
            this.antialiasingCheckbox.Name = "antialiasingCheckbox";
            this.antialiasingCheckbox.Size = new System.Drawing.Size(97, 17);
            this.antialiasingCheckbox.TabIndex = 11;
            this.antialiasingCheckbox.Text = "Antyaliasing:    ";
            this.antialiasingCheckbox.UseVisualStyleBackColor = true;
            this.antialiasingCheckbox.CheckedChanged += new System.EventHandler(this.antialiasingCheckbox_CheckedChanged);
            // 
            // pixelCountLabel
            // 
            this.pixelCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pixelCountLabel.AutoSize = true;
            this.pixelCountLabel.Location = new System.Drawing.Point(9, 361);
            this.pixelCountLabel.Name = "pixelCountLabel";
            this.pixelCountLabel.Size = new System.Drawing.Size(67, 13);
            this.pixelCountLabel.TabIndex = 10;
            this.pixelCountLabel.Text = "Liczba pixeli:";
            // 
            // canvasSizeLabel
            // 
            this.canvasSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.canvasSizeLabel.AutoSize = true;
            this.canvasSizeLabel.Location = new System.Drawing.Point(9, 383);
            this.canvasSizeLabel.Name = "canvasSizeLabel";
            this.canvasSizeLabel.Size = new System.Drawing.Size(48, 13);
            this.canvasSizeLabel.TabIndex = 9;
            this.canvasSizeLabel.Text = "Rozmiar:";
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(6, 24);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(55, 13);
            this.colorLabel.TabIndex = 5;
            this.colorLabel.Text = "Kolor Linii:";
            // 
            // colorPickerButton
            // 
            this.colorPickerButton.BackColor = System.Drawing.Color.Black;
            this.colorPickerButton.Location = new System.Drawing.Point(87, 17);
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.Size = new System.Drawing.Size(27, 27);
            this.colorPickerButton.TabIndex = 2;
            this.colorPickerButton.UseVisualStyleBackColor = false;
            this.colorPickerButton.Click += new System.EventHandler(this.colorPickerButton_Click);
            // 
            // mousePosition
            // 
            this.mousePosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mousePosition.AutoSize = true;
            this.mousePosition.Location = new System.Drawing.Point(9, 406);
            this.mousePosition.Name = "mousePosition";
            this.mousePosition.Size = new System.Drawing.Size(65, 13);
            this.mousePosition.TabIndex = 8;
            this.mousePosition.Text = "Pozycja: 0,0";
            // 
            // lineThicknessLabel
            // 
            this.lineThicknessLabel.AutoSize = true;
            this.lineThicknessLabel.Location = new System.Drawing.Point(6, 57);
            this.lineThicknessLabel.Name = "lineThicknessLabel";
            this.lineThicknessLabel.Size = new System.Drawing.Size(71, 13);
            this.lineThicknessLabel.TabIndex = 4;
            this.lineThicknessLabel.Text = "Grubość Linii:";
            // 
            // lineThicknessNumber
            // 
            this.lineThicknessNumber.Location = new System.Drawing.Point(89, 54);
            this.lineThicknessNumber.Maximum = new decimal(new int[] {
            6,
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectToolRadio);
            this.groupBox1.Controls.Add(this.polygonToolRadio);
            this.groupBox1.Location = new System.Drawing.Point(13, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 70);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Narzędzia";
            // 
            // selectToolRadio
            // 
            this.selectToolRadio.AutoSize = true;
            this.selectToolRadio.Location = new System.Drawing.Point(12, 42);
            this.selectToolRadio.Name = "selectToolRadio";
            this.selectToolRadio.Size = new System.Drawing.Size(57, 17);
            this.selectToolRadio.TabIndex = 10;
            this.selectToolRadio.Text = "Edycja";
            this.selectToolRadio.UseVisualStyleBackColor = true;
            this.selectToolRadio.CheckedChanged += new System.EventHandler(this.selectToolRadio_CheckedChanged);
            // 
            // polygonToolRadio
            // 
            this.polygonToolRadio.AutoSize = true;
            this.polygonToolRadio.Checked = true;
            this.polygonToolRadio.Location = new System.Drawing.Point(12, 19);
            this.polygonToolRadio.Name = "polygonToolRadio";
            this.polygonToolRadio.Size = new System.Drawing.Size(77, 17);
            this.polygonToolRadio.TabIndex = 9;
            this.polygonToolRadio.TabStop = true;
            this.polygonToolRadio.Text = "Rysowanie";
            this.polygonToolRadio.UseVisualStyleBackColor = true;
            this.polygonToolRadio.CheckedChanged += new System.EventHandler(this.polygonToolRadio_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            this.pomocToolStripMenuItem.Click += new System.EventHandler(this.pomocToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 555);
            this.Controls.Add(this.mainWindowSplitContainer);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Polygon Editor - Jan Bajena";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.mainWindowSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainWindowSplitContainer)).EndInit();
            this.mainWindowSplitContainer.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineThicknessNumber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.SplitContainer mainWindowSplitContainer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label pixelCountLabel;
        private System.Windows.Forms.Label canvasSizeLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Button colorPickerButton;
        private System.Windows.Forms.Label mousePosition;
        private System.Windows.Forms.Label lineThicknessLabel;
        private System.Windows.Forms.NumericUpDown lineThicknessNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton selectToolRadio;
        private System.Windows.Forms.RadioButton polygonToolRadio;
        private System.Windows.Forms.CheckBox antialiasingCheckbox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.RadioButton wuDrawingRadioButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton ddaDrawRadioButton;
    }
}

