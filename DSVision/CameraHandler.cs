using MjpegProcessor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace DSVision
{
    class CameraHandler
    {
        private MjpegDecoder mjpegDecoder;

        private MainWindow window;

        private Thread processThread;
        //private Thread originalUpdateThread;

        private bool running;

        public CameraHandler(MainWindow window)
        {
            this.window = window;

            mjpegDecoder = new MjpegDecoder();

            processThread = new Thread(new ThreadStart(runProcessing));
            //originalUpdateThread = new Thread(new ThreadStart(runOriginalUpdate));
        }

        public void Start()
        {
            if (!running)
            {
                running = true;
                processThread.Start();
                //originalUpdateThread.Start();
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
                    window.SetBitmap(bmp, true);
                }
                previous = bmp;
            }
        }

        public void runOriginalUpdate()
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
                    window.SetOriginal(bmp);
                }
                previous = bmp;
            }
        }

        public void SetStream(string url)
        {
            mjpegDecoder.ParseStream(new Uri(url));
        }

    }
}
