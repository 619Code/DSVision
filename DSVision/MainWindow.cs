using AForge;
using AForge.Imaging.Filters;
using MjpegProcessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSVision
{
    public partial class MainWindow : Form
    {
        private ImageProcessor processor;

        private CameraHandler camera;

        public MainWindow()
        {
            InitializeComponent();

            processor = new ImageProcessor();

            //SetBitmap(new Bitmap("Test.png"));

            camera = new CameraHandler(this);

            camera.SetStream("http://10.6.19.11/mjpg/video.mjpg");
            camera.Start();
        }

        public void SetOriginal(Bitmap bmp)
        {
            originalDisplay.Image = (Bitmap)bmp.Clone();
        }

        public static Bitmap GetBitmapFromUrl(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            return new Bitmap(responseStream);
        }

        public void SetBitmap(Bitmap bmp, bool changeOriginal = true)
        {
            processor.Process(bmp);

            if (changeOriginal)
            {
                originalDisplay.Image = (Bitmap)bmp.Clone();
            }

            FilterChanged();
        }

        public void FilterChanged()
        {
            HSLFiltering filter = new HSLFiltering();
            filter.Hue = 
                new IntRange((int)hueMinInput.Value, (int)hueMaxInput.Value);
            filter.Saturation = 
                new Range((float)satMinInput.Value / 100f, (float)satMaxInput.Value / 100f);
            filter.Luminance =
                new Range((float)lumMinInput.Value / 100f, (float)lumMaxInput.Value / 100f);

            processor.SetFilter(filter);
            filteredDisplay.Image = (Bitmap)processor.Filtered.Clone();
            processedDisplay.Image = (Bitmap)processor.GetHullGraphic().Clone();
        }

        public static int Clamp(decimal value, decimal min, decimal max)
        {
            if (value < min)
            {
                return (int)min;
            }
            else if (value > max)
            {
                return (int)max;
            }
            else
            {
                return (int)value;
            }
        }

        private void hueMinInput_ValueChanged(object sender, EventArgs e)
        {
            hueMinInput.Value = Clamp(hueMinInput.Value, 0, hueMaxInput.Value);
            hueMinSlider.Value = (int)hueMinInput.Value;
            FilterChanged();
        }

        private void hueMinSlider_Scroll(object sender, EventArgs e)
        {
            hueMinSlider.Value = Clamp(hueMinSlider.Value, 0, hueMaxInput.Value);
            hueMinInput.Value = hueMinSlider.Value;
            FilterChanged();
        }

        private void hueMaxInput_ValueChanged(object sender, EventArgs e)
        {
            hueMaxInput.Value = Clamp(hueMaxInput.Value, hueMinInput.Value, 360);
            hueMaxSlider.Value = (int)hueMaxInput.Value;
            FilterChanged();
        }

        private void hueMaxSlider_Scroll(object sender, EventArgs e)
        {
            hueMaxSlider.Value = Clamp(hueMaxSlider.Value, hueMinInput.Value, 360);
            hueMaxInput.Value = hueMaxSlider.Value;
            FilterChanged();
        }

        private void satMinInput_ValueChanged(object sender, EventArgs e)
        {
            satMinInput.Value = Clamp(satMinInput.Value, 0, satMaxInput.Value);
            satMinSlider.Value = (int)satMinInput.Value;
            FilterChanged();
        }

        private void satMinSlider_Scroll(object sender, EventArgs e)
        {
            satMinSlider.Value = Clamp(satMinSlider.Value, 0, satMaxInput.Value);
            satMinInput.Value = satMinSlider.Value;
            FilterChanged();
        }

        private void satMaxInput_ValueChanged(object sender, EventArgs e)
        {
            satMaxInput.Value = Clamp(satMaxInput.Value, satMinInput.Value, 100);
            satMaxSlider.Value = (int)satMaxInput.Value;
            FilterChanged();
        }

        private void satMaxSlider_Scroll(object sender, EventArgs e)
        {
            satMaxSlider.Value = Clamp(satMaxSlider.Value, satMinInput.Value, 100);
            satMaxInput.Value = satMaxSlider.Value;
            FilterChanged();
        }

        private void lumMinInput_ValueChanged(object sender, EventArgs e)
        {
            lumMinInput.Value = Clamp(lumMinInput.Value, 0, lumMaxInput.Value);
            lumMinSlider.Value = (int)lumMinInput.Value;
            FilterChanged();
        }

        private void lumMinSlider_Scroll(object sender, EventArgs e)
        {
            lumMinSlider.Value = Clamp(lumMinSlider.Value, 0, lumMaxInput.Value);
            lumMinInput.Value = lumMinSlider.Value;
            FilterChanged();
        }

        private void lumMaxInput_ValueChanged(object sender, EventArgs e)
        {
            lumMaxInput.Value = Clamp(lumMaxInput.Value, lumMinInput.Value, 100);
            lumMaxSlider.Value = (int)lumMaxInput.Value;
            FilterChanged();
        }

        private void lumMaxSlider_Scroll(object sender, EventArgs e)
        {
            lumMaxSlider.Value = Clamp(lumMaxSlider.Value, lumMinInput.Value, 100);
            lumMaxInput.Value = lumMaxSlider.Value;
            FilterChanged();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            camera.Stop();
        }
    }
}
