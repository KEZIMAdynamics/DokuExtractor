using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Threading;
using DokuExtractorStandardGUI.UserControls;
using DokuExtractorCore;
using System.Drawing.Drawing2D;
using DokuExtractorCore.Model.PdfHelper;

namespace KezimaPdfViewer
{
    public partial class ucKezimaPdfViewer : ucViewerBase
    {
        public IPdfTextLoader PdfTextLoader { get; set; } = new PdfTextLoader();

        private int activePageIndex = 0;
        private Point lastPoint = Point.Empty;
        private bool isMouseDown = false;

        private Image imageWithoutDrawing;
        private DateTime lastMouseMove = DateTime.Now;

        private string pdfPath = string.Empty;

        public ucKezimaPdfViewer()
        {
            InitializeComponent();

            var dexTempPath = Path.Combine(Application.StartupPath, "DexPdfTemp");
            if (Directory.Exists(dexTempPath))
            {
                try
                {
                    foreach (var dir in Directory.GetDirectories(dexTempPath))
                    {
                        try
                        {
                            foreach (var file in Directory.GetFiles(dir))
                            {
                                File.Delete(file);
                            }
                            Directory.Delete(dir);
                        }
                        catch (Exception ex)
                        { }
                    }
                    Directory.Delete(dexTempPath);
                }
                catch (Exception ex)
                { }
            }
        }

        public override void CloseDisplayedPdf()
        {
            var flowLayoutControls = flowLayoutPanel1.Controls.Cast<Control>().ToList();
            foreach (Control control in flowLayoutControls)
            {
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            }

            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();

            pictureBox1.Image = null;
        }

        public override async Task LoadPdf(string pdfPath)
        {
            this.pdfPath = pdfPath;

            //var pdfTextLoader = new PdfTextLoader();
            var hashwert = PdfTextLoader.CheckMD5(pdfPath);

            var dexTempPath = Path.Combine(Application.StartupPath, "DexPdfTemp");
            if (Directory.Exists(dexTempPath) == false)
            {
                var dir = Directory.CreateDirectory(dexTempPath);
                dir.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            var pdfImagesPath = Path.Combine(dexTempPath, hashwert);
            if (Directory.Exists(pdfImagesPath) == false)
            {
                var dir = Directory.CreateDirectory(pdfImagesPath);
                dir.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            if (Directory.GetFiles(pdfImagesPath)?.Count() == 0)
                await PdfTextLoader.RenderPdfToPngs(pdfPath, pdfImagesPath);

            CloseDisplayedPdf();

            foreach (var file in Directory.GetFiles(pdfImagesPath))
            {
                AddPageToThumbnailViewer(file);
            }

            var firstPage = flowLayoutPanel1.Controls[0] as PictureBox;
            ImageViewer_Click(firstPage, null);
        }

        private void AddPageToThumbnailViewer(string pagePath)
        {
            var imageViewer = new ucImageViewerForThumbnail();
            //imageViewer.Image = Image.FromFile(pagePath);
            //imageViewer.Image.Tag = pagePath;
            imageViewer.LoadImage(pagePath, 128, 128);
            imageViewer.ImagePath = pagePath;
            imageViewer.SizeMode = PictureBoxSizeMode.Zoom;
            imageViewer.Dock = DockStyle.Bottom;
            imageViewer.Height = 128;
            imageViewer.Width = 128;
            imageViewer.Tag = flowLayoutPanel1.Controls.Count;
            imageViewer.BackColor = Color.Black;
            flowLayoutPanel1.Controls.Add(imageViewer);
            imageViewer.Click += ImageViewer_Click;
        }

        private void ImageViewer_Click(object sender, EventArgs e)
        {
            var imageViewer = sender as ucImageViewerForThumbnail;
            if (imageViewer != null)
            {
                try
                {
                    var previousActiveBox = flowLayoutPanel1.Controls[activePageIndex] as ucImageViewerForThumbnail;
                    previousActiveBox.BackColor = Color.Black;
                }
                catch (Exception ex)
                { }

                imageViewer.BackColor = Color.LightBlue;
                activePageIndex = int.Parse(imageViewer.Tag.ToString());

                var pagePath = imageViewer.ImagePath;
                pictureBox1.Image = Image.FromFile(pagePath);
                imageWithoutDrawing = Image.FromFile(pagePath);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = GetPointOnImage(e.Location);
            isMouseDown = true;
        }

        private async void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;

            if (string.IsNullOrWhiteSpace(this.pdfPath) == false)
            {
                var rect = GetRectangleOnImageFromLastPoint(e.Location);

                var crop = new PercentalCropAreaInfo()
                {
                    PageNumber = activePageIndex,
                    TopLeftX = (float)(rect.X) / (float)(pictureBox1.Image.Width),
                    TopLeftY = (float)(rect.Y) / (float)(pictureBox1.Image.Height),
                    Height = (float)(rect.Height) / (float)(pictureBox1.Image.Height),
                    Width = (float)(rect.Width) / (float)(pictureBox1.Image.Width)
                };

                var rectText = await PdfTextLoader.GetTextFromPdf(pdfPath, crop);
                MessageBox.Show(rectText);
            }

            lastPoint = Point.Empty;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true && lastPoint != null)
            {
                if ((DateTime.Now - lastMouseMove).TotalMilliseconds > 30)
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = imageWithoutDrawing.Clone() as Image;

                        using (var g = Graphics.FromImage(pictureBox1.Image))
                        {
                            var thisPoint = GetPointOnImage(e.Location);
                            var pen = new Pen(Color.Black, 2);

                            try
                            {
                                g.DrawRectangle(pen, GetRectangleOnImageFromLastPoint(e.Location));
                            }
                            catch (Exception ex)
                            { }
                        }

                        pictureBox1.Invalidate();
                        //lastPoint = GetPointOnImage(e.Location);
                    }
                    lastMouseMove = DateTime.Now;
                }
            }
        }

