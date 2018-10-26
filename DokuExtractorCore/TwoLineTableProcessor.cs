using DokuExtractorCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    /// <summary>
    /// Two line table processor
    /// </summary>
    public class TwoLineTableProcessor
    {
        /// <summary>
        /// Runs two line table processor test
        /// </summary>
        public void RunTest()
        {
            string LineTableInbut = @"Pos, EAN Stück/ Listen Nettopreis Pos,
LS/RG 4003318 Bezeichnung Anzahl preis je Stück gesamt";   //Inputstring, 2 lines for the 2linetable call me!!!^^ kkk


            string[] LineTableInbutList = LineTableInbut.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries); //Splits lines into 2 strings
            if (LineTableInbutList.Length > 2)
            {
                Console.WriteLine("To many lines");
            }



            var table1 = new TwoLineTable(LineTableInbutList[1], LineTableInbutList[0]);

            string OldString = "4003318 Bezeichnung";    // User Imput um Lehrzeichen oder OCR Fehler zu Ersetzen
            string NewString = "4003318_Bezeichnung";

            table1 = OcrEmptySpaceReplace(table1, OldString, NewString);
            //  Table1.SecondLine = Table1.OcrEmptySpaceReplace(OldString, NewString)[1].ToString();

            OldString = "je Stück";    // User Imput um Lehrzeichen oder OCR Fehler zu Ersetzen
            NewString = "je_Stück";

            table1 = OcrEmptySpaceReplace(table1, OldString, NewString);
            //Table1.FirstLine = Table1.OcrEmptySpaceReplace(OldString, NewString)[0].ToString();
            //Table1.SecondLine = Table1.OcrEmptySpaceReplace(OldString, NewString)[1].ToString();

            CheckIfNeedEmptySpaceReplace(table1);

            List<List<string>> Final2LineTable = ExtractTwoLineTableLinePairs(table1);
            var bla = ExtractTwoLineTableKeyValues(table1);
        }

        /// <summary>
        /// Extracts two line table key values
        /// </summary>
        /// <param name="twoLineTable"></param>
        /// <returns></returns>
        public Dictionary<string, string> ExtractTwoLineTableKeyValues(TwoLineTable twoLineTable)
        {
            var retVal = new Dictionary<string, string>();

            var linePairs = ExtractTwoLineTableLinePairs(twoLineTable);

            foreach (var item in linePairs)
            {
                var key = item[0];
                var value = item[1];

                while (retVal.ContainsKey(key))
                {
                    key = key + "_1";
                }

                retVal.Add(key, value);

            }

            return retVal;
        }

        /// <summary>
        /// Extracts two line table line pairs
        /// </summary>
        /// <param name="twoLineTable"></param>
        /// <returns></returns>
        public List<List<string>> ExtractTwoLineTableLinePairs(TwoLineTable twoLineTable)   // Erzeugt die List of Lists mit den richtig zugeordneten Elementen
        {
            List<List<string>> TableListOfStrings = new List<List<string>>();
            List<string> First = twoLineTable.FirstLine.Split(' ').ToList();
            List<string> Second = twoLineTable.SecondLine.Split(' ').ToList();
            if (First.Count() == Second.Count())
            {
                for (int i = 0; i < First.Count(); i++)
                {
                    var sublist = new List<string>();
                    sublist.Add(Second[i]);
                    sublist.Add(First[i]);
                    TableListOfStrings.Add(sublist);
                }



                return (TableListOfStrings);
            }
            else
            {
                Console.WriteLine("Need Empty Space Replace");
                return (null);
            }
        }

        /// <summary>
        /// Checks if empty space replace is needed
        /// </summary>
        /// <param name="twoLineTable"></param>
        /// <returns></returns>
        public bool CheckIfNeedEmptySpaceReplace(TwoLineTable twoLineTable) //Checks if need Blankspace(Emptyspace)  
        {
            {
                var emptyspace = ' ';
                var firstWhiteCount = twoLineTable.FirstLine.Count(x => x == emptyspace);
                var secondWhiteCount = twoLineTable.SecondLine.Count(x => x == emptyspace);

                if (firstWhiteCount == secondWhiteCount)
                {
                    Console.WriteLine("Procede with Table");
                    return (true);
                }
                Console.WriteLine("EmptyspaceReplace needed");
                return (false);
            }
        }

        /// <summary>
        /// OCR empty space replace
        /// </summary>
        /// <param name="twoLineTable"></param>
        /// <param name="OldString"></param>
        /// <param name="ReplaceOldString"></param>
        /// <returns></returns>
        public TwoLineTable OcrEmptySpaceReplace(TwoLineTable twoLineTable, string OldString, string ReplaceOldString)  // Either replaces faulty OCR input (save only localy), or removes Emptyspace, so empty space count works and 
        {
            twoLineTable.FirstLine = twoLineTable.FirstLine.Replace(OldString, ReplaceOldString);
            twoLineTable.SecondLine = twoLineTable.SecondLine.Replace(OldString, ReplaceOldString);
            return twoLineTable;
        }
    }
}
