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

namespace KezimaPdfViewer
{
    public partial class ucKezimaPdfViewer : ucViewerBase
    {
        private int activePageIndex = 0;

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
            var pdfTextLoader = new PdfTextLoader();
            var hashwert = pdfTextLoader.CheckMD5(pdfPath);

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
                await pdfTextLoader.RenderPdfToPngs(pdfPath, pdfImagesPath);

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
                    var previousActiveBox = flowLayoutPanel1.Controls[activePageIndex] as PictureBox;
                    previousActiveBox.BackColor = Color.Black;
                }
                catch (Exception ex)
                { }

                imageViewer.BackColor = Color.LightBlue;
                activePageIndex = int.Parse(imageViewer.Tag.ToString());

                var pagePath = imageViewer.ImagePath;
                pictureBox1.Image = Image.FromFile(pagePath);
            }
        }
    }
}
