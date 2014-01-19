using AForge;
using AForge.Imaging;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSVision
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bmp = new Bitmap("Test.png");
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.ProcessImage(bmp);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
            Graphics g = Graphics.FromImage(bmp);
            Pen redPen = new Pen(Color.Red, 2);
            foreach (Blob blob in blobs)
            {
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blob);
                List<IntPoint> corners;
                if (edgePoints.Count == 1)
                {
                    continue;
                }

                if (shapeChecker.IsQuadrilateral(edgePoints, out corners))
                {
                    g.DrawPolygon(redPen, ToPointsArray(corners));
                }
            }
            Application.Run(new MainWindow(bmp));
            redPen.Dispose();
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
