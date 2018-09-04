using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using DokuExtractorCore.Model.PdfHelper;

namespace DokuExtractorCore
{
    /// <summary>
    /// Can open a PDF file and return its content text
    /// </summary>
    public class PdfTextLoader
    {
        private bool popplerChecked;

        /// <summary>
        /// Reads the content text from a PDF file and returns it. The text layout is preserved.
        /// </summary>
        /// <param name="pdfFilePath">Full name of PDF file</param>
        /// <param name="useMd5Cache">Keep extracted text files cached to improve performance if a PDF text is extracted more than one time. Reference between PDFs and text files is kept via the PDF's MD5-hash.</param>
        /// <returns></returns>
        public async Task<string> GetTextFromPdf(string pdfFilePath, bool useMd5Cache)
        {
            return await GetTextFromPdf(pdfFilePath, useMd5Cache, "-layout ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pdfFilePath"></param>
        /// <param name="useMd5Cache"></param>
        /// <param name="cropAreaX">Percentual X-Coordinate of the area which is to be extracted.</param>
        /// <param name="cropAreaY">Percentual Y-Coordinate of the area which is to be extracted.</param>
        /// <param name="cropAreaWdith">Percentual width of the area which is to be extracted.</param>
        /// <param name="cropAreaHeight">Percentual height of the area which is to be extracted.</param>
        /// <returns></returns>
        public async Task<string> GetTextFromPdf(string pdfFilePath, PercentalCropAreaInfo cropAreaInfo)
        {
            var pdfInfo = await GetPdfPageSize(pdfFilePath);
            var x = (int)Math.Round(cropAreaInfo.TopLeftX / 100 * pdfInfo.SizeX, 0);
            var y = (int)Math.Round(cropAreaInfo.TopLeftY / 100 * pdfInfo.SizeY, 0);
            var W = (int)Math.Round(cropAreaInfo.Width / 100 * pdfInfo.SizeX, 0);
            var H = (int)Math.Round(cropAreaInfo.Height / 100 * pdfInfo.SizeY, 0);

            var pdfToTextOptions = " -f " + cropAreaInfo.PageNumber + " -l " + cropAreaInfo.PageNumber + " -x " + x + " -y " + y + " -W " + W + " -H " + H + " -layout ";

            var retVal = await GetTextFromPdf(pdfFilePath, false, pdfToTextOptions);
            return retVal;
        }

        private async Task<string> GetTextFromPdf(string pdfFilePath, bool useMd5Cache, string pdfToTextOptions)
        {
            if (popplerChecked == false)
                SupplyPoppler();

            var pdfInfo = new FileInfo(pdfFilePath);
            var targetFilePath = pdfFilePath + ".txt";

            if (useMd5Cache)
            {
                var hash = CheckMD5(pdfFilePath);
                var hashPath = Path.Combine(pdfInfo.DirectoryName, hash + ".txt");

                if (File.Exists(hashPath))
                    return File.ReadAllText(hashPath);
                else
                    targetFilePath = hashPath;
            }

            var pdfToTextPath = Path.Combine(Environment.CurrentDirectory, "bin", "pdftotext.exe");

            var pdfProcess = new Process();
            pdfProcess.StartInfo.FileName = pdfToTextPath;
            pdfProcess.StartInfo.Arguments = pdfToTextOptions + pdfFilePath.EncapsulateInDoubleQuotes() + " " + targetFilePath.EncapsulateInDoubleQuotes();
            pdfProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            var watch = new Stopwatch();
            watch.Start();
            pdfProcess.Start();
            await pdfProcess.WaitForExitAsync();
            watch.Stop();

            Debug.Print("Extraction time: " + watch.Elapsed);

            var retVal = File.ReadAllText(targetFilePath);

            if (useMd5Cache == false)
                File.Delete(targetFilePath);

            return retVal;
        }

        public async Task<PdfPageSizeInfo> GetPdfPageSize(string pdfFilePath)
        {
            var info = await GetPdfInfo(pdfFilePath);

            var infos = info.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var sizeString = infos.Where(x => x.StartsWith("Page size:")).FirstOrDefault();

            var retVal = new PdfPageSizeInfo();
            retVal.OriginalSizeString = sizeString;

            var splitSize = sizeString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            retVal.SizeX = float.Parse(splitSize[0]);
            retVal.SizeX = float.Parse(splitSize[2]);
            retVal.Unit = splitSize[3];

            return retVal;
        }

        public async Task<string> GetPdfInfo(string pdfFilePath)
        {
            if (popplerChecked == false)
                SupplyPoppler();

            var pdfInfoExePath = Path.Combine(Environment.CurrentDirectory, "bin", "pdftotext.exe");

            var pdfProcess = new Process();
            pdfProcess.StartInfo.FileName = pdfInfoExePath;
            pdfProcess.StartInfo.Arguments = pdfFilePath.EncapsulateInDoubleQuotes();
            pdfProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pdfProcess.StartInfo.RedirectStandardOutput = true;
            pdfProcess.StartInfo.UseShellExecute = false;

            //await Task.Run(() => { pdfProcess.Start(); return pdfProcess.StandardOutput.ReadToEnd(); });
            pdfProcess.Start();
            var retVal = await pdfProcess.StandardOutput.ReadToEndAsync();

            return retVal;
        }

        private string CheckMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                }
            }
        }

        private void SupplyPoppler()
        {
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "bin", "pdftotext.exe")) == false)
            {
                ZipFile.ExtractToDirectory(Path.Combine(Directories.PopplerZipPath, "poppler-0.51.zip"), Path.Combine(Environment.CurrentDirectory));
            }
            popplerChecked = true;
        }
    }
}
