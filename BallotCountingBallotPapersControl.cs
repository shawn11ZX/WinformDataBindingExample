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

namespace ECQ.ePollbook.UI
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

            BindingSource staffDataSource = new BindingSource();
            staffDataSource.DataSource = business.BallotRemainingOfStaffs;
            dgvBallotRemainingOfStaff.DataSource = staffDataSource;
            dgvBallotRemainingOfStaff.DataBindingComplete += DgvBallotRemainingOfStaff_DataBindingComplete;


            BindingSource boothDataSource = new BindingSource();
            boothDataSource.DataSource = business.BallotRemainingOfBooths;
            dgvBallotRemainingOfBooth.DataSource = boothDataSource;
            dgvBallotRemainingOfBooth.DataBindingComplete += DgvBallotRemainingOfBooth_DataBindingComplete;

        }

        private void DgvBallotRemainingOfBooth_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            InitializeDgvBallotRemainingOfBooth();
        }

        private void DgvBallotRemainingOfStaff_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            InitializeDgvBallotRemainingOfStaff();
        }

        private void InitializeDgvBallotRemainingOfStaff()
        {
            DataGridView dgv = dgvBallotRemainingOfStaff;
            // call this first, otherwise row count might not correct
            InitializeDataGridViewOverallStyle(dgv);
            dgv.Columns.Remove("ExpectedRemaining");
            dgv.Columns.Remove("DiffOfExpectToRealRemaining");
            var column = new DataGridViewRichTextBoxColumn();
            dgv.Columns.Add(column);


            dgv.Columns[0].HeaderText = "";
            dgv.Columns[1].HeaderText = "Allocated by Supervisor";
            dgv.Columns[2].HeaderText = "";
            dgv.Columns[3].HeaderText = "Spoiled";
            dgv.Columns[4].HeaderText = "";
            dgv.Columns[5].HeaderText = "Issued to voters";
            dgv.Columns[6].HeaderText = "";
            dgv.Columns[7].HeaderText = "Expected remaining(staff)";

            dgv.Columns[0].Width = 214;
            dgv.Columns[1].Width = 218;
            dgv.Columns[2].Width = 30;
            dgv.Columns[3].Width = 180;
            dgv.Columns[4].Width = 30;
            dgv.Columns[5].Width = 150;
            dgv.Columns[6].Width = 30;
            dgv.Columns[7].Width = 210;

            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[1].ReadOnly = true;
            dgv.Columns[2].ReadOnly = true;
            dgv.Columns[3].ReadOnly = true;
            dgv.Columns[4].ReadOnly = true;
            dgv.Columns[5].ReadOnly = true;
            dgv.Columns[6].ReadOnly = true;
            dgv.Columns[7].ReadOnly = true;



            for (int i = 0; i < business.BallotRemainingOfStaffs.Count; i++)
            {
                string value = rtfTemplate1.Replace("{0}", business.BallotRemainingOfStaffs[i].ExpectedRemaining + "");
                if (business.BallotRemainingOfStaffs[i].DiffOfExpectToRealRemaining > 0)
                {
                    value = value.Replace("{1}", "(+" + business.BallotRemainingOfStaffs[i].DiffOfExpectToRealRemaining + ")");
                }
                else if (business.BallotRemainingOfStaffs[i].DiffOfExpectToRealRemaining < 0)
                {
                    value = value.Replace("{1}", "(" + business.BallotRemainingOfStaffs[i].DiffOfExpectToRealRemaining + ")");
                }
                else
                {
                    value = value.Replace("{1}", "");
                }

                dgv[7, i].Value = value;
            }


            
            InitializeDataGridViewHeader(dgv);
            InitializeDataGridViewOrdinaryRow(dgv);
            InitializeDataGridViewLastRow(dgv);
            InitializeDataGridViewTotalCell(dgv);
            InitializeDataGrideViewControlSize(dgv);
        }

        private void InitializeDgvBallotRemainingOfBooth()
        {
            DataGridView dgv = dgvBallotRemainingOfBooth;
            // call this first, otherwise row count might not correct
            InitializeDataGridViewOverallStyle(dgv);

            dgv.Columns[0].HeaderText = "";
            dgv.Columns[1].HeaderText = "Actual remaining (staff)";
            dgv.Columns[2].HeaderText = "";
            dgv.Columns[3].HeaderText = "In reserve (Supervisor)";
            dgv.Columns[4].HeaderText = "";
            dgv.Columns[5].HeaderText = "Discarded";
            dgv.Columns[6].HeaderText = "";
            dgv.Columns[7].HeaderText = "Total remaining";
            dgv.Columns[8].HeaderText = "";
            dgv.Columns[9].HeaderText = "Total supplied by RO";

            dgv.Columns[0].Width = 214;
            dgv.Columns[1].Width = 218;
            dgv.Columns[2].Width = 30;
            dgv.Columns[3].Width = 180;
            dgv.Columns[4].Width = 30;
            dgv.Columns[5].Width = 150;
            dgv.Columns[6].Width = 30;
            dgv.Columns[7].Width = 210;
            dgv.Columns[8].Width = 30;
            dgv.Columns[9].Width = 240;

            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[1].ReadOnly = true;
            dgv.Columns[2].ReadOnly = true;
            dgv.Columns[3].ReadOnly = false;
            dgv.Columns[4].ReadOnly = true;
            dgv.Columns[5].ReadOnly = false;
            dgv.Columns[6].ReadOnly = true;
            dgv.Columns[7].ReadOnly = true;
            dgv.Columns[8].ReadOnly = true;
            dgv.Columns[9].ReadOnly = true;

            var editaleStyle = new DataGridViewCellStyle(dgv.Rows[3].DefaultCellStyle);
            editaleStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                dgv[3, i].Style = editaleStyle;
                dgv[5, i].Style = editaleStyle;
            }
            dgv[3, dgv.RowCount - 1].ReadOnly = true;
            dgv[5, dgv.RowCount - 1].ReadOnly = true;

            
                     
            InitializeDataGridViewHeader(dgv);
            InitializeDataGridViewOrdinaryRow(dgv);
            InitializeDataGridViewLastRow(dgv);
            InitializeDataGridViewTotalCell(dgv);
            InitializeDataGrideViewControlSize(dgv);
        }

        private static void InitializeDataGridViewOverallStyle(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.BackgroundColor = dgv.Parent.BackColor;
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            
            
        }

        private static void InitializeDataGrideViewControlSize(DataGridView dgv)
        {
            var width = dgv.Columns.GetColumnsWidth(DataGridViewElementStates.None);
            var height = dgv.Rows.GetRowsHeight(DataGridViewElementStates.None);

            dgv.Size = new Size(width + dgv.RowHeadersWidth + 30, height + dgv.ColumnHeadersHeight + 30);
        }

        private static void InitializeDataGridViewOrdinaryRow(DataGridView dgv)
        {
            System.Windows.Forms.DataGridViewCellStyle normalRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            normalRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            normalRowStyle.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            normalRowStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            normalRowStyle.SelectionForeColor = normalRowStyle.ForeColor;
            normalRowStyle.SelectionBackColor = normalRowStyle.BackColor;
            normalRowStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);

            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                dgv.Rows[i].DefaultCellStyle = normalRowStyle;
                dgv.Rows[i].Height = 34;
            }
        }

        private static void InitializeDataGridViewLastRow(DataGridView dgv)
        {
            System.Windows.Forms.DataGridViewCellStyle lastRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            lastRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            lastRowStyle.BackColor = System.Drawing.Color.FromArgb(228, 228, 228);
            lastRowStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            lastRowStyle.SelectionForeColor = lastRowStyle.ForeColor;
            lastRowStyle.SelectionBackColor = lastRowStyle.BackColor;
            int rowIndex = dgv.Rows.Count - 1;
            dgv.Rows[rowIndex].DefaultCellStyle = lastRowStyle;
            dgv.Rows[rowIndex].Height = 34;
        }

        private static void InitializeDataGridViewTotalCell(DataGridView dgv)
        {
            DataGridViewCellStyle totalCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            totalCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            totalCellStyle.BackColor = System.Drawing.Color.FromArgb(228, 228, 228);
            totalCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            totalCellStyle.SelectionForeColor = totalCellStyle.ForeColor;
            totalCellStyle.SelectionBackColor = totalCellStyle.BackColor;
            dgv.Rows[dgv.Rows.Count - 1].Cells[0].Style = totalCellStyle;
        }

        private static void InitializeDataGridViewHeader(DataGridView dgv)
        {
            System.Windows.Forms.DataGridViewCellStyle headerRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerRowStyle.BackColor = System.Drawing.Color.FromArgb(228, 228, 228);
            headerRowStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle = headerRowStyle;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 34;
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dgv.EnableHeadersVisualStyles = false;
        }
    }
}
