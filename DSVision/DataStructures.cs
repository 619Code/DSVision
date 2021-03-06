﻿using AForge;
using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DSVision
{
    interface CameraDisplay
    {
        void UpdateOriginal(Bitmap bmp);
        void UpdateProcessed(Bitmap bmp);
    }

    class ProcessedBlob
    {
        public Blob Blob;
        public List<IntPoint> Edges;
        public List<IntPoint> Hull;
        public Vector4 Bounds;
        public ApproximateLine[] Lines;
        public bool IsQuad;
        public List<IntPoint> QuadPoints;

        public ProcessedBlob(Blob blob, List<IntPoint> edges, 
            List<IntPoint> hull, Vector4 bounds, ApproximateLine[] lines,
            bool isQuad, List<IntPoint> quadPoints = null)
        {
            Blob = blob;
            Edges = edges;
            Hull = hull;
            Bounds = bounds;
            Lines = lines;
            IsQuad = isQuad;
            if (isQuad)
            {
                QuadPoints = quadPoints;
            }
            else
            {
                QuadPoints = new List<IntPoint>();
            }
        }
    }

    struct Vector4
    {
        public int Left;
        public int Right;
        public int Up;
        public int Down;

        public Vector4(int left, int right, int up, int down)
        {
            Left = left;
            Right = right;
            Up = up;
            Down = down;
        }
    }

    class ApproximateLine //Don't use Points.Add
    {
        public List<IntPoint> Points { private set; get; }
        public double Length { private set; get; }

        public ApproximateLine()
        {
            Points = new List<IntPoint>();
            Length = 0;
        }

        public void Add(IntPoint point)
        {
            if (Points.Count != 0)
            {
                Length += point.DistanceTo(Points.Last());
            }
            Points.Add(point);
        }
    }
}
