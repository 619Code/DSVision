using MjpegProcessor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DSVision
{
    class CameraHandler
    {
        private MjpegDecoder mjpegDecoder;

        private MainWindow window;

        private Thread processThread;

        private bool running;

        public CameraHandler(MainWindow window)
        {
            this.window = window;

            mjpegDecoder = new MjpegDecoder();
            mjpegDecoder.FrameReady += frameReady;

            processThread = new Thread(new ThreadStart(runProcessing));
        }

        public void Start()
        {
            if (!running)
            {
                running = true;
                processThread.Start();
            }
        }

        public void Stop()
        {
            running = false;
        }

        private void runProcessing()
        {
            Bitmap previous = null;
            Bitmap bmp;
            while (running)
            {
                bmp = mjpegDecoder.Bitmap;
                if (bmp == null || bmp == previous)
                {
                    Thread.Sleep(20);
                    continue;
                }
                lock (bmp)
                {
                    window.SetBitmap(bmp, false);
                }
                previous = bmp;
            }
        }

        public void SetStream(string url)
        {
            mjpegDecoder.ParseStream(new Uri(url));
        }

        private void frameReady(object sender, FrameReadyEventArgs e)
        {
            lock (e.Bitmap)
            {
                window.SetOriginal(e.Bitmap);
            }
        }
    }
}
