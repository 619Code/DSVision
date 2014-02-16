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

namespace DSVision
{
    class ImageProcessor
    {
        //0,15	43,15	47.5,13	50,8.5
        //0,0	43,0	47.5,2	50,6.5

        //Programming Room Lighting
        //Hue: 100-160
        //Sat: 45-100
        //Lum: 30-70

        //White Balance: Fixed Flourescent 1
        //Exposure Control: Flicker-free 60 Hz
        //Exposure Priority: Prioritize Image Quality

        //Resolution: 640x480
        //Compression: 50
        //Rotate Image: 0
        //Color Level: 100
        //Brightness: 50
        //Sharpness: 0
        //Frame Rate: 10

        private const double AngleErrorMargin = Math.PI / 12d;

        private SimpleShapeChecker shapeChecker;
        private GrahamConvexHull hullFinder;

        public Bitmap Original { private set; get; }
        public Bitmap Filtered { private set; get; }

        private HSLFiltering filter;

        private BlobCounter blobCounter;
        public ProcessedBlob[] Blobs { private set; get; }

        private Pen greenPen;
        private Pen yellowPen;
        private Pen redPen;
        private Pen orangePen;
        private Pen purplePen;
        private SolidBrush redBrush;
        private SolidBrush blueBrush;

        public ImageProcessor()
        {
            shapeChecker = new SimpleShapeChecker();
            hullFinder = new GrahamConvexHull();

            blobCounter = new BlobCounter();

            greenPen = new Pen(Color.FromArgb(0, 255, 0), 1);
            yellowPen = new Pen(Color.FromArgb(255, 255, 0), 1);
            redPen = new Pen(Color.FromArgb(255, 0, 0), 2);
            orangePen = new Pen(Color.FromArgb(255, 127, 0), 1);
            purplePen = new Pen(Color.FromArgb(102, 51, 153), 1);
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

            if (Original == null)
            {
                return;
            }

            Filtered = (Bitmap)Original.Clone();
            filter.ApplyInPlace(Filtered);

            processData();
        }

        public void SetFilter(HSLFiltering newFilter, bool process = true)
        {
            filter = newFilter;

            if (!process)
            {
                return;
            }

            if (Original == null)
            {
                return;
            }

            Filtered = (Bitmap)Original.Clone();
            filter.ApplyInPlace(Filtered);

            processData();
        }

        private void processData()
        {
            blobCounter.ProcessImage(Filtered);
            Blob[] blobs = blobCounter.GetObjectsInformation();

            Blobs = new ProcessedBlob[blobs.Length];

            for (int i = 0; i < blobs.Length; i++)
            {
                Blob blob = blobs[i];
                List<IntPoint> edges = blobCounter.GetBlobsEdgePoints(blob);

                List<IntPoint> quadPoints = null;
                bool isQuad = false;
                if (edges.Count > 3)
                {
                    isQuad = shapeChecker.IsQuadrilateral(edges, out quadPoints);
                }

                List<IntPoint> hull = hullFinder.FindHull(edges);

                Vector4 bounds = 
                    new Vector4(int.MaxValue, int.MinValue, int.MaxValue, int.MinValue);

                foreach (IntPoint point in hull)
                {
                    if (point.X > bounds.Right)
                    {
                        bounds.Right = point.X;
                    }
                    if (point.X < bounds.Left)
                    {
                        bounds.Left = point.X;
                    }
                    if (point.Y < bounds.Up) //Up and down are reversed because it is a bitmap
                    {
                        bounds.Up = point.Y;
                    }
                    if (point.Y > bounds.Down)
                    {
                        bounds.Down = point.Y;
                    }
                }

                Blobs[i] = new ProcessedBlob(blob, edges, hull, bounds, findLines(hull), isQuad, quadPoints);
            }
        }

