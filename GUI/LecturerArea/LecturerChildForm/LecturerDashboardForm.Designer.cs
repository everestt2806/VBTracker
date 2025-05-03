namespace VBTracker.GUI.LecturerArea.LecturerChildForm
{
    partial class LecturerDashboardForm
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
            this.lblTotalClasses = new System.Windows.Forms.Label();
            this.lblTodayClasses = new System.Windows.Forms.Label();
            this.lblPendingRequests = new System.Windows.Forms.Label();
            this.weeklySchedule = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();

            // 
            // lblTotalClasses
            // 
            this.lblTotalClasses.AutoSize = true;
            this.lblTotalClasses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalClasses.Location = new System.Drawing.Point(20, 20);
            this.lblTotalClasses.Name = "lblTotalClasses";
            this.lblTotalClasses.Size = new System.Drawing.Size(180, 28);
            this.lblTotalClasses.Text = "Tổng số lớp: 10";

            // 
            // lblTodayClasses
            // 
            this.lblTodayClasses.AutoSize = true;
            this.lblTodayClasses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTodayClasses.Location = new System.Drawing.Point(20, 60);
            this.lblTodayClasses.Name = "lblTodayClasses";
            this.lblTodayClasses.Size = new System.Drawing.Size(230, 28);
            this.lblTodayClasses.Text = "Số buổi dạy hôm nay: 2";

            // 
            // lblPendingRequests
            // 
            this.lblPendingRequests.AutoSize = true;
            this.lblPendingRequests.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPendingRequests.Location = new System.Drawing.Point(20, 100);
            this.lblPendingRequests.Name = "lblPendingRequests";
            this.lblPendingRequests.Size = new System.Drawing.Size(300, 28);
            this.lblPendingRequests.Text = "Yêu cầu cần xử lý: 5";

            // 
            // weeklySchedule
            // 
            this.weeklySchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.weeklySchedule.Location = new System.Drawing.Point(20, 150);
            this.weeklySchedule.Name = "weeklySchedule";
            this.weeklySchedule.Size = new System.Drawing.Size(750, 300);
            this.weeklySchedule.TabIndex = 0;

            // 
            // LecturerDashboardForm
            // 
            this.Controls.Add(this.lblTotalClasses);
            this.Controls.Add(this.lblTodayClasses);
            this.Controls.Add(this.lblPendingRequests);
            this.Controls.Add(this.weeklySchedule);
            this.Name = "LecturerDashboardForm";
            this.Size = new System.Drawing.Size(800, 500);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTotalClasses;
        private System.Windows.Forms.Label lblTodayClasses;
        private System.Windows.Forms.Label lblPendingRequests;
        private System.Windows.Forms.DataGridView weeklySchedule;

        #endregion
    }
}