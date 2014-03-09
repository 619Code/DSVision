using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DSVision
{
    class RobotUpdater
    {

        private TcpClient client;

        private string server;
        private int port;

        private bool running = false;
        private Thread thread;
        private ImageProcessor processor;

        public RobotUpdater(string server, int port, ImageProcessor processor)
        {
            client = new TcpClient();
            this.server = server;
            this.port = port;
            thread = new Thread(new ThreadStart(run));
            this.processor = processor;
        }

        public void Start()
        {
            if (running)
            {
                return;
            }

            running = true;

            thread.Start();
        }

        public void Stop()
        {
            running = false;
        }

        private void connect()
        {
            IAsyncResult result = client.BeginConnect(server, port, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
            if (!success)
            {
                Debug.WriteLine("Failed to connect");
                return;
            }
            client.EndConnect(result);
            Debug.WriteLine("Connected");
        }

        private void run()
        {
            Stopwatch watch = new Stopwatch();
            int time;

            while (running)
            {
                watch.Reset();
                watch.Start();

                if (!client.Connected)
                {
                    connect();
                }
                else
                {
                    client.GetStream().Write(BitConverter.GetBytes(processor.HotGoal), 0, 4);
                    Debug.WriteLine("Sent " + processor.HotGoal);
                }

                time = (int)watch.ElapsedMilliseconds;

                if (time < 100)
                {
                    Thread.Sleep(100 - time);
                }
            }
        }
    }
}
