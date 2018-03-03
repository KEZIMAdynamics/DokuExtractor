using DokuExtractorCore;
using DokuExtractorCore.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DokuExtractorGUI
{
    public partial class frmTableProcessor : Form
    {
        public frmTableProcessor()
        {
            InitializeComponent();
        }

        private void frmTableProcessor_Load(object sender, EventArgs e)
        {
            var processor = new TableProcessor(Path.Combine(Application.StartupPath, "TableFiles"));

            var tableResult = processor.RunDemo();

            var tableArray = new List<List<string>>();

            var columnCount = tableResult.Table.Length / tableResult.Table.GetLength(0);
            var lineCount = tableResult.Table.GetLength(0);

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

            //for (int i = 0; i < tableColumns.Count; i++)
            //{
            //    dataGridView1.Columns.Add(i.ToString(), i.ToString());
            //}

            //dataGridView1.Rows.Add(tableColumns.First());

            var twoD = tableResult.Table;
            int height = twoD.GetLength(0);
            int width = twoD.GetLength(1);

            this.dataGridView1.ColumnCount = width;

            for (int r = 0; r < height; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);

                for (int c = 0; c < width; c++)
                {
                    row.Cells[c].Value = twoD[r, c];
                }

                this.dataGridView1.Rows.Add(row);
            }


            //    dataGridView1.DataSource = tableArray;

        }
    }
}
