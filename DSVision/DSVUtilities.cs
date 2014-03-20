using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DSVision
{
    class DSVUtilities
    {
        public static Bitmap GetBitmapFromUrl(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            return new Bitmap(responseStream);
        }

        public static void SafelySetBitmap(PictureBox display, Bitmap image)
        {
            Bitmap previous = (Bitmap)display.Image;
            display.Image = (Bitmap)image.Clone();
            if (previous != null)
            {
                previous.Dispose();
            }
        }
    }
}
