namespace VBTracker.GUI.LecturerArea
{
    partial class LecturerDashboard
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
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.dashboardButton = new System.Windows.Forms.Button();
            this.manageClassesButton = new System.Windows.Forms.Button();
            this.attendanceButton = new System.Windows.Forms.Button();
            this.leaveRequestButton = new System.Windows.Forms.Button();
            this.sendNotificationButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sidebarPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.sidebarPanel.Controls.Add(this.reportButton);
            this.sidebarPanel.Controls.Add(this.sendNotificationButton);
            this.sidebarPanel.Controls.Add(this.leaveRequestButton);
            this.sidebarPanel.Controls.Add(this.attendanceButton);
            this.sidebarPanel.Controls.Add(this.manageClassesButton);
            this.sidebarPanel.Controls.Add(this.dashboardButton);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(200, 600);
            this.sidebarPanel.TabIndex = 0;

            // 
            // dashboardButton
            // 
            this.dashboardButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dashboardButton.ForeColor = System.Drawing.Color.White;
            this.dashboardButton.Location = new System.Drawing.Point(0, 0);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Size = new System.Drawing.Size(200, 50);
            this.dashboardButton.TabIndex = 1;
            this.dashboardButton.Text = "Dashboard";
            this.dashboardButton.UseVisualStyleBackColor = true;
            this.dashboardButton.Click += new System.EventHandler(this.DashboardButton_Click);

            // 
            // manageClassesButton
            // 
            this.manageClassesButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.manageClassesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageClassesButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.manageClassesButton.ForeColor = System.Drawing.Color.White;
            this.manageClassesButton.Location = new System.Drawing.Point(0, 50);
            this.manageClassesButton.Name = "manageClassesButton";
            this.manageClassesButton.Size = new System.Drawing.Size(200, 50);
            this.manageClassesButton.TabIndex = 2;
            this.manageClassesButton.Text = "Quản lý lớp học";
            this.manageClassesButton.UseVisualStyleBackColor = true;
            this.manageClassesButton.Click += new System.EventHandler(this.ManageClassesButton_Click);

            // 
            // attendanceButton
            // 
            this.attendanceButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.attendanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attendanceButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.attendanceButton.ForeColor = System.Drawing.Color.White;
            this.attendanceButton.Location = new System.Drawing.Point(0, 100);
            this.attendanceButton.Name = "attendanceButton";
            this.attendanceButton.Size = new System.Drawing.Size(200, 50);
            this.attendanceButton.TabIndex = 3;
            this.attendanceButton.Text = "Điểm danh";
            this.attendanceButton.UseVisualStyleBackColor = true;
            this.attendanceButton.Click += new System.EventHandler(this.AttendanceButton_Click);

            // 
            // leaveRequestButton
            // 
            this.leaveRequestButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.leaveRequestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leaveRequestButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.leaveRequestButton.ForeColor = System.Drawing.Color.White;
            this.leaveRequestButton.Location = new System.Drawing.Point(0, 150);
            this.leaveRequestButton.Name = "leaveRequestButton";
            this.leaveRequestButton.Size = new System.Drawing.Size(200, 50);
            this.leaveRequestButton.TabIndex = 4;
            this.leaveRequestButton.Text = "Báo vắng/Báo bù";
            this.leaveRequestButton.UseVisualStyleBackColor = true;
            this.leaveRequestButton.Click += new System.EventHandler(this.LeaveRequestButton_Click);

            // 
            // sendNotificationButton
            // 
            this.sendNotificationButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.sendNotificationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendNotificationButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.sendNotificationButton.ForeColor = System.Drawing.Color.White;
            this.sendNotificationButton.Location = new System.Drawing.Point(0, 200);
            this.sendNotificationButton.Name = "sendNotificationButton";
            this.sendNotificationButton.Size = new System.Drawing.Size(200, 50);
            this.sendNotificationButton.TabIndex = 5;
            this.sendNotificationButton.Text = "Gửi thông báo";
            this.sendNotificationButton.UseVisualStyleBackColor = true;
            this.sendNotificationButton.Click += new System.EventHandler(this.SendNotificationButton_Click);

            // 
            // reportButton
            // 
            this.reportButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.reportButton.ForeColor = System.Drawing.Color.White;
            this.reportButton.Location = new System.Drawing.Point(0, 250);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(200, 50);
            this.reportButton.TabIndex = 6;
            this.reportButton.Text = "Báo cáo";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.ReportButton_Click);

            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(200, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 600);
            this.mainPanel.TabIndex = 1;

            // 
            // LecturerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Name = "LecturerDashboard";
            this.Text = "Dashboard - Giảng viên";
            this.sidebarPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Button dashboardButton;
        private System.Windows.Forms.Button manageClassesButton;
        private System.Windows.Forms.Button attendanceButton;
        private System.Windows.Forms.Button leaveRequestButton;
        private System.Windows.Forms.Button sendNotificationButton;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.Panel mainPanel;

        #endregion
    }
}