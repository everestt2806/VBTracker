using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;
using VBTracker.BUS;
using VBTracker.DTO;

namespace VBTracker.GUI
{
    public partial class MakeupAttendanceForm : Form
    {
        private MakeupAttendanceBUS makeupAttendanceBUS;
        private MakeupClassBUS makeupClassBUS;
        private string currentUserID;
        private string selectedMakeupID;

        public MakeupAttendanceForm()
        {
            InitializeComponent();
            makeupAttendanceBUS = new MakeupAttendanceBUS();
            makeupClassBUS = new MakeupClassBUS();

            // Lấy ID người dùng hiện tại từ session
            currentUserID = UserSession.CurrentUser.UserID;

            // Thiết lập form
            this.Text = "Quản lý điểm danh bù";
            SetupComboBoxes();
            LoadMakeupClasses();
        }

        private void SetupComboBoxes()
        {
            // Thiết lập combobox trạng thái điểm danh
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Present");
            cboStatus.Items.Add("Absent");
            cboStatus.Items.Add("Late");
            cboStatus.Items.Add("Excused");
            cboStatus.SelectedIndex = 0;

            // Thiết lập combobox tìm kiếm
            cboSearchBy.Items.Clear();
            cboSearchBy.Items.Add("StudentID");
            cboSearchBy.Items.Add("MakeupID");
            cboSearchBy.Items.Add("Status");
            cboSearchBy.SelectedIndex = 0;
        }

