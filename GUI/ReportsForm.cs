using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using VBTracker.BUS;
using VBTracker.DTO;
using System.Windows.Forms.DataVisualization.Charting;


namespace VBTracker.GUI
{
    public partial class ReportsForm : Form
    {
        private AttendanceBUS attendanceBUS;
        private ClassBUS classBUS;
        private StudentBUS studentBUS;

        public ReportsForm()
        {
            InitializeComponent();
            attendanceBUS = new AttendanceBUS();
            classBUS = new ClassBUS();
            studentBUS = new StudentBUS();

            InitializeForm();
        }

        private void InitializeForm()
        {
            // Khởi tạo các control và load dữ liệu ban đầu
            SetupReportOptions();
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

        private void SetupReportOptions()
        {
            // Thiết lập các tùy chọn báo cáo
            cboReportType.Items.Add("Báo cáo điểm danh theo lớp");
            cboReportType.Items.Add("Báo cáo điểm danh theo sinh viên");
            cboReportType.Items.Add("Báo cáo tổng hợp điểm danh");
            cboReportType.SelectedIndex = 0;
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
            // Sinh viên chỉ xem được báo cáo của mình
            cboReportType.Items.Clear();
            cboReportType.Items.Add("Báo cáo điểm danh cá nhân");
            cboReportType.SelectedIndex = 0;

            lblStudent.Visible = false;
            cboStudents.Visible = false;
        }

        private void SetupLecturerView()
        {
            // Cấu hình giao diện cho giảng viên
            // Giảng viên có thể xem báo cáo của tất cả sinh viên trong lớp
            lblStudent.Visible = true;
            cboStudents.Visible = true;
        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Thay đổi giao diện theo loại báo cáo
            switch (cboReportType.SelectedIndex)
            {
                case 0: // Báo cáo điểm danh theo lớp
                    lblClass.Visible = true;
                    cboClasses.Visible = true;
                    lblStudent.Visible = false;
                    cboStudents.Visible = false;
                    break;
                case 1: // Báo cáo điểm danh theo sinh viên
                    lblClass.Visible = true;
                    cboClasses.Visible = true;
                    lblStudent.Visible = true;
                    cboStudents.Visible = true;
                    break;
                case 2: // Báo cáo tổng hợp điểm danh
                    lblClass.Visible = true;
                    cboClasses.Visible = true;
                    lblStudent.Visible = false;
                    cboStudents.Visible = false;
                    break;
            }
        }

        private void cboClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClasses.SelectedValue != null)
            {
                string classID = cboClasses.SelectedValue.ToString();

                if (cboReportType.SelectedIndex == 1) // Báo cáo điểm danh theo sinh viên
                {
                    LoadStudentsByClass(classID);
                }
            }
        }

        private void LoadStudentsByClass(string classID)
        {
            try
            {
                // Lấy danh sách sinh viên trong lớp
                List<StudentDTO> students = studentBUS.GetStudentByID(classID);

                // Hiển thị danh sách sinh viên trong ComboBox
                cboStudents.DataSource = students;
                cboStudents.DisplayMember = "FullName";
                cboStudents.ValueMember = "StudentID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sinh viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo báo cáo dựa trên loại báo cáo được chọn
                switch (cboReportType.SelectedIndex)
                {
                    case 0: // Báo cáo điểm danh theo lớp
                        GenerateClassAttendanceReport();
                        break;
                    case 1: // Báo cáo điểm danh theo sinh viên
                        GenerateStudentAttendanceReport();
                        break;
                    case 2: // Báo cáo tổng hợp điểm danh
                        GenerateSummaryReport();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo báo cáo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateClassAttendanceReport()
        {
            if (cboClasses.SelectedValue == null) return;

            string classID = cboClasses.SelectedValue.ToString();

            // Lấy dữ liệu điểm danh theo lớp
            // TODO: Implement GenerateClassAttendanceReport

            // Hiển thị báo cáo
            DisplayReport("Báo cáo điểm danh theo lớp");
        }

        private void GenerateStudentAttendanceReport()
        {
            if (cboClasses.SelectedValue == null || cboStudents.SelectedValue == null) return;

            string classID = cboClasses.SelectedValue.ToString();
            string studentID = cboStudents.SelectedValue.ToString();

            // Lấy dữ liệu điểm danh theo sinh viên
            // TODO: Implement GenerateStudentAttendanceReport

            // Hiển thị báo cáo
            DisplayReport("Báo cáo điểm danh theo sinh viên");
        }

        private void GenerateSummaryReport()
        {
            if (cboClasses.SelectedValue == null) return;

            string classID = cboClasses.SelectedValue.ToString();

            // Lấy dữ liệu tổng hợp điểm danh
            // TODO: Implement GenerateSummaryReport

            // Hiển thị báo cáo
            DisplayReport("Báo cáo tổng hợp điểm danh");
        }

        private void DisplayReport(string reportTitle)
        {
            // Hiển thị báo cáo
            lblReportTitle.Text = reportTitle;

            // TODO: Hiển thị dữ liệu báo cáo lên DataGridView hoặc control khác
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Xuất báo cáo ra file Excel hoặc PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx|PDF Files|*.pdf";
                saveFileDialog.Title = "Xuất báo cáo";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // TODO: Implement ExportReport

                    MessageBox.Show($"Xuất báo cáo thành công!\nĐường dẫn: {filePath}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất báo cáo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm các phương thức và xử lý sự kiện khác nếu cần
    }
}
