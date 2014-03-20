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

        private CameraDisplay display;

        private Thread processThread;
        private Thread originalUpdateThread;

        public bool Running { get; private set; }

        public CameraHandler(CameraDisplay display)
        {
            this.display = display;

            mjpegDecoder = new MjpegDecoder();

            processThread = new Thread(new ThreadStart(runProcessing));
            originalUpdateThread = new Thread(new ThreadStart(runOriginalUpdate));
        }

        public void Start()
        {
            if (!Running)
            {
                Running = true;
                processThread.Start();
                originalUpdateThread.Start();
            }
        }

        public void Stop()
        {
            Running = false;
        }

        private void runProcessing()
        {
            Bitmap previous = null;
            Bitmap bmp;
            while (Running)
            {
                bmp = mjpegDecoder.Bitmap;
                if (bmp == null || bmp == previous)
                {
                    Thread.Sleep(20);
                    continue;
                }
                display.UpdateProcessed(bmp);
                if (previous != null)
                {
                    previous.Dispose();
                }
                previous = bmp;
            }
        }

        private void runOriginalUpdate()
        {
            Bitmap previous = null;
            Bitmap bmp;
            while (Running)
            {
                bmp = mjpegDecoder.Bitmap;
                if (bmp == null || bmp == previous)
                {
                    Thread.Sleep(20);
                    continue;
                }
                display.UpdateOriginal(bmp);
                previous = bmp;
            }
        }

        public void SetStream(string url)
        {
            mjpegDecoder.ParseStream(new Uri(url));
        }

    }
}
