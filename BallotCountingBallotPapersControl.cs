using com.hz.epollbook.datasource.business;
using DataGridViewRichTextBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class BallotCountingBallotPapersControl : Form
    {
        

        string rtfTemplate1 = @"{\rtf1
{\fonttbl 
	{\f0 Arial;}
}
{\colortbl
	;
	\red255\green0\blue0;
	\red0\green0\blue255;
	\red255\green255\blue255;
	\red0\green0\blue0;
}
\sb120\qc\f0\fs24 {0} \f0\fs24\cf1 {1}
}";

    
        BallotCountingBallotPapersBusiness business = new BallotCountingBallotPapersBusiness();
        public BallotCountingBallotPapersControl()
        {
            InitializeComponent();

            dgvBallotUsages.DataSource = business.BallotUsages;
            dgvBallotUsages.DataBindingComplete += DgvBallotUsages_DataBindingComplete;
            


        }

        private void DgvBallotUsages_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvBallotUsages.AllowUserToAddRows = false;
            dgvBallotUsages.AllowUserToDeleteRows = false;
            dgvBallotUsages.AllowUserToResizeColumns = false;
            dgvBallotUsages.AllowUserToResizeRows = false;
            dgvBallotUsages.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dgvBallotUsages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvBallotUsages.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dgvBallotUsages.BorderStyle = BorderStyle.None;
            dgvBallotUsages.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvBallotUsages.RowHeadersVisible = false;
            dgvBallotUsages.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvBallotUsages.Columns.Remove("ExpectedRemaining");
            dgvBallotUsages.Columns.Remove("DiffOfExpectToRealRemaining");
            var column = new DataGridViewRichTextBoxColumn();
            dgvBallotUsages.Columns.Add(column);
           

            dgvBallotUsages.Columns[0].HeaderText = "";
            dgvBallotUsages.Columns[1].HeaderText = "Allocated by Supervisor";
            dgvBallotUsages.Columns[2].HeaderText = "";
            dgvBallotUsages.Columns[3].HeaderText = "Spoiled";
            dgvBallotUsages.Columns[4].HeaderText = "";
            dgvBallotUsages.Columns[5].HeaderText = "Issued to voters";
            dgvBallotUsages.Columns[6].HeaderText = "";
            dgvBallotUsages.Columns[7].HeaderText = "Expected remaining(staff)";

            dgvBallotUsages.Columns[0].Width = 214;
            dgvBallotUsages.Columns[1].Width = 218;
            dgvBallotUsages.Columns[2].Width = 30;
            dgvBallotUsages.Columns[3].Width = 180;
            dgvBallotUsages.Columns[4].Width = 30;
            dgvBallotUsages.Columns[5].Width = 150;
            dgvBallotUsages.Columns[6].Width = 30;
            dgvBallotUsages.Columns[7].Width = 210;



            for (int i = 0; i < business.BallotUsages.Count; i++)
            {
                string value = rtfTemplate1.Replace("{0}", business.BallotUsages[i].ExpectedRemaining + "");
                if (business.BallotUsages[i].DiffOfExpectToRealRemaining > 0)
                {
                    value = value.Replace("{1}", "(+" + business.BallotUsages[i].DiffOfExpectToRealRemaining + ")");
                }
                else if (business.BallotUsages[i].DiffOfExpectToRealRemaining < 0)
                {
                    value = value.Replace("{1}", "(" + business.BallotUsages[i].DiffOfExpectToRealRemaining + ")");
                }
                else
                {
                    value = value.Replace("{1}", "");
                }

                dgvBallotUsages[7, i].Value = value;
            }


            for (int i = 0; i < dgvBallotUsages.RowCount; i++)
                dgvBallotUsages.Rows[i].Height = 34;


            var width = dgvBallotUsages.Columns.GetColumnsWidth(DataGridViewElementStates.None);
            var height = dgvBallotUsages.Rows.GetRowsHeight(DataGridViewElementStates.None);

            dgvBallotUsages.Size = new Size(width + dgvBallotUsages.RowHeadersWidth + 30, height + dgvBallotUsages.ColumnHeadersHeight + 30);

            System.Windows.Forms.DataGridViewCellStyle headerRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerRowStyle.BackColor = System.Drawing.Color.FromArgb(228, 228, 228);
            headerRowStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            dgvBallotUsages.ColumnHeadersDefaultCellStyle = headerRowStyle;
            dgvBallotUsages.ColumnHeadersHeight = 34;

            System.Windows.Forms.DataGridViewCellStyle normalRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            normalRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            normalRowStyle.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            normalRowStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            normalRowStyle.SelectionForeColor = normalRowStyle.ForeColor;
            normalRowStyle.SelectionBackColor = normalRowStyle.BackColor;
            normalRowStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);

            for (int i = 0; i < dgvBallotUsages.RowCount -1; i++)
            {
                dgvBallotUsages.Rows[i].DefaultCellStyle = normalRowStyle;
            }

            System.Windows.Forms.DataGridViewCellStyle lastRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            lastRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            lastRowStyle.BackColor = System.Drawing.Color.FromArgb(228, 228, 228);
            lastRowStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            lastRowStyle.SelectionForeColor = lastRowStyle.ForeColor;
            lastRowStyle.SelectionBackColor = lastRowStyle.BackColor;
            dgvBallotUsages.Rows[dgvBallotUsages.Rows.Count-1].DefaultCellStyle = lastRowStyle;


            System.Windows.Forms.DataGridViewCellStyle totalCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            totalCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            totalCellStyle.BackColor = System.Drawing.Color.FromArgb(228, 228, 228);
            totalCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            totalCellStyle.SelectionForeColor = totalCellStyle.ForeColor;
            totalCellStyle.SelectionBackColor = totalCellStyle.BackColor;
            dgvBallotUsages.Rows[dgvBallotUsages.Rows.Count - 1].Cells[0].Style = totalCellStyle;
        }
    }
}
