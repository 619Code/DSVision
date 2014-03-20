namespace DSVision
{
    partial class DebugDisplay
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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.processedDisplay = new System.Windows.Forms.PictureBox();
            this.originalDisplay = new System.Windows.Forms.PictureBox();
            this.filteredDisplay = new System.Windows.Forms.PictureBox();
            this.filterOptionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.hueMinLabel = new System.Windows.Forms.Label();
            this.hueMaxLabel = new System.Windows.Forms.Label();
            this.satMinLabel = new System.Windows.Forms.Label();
            this.satMaxLabel = new System.Windows.Forms.Label();
            this.lightMinLabel = new System.Windows.Forms.Label();
            this.lightMaxLabel = new System.Windows.Forms.Label();
            this.hueMinSlider = new System.Windows.Forms.TrackBar();
            this.hueMaxSlider = new System.Windows.Forms.TrackBar();
            this.satMinSlider = new System.Windows.Forms.TrackBar();
            this.satMaxSlider = new System.Windows.Forms.TrackBar();
            this.lumMinSlider = new System.Windows.Forms.TrackBar();
            this.lumMaxSlider = new System.Windows.Forms.TrackBar();
            this.hueMinInput = new System.Windows.Forms.NumericUpDown();
            this.hueMaxInput = new System.Windows.Forms.NumericUpDown();
            this.satMinInput = new System.Windows.Forms.NumericUpDown();
            this.satMaxInput = new System.Windows.Forms.NumericUpDown();
            this.lumMinInput = new System.Windows.Forms.NumericUpDown();
            this.lumMaxInput = new System.Windows.Forms.NumericUpDown();
            this.mainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processedDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredDisplay)).BeginInit();
            this.filterOptionLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hueMinSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueMaxSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.satMinSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.satMaxSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lumMinSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lumMaxSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueMinInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueMaxInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.satMinInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.satMaxInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lumMinInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lumMaxInput)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.Controls.Add(this.processedDisplay, 0, 0);
            this.mainLayout.Controls.Add(this.originalDisplay, 0, 1);
            this.mainLayout.Controls.Add(this.filteredDisplay, 1, 1);
            this.mainLayout.Controls.Add(this.filterOptionLayout, 1, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.Size = new System.Drawing.Size(624, 442);
            this.mainLayout.TabIndex = 0;
            // 
            // processedDisplay
            // 
            this.processedDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processedDisplay.Location = new System.Drawing.Point(3, 3);
            this.processedDisplay.MaximumSize = new System.Drawing.Size(640, 480);
            this.processedDisplay.Name = "processedDisplay";
            this.processedDisplay.Size = new System.Drawing.Size(306, 215);
            this.processedDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.processedDisplay.TabIndex = 0;
            this.processedDisplay.TabStop = false;
            // 
            // originalDisplay
            // 
            this.originalDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.originalDisplay.Location = new System.Drawing.Point(3, 224);
            this.originalDisplay.MaximumSize = new System.Drawing.Size(640, 480);
            this.originalDisplay.Name = "originalDisplay";
            this.originalDisplay.Size = new System.Drawing.Size(306, 215);
            this.originalDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalDisplay.TabIndex = 1;
            this.originalDisplay.TabStop = false;
            // 
            // filteredDisplay
            // 
            this.filteredDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filteredDisplay.Location = new System.Drawing.Point(315, 224);
            this.filteredDisplay.MaximumSize = new System.Drawing.Size(640, 480);
            this.filteredDisplay.Name = "filteredDisplay";
            this.filteredDisplay.Size = new System.Drawing.Size(306, 215);
            this.filteredDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.filteredDisplay.TabIndex = 2;
            this.filteredDisplay.TabStop = false;
            // 
            // filterOptionLayout
            // 
            this.filterOptionLayout.ColumnCount = 3;
            this.filterOptionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.filterOptionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.filterOptionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filterOptionLayout.Controls.Add(this.hueMinLabel, 0, 0);
            this.filterOptionLayout.Controls.Add(this.hueMaxLabel, 0, 1);
            this.filterOptionLayout.Controls.Add(this.satMinLabel, 0, 2);
            this.filterOptionLayout.Controls.Add(this.satMaxLabel, 0, 3);
            this.filterOptionLayout.Controls.Add(this.lightMinLabel, 0, 4);
            this.filterOptionLayout.Controls.Add(this.lightMaxLabel, 0, 5);
            this.filterOptionLayout.Controls.Add(this.hueMinSlider, 2, 0);
            this.filterOptionLayout.Controls.Add(this.hueMaxSlider, 2, 1);
            this.filterOptionLayout.Controls.Add(this.satMinSlider, 2, 2);
            this.filterOptionLayout.Controls.Add(this.satMaxSlider, 2, 3);
            this.filterOptionLayout.Controls.Add(this.lumMinSlider, 2, 4);
            this.filterOptionLayout.Controls.Add(this.lumMaxSlider, 2, 5);
            this.filterOptionLayout.Controls.Add(this.hueMinInput, 1, 0);
            this.filterOptionLayout.Controls.Add(this.hueMaxInput, 1, 1);
            this.filterOptionLayout.Controls.Add(this.satMinInput, 1, 2);
            this.filterOptionLayout.Controls.Add(this.satMaxInput, 1, 3);
            this.filterOptionLayout.Controls.Add(this.lumMinInput, 1, 4);
            this.filterOptionLayout.Controls.Add(this.lumMaxInput, 1, 5);
            this.filterOptionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterOptionLayout.Location = new System.Drawing.Point(315, 3);
            this.filterOptionLayout.Name = "filterOptionLayout";
            this.filterOptionLayout.RowCount = 6;
            this.filterOptionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.filterOptionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.filterOptionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.filterOptionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.filterOptionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.filterOptionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.filterOptionLayout.Size = new System.Drawing.Size(306, 215);
            this.filterOptionLayout.TabIndex = 3;
            // 
            // hueMinLabel
            // 
            this.hueMinLabel.AutoSize = true;
            this.hueMinLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hueMinLabel.Location = new System.Drawing.Point(0, 8);
            this.hueMinLabel.Margin = new System.Windows.Forms.Padding(0, 8, 3, 0);
            this.hueMinLabel.Name = "hueMinLabel";
            this.hueMinLabel.Size = new System.Drawing.Size(42, 27);
            this.hueMinLabel.TabIndex = 0;
            this.hueMinLabel.Text = "H Min";
            this.hueMinLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // hueMaxLabel
            // 
            this.hueMaxLabel.AutoSize = true;
            this.hueMaxLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hueMaxLabel.Location = new System.Drawing.Point(0, 43);
            this.hueMaxLabel.Margin = new System.Windows.Forms.Padding(0, 8, 3, 0);
            this.hueMaxLabel.Name = "hueMaxLabel";
            this.hueMaxLabel.Size = new System.Drawing.Size(42, 27);
            this.hueMaxLabel.TabIndex = 1;
            this.hueMaxLabel.Text = "H Max";
            this.hueMaxLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // satMinLabel
            // 
            this.satMinLabel.AutoSize = true;
            this.satMinLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.satMinLabel.Location = new System.Drawing.Point(0, 78);
            this.satMinLabel.Margin = new System.Windows.Forms.Padding(0, 8, 3, 0);
            this.satMinLabel.Name = "satMinLabel";
            this.satMinLabel.Size = new System.Drawing.Size(42, 27);
            this.satMinLabel.TabIndex = 2;
            this.satMinLabel.Text = "S Min";
            this.satMinLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // satMaxLabel
            // 
            this.satMaxLabel.AutoSize = true;
            this.satMaxLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.satMaxLabel.Location = new System.Drawing.Point(0, 113);
            this.satMaxLabel.Margin = new System.Windows.Forms.Padding(0, 8, 3, 0);
            this.satMaxLabel.Name = "satMaxLabel";
            this.satMaxLabel.Size = new System.Drawing.Size(42, 27);
            this.satMaxLabel.TabIndex = 3;
            this.satMaxLabel.Text = "S Max";
            this.satMaxLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lightMinLabel
            // 
            this.lightMinLabel.AutoSize = true;
            this.lightMinLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightMinLabel.Location = new System.Drawing.Point(0, 148);
            this.lightMinLabel.Margin = new System.Windows.Forms.Padding(0, 8, 3, 0);
            this.lightMinLabel.Name = "lightMinLabel";
            this.lightMinLabel.Size = new System.Drawing.Size(42, 27);
            this.lightMinLabel.TabIndex = 4;
            this.lightMinLabel.Text = "L Min";
            this.lightMinLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lightMaxLabel
            // 
            this.lightMaxLabel.AutoSize = true;
            this.lightMaxLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightMaxLabel.Location = new System.Drawing.Point(0, 183);
            this.lightMaxLabel.Margin = new System.Windows.Forms.Padding(0, 8, 3, 0);
            this.lightMaxLabel.Name = "lightMaxLabel";
            this.lightMaxLabel.Size = new System.Drawing.Size(42, 32);
            this.lightMaxLabel.TabIndex = 5;
            this.lightMaxLabel.Text = "L Max";
            this.lightMaxLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // hueMinSlider
            // 
            this.hueMinSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hueMinSlider.LargeChange = 10;
            this.hueMinSlider.Location = new System.Drawing.Point(98, 3);
            this.hueMinSlider.Maximum = 360;
            this.hueMinSlider.Name = "hueMinSlider";
            this.hueMinSlider.Size = new System.Drawing.Size(205, 29);
            this.hueMinSlider.TabIndex = 12;
            this.hueMinSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.hueMinSlider.Value = 100;
            this.hueMinSlider.Scroll += new System.EventHandler(this.hueMinSlider_Scroll);
            // 
            // hueMaxSlider
            // 
            this.hueMaxSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hueMaxSlider.LargeChange = 10;
            this.hueMaxSlider.Location = new System.Drawing.Point(98, 38);
            this.hueMaxSlider.Maximum = 360;
            this.hueMaxSlider.Name = "hueMaxSlider";
            this.hueMaxSlider.Size = new System.Drawing.Size(205, 29);
            this.hueMaxSlider.TabIndex = 13;
            this.hueMaxSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.hueMaxSlider.Value = 160;
            this.hueMaxSlider.Scroll += new System.EventHandler(this.hueMaxSlider_Scroll);
            // 
            // satMinSlider
            // 
            this.satMinSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.satMinSlider.LargeChange = 10;
            this.satMinSlider.Location = new System.Drawing.Point(98, 73);
            this.satMinSlider.Maximum = 100;
            this.satMinSlider.Name = "satMinSlider";
            this.satMinSlider.Size = new System.Drawing.Size(205, 29);
            this.satMinSlider.TabIndex = 14;
            this.satMinSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.satMinSlider.Value = 45;
            this.satMinSlider.Scroll += new System.EventHandler(this.satMinSlider_Scroll);
            // 
            // satMaxSlider
            // 
            this.satMaxSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.satMaxSlider.LargeChange = 10;
            this.satMaxSlider.Location = new System.Drawing.Point(98, 108);
            this.satMaxSlider.Maximum = 100;
            this.satMaxSlider.Name = "satMaxSlider";
            this.satMaxSlider.Size = new System.Drawing.Size(205, 29);
            this.satMaxSlider.TabIndex = 15;
            this.satMaxSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.satMaxSlider.Value = 100;
            this.satMaxSlider.Scroll += new System.EventHandler(this.satMaxSlider_Scroll);
            // 
            // lumMinSlider
            // 
            this.lumMinSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lumMinSlider.LargeChange = 10;
            this.lumMinSlider.Location = new System.Drawing.Point(98, 143);
            this.lumMinSlider.Maximum = 100;
            this.lumMinSlider.Name = "lumMinSlider";
            this.lumMinSlider.Size = new System.Drawing.Size(205, 29);
            this.lumMinSlider.TabIndex = 16;
            this.lumMinSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.lumMinSlider.Value = 30;
            this.lumMinSlider.Scroll += new System.EventHandler(this.lumMinSlider_Scroll);
            // 
            // lumMaxSlider
            // 
            this.lumMaxSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lumMaxSlider.LargeChange = 10;
            this.lumMaxSlider.Location = new System.Drawing.Point(98, 178);
            this.lumMaxSlider.Maximum = 100;
            this.lumMaxSlider.Name = "lumMaxSlider";
            this.lumMaxSlider.Size = new System.Drawing.Size(205, 34);
            this.lumMaxSlider.TabIndex = 17;
            this.lumMaxSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.lumMaxSlider.Value = 70;
            this.lumMaxSlider.Scroll += new System.EventHandler(this.lumMaxSlider_Scroll);
            // 
            // hueMinInput
            // 
            this.hueMinInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hueMinInput.Location = new System.Drawing.Point(48, 5);
            this.hueMinInput.Margin = new System.Windows.Forms.Padding(3, 5, 0, 3);
            this.hueMinInput.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.hueMinInput.Name = "hueMinInput";
            this.hueMinInput.Size = new System.Drawing.Size(47, 20);
            this.hueMinInput.TabIndex = 18;
            this.hueMinInput.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.hueMinInput.ValueChanged += new System.EventHandler(this.hueMinInput_ValueChanged);
            // 
            // hueMaxInput
            // 
            this.hueMaxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hueMaxInput.Location = new System.Drawing.Point(48, 40);
            this.hueMaxInput.Margin = new System.Windows.Forms.Padding(3, 5, 0, 3);
            this.hueMaxInput.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.hueMaxInput.Name = "hueMaxInput";
            this.hueMaxInput.Size = new System.Drawing.Size(47, 20);
            this.hueMaxInput.TabIndex = 19;
            this.hueMaxInput.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.hueMaxInput.ValueChanged += new System.EventHandler(this.hueMaxInput_ValueChanged);
            // 
            // satMinInput
            // 
            this.satMinInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.satMinInput.Location = new System.Drawing.Point(48, 75);
            this.satMinInput.Margin = new System.Windows.Forms.Padding(3, 5, 0, 3);
            this.satMinInput.Name = "satMinInput";
            this.satMinInput.Size = new System.Drawing.Size(47, 20);
            this.satMinInput.TabIndex = 20;
            this.satMinInput.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.satMinInput.ValueChanged += new System.EventHandler(this.satMinInput_ValueChanged);
            // 
            // satMaxInput
            // 
            this.satMaxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.satMaxInput.Location = new System.Drawing.Point(48, 110);
            this.satMaxInput.Margin = new System.Windows.Forms.Padding(3, 5, 0, 3);
            this.satMaxInput.Name = "satMaxInput";
            this.satMaxInput.Size = new System.Drawing.Size(47, 20);
            this.satMaxInput.TabIndex = 21;
            this.satMaxInput.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.satMaxInput.ValueChanged += new System.EventHandler(this.satMaxInput_ValueChanged);
            // 
            // lumMinInput
            // 
            this.lumMinInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lumMinInput.Location = new System.Drawing.Point(48, 145);
            this.lumMinInput.Margin = new System.Windows.Forms.Padding(3, 5, 0, 3);
            this.lumMinInput.Name = "lumMinInput";
            this.lumMinInput.Size = new System.Drawing.Size(47, 20);
            this.lumMinInput.TabIndex = 22;
            this.lumMinInput.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.lumMinInput.ValueChanged += new System.EventHandler(this.lumMinInput_ValueChanged);
            // 
            // lumMaxInput
            // 
            this.lumMaxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lumMaxInput.Location = new System.Drawing.Point(48, 180);
            this.lumMaxInput.Margin = new System.Windows.Forms.Padding(3, 5, 0, 3);
            this.lumMaxInput.Name = "lumMaxInput";
            this.lumMaxInput.Size = new System.Drawing.Size(47, 20);
            this.lumMaxInput.TabIndex = 23;
            this.lumMaxInput.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.lumMaxInput.ValueChanged += new System.EventHandler(this.lumMaxInput_ValueChanged);
            // 
            // DebugDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.mainLayout);
            this.Name = "DebugDisplay";
            this.Text = "Debug Display";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.mainLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.processedDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredDisplay)).EndInit();
            this.filterOptionLayout.ResumeLayout(false);
            this.filterOptionLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hueMinSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueMaxSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.satMinSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.satMaxSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lumMinSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lumMaxSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueMinInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueMaxInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.satMinInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.satMaxInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lumMinInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lumMaxInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.PictureBox processedDisplay;
        private System.Windows.Forms.PictureBox originalDisplay;
        private System.Windows.Forms.PictureBox filteredDisplay;
        private System.Windows.Forms.TableLayoutPanel filterOptionLayout;
        private System.Windows.Forms.Label hueMinLabel;
        private System.Windows.Forms.Label hueMaxLabel;
        private System.Windows.Forms.Label satMinLabel;
        private System.Windows.Forms.Label satMaxLabel;
        private System.Windows.Forms.Label lightMinLabel;
        private System.Windows.Forms.Label lightMaxLabel;
        private System.Windows.Forms.TrackBar hueMinSlider;
        private System.Windows.Forms.TrackBar hueMaxSlider;
        private System.Windows.Forms.TrackBar satMinSlider;
        private System.Windows.Forms.TrackBar satMaxSlider;
        private System.Windows.Forms.TrackBar lumMinSlider;
        private System.Windows.Forms.TrackBar lumMaxSlider;
        private System.Windows.Forms.NumericUpDown hueMinInput;
        private System.Windows.Forms.NumericUpDown hueMaxInput;
        private System.Windows.Forms.NumericUpDown satMinInput;
        private System.Windows.Forms.NumericUpDown satMaxInput;
        private System.Windows.Forms.NumericUpDown lumMinInput;
        private System.Windows.Forms.NumericUpDown lumMaxInput;


    }
}