﻿using AForge;
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
        public ProcessedBlob[] Blobs { private set; get; }

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
            Blob[] blobs = blobCounter.GetObjectsInformation();

            Blobs = new ProcessedBlob[blobs.Length];

            for (int i = 0; i < blobs.Length; i++)
            {
                Blob blob = blobs[i];
                List<IntPoint> edges = blobCounter.GetBlobsEdgePoints(blob);
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

                Blobs[i] = new ProcessedBlob(blob, edges, hull, bounds, findLines(hull));
            }
        }

        private const double AngleErrorMargin = Math.PI / 4d;

        private static ApproximateLine[] findLines(List<IntPoint> points)
        {
            if (points.Count == 1)
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
            Bitmap tmp = new Bitmap(Filtered.Width, Filtered.Height);
            Graphics g = Graphics.FromImage(tmp);
            g.DrawImage(Filtered, 0, 0);
            foreach (ProcessedBlob blob in Blobs)
            {
                List<IntPoint> edges = blob.Edges;
                foreach (IntPoint point in edges)
                {
                    g.FillEllipse(redBrush, point.X, point.Y, 3, 3);
                }

                List<IntPoint> hull = blob.Hull;
                if (hull.Count > 2)
                {
                    g.DrawPolygon(greenPen, ToPointsArray(hull));
                }

                foreach (IntPoint point in hull)
                {
                    g.FillEllipse(blueBrush, point.X, point.Y, 4, 4);
                }

                Vector4 bounds = blob.Bounds;

                g.DrawRectangle(yellowPen, bounds.Left, bounds.Up, 
                    bounds.Right - bounds.Left, bounds.Down - bounds.Up);

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