        private static ApproximateLine[] findLines(List<IntPoint> points)
        {
            if (points.Count < 3)
            {
                return new ApproximateLine[0];
            }

            List<ApproximateLine> results = new List<ApproximateLine>();

            ApproximateLine line = null;
            double lineAngle = 0, newAngle, diff, distance;
            IntPoint previous = new IntPoint(); //Essentially, initialization is null

            bool quitting = false;

            for(int i = 0; i < points.Count; i++)
            {
                IntPoint point = points[i];

                if (results.Count > 0 && point == results[0].Points.Last())
                {
                    quitting = true;
                }

                if (line == null)
                {
                    line = new ApproximateLine();
                    line.Add(point);
                    previous = point;
                    continue;
                }

                if (line.Points.Count == 1)
                {
                    lineAngle = Math.Atan2((double)point.Y - (double)previous.Y,
                        (double)point.X - (double)previous.X);
                    line.Add(point);
                }
                else
                {
                    newAngle = Math.Atan2((double)point.Y - (double)previous.Y,
                        (double)point.X - (double)previous.X);
                    diff = Math.Min((2d * Math.PI) - Math.Abs(newAngle - lineAngle),
                        Math.Abs(newAngle - lineAngle));
                    if (diff > AngleErrorMargin)
                    {
                        results.Add(line);
                        if (quitting)
                        {
                            break;
                        }
                        line = new ApproximateLine();
                        line.Add(previous);
                        line.Add(point);
                    }
                    else
                    {
                        distance = point.DistanceTo(previous);
                        lineAngle = (lineAngle * line.Length + newAngle * distance) /
                            (line.Length + distance);
                        line.Add(point);
                    }
                }

                previous = point;

                if (i + 1 == points.Count)
                {
                    i = 0;
                }
            }

            results.RemoveAt(0);

            return results.ToArray();
        }

        private const double TwoPI = Math.PI * 2d;
        private static double angleWrap(double angle)
        {
            return ((angle % TwoPI) + TwoPI) % TwoPI;
        }

        public Bitmap GetHullGraphic()
        {
            if (Filtered == null)
            {
                return null;
            }
            Bitmap tmp = new Bitmap(Filtered);
            Graphics g = Graphics.FromImage(tmp);
            foreach (ProcessedBlob blob in Blobs)
            {
                //List<IntPoint> edges = blob.Edges;
                //foreach (IntPoint point in edges)
                //{
                //    g.FillEllipse(redBrush, point.X, point.Y, 3, 3);
                //}

                List<IntPoint> hull = blob.Hull;
                if (hull.Count > 2)
                {
                    g.DrawPolygon(redPen, ToPointsArray(hull));
                }

                Vector4 bounds = blob.Bounds;

                g.DrawRectangle(yellowPen, bounds.Left, bounds.Up, 
                    bounds.Right - bounds.Left, bounds.Down - bounds.Up);

                ApproximateLine[] lines = blob.Lines;
                Debug.WriteLine(lines.Length + " lines");
                foreach (ApproximateLine line in lines)
                {
                    DrawApproximateLine(g, greenPen, line);
                }

<<<<<<< HEAD
                foreach (IntPoint point in hull)
                {
                    g.FillEllipse(blueBrush, point.X, point.Y, 4, 4);
=======
                if (blob.IsQuad)
                {
                    g.DrawPolygon(purplePen, ToPointsArray(blob.QuadPoints));
>>>>>>> Adjusted default values to new Camera
                }

                //Debug.WriteLine(shapeChecker.CheckShapeType(edges).ToString() +
                //": " + edges.Count);
            }
            g.Dispose();
            return tmp;
        }

        public static void DrawApproximateLine(Graphics g, Pen pen, ApproximateLine line)
        {
            IntPoint first = line.Points.First();
            IntPoint last = line.Points.Last();

            IntPoint diff = first - last;

            g.DrawLine(pen, new System.Drawing.Point(first.X + diff.X, first.Y + diff.Y), 
                new System.Drawing.Point(last.X - diff.X, last.Y - diff.Y));
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
