using DokuExtractorCore.Model;
using DokuExtractorCore.Model.PdfHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    public class PdfTextLoaderArea : WorkingWithPopplerBase, IPdfTextLoaderArea
    {
        /// <summary>
        /// Gets text from a PDF based that is within a given area.
        /// </summary>
        /// <param name="pdfFilePath">PDF location on disk.</param>
        /// <param name="cropAreaInfo">Percentual area which is to be extracted.</param>
        /// <returns></returns>
        public async Task<string> GetTextFromPdf(string pdfFilePath, PercentalAreaInfo cropAreaInfo)
        {
            var pdfInfo = await GetPdfPageSize(pdfFilePath);
            return await GetTextFromPdf(pdfFilePath, cropAreaInfo, pdfInfo);
        }

        /// <summary>
        /// Gets text from a PDF based that is within a given areas.
        /// </summary>
        /// <param name="pdfFilePath">PDF location on disk.</param>
        /// <param name="cropAreaInfos">Percentual areas which is to be extracted.</param>
        /// <returns></returns>
        public async Task<List<string>> GetTextFromPdf(string pdfFilePath, List<PercentalAreaInfo> cropAreaInfos)
        {
            var retVal = new List<string>();
            var pdfInfo = await GetPdfPageSize(pdfFilePath);

            foreach (var cropArea in cropAreaInfos)
            {
                var text = await GetTextFromPdf(pdfFilePath, cropArea, pdfInfo);
                retVal.Add(text);
            }

            return retVal;
        }

        /// <summary>
        /// Gets text from a PDF based that is within a given area.
        /// </summary>
        /// <param name="pdfFilePath">PDF location on disk.</param>
        /// <param name="cropAreaInfo">Percentual area which is to be extracted.</param>
        /// <param name="pdfPageSizeInfo">Size information of the PDF file. Used to calculate absolute area from percental area.</param>
        /// <returns></returns>
        public async Task<string> GetTextFromPdf(string pdfFilePath, PercentalAreaInfo cropAreaInfo, PdfPageSizeInfo pdfPageSizeInfo)
        {
            var pdfInfo = pdfPageSizeInfo;
            var x = (int)Math.Round(cropAreaInfo.TopLeftX * pdfInfo.SizeX, 0);
            var y = (int)Math.Round(cropAreaInfo.TopLeftY * pdfInfo.SizeY, 0);
            var W = (int)Math.Round(cropAreaInfo.Width * pdfInfo.SizeX, 0);
            var H = (int)Math.Round(cropAreaInfo.Height * pdfInfo.SizeY, 0);

            var pdfToTextOptions = " -f " + cropAreaInfo.PageNumber + " -l " + cropAreaInfo.PageNumber + " -x " + x + " -y " + y + " -W " + W + " -H " + H + " -layout -nopgbrk ";

            var retVal = await GetTextFromPdf(pdfFilePath, false, pdfToTextOptions);

            // Remove last line break, as it is added by poppler and does not represent the selected area
            if (retVal.Length > 1)
                retVal = retVal.Remove(retVal.Length - 2);

            if (retVal is null)
                retVal = string.Empty;

            return retVal;
        }

        private async Task<PdfPageSizeInfo> GetPdfPageSize(string pdfFilePath)
        {
            var info = await GetPdfInfo(pdfFilePath);

            var infos = info.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var sizeString = infos.Where(x => x.StartsWith("Page size:")).FirstOrDefault();

            var retVal = new PdfPageSizeInfo();
            retVal.OriginalSizeString = sizeString;

            var splitSize = sizeString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            retVal.SizeX = float.Parse(splitSize[2].Replace('.',','), new System.Globalization.CultureInfo("de-DE"));
            retVal.SizeY = float.Parse(splitSize[4].Replace('.',','), new System.Globalization.CultureInfo("de-DE"));
            retVal.Unit = splitSize[5];

            return retVal;
        }

        private async Task<string> GetPdfInfo(string pdfFilePath)
        {
            if (popplerChecked == false)
                SupplyPoppler();

            var pdfInfoExePath = Path.Combine(Environment.CurrentDirectory, "bin", "pdfinfo.exe");

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


    }
}
