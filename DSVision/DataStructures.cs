using AForge;
using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSVision
{
    struct ProcessedBlob
    {
        public Blob Blob;
        public List<IntPoint> Edges;
        public List<IntPoint> Hull;
        public Vector4 Bounds;

        public ProcessedBlob(Blob blob, List<IntPoint> edges, 
            List<IntPoint> hull, Vector4 bounds)
        {
            Blob = blob;
            Edges = edges;
            Hull = hull;
            Bounds = bounds;
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
}