        private void LoadMakeupClasses()
        {
            try
            {
                List<MakeupClassDTO> makeupClasses = makeupClassBUS.GetMakeupClassesByLecturerID(currentUserID);
                cboMakeupClass.DataSource = makeupClasses;
                cboMakeupClass.DisplayMember = "MakeupID";
                cboMakeupClass.ValueMember = "MakeupID";

                if (makeupClasses.Count > 0)
                {
                    cboMakeupClass.SelectedIndex = 0;
                    selectedMakeupID = cboMakeupClass.SelectedValue.ToString();
                    LoadAttendanceData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách lớp học bù: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAttendanceData()
        {
            try
            {
                if (string.IsNullOrEmpty(selectedMakeupID))
                    return;

                // Lấy thông tin lớp học bù
                MakeupClassDTO makeupClass = makeupClassBUS.GetMakeupClassByID(selectedMakeupID);
                lblMakeupInfo.Text = $"Lớp bù: {makeupClass.MakeupClassID} | Ngày: {makeupClass.MakeupDate.ToString("dd/MM/yyyy")} | Tiết: {makeupClass.Session} | Phòng: {makeupClass.RoomID}";

                // Lấy danh sách điểm danh
                List<MakeupAttendanceDTO> attendanceList = makeupAttendanceBUS.GetMakeupAttendancesByMakeupClassID(selectedMakeupID);
                dgvAttendance.DataSource = attendanceList;

                // Định dạng lại hiển thị của DataGridView
                FormatDataGridView();

                // Hiển thị thông báo số lượng
                lblTotalRecords.Text = $"Tổng số: {attendanceList.Count} sinh viên";

                // Kiểm tra trạng thái lớp học bù
                bool isEditable = makeupClass.Status == "Scheduled";
                btnAdd.Enabled = isEditable;
                btnUpdate.Enabled = isEditable;
                btnDelete.Enabled = isEditable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu điểm danh: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttendance.MultiSelect = false;
            dgvAttendance.ReadOnly = true;

            // Đổi tên các cột hiển thị
            dgvAttendance.Columns["AttendanceID"].HeaderText = "Mã điểm danh";
            dgvAttendance.Columns["StudentID"].HeaderText = "Mã sinh viên";
            dgvAttendance.Columns["MakeupID"].HeaderText = "Mã lớp bù";
            dgvAttendance.Columns["Status"].HeaderText = "Trạng thái";
            dgvAttendance.Columns["Notes"].HeaderText = "Ghi chú";
            dgvAttendance.Columns["UpdatedDate"].HeaderText = "Ngày cập nhật";

            // Định dạng hiển thị ngày tháng
            dgvAttendance.Columns["UpdatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            // Màu nền cho header và các dòng
            dgvAttendance.EnableHeadersVisualStyles = false;
            dgvAttendance.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 150, 136);
            dgvAttendance.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAttendance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvAttendance.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvAttendance.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // Màu khi chọn dòng
            dgvAttendance.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 109);
            dgvAttendance.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void cboMakeupClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMakeupClass.SelectedIndex >= 0)
            {
                selectedMakeupID = cboMakeupClass.SelectedValue.ToString();
                LoadAttendanceData();
                ClearForm();
            }
        }

        private void dgvAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAttendance.Rows[e.RowIndex];

                // Hiển thị thông tin điểm danh được chọn lên form
                txtAttendanceID.Text = row.Cells["AttendanceID"].Value.ToString();
                txtStudentID.Text = row.Cells["StudentID"].Value.ToString();
                cboStatus.Text = row.Cells["Status"].Value.ToString();
                txtNotes.Text = row.Cells["Notes"].Value.ToString();

                // Kiểm tra trạng thái lớp học bù
                MakeupClassDTO makeupClass = makeupClassBUS.GetMakeupClassByID(selectedMakeupID);
                bool isEditable = makeupClass.Status == "Scheduled";

                btnUpdate.Enabled = isEditable;
                btnDelete.Enabled = isEditable;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập
                if (string.IsNullOrWhiteSpace(txtAttendanceID.Text) ||
                    string.IsNullOrWhiteSpace(txtStudentID.Text) ||
                    cboStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin điểm danh!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng điểm danh mới
                MakeupAttendanceDTO attendance = new MakeupAttendanceDTO
                {
                    MakeupAttendanceID = txtAttendanceID.Text.Trim(),
                    StudentID = txtStudentID.Text.Trim(),
                    MakeupClassID = selectedMakeupID,
                    Status = cboStatus.Text,
                    Notes = txtNotes.Text.Trim(),
                    UpdatedDate = DateTime.Now
                };

                // Thêm điểm danh mới
                bool result = makeupAttendanceBUS.AddMakeupAttendance(attendance);
                if (result)
                {
                    MessageBox.Show("Thêm điểm danh thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAttendanceData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm điểm danh thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đã chọn điểm danh chưa
                if (string.IsNullOrWhiteSpace(txtAttendanceID.Text))
                {
                    MessageBox.Show("Vui lòng chọn điểm danh cần cập nhật!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng điểm danh cập nhật
                MakeupAttendanceDTO attendance = new MakeupAttendanceDTO
                {
                    MakeupAttendanceID = txtAttendanceID.Text.Trim(),
                    StudentID = txtStudentID.Text.Trim(),
                    MakeupClassID = selectedMakeupID,
                    Status = cboStatus.Text,
                    Notes = txtNotes.Text.Trim(),
                    UpdatedDate = DateTime.Now
                };

                // Cập nhật điểm danh
                bool result = makeupAttendanceBUS.UpdateMakeupAttendance(attendance);
                if (result)
                {
                    MessageBox.Show("Cập nhật điểm danh thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAttendanceData();
                }
                else
                {
                    MessageBox.Show("Cập nhật điểm danh thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đã chọn điểm danh chưa
                if (string.IsNullOrWhiteSpace(txtAttendanceID.Text))
                {
                    MessageBox.Show("Vui lòng chọn điểm danh cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa điểm danh này?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa điểm danh
                    bool deleteResult = makeupAttendanceBUS.DeleteMakeupAttendance(txtAttendanceID.Text.Trim());
                    if (deleteResult)
                    {
                        MessageBox.Show("Xóa điểm danh thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAttendanceData();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa điểm danh thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtAttendanceID.Text = string.Empty;
            txtStudentID.Text = string.Empty;
            cboStatus.SelectedIndex = 0;
            txtNotes.Text = string.Empty;

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtSearch.Text.Trim();
                if (string.IsNullOrWhiteSpace(searchValue))
                {
                    LoadAttendanceData();
                    return;
                }

                List<MakeupAttendanceDTO> searchResults = new List<MakeupAttendanceDTO>();
                string searchBy = cboSearchBy.Text;

                // Tìm kiếm theo tiêu chí
                switch (searchBy)
                {
                    case "StudentID":
                        searchResults = makeupAttendanceBUS.GetMakeupAttendancesByMakeupClassID(selectedMakeupID);
                        break;
                    case "Status":
                        searchResults = makeupAttendanceBUS.GetMakeupAttendancesByMakeupClassID(selectedMakeupID);
                        break;
                    default:
                        searchResults = makeupAttendanceBUS.GetMakeupAttendancesByMakeupClassID(selectedMakeupID);
                        break;
                }

                dgvAttendance.DataSource = searchResults;
                lblTotalRecords.Text = $"Tổng số: {searchResults.Count} sinh viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            LoadAttendanceData();
            ClearForm();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Excel Files|*.xlsx;*.xls",
                    Title = "Chọn file Excel chứa dữ liệu điểm danh"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    // Gọi hàm import từ BUS
                    bool result = makeupAttendanceBUS.ImportFromExcel(filePath, selectedMakeupID);

                    if (result)
                    {
                        MessageBox.Show("Import dữ liệu điểm danh thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAttendanceData();
                    }
                    else
                    {
                        MessageBox.Show("Import dữ liệu điểm danh thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi import dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Lưu file Excel điểm danh",
                    FileName = $"DiemDanhBu_{selectedMakeupID}_{DateTime.Now.ToString("yyyyMMdd")}"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    // Gọi hàm export từ BUS
                    bool result = makeupAttendanceBUS.ExportToExcel(filePath, selectedMakeupID);

                    if (result)
                    {
                        MessageBox.Show("Export dữ liệu điểm danh thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file Excel sau khi export thành công
                        System.Diagnostics.Process.Start(filePath);
                    }
                    else
                    {
                        MessageBox.Show("Export dữ liệu điểm danh thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi export dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStudentList_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở form danh sách sinh viên để chọn
                StudentListForm studentListForm = new StudentListForm(selectedMakeupID);
                if (studentListForm.ShowDialog() == DialogResult.OK)
                {
                    // Lấy sinh viên được chọn từ form danh sách
                    string selectedStudentID = studentListForm.SelectedStudentID;
                    if (!string.IsNullOrEmpty(selectedStudentID))
                    {
                        txtStudentID.Text = selectedStudentID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTakeAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra trạng thái lớp học bù
                MakeupClassDTO makeupClass = makeupClassBUS.GetMakeupClassByID(selectedMakeupID)[0];
                if (makeupClass.Status != "Scheduled")
                {
                    MessageBox.Show("Không thể điểm danh cho lớp học bù đã hoàn thành hoặc đã hủy!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mở form điểm danh nhanh
                QuickAttendanceForm quickAttendanceForm = new QuickAttendanceForm(selectedMakeupID);
                if (quickAttendanceForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAttendanceData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

