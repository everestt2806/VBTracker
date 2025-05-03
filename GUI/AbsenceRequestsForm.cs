using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;
using VBTracker.BUS;
using VBTracker.DTO;

namespace VBTracker.GUI
{
    public partial class AbsenceRequestsForm : Form
    {
        private AbsenceRequestBUS absenceRequestBUS;
        private string currentUserID;
        private string currentUserRole;

        public AbsenceRequestsForm()
        {
            InitializeComponent();
            absenceRequestBUS = new AbsenceRequestBUS();

            // Lấy thông tin người dùng hiện tại từ session
            currentUserID = UserSession.CurrentUser.UserID;
            currentUserRole = UserSession.CurrentUser.Role;

            // Thiết lập form
            this.Text = "Quản lý đơn xin nghỉ";
            SetupComboBoxes();
            LoadData();

            // Hiển thị các chức năng khác nhau tùy theo vai trò người dùng
            ConfigureByUserRole();
        }

        private void ConfigureByUserRole()
        {
            // Nếu là sinh viên, chỉ hiển thị đơn của mình
            if (currentUserRole == "Student")
            {
                lblTitle.Text = "QUẢN LÝ ĐƠN XIN NGHỈ CỦA TÔI";
                btnApprove.Visible = false;
                btnReject.Visible = false;

                // Hiển thị đơn của sinh viên hiện tại
                LoadStudentRequests();
            }
            // Nếu là giảng viên, hiển thị đơn của sinh viên trong các lớp mình dạy
            else if (currentUserRole == "Lecturer")
            {
                lblTitle.Text = "DUYỆT ĐƠN XIN NGHỈ";
                btnDelete.Visible = false;

                // Hiển thị đơn chờ duyệt
                LoadPendingRequests();
            }
            // Nếu là admin, hiển thị tất cả đơn
            else if (currentUserRole == "Admin")
            {
                lblTitle.Text = "QUẢN LÝ ĐƠN XIN NGHỈ";
                // Hiển thị tất cả đơn
                LoadData();
            }
        }

        private void SetupComboBoxes()
        {
            // Thiết lập combobox trạng thái
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Pending");
            cboStatus.Items.Add("Approved");
            cboStatus.Items.Add("Rejected");
            cboStatus.SelectedIndex = 0;

            // Thiết lập combobox tìm kiếm
            cboSearchBy.Items.Clear();
            cboSearchBy.Items.Add("RequestID");
            cboSearchBy.Items.Add("StudentID");
            cboSearchBy.Items.Add("ScheduleID");
            cboSearchBy.Items.Add("Status");
            cboSearchBy.SelectedIndex = 0;
        }

