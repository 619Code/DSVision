using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSVision
{
    public partial class FieldInterface : Form, CameraDisplay
    {
        private ImageProcessor processor;
        private CameraHandler camera;
        private HSLFiltering filter;

        private DirectoryInfo savedDir;

        public FieldInterface()
        {
            InitializeComponent();

            savedDir = new DirectoryInfo("Saved");
            if (!savedDir.Exists)
            {
                savedDir.Create();
            }

            processor = new ImageProcessor();
            camera = new CameraHandler(this);

            filter = new HSLFiltering();

            camera.SetStream("http://10.6.19.11/mjpg/video.mjpg");

            camera.Start();
        }

        public void UpdateProcessed(Bitmap bmp)
        {
            Bitmap clone;
            lock (this)
            {
                clone = (Bitmap)bmp.Clone();
            }
            processor.Process(bmp, filter, clone);
            lock (this)
            {
                DSVUtilities.SafelySetBitmap(processedDisplay, bmp);
            }
        }

        public void UpdateOriginal(Bitmap bmp)
        {
            Bitmap clone;
            lock (this)
            {
                clone = (Bitmap)bmp.Clone();
            }
            clone.Save(Path.Combine(savedDir.FullName, 
                (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond).ToString() + ".png"), ImageFormat.Png);
            Bitmap previous = (Bitmap)processedDisplay.Image;
            processedDisplay.Image = clone;
            if (previous != null)
            {
                previous.Dispose();
            }
        }

        private void FieldInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            camera.Stop();
        }
    }
}
