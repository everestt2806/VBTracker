namespace VBTracker.GUI.StudentArea
{
    partial class StudentDashboard
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
            this.scheduleButton = new System.Windows.Forms.Button();
            this.leaveRequestButton = new System.Windows.Forms.Button();
            this.notificationButton = new System.Windows.Forms.Button();
            this.attendanceButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sidebarPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.sidebarPanel.Controls.Add(this.reportButton);
            this.sidebarPanel.Controls.Add(this.attendanceButton);
            this.sidebarPanel.Controls.Add(this.notificationButton);
            this.sidebarPanel.Controls.Add(this.leaveRequestButton);
            this.sidebarPanel.Controls.Add(this.scheduleButton);
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
            // scheduleButton
            // 
            this.scheduleButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.scheduleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scheduleButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.scheduleButton.ForeColor = System.Drawing.Color.White;
            this.scheduleButton.Location = new System.Drawing.Point(0, 50);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(200, 50);
            this.scheduleButton.TabIndex = 2;
            this.scheduleButton.Text = "Lịch học";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Click += new System.EventHandler(this.ScheduleButton_Click);

            // 
            // leaveRequestButton
            // 
            this.leaveRequestButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.leaveRequestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leaveRequestButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.leaveRequestButton.ForeColor = System.Drawing.Color.White;
            this.leaveRequestButton.Location = new System.Drawing.Point(0, 100);
            this.leaveRequestButton.Name = "leaveRequestButton";
            this.leaveRequestButton.Size = new System.Drawing.Size(200, 50);
            this.leaveRequestButton.TabIndex = 3;
            this.leaveRequestButton.Text = "Báo vắng/Báo bù";
            this.leaveRequestButton.UseVisualStyleBackColor = true;
            this.leaveRequestButton.Click += new System.EventHandler(this.LeaveRequestButton_Click);

            // 
            // notificationButton
            // 
            this.notificationButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.notificationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notificationButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.notificationButton.ForeColor = System.Drawing.Color.White;
            this.notificationButton.Location = new System.Drawing.Point(0, 150);
            this.notificationButton.Name = "notificationButton";
            this.notificationButton.Size = new System.Drawing.Size(200, 50);
            this.notificationButton.TabIndex = 4;
            this.notificationButton.Text = "Thông báo";
            this.notificationButton.UseVisualStyleBackColor = true;
            this.notificationButton.Click += new System.EventHandler(this.NotificationButton_Click);

            // 
            // attendanceButton
            // 
            this.attendanceButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.attendanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attendanceButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.attendanceButton.ForeColor = System.Drawing.Color.White;
            this.attendanceButton.Location = new System.Drawing.Point(0, 200);
            this.attendanceButton.Name = "attendanceButton";
            this.attendanceButton.Size = new System.Drawing.Size(200, 50);
            this.attendanceButton.TabIndex = 5;
            this.attendanceButton.Text = "Điểm danh";
            this.attendanceButton.UseVisualStyleBackColor = true;
            this.attendanceButton.Click += new System.EventHandler(this.AttendanceButton_Click);

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
            this.reportButton.Text = "Báo cáo cá nhân";
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
            // StudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Name = "StudentDashboard";
            this.Text = "Dashboard - Sinh viên";
            this.sidebarPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Button dashboardButton;
        private System.Windows.Forms.Button scheduleButton;
        private System.Windows.Forms.Button leaveRequestButton;
        private System.Windows.Forms.Button notificationButton;
        private System.Windows.Forms.Button attendanceButton;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.Panel mainPanel;


        #endregion
    }
}