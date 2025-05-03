namespace VBTracker.GUI
{
    partial class HomeForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.tlpDashboard = new System.Windows.Forms.TableLayoutPanel();
            this.pnlClasses = new System.Windows.Forms.Panel();
            this.lblClassesDesc = new System.Windows.Forms.Label();
            this.lblClassesCount = new System.Windows.Forms.Label();
            this.lblClassesTitle = new System.Windows.Forms.Label();
            this.pnlAttendance = new System.Windows.Forms.Panel();
            this.lblAttendanceDesc = new System.Windows.Forms.Label();
            this.lblAttendanceRate = new System.Windows.Forms.Label();
            this.lblAttendanceTitle = new System.Windows.Forms.Label();
            this.pnlAbsenceRequests = new System.Windows.Forms.Panel();
            this.lblRequestsDesc = new System.Windows.Forms.Label();
            this.lblRequestsCount = new System.Windows.Forms.Label();
            this.lblRequestsTitle = new System.Windows.Forms.Label();
            this.pnlUpcoming = new System.Windows.Forms.Panel();
            this.dgvUpcoming = new System.Windows.Forms.DataGridView();
            this.lblUpcomingTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tlpDashboard.SuspendLayout();
            this.pnlClasses.SuspendLayout();
            this.pnlAttendance.SuspendLayout();
            this.pnlAbsenceRequests.SuspendLayout();
            this.pnlUpcoming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcoming)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlHeader.Controls.Add(this.lblDateTime);
            this.pnlHeader.Controls.Add(this.lblRole);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(12, 52);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(183, 15);
            this.lblDateTime.TabIndex = 2;
            this.lblDateTime.Text = "Đăng nhập lúc: 01/01/2023 08:00";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(12, 32);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(67, 17);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Sinh viên";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(12, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(290, 24);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Xin chào, Nguyễn Văn A!";
            // 
            // tlpDashboard
            // 
            this.tlpDashboard.ColumnCount = 2;
            this.tlpDashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDashboard.Controls.Add(this.pnlClasses, 0, 0);
            this.tlpDashboard.Controls.Add(this.pnlAttendance, 1, 0);
            this.tlpDashboard.Controls.Add(this.pnlAbsenceRequests, 0, 1);
            this.tlpDashboard.Controls.Add(this.pnlUpcoming, 1, 1);
            this.tlpDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDashboard.Location = new System.Drawing.Point(0, 80);
            this.tlpDashboard.Name = "tlpDashboard";
            this.tlpDashboard.RowCount = 2;
            this.tlpDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpDashboard.Size = new System.Drawing.Size(800, 480);
            this.tlpDashboard.TabIndex = 1;
            // 
            // pnlClasses
            // 
            this.pnlClasses.BackColor = System.Drawing.Color.LightBlue;
            this.pnlClasses.Controls.Add(this.lblClassesDesc);
            this.pnlClasses.Controls.Add(this.lblClassesCount);
            this.pnlClasses.Controls.Add(this.lblClassesTitle);
            this.pnlClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClasses.Location = new System.Drawing.Point(10, 10);
            this.pnlClasses.Margin = new System.Windows.Forms.Padding(10);
            this.pnlClasses.Name = "pnlClasses";
            this.pnlClasses.Size = new System.Drawing.Size(380, 172);
            this.pnlClasses.TabIndex = 0;
            // 
            // lblClassesDesc
            // 
            this.lblClassesDesc.AutoSize = true;
            this.lblClassesDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassesDesc.Location = new System.Drawing.Point(147, 100);
            this.lblClassesDesc.Name = "lblClassesDesc";
            this.lblClassesDesc.Size = new System.Drawing.Size(146, 17);
            this.lblClassesDesc.TabIndex = 2;
            this.lblClassesDesc.Text = "lớp học đang tham gia";
            // 
            // lblClassesCount
            // 
            this.lblClassesCount.AutoSize = true;
            this.lblClassesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassesCount.Location = new System.Drawing.Point(100, 50);
            this.lblClassesCount.Name = "lblClassesCount";
            this.lblClassesCount.Size = new System.Drawing.Size(52, 55);
            this.lblClassesCount.TabIndex = 1;
            this.lblClassesCount.Text = "0";
            // 
            // lblClassesTitle
            // 
            this.lblClassesTitle.AutoSize = true;
            this.lblClassesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassesTitle.Location = new System.Drawing.Point(10, 10);
            this.lblClassesTitle.Name = "lblClassesTitle";
            this.lblClassesTitle.Size = new System.Drawing.Size(72, 20);
            this.lblClassesTitle.TabIndex = 0;
            this.lblClassesTitle.Text = "Lớp học";
            // 
            // pnlAttendance
            // 
            this.pnlAttendance.BackColor = System.Drawing.Color.LightGreen;
            this.pnlAttendance.Controls.Add(this.lblAttendanceDesc);
            this.pnlAttendance.Controls.Add(this.lblAttendanceRate);
            this.pnlAttendance.Controls.Add(this.lblAttendanceTitle);
            this.pnlAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttendance.Location = new System.Drawing.Point(410, 10);
            this.pnlAttendance.Margin = new System.Windows.Forms.Padding(10);
            this.pnlAttendance.Name = "pnlAttendance";
            this.pnlAttendance.Size = new System.Drawing.Size(380, 172);
            this.pnlAttendance.TabIndex = 1;
            // 
            // lblAttendanceDesc
            // 
            this.lblAttendanceDesc.AutoSize = true;
            this.lblAttendanceDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttendanceDesc.Location = new System.Drawing.Point(147, 100);
            this.lblAttendanceDesc.Name = "lblAttendanceDesc";
            this.lblAttendanceDesc.Size = new System.Drawing.Size(112, 17);
            this.lblAttendanceDesc.TabIndex = 2;
            this.lblAttendanceDesc.Text = "tỷ lệ điểm danh";
            // 
            // lblAttendanceRate
            // 
            this.lblAttendanceRate.AutoSize = true;
            this.lblAttendanceRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttendanceRate.Location = new System.Drawing.Point(100, 50);
            this.lblAttendanceRate.Name = "lblAttendanceRate";
            this.lblAttendanceRate.Size = new System.Drawing.Size(98, 55);
            this.lblAttendanceRate.TabIndex = 1;
            this.lblAttendanceRate.Text = "0%";
            // 
            // lblAttendanceTitle
            // 
            this.lblAttendanceTitle.AutoSize = true;
            this.lblAttendanceTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttendanceTitle.Location = new System.Drawing.Point(10, 10);
            this.lblAttendanceTitle.Name = "lblAttendanceTitle";
            this.lblAttendanceTitle.Size = new System.Drawing.Size(95, 20);
            this.lblAttendanceTitle.TabIndex = 0;
            this.lblAttendanceTitle.Text = "Điểm danh";
            // 
            // pnlAbsenceRequests
            // 
            this.pnlAbsenceRequests.BackColor = System.Drawing.Color.LightYellow;
            this.pnlAbsenceRequests.Controls.Add(this.lblRequestsDesc);
            this.pnlAbsenceRequests.Controls.Add(this.lblRequestsCount);
            this.pnlAbsenceRequests.Controls.Add(this.lblRequestsTitle);
            this.pnlAbsenceRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAbsenceRequests.Location = new System.Drawing.Point(10, 202);
            this.pnlAbsenceRequests.Margin = new System.Windows.Forms.Padding(10);
            this.pnlAbsenceRequests.Name = "pnlAbsenceRequests";
            this.pnlAbsenceRequests.Size = new System.Drawing.Size(380, 268);
            this.pnlAbsenceRequests.TabIndex = 2;
            // 
            // lblRequestsDesc
            // 
            this.lblRequestsDesc.AutoSize = true;
            this.lblRequestsDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestsDesc.Location = new System.Drawing.Point(147, 100);
            this.lblRequestsDesc.Name = "lblRequestsDesc";
            this.lblRequestsDesc.Size = new System.Drawing.Size(131, 17);
            this.lblRequestsDesc.TabIndex = 2;
            this.lblRequestsDesc.Text = "đơn đang chờ duyệt";
            // 
            // lblRequestsCount
            // 
            this.lblRequestsCount.AutoSize = true;
            this.lblRequestsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestsCount.Location = new System.Drawing.Point(100, 50);
            this.lblRequestsCount.Name = "lblRequestsCount";
            this.lblRequestsCount.Size = new System.Drawing.Size(52, 55);
            this.lblRequestsCount.TabIndex = 1;
            this.lblRequestsCount.Text = "0";
            // 
            // lblRequestsTitle
            // 
            this.lblRequestsTitle.AutoSize = true;
            this.lblRequestsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestsTitle.Location = new System.Drawing.Point(10, 10);
            this.lblRequestsTitle.Name = "lblRequestsTitle";
            this.lblRequestsTitle.Size = new System.Drawing.Size(111, 20);
            this.lblRequestsTitle.TabIndex = 0;
            this.lblRequestsTitle.Text = "Đơn xin nghỉ";
            // 
            // pnlUpcoming
            // 
            this.pnlUpcoming.BackColor = System.Drawing.Color.LightPink;
            this.pnlUpcoming.Controls.Add(this.dgvUpcoming);
            this.pnlUpcoming.Controls.Add(this.lblUpcomingTitle);
            this.pnlUpcoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUpcoming.Location = new System.Drawing.Point(410, 202);
            this.pnlUpcoming.Margin = new System.Windows.Forms.Padding(10);
            this.pnlUpcoming.Name = "pnlUpcoming";
            this.pnlUpcoming.Size = new System.Drawing.Size(380, 268);
            this.pnlUpcoming.TabIndex = 3;
            // 
            // dgvUpcoming
            // 
            this.dgvUpcoming.AllowUserToAddRows = false;
            this.dgvUpcoming.AllowUserToDeleteRows = false;
            this.dgvUpcoming.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUpcoming.BackgroundColor = System.Drawing.Color.White;
            this.dgvUpcoming.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpcoming.Location = new System.Drawing.Point(10, 40);
            this.dgvUpcoming.Name = "dgvUpcoming";
            this.dgvUpcoming.ReadOnly = true;
            this.dgvUpcoming.Size = new System.Drawing.Size(360, 218);
            this.dgvUpcoming.TabIndex = 1;
            // 
            // lblUpcomingTitle
            // 
            this.lblUpcomingTitle.AutoSize = true;
            this.lblUpcomingTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomingTitle.Location = new System.Drawing.Point(10, 10);
            this.lblUpcomingTitle.Name = "lblUpcomingTitle";
            this.lblUpcomingTitle.Size = new System.Drawing.Size(72, 20);
            this.lblUpcomingTitle.TabIndex = 0;
            this.lblUpcomingTitle.Text = "Sắp tới";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.LightGray;
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 560);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 40);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblFooter
            // 
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.Location = new System.Drawing.Point(0, 0);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(800, 40);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "VBTracker - Hệ thống quản lý điểm danh";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tlpDashboard);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.Text = "Trang chủ";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpDashboard.ResumeLayout(false);
            this.pnlClasses.ResumeLayout(false);
            this.pnlClasses.PerformLayout();
            this.pnlAttendance.ResumeLayout(false);
            this.pnlAttendance.PerformLayout();
            this.pnlAbsenceRequests.ResumeLayout(false);
            this.pnlAbsenceRequests.PerformLayout();
            this.pnlUpcoming.ResumeLayout(false);
            this.pnlUpcoming.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcoming)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TableLayoutPanel tlpDashboard;
        private System.Windows.Forms.Panel pnlClasses;
        private System.Windows.Forms.Label lblClassesDesc;
        private System.Windows.Forms.Label lblClassesCount;
        private System.Windows.Forms.Label lblClassesTitle;
        private System.Windows.Forms.Panel pnlAttendance;
        private System.Windows.Forms.Label lblAttendanceDesc;
        private System.Windows.Forms.Label lblAttendanceRate;
        private System.Windows.Forms.Label lblAttendanceTitle;
        private System.Windows.Forms.Panel pnlAbsenceRequests;
        private System.Windows.Forms.Label lblRequestsDesc;
        private System.Windows.Forms.Label lblRequestsCount;
        private System.Windows.Forms.Label lblRequestsTitle;
        private System.Windows.Forms.Panel pnlUpcoming;
        private System.Windows.Forms.DataGridView dgvUpcoming;
        private System.Windows.Forms.Label lblUpcomingTitle;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}