        private void LoadData()
        {
            try
            {
                List<AbsenceRequestDTO> requests = absenceRequestBUS.GetAllAbsenceRequests();
                dgvAbsenceRequests.DataSource = requests;

                // Định dạng lại hiển thị của DataGridView
                FormatDataGridView();

                // Hiển thị thông báo số lượng
                lblTotalRecords.Text = $"Tổng số: {requests.Count} đơn xin nghỉ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStudentRequests()
        {
            try
            {
                List<AbsenceRequestDTO> requests = absenceRequestBUS.GetAbsenceRequestsByStudentID(currentUserID);
                dgvAbsenceRequests.DataSource = requests;

                // Định dạng lại hiển thị của DataGridView
                FormatDataGridView();

                // Hiển thị thông báo số lượng
                lblTotalRecords.Text = $"Tổng số: {requests.Count} đơn xin nghỉ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPendingRequests()
        {
            try
            {
                // Thay thế phương thức không tồn tại bằng phương thức tương tự
                List<AbsenceRequestDTO> requests = absenceRequestBUS.GetAbsenceRequestsByLecturerAndStatus(currentUserID, "Pending");
                dgvAbsenceRequests.DataSource = requests;
                
                // Định dạng lại hiển thị của DataGridView
                FormatDataGridView();
                
                // Hiển thị thông báo số lượng
                lblTotalRecords.Text = $"Tổng số: {requests.Count} đơn xin nghỉ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            dgvAbsenceRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAbsenceRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAbsenceRequests.MultiSelect = false;
            dgvAbsenceRequests.ReadOnly = true;

            // Đổi tên các cột hiển thị
            dgvAbsenceRequests.Columns["RequestID"].HeaderText = "Mã đơn";
            dgvAbsenceRequests.Columns["StudentID"].HeaderText = "Mã sinh viên";
            dgvAbsenceRequests.Columns["ScheduleID"].HeaderText = "Mã lịch học";
            dgvAbsenceRequests.Columns["RequestDate"].HeaderText = "Ngày yêu cầu";
            dgvAbsenceRequests.Columns["Reason"].HeaderText = "Lý do";
            dgvAbsenceRequests.Columns["Status"].HeaderText = "Trạng thái";
            dgvAbsenceRequests.Columns["ApprovedBy"].HeaderText = "Người duyệt";
            dgvAbsenceRequests.Columns["ApprovalDate"].HeaderText = "Ngày duyệt";
            dgvAbsenceRequests.Columns["Comments"].HeaderText = "Ghi chú";

            // Định dạng hiển thị ngày tháng
            dgvAbsenceRequests.Columns["RequestDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvAbsenceRequests.Columns["ApprovalDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            // Màu nền cho header và các dòng
            dgvAbsenceRequests.EnableHeadersVisualStyles = false;
            dgvAbsenceRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 150, 136);
            dgvAbsenceRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAbsenceRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvAbsenceRequests.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvAbsenceRequests.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // Màu khi chọn dòng
            dgvAbsenceRequests.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 109);
            dgvAbsenceRequests.DefaultCellStyle.SelectionForeColor = Color.White;

            // Màu cho các trạng thái khác nhau
            foreach (DataGridViewRow row in dgvAbsenceRequests.Rows)
            {
                string status = row.Cells["Status"].Value.ToString();
                if (status == "Approved")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220);
                }
                else if (status == "Rejected")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                }
                else if (status == "Pending")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 220);
                }
            }
        }

        private void dgvAbsenceRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAbsenceRequests.Rows[e.RowIndex];

                // Hiển thị thông tin đơn xin nghỉ được chọn lên form
                txtRequestID.Text = row.Cells["RequestID"].Value.ToString();
                txtStudentID.Text = row.Cells["StudentID"].Value.ToString();
                txtScheduleID.Text = row.Cells["ScheduleID"].Value.ToString();
                dtpRequestDate.Value = Convert.ToDateTime(row.Cells["RequestDate"].Value);
                txtReason.Text = row.Cells["Reason"].Value.ToString();
                cboStatus.Text = row.Cells["Status"].Value.ToString();
                txtComments.Text = row.Cells["Comments"].Value.ToString();

                // Kiểm tra quyền chỉnh sửa
                string status = row.Cells["Status"].Value.ToString();
                string studentID = row.Cells["StudentID"].Value.ToString();

