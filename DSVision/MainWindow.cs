using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSVision
{
    public partial class MainWindow : Form
    {
        public MainWindow(Bitmap bmp)
        {
            InitializeComponent();

            picture.Image = bmp;
        }
    }
}
