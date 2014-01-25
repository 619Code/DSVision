using AForge;
using AForge.Imaging;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSVision
{
    class Program
    {
        //0,15	43,15	47.5,13	50,8.5
        //0,0	43,0	47.5,2	50,6.5

        static void Main(string[] args)
        {
            Bitmap bmp = new Bitmap("Test.png");
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.ProcessImage(bmp);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
            Bitmap tmp = new Bitmap(bmp.Width, bmp.Height);
            Graphics g = Graphics.FromImage(tmp);
            g.DrawImage(bmp, 0, 0);
            Pen pen = new Pen(Color.FromArgb(0, 255, 0), 2);
            foreach (Blob blob in blobs)
            {
                List<IntPoint> edges = blobCounter.GetBlobsEdgePoints(blob);
                foreach (IntPoint point in edges)
                {
                    g.FillEllipse(Brushes.Red, point.X, point.Y, 3, 3);
                }
                GrahamConvexHull hullFinder = new GrahamConvexHull();
                List<IntPoint> hull = hullFinder.FindHull(edges);
                //foreach (IntPoint point in hull)
                //{
                //    g.FillEllipse(Brushes.Blue, point.X, point.Y, 4, 4);
                //}
                g.DrawPolygon(pen, ToPointsArray(hull));
                Debug.WriteLine(shapeChecker.CheckShapeType(edges).ToString() +
                    ": " + edges.Count);
            }
            Application.Run(new MainWindow(tmp));
            pen.Dispose();
            g.Dispose();
        }
        
        public static System.Drawing.Point[] ToPointsArray(List<IntPoint> points)
        {
            System.Drawing.Point[] array = new System.Drawing.Point[points.Count];

            for (int i = 0, n = points.Count; i < n; i++)
            {
                array[i] = new System.Drawing.Point(points[i].X, points[i].Y);
            }

            return array;
        }
    }
}
