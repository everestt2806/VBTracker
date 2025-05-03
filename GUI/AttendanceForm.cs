using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VBTracker.BUS;
using VBTracker.DTO;

namespace VBTracker.GUI
{
    public partial class AttendanceForm : Form
    {
        private AttendanceBUS attendanceBUS;
        private ScheduleBUS scheduleBUS;
        private ClassBUS classBUS;

        public AttendanceForm()
        {
            InitializeComponent();
            attendanceBUS = new AttendanceBUS();
            scheduleBUS = new ScheduleBUS();
            classBUS = new ClassBUS();

            InitializeForm();
        }

        private void InitializeForm()
        {
            // Khởi tạo các control và load dữ liệu ban đầu
            LoadClassList();

            // Hiển thị giao diện phù hợp với vai trò người dùng
            if (UserSession.Instance.IsStudent())
            {
                SetupStudentView();
            }
            else if (UserSession.Instance.IsLecturer())
            {
                SetupLecturerView();
            }
        }

        private void LoadClassList()
        {
            try
            {
                List<ClassDTO> classes;

                if (UserSession.Instance.IsStudent())
                {
                    // Lấy danh sách lớp học của sinh viên
                    classes = classBUS.GetClassesByStudentID(UserSession.Instance.UserID);
                }
                else if (UserSession.Instance.IsLecturer())
                {
                    // Lấy danh sách lớp học của giảng viên
                    classes = classBUS.GetClassesByLecturerID(UserSession.Instance.UserID);
                }
                else
                {
                    classes = new List<ClassDTO>();
                }

                // Hiển thị danh sách lớp học trong ComboBox
                cboClasses.DataSource = classes;
                cboClasses.DisplayMember = "ClassName";
                cboClasses.ValueMember = "ClassID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách lớp học: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupStudentView()
        {
            // Cấu hình giao diện cho sinh viên
            // Sinh viên chỉ xem được điểm danh của mình
            pnlAttendanceInput.Visible = false;
            btnSaveAttendance.Visible = false;

            // Load điểm danh của sinh viên
            LoadStudentAttendance();
        }

        private void SetupLecturerView()
        {
            // Cấu hình giao diện cho giảng viên
            // Giảng viên có thể nhập điểm danh cho sinh viên
            pnlAttendanceInput.Visible = true;
            btnSaveAttendance.Visible = true;
        }

        private void LoadStudentAttendance()
        {
            try
            {
                // Lấy thông tin điểm danh của sinh viên
                List<AttendanceDTO> attendanceList = attendanceBUS.GetAttendanceByStudentID(UserSession.Instance.UserID);

                // Hiển thị thông tin điểm danh
                dgvAttendance.DataSource = attendanceList;

                // Định dạng lại hiển thị của DataGridView
                FormatAttendanceDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu điểm danh: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatAttendanceDataGridView()
        {
            // Định dạng lại hiển thị của DataGridView
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đổi tên các cột
            dgvAttendance.Columns["AttendanceID"].HeaderText = "Mã điểm danh";
            dgvAttendance.Columns["ScheduleID"].HeaderText = "Mã lịch học";
            dgvAttendance.Columns["StudentID"].HeaderText = "Mã sinh viên";
            dgvAttendance.Columns["Status"].HeaderText = "Trạng thái";
            dgvAttendance.Columns["AttendanceDate"].HeaderText = "Ngày điểm danh";
            dgvAttendance.Columns["Notes"].HeaderText = "Ghi chú";
            // Thêm các cột khác nếu cần
        }

        private void cboClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClasses.SelectedValue != null)
            {
                string classID = cboClasses.SelectedValue.ToString();
                LoadSchedulesByClass(classID);
            }
        }

        private void LoadSchedulesByClass(string classID)
        {
            try
            {
                // Lấy danh sách lịch học của lớp
                List<ScheduleDTO> schedules = scheduleBUS.GetSchedulesByClassID(classID);

                // Hiển thị danh sách lịch học trong ComboBox
                cboSchedules.DataSource = schedules;
                cboSchedules.DisplayMember = "ScheduleDate"; // Hiển thị ngày học
                cboSchedules.ValueMember = "ScheduleID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách lịch học: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSchedules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSchedules.SelectedValue != null && UserSession.Instance.IsLecturer())
            {
                string scheduleID = cboSchedules.SelectedValue.ToString();
                LoadStudentsBySchedule(scheduleID);
            }
        }

        private void LoadStudentsBySchedule(string scheduleID)
        {
            try
            {
                // Lấy danh sách sinh viên và trạng thái điểm danh theo lịch học
                // TODO: Implement LoadStudentsBySchedule
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sinh viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu thông tin điểm danh
                // TODO: Implement SaveAttendance

                MessageBox.Show("Lưu điểm danh thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu điểm danh: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm các phương thức và xử lý sự kiện khác nếu cần
    }
}
