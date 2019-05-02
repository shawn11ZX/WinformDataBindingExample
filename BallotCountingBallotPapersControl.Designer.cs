namespace ECQ.ePollbook.UI
{
    partial class BallotCountingBallotPapersControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvBallotRemainStatiscsTable1 = new System.Windows.Forms.DataGridView();
            this.dgvBallotRemainStatiscsTable2 = new System.Windows.Forms.DataGridView();
            this.dgvBallotRemainStatiscsTable3 = new System.Windows.Forms.DataGridView();
            this.tlpTab = new System.Windows.Forms.TableLayoutPanel();
            this.btnAll = new System.Windows.Forms.RadioButton();
            this.btnOwnDistrict = new System.Windows.Forms.RadioButton();
            this.btnOverprint = new System.Windows.Forms.RadioButton();
            this.btnHandwritten = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBallotRemainStatiscsTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBallotRemainStatiscsTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBallotRemainStatiscsTable3)).BeginInit();
            this.tlpTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBallotRemainStatiscsTable1
            // 
            this.dgvBallotRemainStatiscsTable1.Location = new System.Drawing.Point(30, 29);
            this.dgvBallotRemainStatiscsTable1.Name = "dgvBallotRemainStatiscsTable1";
            this.dgvBallotRemainStatiscsTable1.Size = new System.Drawing.Size(977, 208);
            this.dgvBallotRemainStatiscsTable1.TabIndex = 0;
            // 
            // dgvBallotRemainStatiscsTable2
            // 
            this.dgvBallotRemainStatiscsTable2.Location = new System.Drawing.Point(33, 267);
            this.dgvBallotRemainStatiscsTable2.Name = "dgvBallotRemainStatiscsTable2";
            this.dgvBallotRemainStatiscsTable2.Size = new System.Drawing.Size(240, 150);
            this.dgvBallotRemainStatiscsTable2.TabIndex = 1;
            // 
            // dgvBallotRemainStatiscsTable3
            // 
            this.dgvBallotRemainStatiscsTable3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBallotRemainStatiscsTable3.Location = new System.Drawing.Point(33, 517);
            this.dgvBallotRemainStatiscsTable3.Name = "dgvBallotRemainStatiscsTable3";
            this.dgvBallotRemainStatiscsTable3.Size = new System.Drawing.Size(240, 150);
            this.dgvBallotRemainStatiscsTable3.TabIndex = 3;
            // 
            // tlpTab
            // 
            this.tlpTab.AutoSize = true;
            this.tlpTab.ColumnCount = 4;
            this.tlpTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpTab.Controls.Add(this.btnAll, 0, 0);
            this.tlpTab.Controls.Add(this.btnOwnDistrict, 1, 0);
            this.tlpTab.Controls.Add(this.btnOverprint, 2, 0);
            this.tlpTab.Controls.Add(this.btnHandwritten, 3, 0);
            this.tlpTab.Location = new System.Drawing.Point(33, 455);
            this.tlpTab.Name = "tlpTab";
            this.tlpTab.RowCount = 1;
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTab.Size = new System.Drawing.Size(840, 40);
            this.tlpTab.TabIndex = 4;
            // 
            // btnAll
            // 
            this.btnAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnAll.AutoSize = true;
            this.btnAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAll.Location = new System.Drawing.Point(3, 3);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(204, 34);
            this.btnAll.TabIndex = 0;
            this.btnAll.TabStop = true;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            // 
            // btnOwnDistrict
            // 
            this.btnOwnDistrict.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnOwnDistrict.AutoSize = true;
            this.btnOwnDistrict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOwnDistrict.Location = new System.Drawing.Point(213, 3);
            this.btnOwnDistrict.Name = "btnOwnDistrict";
            this.btnOwnDistrict.Size = new System.Drawing.Size(204, 34);
            this.btnOwnDistrict.TabIndex = 1;
            this.btnOwnDistrict.TabStop = true;
            this.btnOwnDistrict.Text = "Own District";
            this.btnOwnDistrict.UseVisualStyleBackColor = true;
            // 
            // btnOverprint
            // 
            this.btnOverprint.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnOverprint.AutoSize = true;
            this.btnOverprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOverprint.Location = new System.Drawing.Point(423, 3);
            this.btnOverprint.Name = "btnOverprint";
            this.btnOverprint.Size = new System.Drawing.Size(204, 34);
            this.btnOverprint.TabIndex = 2;
            this.btnOverprint.TabStop = true;
            this.btnOverprint.Text = "Overprint";
            this.btnOverprint.UseVisualStyleBackColor = true;
            // 
            // btnHandwritten
            // 
            this.btnHandwritten.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnHandwritten.AutoSize = true;
            this.btnHandwritten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHandwritten.Location = new System.Drawing.Point(633, 3);
            this.btnHandwritten.Name = "btnHandwritten";
            this.btnHandwritten.Size = new System.Drawing.Size(204, 34);
            this.btnHandwritten.TabIndex = 3;
            this.btnHandwritten.TabStop = true;
            this.btnHandwritten.Text = "Handwritten";
            this.btnHandwritten.UseVisualStyleBackColor = true;
            // 
            // BallotCountingBallotPapersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1044, 803);
            this.Controls.Add(this.tlpTab);
            this.Controls.Add(this.dgvBallotRemainStatiscsTable3);
            this.Controls.Add(this.dgvBallotRemainStatiscsTable2);
            this.Controls.Add(this.dgvBallotRemainStatiscsTable1);
            this.Name = "BallotCountingBallotPapersControl";
            this.Text = "BallotPaper";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBallotRemainStatiscsTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBallotRemainStatiscsTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBallotRemainStatiscsTable3)).EndInit();
            this.tlpTab.ResumeLayout(false);
            this.tlpTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBallotRemainStatiscsTable1;
        private System.Windows.Forms.DataGridView dgvBallotRemainStatiscsTable2;
        private System.Windows.Forms.DataGridView dgvBallotRemainStatiscsTable3;
        private System.Windows.Forms.TableLayoutPanel tlpTab;
        private System.Windows.Forms.RadioButton btnAll;
        private System.Windows.Forms.RadioButton btnOwnDistrict;
        private System.Windows.Forms.RadioButton btnOverprint;
        private System.Windows.Forms.RadioButton btnHandwritten;
    }
}