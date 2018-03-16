using DokuExtractorCore.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DokuExtractorTableGUI
{
    public partial class frmTableViewer : Form
    {
        public frmTableViewer()
        {
            InitializeComponent();
        }

        public void ShowTable(TableResult tableResult)
        {
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

                if (row != null && row.Index != -1)
                    this.dataGridView1.Rows.Add(row);
            }
        }
    }
}
