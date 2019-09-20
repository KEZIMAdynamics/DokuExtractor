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
using DokuExtractorCore.Model;
using System.Collections;

namespace DokuExtractorCore
{
    /// <summary>
    /// Can open a PDF file and return its content text
    /// </summary>
    public class PdfTextLoaderFull : WorkingWithPopplerBase, IPdfTextLoaderFull
    {
        public IPdfTextLoaderArea AreaLoader { get; set; } = new PdfTextLoaderArea();

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

        public async Task<List<DataFieldResult>> GetTextFromPdfForPositionalDataFields(string pdfFilePath, List<DataFieldClassTemplate> datafields)
        {
            var retVal = new List<DataFieldResult>();

            if (string.IsNullOrWhiteSpace(pdfFilePath) || File.Exists(pdfFilePath) == false)
                return retVal;

            //  var pdfInfo = await GetPdfPageSize(pdfFilePath);
            //var pdfInfo = await AreaLoader.GetPdfPageSize(pdfFilePath);

            var areaInfoList = datafields.Where(x => x.FieldMode == DataFieldMode.Position).Select(x => x.ValueArea).ToList();

            var textList = await AreaLoader.GetTextFromPdf(pdfFilePath, areaInfoList);

            foreach (var item in datafields)
            {
                if (item.FieldMode == DataFieldMode.Position)
                {
                    var resultItem = new DataFieldResult() { FieldType = item.FieldType, Name = item.Name };
                    //    resultItem.Value = await GetTextFromPdf(pdfFilePath, item.ValueArea);
                    resultItem.Value = textList.First();
                    textList.RemoveAt(0);
                    retVal.Add(resultItem);
                }
            }

            return retVal;
        }

        public async Task<string> GetTextFromPdf(string pdfFilePath, int pageNumber, float percentalLeftX, float percentalTopY, float percentalWidth, float percentalHeigth)
        {
            var cropArea = new PercentalAreaInfo()
            {
                PageNumber = pageNumber,
                TopLeftX = percentalLeftX,
                TopLeftY = percentalTopY,
                Width = percentalWidth,
                Height = percentalHeigth
            };

            return await AreaLoader.GetTextFromPdf(pdfFilePath, cropArea);
        }

        public async Task<string> GetTextFromPdf(string pdfFilePath, PercentalAreaInfo cropAreaInfo)
        {
            return await AreaLoader.GetTextFromPdf(pdfFilePath, cropAreaInfo);
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

            //var pdfToTextPath = Path.Combine(Environment.CurrentDirectory, "bin", "pdftotext.exe");
            var pdfToTextPath = "pdftotext";

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

        //public async Task<PdfPageSizeInfo> GetPdfPageSize(string pdfFilePath)
        //{
        //    var info = await GetPdfInfo(pdfFilePath);

        //    var infos = info.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //    var sizeString = infos.Where(x => x.StartsWith("Page size:")).FirstOrDefault();

        //    var retVal = new PdfPageSizeInfo();
        //    retVal.OriginalSizeString = sizeString;

        //    var splitSize = sizeString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        //    retVal.SizeX = float.Parse(splitSize[2]);
        //    retVal.SizeY = float.Parse(splitSize[4]);
        //    retVal.Unit = splitSize[5];

        //    return retVal;
        //}

        //public async Task<string> GetPdfInfo(string pdfFilePath)
        //{
        //    if (popplerChecked == false)
        //        SupplyPoppler();

        //    var pdfInfoExePath = Path.Combine(Environment.CurrentDirectory, "bin", "pdfinfo.exe");

        //    var pdfProcess = new Process();
        //    pdfProcess.StartInfo.FileName = pdfInfoExePath;
        //    pdfProcess.StartInfo.Arguments = pdfFilePath.EncapsulateInDoubleQuotes();
        //    pdfProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //    pdfProcess.StartInfo.RedirectStandardOutput = true;
        //    pdfProcess.StartInfo.UseShellExecute = false;

        //    //await Task.Run(() => { pdfProcess.Start(); return pdfProcess.StandardOutput.ReadToEnd(); });
        //    pdfProcess.Start();
        //    var retVal = await pdfProcess.StandardOutput.ReadToEndAsync();

        //    return retVal;
        //}

        public string CheckMD5(string filename)
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