                // Sinh viên chỉ có thể xóa đơn của mình khi đang ở trạng thái Pending
                if (currentUserRole == "Student")
                {
                    btnDelete.Enabled = (studentID == currentUserID && status == "Pending");
                    btnUpdate.Enabled = (studentID == currentUserID && status == "Pending");
                }
                // Giảng viên chỉ có thể duyệt/từ chối đơn khi đang ở trạng thái Pending
                else if (currentUserRole == "Lecturer")
                {
                    btnApprove.Enabled = (status == "Pending");
                    btnReject.Enabled = (status == "Pending");
                }
                // Admin có thể thao tác mọi đơn
                else if (currentUserRole == "Admin")
                {
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnApprove.Enabled = (status == "Pending");
                    btnReject.Enabled = (status == "Pending");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập
                if (string.IsNullOrWhiteSpace(txtRequestID.Text) ||
                    string.IsNullOrWhiteSpace(txtScheduleID.Text) ||
                    string.IsNullOrWhiteSpace(txtReason.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin đơn xin nghỉ!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng đơn xin nghỉ mới
                AbsenceRequestDTO request = new AbsenceRequestDTO
                {
                    RequestID = txtRequestID.Text.Trim(),
                    StudentID = currentUserRole == "Student" ? currentUserID : txtStudentID.Text.Trim(),
                    ScheduleID = txtScheduleID.Text.Trim(),
                    RequestDate = dtpRequestDate.Value,
                    Reason = txtReason.Text.Trim(),
                    Status = "Pending",
                    Comments = txtComments.Text.Trim()
                };

                // Thêm đơn xin nghỉ mới
                bool result = absenceRequestBUS.AddAbsenceRequest(request);
                if (result)
                {
                    MessageBox.Show("Thêm đơn xin nghỉ thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại dữ liệu theo vai trò người dùng
                    if (currentUserRole == "Student")
                        LoadStudentRequests();
                    else if (currentUserRole == "Lecturer")
                        LoadPendingRequests();
                    else
                        LoadData();

                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm đơn xin nghỉ thất bại!", "Lỗi",
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
                // Kiểm tra đã chọn đơn xin nghỉ chưa
                if (string.IsNullOrWhiteSpace(txtRequestID.Text))
                {
                    MessageBox.Show("Vui lòng chọn đơn xin nghỉ cần cập nhật!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng đơn xin nghỉ cập nhật
                AbsenceRequestDTO request = new AbsenceRequestDTO
                {
                    RequestID = txtRequestID.Text.Trim(),
                    StudentID = txtStudentID.Text.Trim(),
                    ScheduleID = txtScheduleID.Text.Trim(),
                    RequestDate = dtpRequestDate.Value,
                    Reason = txtReason.Text.Trim(),
                    Status = cboStatus.Text,
                    Comments = txtComments.Text.Trim()
                };

                // Cập nhật đơn xin nghỉ
                bool result = absenceRequestBUS.UpdateAbsenceRequest(request);
                if (result)
                {
                    MessageBox.Show("Cập nhật đơn xin nghỉ thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại dữ liệu theo vai trò người dùng
                    if (currentUserRole == "Student")
                        LoadStudentRequests();
                    else if (currentUserRole == "Lecturer")
                        LoadPendingRequests();
                    else
                        LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật đơn xin nghỉ thất bại!", "Lỗi",
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
                // Kiểm tra đã chọn đơn xin nghỉ chưa
                if (string.IsNullOrWhiteSpace(txtRequestID.Text))
                {
                    MessageBox.Show("Vui lòng chọn đơn xin nghỉ cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn xin nghỉ này?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa đơn xin nghỉ
                    bool deleteResult = absenceRequestBUS.DeleteAbsenceRequest(txtRequestID.Text.Trim());
                    if (deleteResult)
                    {
                        MessageBox.Show("Xóa đơn xin nghỉ thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại dữ liệu theo vai trò người dùng
                        if (currentUserRole == "Student")
                            LoadStudentRequests();
                        else if (currentUserRole == "Lecturer")
                            LoadPendingRequests();
                        else
                            LoadData();

                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa đơn xin nghỉ thất bại!", "Lỗi",
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

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đã chọn đơn xin nghỉ chưa
                if (string.IsNullOrWhiteSpace(txtRequestID.Text))
                {
                    MessageBox.Show("Vui lòng chọn đơn xin nghỉ cần duyệt!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận duyệt
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn duyệt đơn xin nghỉ này?",
                    "Xác nhận duyệt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Duyệt đơn xin nghỉ
                    bool approveResult = absenceRequestBUS.ApproveAbsenceRequest(
                        txtRequestID.Text.Trim(),
                        currentUserID,
                        txtComments.Text.Trim());

                    if (approveResult)
                    {
                        MessageBox.Show("Duyệt đơn xin nghỉ thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại dữ liệu theo vai trò người dùng
                        if (currentUserRole == "Lecturer")
                            LoadPendingRequests();
                        else
                            LoadData();

                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Duyệt đơn xin nghỉ thất bại!", "Lỗi",
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

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đã chọn đơn xin nghỉ chưa
                if (string.IsNullOrWhiteSpace(txtRequestID.Text))
                {
                    MessageBox.Show("Vui lòng chọn đơn xin nghỉ cần từ chối!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận từ chối
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn từ chối đơn xin nghỉ này?",
                    "Xác nhận từ chối", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Từ chối đơn xin nghỉ
                    bool rejectResult = absenceRequestBUS.RejectAbsenceRequest(
                        txtRequestID.Text.Trim(),
                        currentUserID,
                        txtComments.Text.Trim());

                    if (rejectResult)
                    {
                        MessageBox.Show("Từ chối đơn xin nghỉ thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại dữ liệu theo vai trò người dùng
                        if (currentUserRole == "Lecturer")
                            LoadPendingRequests();
                        else
                            LoadData();

                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Từ chối đơn xin nghỉ thất bại!", "Lỗi",
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
            txtRequestID.Text = string.Empty;
            txtStudentID.Text = string.Empty;
            txtScheduleID.Text = string.Empty;
            dtpRequestDate.Value = DateTime.Today;
            txtReason.Text = string.Empty;
            cboStatus.SelectedIndex = 0;
            txtComments.Text = string.Empty;

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnApprove.Enabled = false;
            btnReject.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtSearch.Text.Trim();
                if (string.IsNullOrWhiteSpace(searchValue))
                {
                    // Tải lại dữ liệu theo vai trò người dùng
                    if (currentUserRole == "Student")
                        LoadStudentRequests();
                    else if (currentUserRole == "Lecturer")
                        LoadPendingRequests();
                    else
                        LoadData();

                    return;
                }

                List<AbsenceRequestDTO> searchResults = new List<AbsenceRequestDTO>();
                string searchBy = cboSearchBy.Text;

                // Tìm kiếm theo tiêu chí
                switch (searchBy)
                {
                    case "RequestID":
                        searchResults = absenceRequestBUS.GetAbsenceRequestByID(searchValue);
                        break;
                    case "StudentID":
                        searchResults = absenceRequestBUS.GetAbsenceRequestsByStudentID(searchValue);
                        break;
                    case "ScheduleID":
                        searchResults = absenceRequestBUS.GetAbsenceRequestsByScheduleID(searchValue);
                        break;
                    case "Status":
                        searchResults = absenceRequestBUS.GetAbsenceRequestsByStatus(searchValue);
                        break;
                    default:
                        if (currentUserRole == "Student")
                            searchResults = absenceRequestBUS.GetAbsenceRequestsByStudentID(currentUserID);
                        else if (currentUserRole == "Lecturer")
                            searchResults = absenceRequestBUS.GetPendingRequests();
                        else
                            searchResults = absenceRequestBUS.GetAllAbsenceRequests();
                        break;
                }

                // Lọc thêm theo vai trò người dùng
                if (currentUserRole == "Student")
                {
                    searchResults = searchResults.FindAll(r => r.StudentID == currentUserID);
                }
                else if (currentUserRole == "Lecturer")
                {
                    // Lọc theo lớp học mà giảng viên phụ trách
                    // (Giả sử đã có phương thức lọc trong BUS)
                    searchResults = absenceRequestBUS.FilterRequestsByLecturer(searchResults, currentUserID);
                }

                dgvAbsenceRequests.DataSource = searchResults;
                FormatDataGridView();
                lblTotalRecords.Text = $"Tổng số: {searchResults.Count} đơn xin nghỉ";
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

            // Tải lại dữ liệu theo vai trò người dùng
            if (currentUserRole == "Student")
                LoadStudentRequests();
            else if (currentUserRole == "Lecturer")
                LoadPendingRequests();
            else
                LoadData();

            ClearForm();
        }

        private void btnScheduleList_Click(object sender, EventArgs e)
        {
            try
            {
                //// Mở form danh sách lịch học để chọn
                //ScheduleListForm scheduleListForm = new ScheduleListForm();
                //if (scheduleListForm.ShowDialog() == DialogResult.OK)
                //{
                //    // Lấy lịch học được chọn từ form danh sách
                //    string selectedScheduleID = scheduleListForm.SelectedScheduleID;
                //    if (!string.IsNullOrEmpty(selectedScheduleID))
                //    {
                //        txtScheduleID.Text = selectedScheduleID;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

