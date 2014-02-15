using AForge;
using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSVision
{
    struct ProcessedBlob
    {
        public Blob Blob;
        public List<IntPoint> Edges;
        public List<IntPoint> Hull;
        public Vector4 Bounds;
        public ApproximateLine[] Lines;

        public ProcessedBlob(Blob blob, List<IntPoint> edges, 
            List<IntPoint> hull, Vector4 bounds, ApproximateLine[] lines)
        {
            Blob = blob;
            Edges = edges;
            Hull = hull;
            Bounds = bounds;
            Lines = lines;
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
