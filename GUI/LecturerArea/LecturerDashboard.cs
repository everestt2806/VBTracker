using System;
using System.Windows.Forms;
using VBTracker.GUI.LecturerArea.LecturerChildForm;

namespace VBTracker.GUI.LecturerArea
{
    public partial class LecturerDashboard : Form
    {
        public LecturerDashboard()
        {
            InitializeComponent();
        }

    

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            LecturerDashboardForm dashboard = new LecturerDashboardForm();
            dashboard.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(dashboard);
        }

        private void ManageClassesButton_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            ManageClassesForm dashboard = new ManageClassesForm();
            dashboard.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(dashboard);
        }

        private void AttendanceButton_Click(object sender, EventArgs e)
        {
            // Load Attendance content into mainPanel
        }

        private void LeaveRequestButton_Click(object sender, EventArgs e)
        {
            // Load Leave Request content into mainPanel
        }

        private void SendNotificationButton_Click(object sender, EventArgs e)
        {
            // Load Send Notification content into mainPanel
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            // Load Report content into mainPanel
        }
    }
}
