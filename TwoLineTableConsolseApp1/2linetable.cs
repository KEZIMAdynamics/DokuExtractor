using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoLineTableConsolseApp1
{
    public class The2LineTable
    {
        public The2LineTable(string FirstLine, string SecondLine)     // Constructor with FirstLine and SecondLine 
        {
            this.FirstLine = FirstLine;
            this.SecondLine = SecondLine;
        }
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }


        public List<List<string>> The2LineTableheart()   // Erzeugt die List of Lists mit den richtig zugeordneten Elementen
        {
            List<List<string>> TableListOfStrings = new List<List<string>>();
            List<string> First = this.FirstLine.Split(' ').ToList();
            List<string> Second = this.SecondLine.Split(' ').ToList();
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



        public Boolean CheckIfNeedEmptySpaceReplace() //Checks if need Blankspace(Emptyspace)  
        {
            {
                var emptyspace = ' ';
                var firstWhiteCount = this.FirstLine.Count(x => x == emptyspace);
                var secondWhiteCount = this.SecondLine.Count(x => x == emptyspace);

                if (firstWhiteCount == secondWhiteCount)
                {
                    Console.WriteLine("Procede with Table");
                    return (true);
                }
                Console.WriteLine("EmptyspaceReplace needed");
                return (false);
            }
        }

        public List<string> OcrEmptySpaceReplace(string OldString, string ReplaceOldString)  // Either replaces faulty OCR input (save only localy), or removes Emptyspace, so empty space count works and 
        {
            List<string> retval = new List<string>();
            {

                string First = this.FirstLine.Replace(OldString, ReplaceOldString);
                string Second = this.SecondLine.Replace(OldString, ReplaceOldString);
                retval.Add(First);
                retval.Add(Second);
            }
            return retval;
        }
    }
}
