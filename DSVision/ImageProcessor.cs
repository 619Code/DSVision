using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSVision
{
    class ImageProcessor
    {
        //0,15	43,15	47.5,13	50,8.5
        //0,0	43,0	47.5,2	50,6.5

        private SimpleShapeChecker shapeChecker;

        public Bitmap Original { private set; get; }
        public Bitmap Filtered { private set; get; }

        private BlobCounter blobCounter;
        private Blob[] blobs;

        private Pen greenPen;
        private SolidBrush redBrush;
        private SolidBrush blueBrush;

        public ImageProcessor()
        {
            shapeChecker = new SimpleShapeChecker();
            blobCounter = new BlobCounter();

            greenPen = new Pen(Color.FromArgb(0, 255, 0), 2);
            redBrush = new SolidBrush(Color.FromArgb(255, 0, 0));
            blueBrush = new SolidBrush(Color.FromArgb(0, 0, 255));
        }

        public void Process(Bitmap bmp, HSLFiltering filter = null)
        {
            Original = bmp;

            if (filter == null)
            {
                Filtered = Original;
            }
            else
            {
                SetFilter(filter);
            }

            blobCounter.ProcessImage(Filtered);
            blobs = blobCounter.GetObjectsInformation();
        }

        public void SetFilter(HSLFiltering filter)
        {
            Filtered = new Bitmap(Original);
            filter.ApplyInPlace(Filtered);

            blobCounter.ProcessImage(Filtered);
            blobs = blobCounter.GetObjectsInformation();
        }

        public Bitmap GetHullGraphic()
        {
            if (Filtered == null)
            {
                return null;
            }
            Bitmap tmp = new Bitmap(Filtered.Width, Filtered.Height);
            Graphics g = Graphics.FromImage(tmp);
            g.DrawImage(Filtered, 0, 0);
            foreach (Blob blob in blobs)
            {
                List<IntPoint> edges = blobCounter.GetBlobsEdgePoints(blob);
                foreach (IntPoint point in edges)
                {
                    g.FillEllipse(redBrush, point.X, point.Y, 3, 3);
                }
                GrahamConvexHull hullFinder = new GrahamConvexHull();
                List<IntPoint> hull = hullFinder.FindHull(edges);
                if (hull.Count > 2)
                {
                    g.DrawPolygon(greenPen, ToPointsArray(hull));
                }
                foreach (IntPoint point in hull)
                {
                    g.FillEllipse(blueBrush, point.X, point.Y, 4, 4);
                }
                //Debug.WriteLine(shapeChecker.CheckShapeType(edges).ToString() +
                    //": " + edges.Count);
            }
            g.Dispose();
            return tmp;
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
