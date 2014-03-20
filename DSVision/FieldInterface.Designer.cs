namespace DSVision
{
    partial class FieldInterface
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
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.originalDisplay = new System.Windows.Forms.PictureBox();
            this.processedDisplay = new System.Windows.Forms.PictureBox();
            this.tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Controls.Add(this.originalDisplay, 0, 0);
            this.tableLayout.Controls.Add(this.processedDisplay, 1, 0);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 1;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Size = new System.Drawing.Size(944, 321);
            this.tableLayout.TabIndex = 0;
            // 
            // originalDisplay
            // 
            this.originalDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalDisplay.Location = new System.Drawing.Point(3, 3);
            this.originalDisplay.MaximumSize = new System.Drawing.Size(640, 480);
            this.originalDisplay.Name = "originalDisplay";
            this.originalDisplay.Size = new System.Drawing.Size(466, 315);
            this.originalDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalDisplay.TabIndex = 0;
            this.originalDisplay.TabStop = false;
            // 
            // processedDisplay
            // 
            this.processedDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processedDisplay.Location = new System.Drawing.Point(475, 3);
            this.processedDisplay.MaximumSize = new System.Drawing.Size(640, 480);
            this.processedDisplay.Name = "processedDisplay";
            this.processedDisplay.Size = new System.Drawing.Size(466, 315);
            this.processedDisplay.TabIndex = 1;
            this.processedDisplay.TabStop = false;
            // 
            // FieldInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 321);
            this.Controls.Add(this.tableLayout);
            this.Name = "FieldInterface";
            this.Text = "Field Interface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FieldInterface_FormClosing);
            this.tableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.PictureBox originalDisplay;
        private System.Windows.Forms.PictureBox processedDisplay;
    }
}