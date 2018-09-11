using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace KezimaPdfViewer
{
    public partial class ucImageViewerForThumbnail : PictureBox
    {
        public string ImagePath { get; set; } = string.Empty;
        private Bitmap thumbnailImage;

        public ucImageViewerForThumbnail()
        {
            InitializeComponent();
        }

        public void LoadImage(string imageFilename, int width, int height)
        {
            Image tempImage = Image.FromFile(imageFilename);

            int dw = tempImage.Width;
            int dh = tempImage.Height;
            int tw = width;
            int th = height;
            double zw = (tw / (double)dw);
            double zh = (th / (double)dh);
            double z = (zw <= zh) ? zw : zh;
            dw = (int)(dw * z);
            dh = (int)(dh * z);

            thumbnailImage = new Bitmap(dw, dh);
            Graphics g = Graphics.FromImage(thumbnailImage);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(tempImage, 0, 0, dw, dh);
            g.Dispose();

            tempImage.Dispose(); // do not forget to dispose and don't wait for GC
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (g == null) return;

            int dw = thumbnailImage.Width;
            int dh = thumbnailImage.Height;
            int tw = this.Width;
            int th = this.Height;
            double zw = (tw / (double)dw);
            double zh = (th / (double)dh);
            double z = (zw <= zh) ? zw : zh;

            dw = (int)(dw * z);
            dh = (int)(dh * z);
            int dl = (tw - dw) / 2;
            int dt = (th - dh) / 2;

            g.DrawImage(thumbnailImage, dl, dt, dw, dh);
        }
    }
}
