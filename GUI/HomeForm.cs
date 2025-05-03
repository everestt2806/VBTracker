using System;
using System.Data.SqlTypes;
using System.Windows.Forms;
using VBTracker.BUS;

namespace VBTracker.GUI
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                // Hiển thị thông tin tổng quan cho người dùng hiện tại
                DisplayWelcomeMessage();

                if (UserSession.Instance.IsStudent())
                {
                    LoadStudentDashboard();
                }
                else if (UserSession.Instance.IsLecturer())
                {
                    LoadLecturerDashboard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu trang chủ: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayWelcomeMessage()
        {
            // Hiển thị thông điệp chào mừng với tên người dùng
            lblWelcome.Text = $"Xin chào, {UserSession.Instance.FullName}!";
            lblRole.Text = UserSession.Instance.Role == "Student" ? "Sinh viên" : "Giảng viên";
            lblDateTime.Text = $"Đăng nhập lúc: {UserSession.Instance.LoginTime.ToString("dd/MM/yyyy HH:mm:ss")}";
        }

        private void LoadStudentDashboard()
        {
            // Hiển thị thông tin tổng quan cho sinh viên
            // Ví dụ: số lớp đang học, tỷ lệ điểm danh, đơn xin nghỉ, v.v.

            // TODO: Implement student dashboard
        }

        private void LoadLecturerDashboard()
        {
            // Hiển thị thông tin tổng quan cho giảng viên
            // Ví dụ: số lớp đang dạy, lịch dạy sắp tới, đơn xin nghỉ cần phê duyệt, v.v.

            // TODO: Implement lecturer dashboard
        }

        // Thêm các phương thức và xử lý sự kiện khác nếu cần
    }
}