        private Point GetPointOnImage(Point location)
        {
            var retVal = location;

            float relation = 1;

            if (AreStripesLeftAndRight() == true)
            {
                if (pictureBox1.Image != null)
                    relation = (float)(pictureBox1.Image.Size.Height) / (float)(pictureBox1.Height);

                var blackStripe = ((pictureBox1.Width * relation) - pictureBox1.Image.Width) / 2;

                retVal.X = (int)((Math.Round((float)(location.X) * relation) - blackStripe));
                retVal.Y = (int)(Math.Round((float)(location.Y) * relation));
            }
            else
            {
                if (pictureBox1.Image != null)
                    relation = (float)(pictureBox1.Image.Size.Width) / (float)(pictureBox1.Width);

                var blackStripe = ((pictureBox1.Height * relation) - pictureBox1.Image.Height) / 2;

                retVal.X = (int)((Math.Round((float)(location.X) * relation)));
                retVal.Y = (int)(Math.Round((float)(location.Y) * relation) - blackStripe);
            }

            return retVal;
        }

        private bool AreStripesLeftAndRight()
        {
            var retVal = true;

            var pbWidthHeightRatio = (float)(pictureBox1.Width) / (float)(pictureBox1.Height);
            var imgWidthHeightRatio = (float)(pictureBox1.Image.Width) / (float)(pictureBox1.Image.Height);

            if (imgWidthHeightRatio >= pbWidthHeightRatio)
                retVal = false;

            return retVal;
        }

        private Rectangle GetRectangleOnImageFromLastPoint(Point mousePoint)
        {
            var retVal = new Rectangle();

            var mousePointOnImage = GetPointOnImage(mousePoint);

            var width = mousePointOnImage.X - lastPoint.X;
            var height = mousePointOnImage.Y - lastPoint.Y;

            if (width >= 0 && height >= 0)
                retVal = new Rectangle(lastPoint.X, lastPoint.Y, width, height);
            else if (width >= 0 && height < 0)
                retVal = new Rectangle(lastPoint.X, lastPoint.Y + height, width, -height);
            else if (width < 0 && height >= 0)
                retVal = new Rectangle(lastPoint.X + width, lastPoint.Y, -width, height);
            else if (width < 0 && height < 0)
                retVal = new Rectangle(lastPoint.X + width, lastPoint.Y + height, -width, -height);

            return retVal;
        }
    }
}
