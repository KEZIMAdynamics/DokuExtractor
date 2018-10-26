using DokuExtractorCore.Model.Tables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    /// <summary>
    /// Table Processoner
    /// </summary>
    public class TableProcessor
    {
        string inputFileDirectory;

        /// <summary>
        /// Table Processor
        /// </summary>
        /// <param name="inputFileDirectory"></param>
        public TableProcessor(string inputFileDirectory)
        {
            this.inputFileDirectory = inputFileDirectory;
        }

        /// <summary>
        /// Runs table processor demo
        /// </summary>
        /// <returns></returns>
        public TableResult RunDemo()
        {

            var lines = LoadTableLinesFromFile();
            var columns = LoadTableColumnsFromFile();

            var table = BuildTableFromLinesAndColumns(lines, columns);
            var maxAmountOfItemsPerLineToBeMovedUp = table.TableCountDictionary.Values.Max() / 2;
            table = CleanMultilineTableItems(table, maxAmountOfItemsPerLineToBeMovedUp);

            return table;
        }

        /// <summary>
        /// Loads table lines from file
        /// </summary>
        /// <returns></returns>
        public List<string> LoadTableLinesFromFile()
        {
            var filePath = Path.Combine(inputFileDirectory, "AllTableLines.txt");

            var content = File.ReadAllText(filePath);
            //var lines = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            //return lines.ToList();
            return LoadTableLinesFromString(content);
        }

        /// <summary>
        /// Loads table lines from string
        /// </summary>
        /// <param name="allTableLines"></param>
        /// <returns></returns>
        public List<string> LoadTableLinesFromString(string allTableLines)
        {
            //var filePath = Path.Combine(inputFileDirectory, "AllTableLines.txt");

            //var content = File.ReadAllText(filePath);
            var lines = allTableLines.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return lines.ToList();
        }

        /// <summary>
        /// Loads table columns from file
        /// </summary>
        /// <returns></returns>
        public List<TableColumn> LoadTableColumnsFromFile()
        {
            var retVal = new List<TableColumn>();

            var filePath = Path.Combine(inputFileDirectory, "AllTableColumns.txt");

            var content = File.ReadAllText(filePath);

            return LoadTableColumnsFromString(content);
            //var columns = content.Split("|||".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            //foreach (var item in columns)
            //{
            //    var tableColumn = new TableColumn();

            //    var columnLines = item.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            //    foreach (var line in columnLines)
            //    {
            //        tableColumn.Lines.Add(new TableLine() { Content = line });
            //    }

            //    retVal.Add(tableColumn);
            //}

            //return retVal;
        }

        /// <summary>
        /// Loads table columns from string
        /// </summary>
        /// <param name="allTableColumns"></param>
        /// <returns></returns>
        public List<TableColumn> LoadTableColumnsFromString(string allTableColumns)
        {
            var retVal = new List<TableColumn>();

            //var filePath = Path.Combine(inputFileDirectory, "AllTableColumns.txt");

            //var content = File.ReadAllText(filePath);
            var columns = allTableColumns.Split("|||".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in columns)
            {
                var tableColumn = new TableColumn();

                var columnLines = item.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in columnLines)
                {
                    tableColumn.Lines.Add(new TableLine() { Content = line });
                }

                retVal.Add(tableColumn);
            }

            return retVal;
        }

        /// <summary>
        /// Bilds a table from lines and columns
        /// </summary>
        /// <param name="allTableLines"></param>
        /// <param name="allTableColumns"></param>
        /// <returns></returns>
        public TableResult BuildTableFromLinesAndColumns(List<string> allTableLines, List<TableColumn> allTableColumns)
        {
            int tableWidth = allTableColumns.Count;
            // int tableHeight = allTableColumns.Max(x => x.Lines.Count); // von lines
            int tableHeight = allTableLines.Count;

            var tableMatrix = new string[tableHeight, tableWidth];

            var tableCountDictionary = new Dictionary<int, int>(); // Key: Zahl, Value: Anzahl wie oft die Zahl vorkommt
            var columnCounter = 0;

            for (int i = 0; i < allTableLines.Count; i++)
            {
                allTableLines[i] = " " + allTableLines[i] + " ";
            }

            foreach (var column in allTableColumns) //#column sind die einzelnen spalten bzw. columns der text datei.
            {
                foreach (var columnLine in column.Lines) //# columnLine ist der string einer zeile aus einer spalte
                {
                    for (int i = 0; i < tableHeight; i++) // Zeilenindex 
                    {
                        if (allTableLines[i].Contains(" " + columnLine.Content + " "))
                        {
                            if (tableMatrix[i, columnCounter] == null) // # prüfe auf leeres feld, falls ja schreib eine sache rein, geh zum nächsten
                            {
                                tableMatrix[i, columnCounter] = columnLine.Content;

                                int dictionaryCount;
                                if (tableCountDictionary.TryGetValue(i, out dictionaryCount))
                                {
                                    dictionaryCount++;
                                    tableCountDictionary[i] = dictionaryCount;
                                }
                                else
                                    tableCountDictionary.Add(i, 1);

                                break;
                            }
                        }

                    }


                }

                columnCounter++;
            }

            var retVal = new TableResult();
            retVal.TableCountDictionary = tableCountDictionary;
            retVal.Table = tableMatrix;
            retVal.LineCount = tableHeight;
            retVal.ColumnCount = tableWidth;

            return retVal;
        }

        /// <summary>
        /// Moves items, which span multiple lines, into one line.
        /// </summary>
        /// <param name="tableResult">Table to be modified</param>
        /// <param name="maxAmountOfItemsPerLineToBeMovedUp">Defines the threshold to identify item that span multiple lines. All lines with less items are moved up. Good default value: 1/3 * table width (column count)</param>
        /// <returns></returns>
        public TableResult CleanMultilineTableItems(TableResult tableResult, int maxAmountOfItemsPerLineToBeMovedUp)
        {
            var table = tableResult.Table;

            // Move through columns
            for (int columnCounter = 0; columnCounter < tableResult.ColumnCount; columnCounter++)
            {

                // Move through lines
                for (int lineCounter = 0; lineCounter < tableResult.LineCount; lineCounter++)
                {
                    // Check if the amount of items in this line is small enough to move up the line
                    if (string.IsNullOrEmpty(table[lineCounter, columnCounter]) == false && tableResult.TableCountDictionary[lineCounter] < maxAmountOfItemsPerLineToBeMovedUp)
                    {
                        // Move/bubble up line by line to find the next upwards line to append content to
                        for (int nextUpperOccupiedLineCounter = 0; nextUpperOccupiedLineCounter < table.GetLength(0); nextUpperOccupiedLineCounter++)
                        {
                            if (lineCounter - nextUpperOccupiedLineCounter - 1 >= 0)
                            {
                                if (string.IsNullOrEmpty(table[lineCounter - nextUpperOccupiedLineCounter - 1, columnCounter]) == false)
                                {
                                    table[lineCounter - nextUpperOccupiedLineCounter - 1, columnCounter] = table[lineCounter - nextUpperOccupiedLineCounter - 1, columnCounter] + " hihihi -.- " + table[lineCounter, columnCounter];
                                    table[lineCounter, columnCounter] = null;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return tableResult;
        }

        /// <summary>
        /// Converts a table that is based on a two dimensional string-array/matrix to a list of TableColumns. Empty column lines are NOT removed, so the table structure stays intact.
        /// </summary>
        /// <param name="tableResult"></param>
        /// <returns></returns>
        public List<TableColumn> Convert2dTableToListOfTableColumns(TableResult tableResult)
        {
            var tableArray = new List<List<string>>();

            var columnCount = tableResult.ColumnCount; //.Table.Length / tableResult.Table.GetLength(0);
            var lineCount = tableResult.LineCount; //Table.GetLength(0);

            var tableColumns = new List<TableColumn>();
            for (int lines = 0; lines < lineCount; lines++)

            {
                var printString = "";
                var lineItems = new List<string>();
                var tableColumnLines = new List<TableLine>();
                for (int columns = 0; columns < columnCount; columns++)
                {
                    printString += "|||" + tableResult.Table[lines, columns];
                    lineItems.Add(tableResult.Table[lines, columns]);
                    tableColumnLines.Add(new TableLine() { Content = tableResult.Table[lines, columns] });
                }
                Debug.Print(printString);
                tableArray.Add(lineItems);
                tableColumns.Add(new TableColumn() { Lines = tableColumnLines });
            }

            Debug.Print(tableArray.ToString());

            return tableColumns;
        }
    }
}
