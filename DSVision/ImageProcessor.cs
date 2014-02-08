using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //Programming Room Lighting
        //Hue: 130-190
        //Sat: 70-100
        //Lum: 40-70

        private SimpleShapeChecker shapeChecker;
        private GrahamConvexHull hullFinder;

        public Bitmap Original { private set; get; }
        public Bitmap Filtered { private set; get; }

        private HSLFiltering filter;

        private BlobCounter blobCounter;
        private Blob[] blobs;

        private List<IntPoint>[] edges;
        public List<IntPoint>[] Hulls { private set; get; }

        private Pen greenPen;
        private Pen yellowPen;
        private SolidBrush redBrush;
        private SolidBrush blueBrush;

        public ImageProcessor()
        {
            shapeChecker = new SimpleShapeChecker();
            hullFinder = new GrahamConvexHull();

            blobCounter = new BlobCounter();

            greenPen = new Pen(Color.FromArgb(0, 255, 0), 2);
            yellowPen = new Pen(Color.FromArgb(255, 255, 0), 1);
            redBrush = new SolidBrush(Color.FromArgb(255, 0, 0));
            blueBrush = new SolidBrush(Color.FromArgb(0, 0, 255));
            filter = new HSLFiltering();
        }

        public void Process(Bitmap bmp, HSLFiltering newFilter = null)
        {
            if (bmp == null)
            {
                return;
            }

            Original = bmp;

            if (newFilter == null)
            {
                SetFilter(filter);
            }
            else
            {
                SetFilter(newFilter);
            }
        }

        public void SetFilter(HSLFiltering newFilter)
        {
            filter = newFilter;

            if (Original == null)
            {
                return;
            }

            Filtered = new Bitmap(Original);
            filter.ApplyInPlace(Filtered);

            processData();
        }

        private void processData()
        {
            blobCounter.ProcessImage(Filtered);
            blobs = blobCounter.GetObjectsInformation();

            edges = new List<IntPoint>[blobs.Length];
            Hulls = new List<IntPoint>[blobs.Length];

            for (int i = 0; i < blobs.Length; i++)
            {
                List<IntPoint> lEdges = blobCounter.GetBlobsEdgePoints(blobs[i]);
                edges[i] = lEdges;

                Hulls[i] = hullFinder.FindHull(lEdges);
            }
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
            for (int i = 0; i < blobs.Length; i++)
            {
                List<IntPoint> lEdges = edges[i];
                foreach (IntPoint point in lEdges)
                {
                    g.FillEllipse(redBrush, point.X, point.Y, 3, 3);
                }

                List<IntPoint> hull = Hulls[i];
                if (hull.Count > 2)
                {
                    g.DrawPolygon(greenPen, ToPointsArray(hull));
                }

                foreach (IntPoint point in hull)
                {
                    g.FillEllipse(blueBrush, point.X, point.Y, 4, 4);
                }

                int top = int.MaxValue;
                int bot = int.MinValue;
                int left = int.MaxValue;
                int right = int.MinValue;

                foreach (IntPoint point in hull)
                {
                    if (point.X > right)
                    {
                        right = point.X;
                    }
                    if (point.X < left)
                    {
                        left = point.X;
                    }
                    if (point.Y < top) //Top and bot are reversed because it is a bitmap
                    {
                        top = point.Y;
                    }
                    if (point.Y > bot)
                    {
                        bot = point.Y;
                    }
                }

                g.DrawRectangle(yellowPen, left, top, right - left, bot - top);

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
