using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    public class PdfRenderer : WorkingWithPopplerBase, IPdfRenderer
    {
        public async Task RenderPdfToPngs(string pdfFilePath, string pdfImagesPath)
        {
            if (popplerChecked == false)
                SupplyPoppler();

            var pdfFileInfo = new FileInfo(pdfFilePath);

            var pdfToPpmPath = Path.Combine(Environment.CurrentDirectory, "bin", "pdftoppm.exe");

            var ppmProcess = new Process();
            ppmProcess.StartInfo.FileName = pdfToPpmPath;
            ppmProcess.StartInfo.Arguments = "-png " + "\"" + pdfFilePath + "\"" + " " + "\"" + Path.Combine(pdfImagesPath, pdfFileInfo.Name) + "\"";
            ppmProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            var watch = new Stopwatch();
            watch.Start();
            ppmProcess.Start();

            await ppmProcess.WaitForExitAsync();

            watch.Stop();

            Debug.Print("Render time: " + watch.Elapsed);
        }
    }
}
