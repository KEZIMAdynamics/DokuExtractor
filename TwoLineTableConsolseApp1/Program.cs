using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoLineTableConsolseApp1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            string LineTableInbut = @"Pos, EAN Stück/ Listen Nettopreis Nenowen
LS/RG 4003318 Bezeichnung Anzahl preis je Stück gesamt";   //Inputstring, 2 lines for the 2linetable



            string[] LineTableInbutList = LineTableInbut.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries); //Splits lines into 2 strings
            if (LineTableInbutList.Length > 2)
            {
                Console.WriteLine("To many lines");
            }

            The2LineTable Table1 = new The2LineTable(LineTableInbutList[1], LineTableInbutList[0]);

            string OldString = "4003318 Bezeichnung";    // User Imput um Lehrzeichen oder OCR Fehler zu Ersetzen
            string NewString = "4003318_Bezeichnung";

            Table1.FirstLine = Table1.OcrEmptySpaceReplace(OldString, NewString)[0].ToString();
            Table1.SecondLine = Table1.OcrEmptySpaceReplace(OldString, NewString)[1].ToString();

            OldString = "je Stück";    // User Imput um Lehrzeichen oder OCR Fehler zu Ersetzen
            NewString = "je_Stück";

            Table1.FirstLine = Table1.OcrEmptySpaceReplace(OldString, NewString)[0].ToString();
            Table1.SecondLine = Table1.OcrEmptySpaceReplace(OldString, NewString)[1].ToString();




            Table1.CheckIfNeedEmptySpaceReplace();

            List<List<string>> Final2LineTable = Table1.The2LineTableheart();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
