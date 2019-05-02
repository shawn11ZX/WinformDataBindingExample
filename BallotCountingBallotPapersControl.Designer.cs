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
            this.dgvBallotRemainingOfStaff = new System.Windows.Forms.DataGridView();
            this.dgvBallotRemainingOfBooth = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBallotRemainingOfStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBallotRemainingOfBooth)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBallotRemainingOfStaff
            // 
            this.dgvBallotRemainingOfStaff.Location = new System.Drawing.Point(30, 29);
            this.dgvBallotRemainingOfStaff.Name = "dgvBallotRemainingOfStaff";
            this.dgvBallotRemainingOfStaff.Size = new System.Drawing.Size(977, 208);
            this.dgvBallotRemainingOfStaff.TabIndex = 0;
            // 
            // dgvBallotRemainingOfBooth
            // 
            this.dgvBallotRemainingOfBooth.Location = new System.Drawing.Point(33, 267);
            this.dgvBallotRemainingOfBooth.Name = "dgvBallotRemainingOfBooth";
            this.dgvBallotRemainingOfBooth.Size = new System.Drawing.Size(240, 150);
            this.dgvBallotRemainingOfBooth.TabIndex = 1;
            // 
            // BallotCountingBallotPapersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1044, 496);
            this.Controls.Add(this.dgvBallotRemainingOfBooth);
            this.Controls.Add(this.dgvBallotRemainingOfStaff);
            this.Name = "BallotCountingBallotPapersControl";
            this.Text = "BallotPaper";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBallotRemainingOfStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBallotRemainingOfBooth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBallotRemainingOfStaff;
        private System.Windows.Forms.DataGridView dgvBallotRemainingOfBooth;
    }
}