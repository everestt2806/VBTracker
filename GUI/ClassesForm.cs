using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using VBTracker.BUS;
using VBTracker.DTO;

namespace VBTracker.GUI
{
    public partial class ClassesForm : Form
    {
        private ClassBUS classBUS;
        private ScheduleBUS scheduleBUS;

        public ClassesForm()
        {
            InitializeComponent();
            classBUS = new ClassBUS();
            scheduleBUS = new ScheduleBUS();

            LoadClassData();
        }

        private void LoadClassData()
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

                // Hiển thị danh sách lớp học
                dgvClasses.DataSource = classes;

                // Định dạng lại hiển thị của DataGridView
                FormatClassesDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu lớp học: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatClassesDataGridView()
        {
            // Định dạng lại hiển thị của DataGridView
            dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đổi tên các cột
            dgvClasses.Columns["ClassID"].HeaderText = "Mã lớp";
            dgvClasses.Columns["ClassName"].HeaderText = "Tên lớp";
            dgvClasses.Columns["CourseID"].HeaderText = "Mã khóa học";
            dgvClasses.Columns["LecturerID"].HeaderText = "Mã giảng viên";
            dgvClasses.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
            dgvClasses.Columns["EndDate"].HeaderText = "Ngày kết thúc";
            // Thêm các cột khác nếu cần
        }

        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin lớp học được chọn
                string classID = dgvClasses.Rows[e.RowIndex].Cells["ClassID"].Value.ToString();

                // Hiển thị thông tin chi tiết của lớp học
                DisplayClassDetails(classID);

                // Hiển thị lịch học của lớp
                DisplayClassSchedule(classID);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Xử lý khi nút được bấm
        }


        private void DisplayClassDetails(string classID)
        {
            // Hiển thị thông tin chi tiết của lớp học
            ClassDTO classInfo = classBUS.GetClassByID(classID);

            // TODO: Hiển thị thông tin lớp học lên các control
        }

        private void DisplayClassSchedule(string classID)
        {
            // Hiển thị lịch học của lớp
            List<ScheduleDTO> schedules = scheduleBUS.GetSchedulesByClassID(classID);

            // TODO: Hiển thị lịch học lên DataGridView hoặc control khác
        }

        // Thêm các phương thức và xử lý sự kiện khác nếu cần
    }
}
