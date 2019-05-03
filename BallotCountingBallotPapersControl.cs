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
        
    
        IBallotCountingBallotPapersBusiness business = new BallotCountingBallotPapersBusiness();
        public BallotCountingBallotPapersControl()
        {
            InitializeComponent();

            dgvBallotRemainStatiscsTable1.DataBindings.Add(
                nameof(DataGridView.DataSource),
                business,
                nameof(IBallotCountingBallotPapersBusiness.Table1List));
            dgvBallotRemainStatiscsTable1.DataBindingComplete += DgvBallotRemainStatisticsTable1_DataBindingComplete;

            dgvBallotRemainStatiscsTable2.DataBindings.Add(
                nameof(DataGridView.DataSource),
                business,
                nameof(IBallotCountingBallotPapersBusiness.Table2List));
            dgvBallotRemainStatiscsTable2.DataBindingComplete += DgvBallotRemainStatisticsTable2_DataBindingComplete;


            dgvBallotRemainStatiscsTable3.DataBindings.Add(
                nameof(DataGridView.DataSource), 
                business, 
                nameof(IBallotCountingBallotPapersBusiness.Table3List));
            dgvBallotRemainStatiscsTable3.DataBindingComplete += DgvBallotRemainStatisticsTable3_DataBindingComplete;

            BindRadioButton(btnAll, dgvBallotRemainStatiscsTable3, Table3Type.All);
            BindRadioButton(btnOwnDistrict, dgvBallotRemainStatiscsTable3, Table3Type.OwnDistrict);
            BindRadioButton(btnOverprint, dgvBallotRemainStatiscsTable3, Table3Type.Overprint);
            BindRadioButton(btnHandwritten, dgvBallotRemainStatiscsTable3, Table3Type.Handwritten);
            btnAll.Checked = false;
            btnAll.Checked = true;

            tlpTab.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            InitTable3Button(btnAll);
            InitTable3Button(btnOverprint);
            InitTable3Button(btnHandwritten);
            InitTable3Button(btnOwnDistrict);
        }

        private void InitTable3Button(RadioButton btn)
        {
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Margin = new Padding(0);
            btn.Padding = new Padding(0);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(242, 220, 219);
            btn.FlatAppearance.BorderSize = 0;
        }
        private void BindRadioButton(RadioButton button, Control control, Table3Type type)
        {
            button.CheckedChanged += (sender, e) =>
            {
                if (button.Checked)
                {
                    business.SelectTable3(type);
                }
            };
        }

        private void DgvBallotRemainStatisticsTable1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
            InitializeDgvBallotRemainStatisticsTable1();
            
        }

        private void DgvBallotRemainStatisticsTable2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {       
            
            InitializeDgvBallotRemainStatisticsTable2();
            
        }

        private void DgvBallotRemainStatisticsTable3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            InitializeDgvBallotRemainStatisticsTable3();
            
        }


        
        private void InitializeDgvBallotRemainStatisticsTable1()
        {
            DataGridView dgv = dgvBallotRemainStatiscsTable1;
            
            // call this first, otherwise row count might not correct
            InitializeDataGridViewOverallStyle(dgv);
            InitializeTable1Columns(dgv);

            InitializeDataGridViewHeader(dgv);
            
            InitializeDataGridViewOrdinaryRow(dgv, dgv.RowCount-1);
            InitializeDataGridViewLastRow(dgv);
            InitializeDataGridViewTotalCell(dgv);
            InitializeDataGrideViewControlSize(dgv);
        }

        private void InitializeTable1Columns(DataGridView dgv)
        {
            RemoveAllColumns(dgv, "");
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.ExpectedRemaining));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.ActualRemaining));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.TotalActualRemaining));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.TotalSuppliedByRO));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.InReserveSupervisor));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.Discarded));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.DiffRemaining));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.IssuePoint));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.LastSyncedTime));

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.Type)];
                column.DisplayIndex = 0;
                column.HeaderText = "";
                column.Width = 214;
                column.ReadOnly = true;
            }


            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.AllocatedBySupervisor)];
                column.DisplayIndex = 1;
                column.HeaderText = "Allocated by Supervisor";
                column.Width = 218;
                column.ReadOnly = true;
            }

            {
                var column = new DataGridViewTextBoxColumn();
                column.DisplayIndex = 2;
                column.Width = 30;
                column.HeaderText = "";
                dgv.Columns.Add(column);
                AddOperator(dgv, column, "-");
            }

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.Spoilt)];
                column.DisplayIndex = 3;
                column.HeaderText = "Spoiled";
                column.Width = 180;
                column.ReadOnly = true;
            }

            {
                var column = new DataGridViewTextBoxColumn();
                column.DisplayIndex = 4;
                column.Width = 30;
                column.HeaderText = "";
                dgv.Columns.Add(column);
                AddOperator(dgv, column, "-");
            }

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.IssuedToVoters)];
                column.DisplayIndex = 5;
                column.HeaderText = "Spoiled";
                column.Width = 150;
                column.ReadOnly = true;
            }

            {
                var column = new DataGridViewTextBoxColumn();
                column.DisplayIndex = 6;
                column.Width = 30;
                column.HeaderText = "";
                dgv.Columns.Add(column);
                AddOperator(dgv, column, "=");
            }

            {

                dgv.Columns.Remove(nameof(BallotRemainStatistics.ExpectedRemainingAddDiff));
                var column = new DataGridViewRichTextBoxColumn();
                dgv.Columns.Add(column);
                column.Name = nameof(BallotRemainStatistics.ExpectedRemainingAddDiff);
                column.DataPropertyName = nameof(BallotRemainStatistics.ExpectedRemainingAddDiff);
                column.DisplayIndex = 7;
                column.HeaderText = "Expected remaining(staff)";
                column.Width = 210;
                column.ReadOnly = true;
            }
        }

        

        private void InitializeDgvBallotRemainStatisticsTable2()
        {
            DataGridView dgv = dgvBallotRemainStatiscsTable2;
            
            // call this first, otherwise row count might not correct
            InitializeDataGridViewOverallStyle(dgv);
            InitializeTable2Columns(dgv);

            InitializeDataGridViewHeader(dgv);
            

            InitializeDataGridViewOrdinaryRow(dgv, dgv.RowCount-1);
            InitializeDataGridViewLastRow(dgv);
            InitializeDataGridViewTotalCell(dgv);
            InitializeDataGrideViewControlSize(dgv);
        }

        private void InitializeTable2Columns(DataGridView dgv)
        {
            RemoveAllColumns(dgv, "");
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.AllocatedBySupervisor));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.Spoilt));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.IssuedToVoters));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.DiffRemaining));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.ExpectedRemaining));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.IssuePoint));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.LastSyncedTime));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.ExpectedRemainingAddDiff));
            

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.Type)];
                column.DisplayIndex = 0;
                column.HeaderText = "";
                column.Width = 214;
                column.ReadOnly = true;
            }

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.ActualRemaining)];
                column.DisplayIndex = 1;
                column.HeaderText = "Actual remaining (staff)";
                column.Width = 218;
                column.ReadOnly = true;
            }

            {
                var column = new DataGridViewTextBoxColumn();
                column.DisplayIndex = 2;
                column.Width = 30;
                column.HeaderText = "";
                dgv.Columns.Add(column);
                AddOperator(dgv, column, "-");
            }

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.InReserveSupervisor)];
                column.DisplayIndex = 3;
                column.HeaderText = "In reserve (Supervisor)";
                column.Width = 180;
                column.ReadOnly = false;
                MakeEditableOperator(dgv, column, dgv.RowCount-1);
                
            }

            {
                var column = new DataGridViewTextBoxColumn();
                column.DisplayIndex = 4;
                column.Width = 30;
                column.HeaderText = "";
                dgv.Columns.Add(column);
                AddOperator(dgv, column, "-");
            }

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.Discarded)];
                column.DisplayIndex = 5;
                column.HeaderText = "Discarded";
                column.Width = 150;
                column.ReadOnly = false;
                MakeEditableOperator(dgv, column, dgv.RowCount - 1);
                
            }

            {
                var column = new DataGridViewTextBoxColumn();
                column.DisplayIndex = 6;
                column.Width = 30;
                column.HeaderText = "";
                dgv.Columns.Add(column);
                AddOperator(dgv, column, "=");
            }

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.TotalActualRemaining)];
                column.DisplayIndex = 7;
                column.HeaderText = "TotalRemaining";
                column.Width = 210;
                column.ReadOnly = true;

            }

            {
                var column = new DataGridViewTextBoxColumn();
                column.DisplayIndex = 8;
                column.Width = 30;
                column.HeaderText = "";
                dgv.Columns.Add(column);
                AddOperator(dgv, column, "of");
            }

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.TotalSuppliedByRO)];
                column.DisplayIndex = 9;
                column.HeaderText = "Total supplied by RO";
                column.Width = 240;
                column.ReadOnly = true;

            }
        }

        private void InitializeDgvBallotRemainStatisticsTable3()
        {
            DataGridView dgv = dgvBallotRemainStatiscsTable3;
            
            // call this first, otherwise row count might not correct
            InitializeDataGridViewOverallStyle(dgv);
            InitializeTable3Columns(dgv);
            InitializeDataGridViewHeader(dgv);
            InitializeDataGridViewOrdinaryRow(dgv, dgv.RowCount);
            InitializeDataGrideViewControlSize(dgv);
        }

        private void RemoveAllColumns(DataGridView dgv, string columnName)
        {
            while (dgv.Columns.Contains(columnName))
                dgv.Columns.Remove(columnName);
        }
        private void InitializeTable3Columns(DataGridView dgv)
        {
            RemoveAllColumns(dgv, "");
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.DiffRemaining));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.TotalSuppliedByRO));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.ExpectedRemaining));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.InReserveSupervisor));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.Discarded));
            RemoveAllColumns(dgv, nameof(BallotRemainStatistics.TotalActualRemaining));


            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.IssuePoint)];
                column.DisplayIndex = 0;
                column.HeaderText = "Issuing Point";
                column.Width = 193;
                column.ReadOnly = true;
            }

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.LastSyncedTime)];
                column.DisplayIndex = 1;
                column.HeaderText = "Last synced";
                column.Width = 147;
                column.ReadOnly = true;
            }

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.Type)];
                column.DisplayIndex = 2;
                column.HeaderText = "Type";
                column.Width = 114;
                column.ReadOnly = true;
            }

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.AllocatedBySupervisor)];
                column.DisplayIndex = 3;
                column.HeaderText = "Allocated by Supervisor";
                column.Width = 152;
                column.ReadOnly = false;
                
            }

            {
                var column = new DataGridViewTextBoxColumn();
                column.DisplayIndex = 4;
                column.Width = 30;
                column.HeaderText = "";
                dgv.Columns.Add(column);
                AddOperator(dgv, column, "-");
            }

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.Spoilt)];
                column.DisplayIndex = 5;
                column.HeaderText = "Spoiled";
                column.Width = 150;
                column.ReadOnly = false;
                
            }

            {
                var column = new DataGridViewTextBoxColumn();
                column.DisplayIndex = 6;
                column.Width = 30;
                column.HeaderText = "";
                dgv.Columns.Add(column);
                AddOperator(dgv, column, "-");
            }

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.IssuedToVoters)];
                column.DisplayIndex = 7;
                column.HeaderText = "Issued to voters";
                column.Width = 150;
                column.ReadOnly = true;
            }

            {
                var column = new DataGridViewTextBoxColumn();
                column.DisplayIndex = 8;
                column.Width = 30;
                column.HeaderText = "";
                dgv.Columns.Add(column);
                AddOperator(dgv, column, "=");
            }

            {
                dgv.Columns.Remove(nameof(BallotRemainStatistics.ExpectedRemainingAddDiff));
                var column = new DataGridViewRichTextBoxColumn();
                dgv.Columns.Add(column);

                column.Name = nameof(BallotRemainStatistics.ExpectedRemainingAddDiff);
                column.DataPropertyName = nameof(BallotRemainStatistics.ExpectedRemainingAddDiff);
                column.DisplayIndex = 9;
                column.HeaderText = "Expected remaining(staff)";
                column.Width = 210;
                column.ReadOnly = true;
                
            }

            {
                var column = dgv.Columns[nameof(BallotRemainStatistics.ActualRemaining)];
                column.DisplayIndex = 10;
                column.HeaderText = "Actual remaining";
                column.Width = 150;
                column.ReadOnly = false;
                MakeEditableOperator(dgv, column, dgv.RowCount);
            }

           
        }

        private void AddOperator(DataGridView dgv, DataGridViewColumn col, string op)
        {
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                dgv[col.Index, i].Value = op;
            }
        }

        private void MakeEditableOperator(DataGridView dgv, DataGridViewColumn col, int rowCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                var editaleStyle = new DataGridViewCellStyle(col.DefaultCellStyle);
                editaleStyle.BackColor = dgv.BackgroundColor;
                dgv[col.Index, i].Style = editaleStyle;
                dgv[col.Index, i].ReadOnly = false;
            }

            
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

        private static void InitializeDataGridViewOrdinaryRow(DataGridView dgv, int rowCount)
        {
            System.Windows.Forms.DataGridViewCellStyle normalRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            normalRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            normalRowStyle.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            normalRowStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            normalRowStyle.SelectionForeColor = normalRowStyle.ForeColor;
            normalRowStyle.SelectionBackColor = normalRowStyle.BackColor;
            normalRowStyle.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);

            for (int i = 0; i < rowCount; i++)
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
            lastRowStyle.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
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
            totalCellStyle.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            totalCellStyle.SelectionForeColor = totalCellStyle.ForeColor;
            totalCellStyle.SelectionBackColor = totalCellStyle.BackColor;
            dgv.Rows[dgv.Rows.Count - 1].Cells[0].Style = totalCellStyle;
        }

        private static void InitializeDataGridViewHeader(DataGridView dgv)
        {
            System.Windows.Forms.DataGridViewCellStyle headerRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerRowStyle.BackColor = System.Drawing.Color.FromArgb(228, 228, 228);
            headerRowStyle.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle = headerRowStyle;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 34;
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dgv.EnableHeadersVisualStyles = false;
        }
    }
}
