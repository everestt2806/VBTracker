using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;
using VBTracker.BUS;
using VBTracker.DTO;

namespace VBTracker.GUI
{
    public partial class MakeupClassesForm : Form
    {
        private MakeupClassBUS makeupClassBUS;
        private string currentUserID;

        public MakeupClassesForm()
        {
            InitializeComponent();
            makeupClassBUS = new MakeupClassBUS();

            // Lấy ID người dùng hiện tại từ session
            currentUserID = UserSession.CurrentUser.UserID;

            // Thiết lập form
            this.Text = "Quản lý lớp học bù";
            LoadData();
            SetupComboBoxes();
        }

        private void LoadData()
        {
            try
            {
                List<MakeupClassDTO> makeupClasses = makeupClassBUS.GetAllMakeupClasses();
                dgvMakeupClasses.DataSource = makeupClasses;

                // Định dạng lại hiển thị của DataGridView
                FormatDataGridView();

                // Hiển thị thông báo số lượng
                lblTotalRecords.Text = $"Tổng số: {makeupClasses.Count} lớp học bù";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupComboBoxes()
        {
            // Thiết lập combobox trạng thái
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Scheduled");
            cboStatus.Items.Add("Completed");
            cboStatus.Items.Add("Cancelled");
            cboStatus.SelectedIndex = 0;

            // Thiết lập combobox tiết học
            cboSession.Items.Clear();
            cboSession.Items.Add("1");
            cboSession.Items.Add("2");
            cboSession.Items.Add("3");
            cboSession.Items.Add("4");
            cboSession.Items.Add("5");
            cboSession.Items.Add("6");

            // Thiết lập combobox tìm kiếm
            cboSearchBy.Items.Clear();
            cboSearchBy.Items.Add("MakeupID");
            cboSearchBy.Items.Add("OriginalScheduleID");
            cboSearchBy.Items.Add("RoomID");
            cboSearchBy.Items.Add("Status");
            cboSearchBy.SelectedIndex = 0;
        }

        private void FormatDataGridView()
        {
            dgvMakeupClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMakeupClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMakeupClasses.MultiSelect = false;
            dgvMakeupClasses.ReadOnly = true;

            // Đổi tên các cột hiển thị
            dgvMakeupClasses.Columns["MakeupID"].HeaderText = "Mã lớp bù";
            dgvMakeupClasses.Columns["OriginalScheduleID"].HeaderText = "Mã lịch gốc";
            dgvMakeupClasses.Columns["RoomID"].HeaderText = "Phòng học";
            dgvMakeupClasses.Columns["MakeupDate"].HeaderText = "Ngày học bù";
            dgvMakeupClasses.Columns["Session"].HeaderText = "Tiết";
            dgvMakeupClasses.Columns["Status"].HeaderText = "Trạng thái";
            dgvMakeupClasses.Columns["CreatedBy"].HeaderText = "Người tạo";
            dgvMakeupClasses.Columns["CreatedDate"].HeaderText = "Ngày tạo";
            dgvMakeupClasses.Columns["Notes"].HeaderText = "Ghi chú";

            // Định dạng hiển thị ngày tháng
            dgvMakeupClasses.Columns["MakeupDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMakeupClasses.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            // Màu nền cho header và các dòng
            dgvMakeupClasses.EnableHeadersVisualStyles = false;
            dgvMakeupClasses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 150, 136);
            dgvMakeupClasses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMakeupClasses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvMakeupClasses.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvMakeupClasses.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // Màu khi chọn dòng
            dgvMakeupClasses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 109);
            dgvMakeupClasses.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void dgvMakeupClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMakeupClasses.Rows[e.RowIndex];

                // Hiển thị thông tin lớp học bù được chọn lên form
                txtMakeupID.Text = row.Cells["MakeupID"].Value.ToString();
                txtOriginalScheduleID.Text = row.Cells["OriginalScheduleID"].Value.ToString();
                txtRoomID.Text = row.Cells["RoomID"].Value.ToString();
                dtpMakeupDate.Value = Convert.ToDateTime(row.Cells["MakeupDate"].Value);
                cboSession.Text = row.Cells["Session"].Value.ToString();
                cboStatus.Text = row.Cells["Status"].Value.ToString();
                txtNotes.Text = row.Cells["Notes"].Value.ToString();

                // Kiểm tra quyền chỉnh sửa
                bool isCreator = row.Cells["CreatedBy"].Value.ToString() == currentUserID;
                bool isScheduled = row.Cells["Status"].Value.ToString() == "Scheduled";

                // Chỉ cho phép chỉnh sửa nếu là người tạo và trạng thái là Scheduled
                btnUpdate.Enabled = isCreator && isScheduled;
                btnDelete.Enabled = isCreator && isScheduled;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập
                if (string.IsNullOrWhiteSpace(txtMakeupID.Text) ||
                    string.IsNullOrWhiteSpace(txtOriginalScheduleID.Text) ||
                    string.IsNullOrWhiteSpace(txtRoomID.Text) ||
                    cboSession.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin lớp học bù!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng lớp học bù mới
                MakeupClassDTO makeupClass = new MakeupClassDTO
                {
                    MakeupID = txtMakeupID.Text.Trim(),
                    OriginalScheduleID = txtOriginalScheduleID.Text.Trim(),
                    RoomID = txtRoomID.Text.Trim(),
                    MakeupDate = dtpMakeupDate.Value,
                    Session = cboSession.Text,
                    Status = cboStatus.Text,
                    CreatedBy = currentUserID,
                    Notes = txtNotes.Text.Trim()
                };

                // Thêm lớp học bù mới
                bool result = makeupClassBUS.AddMakeupClass(makeupClass);
                if (result)
                {
                    MessageBox.Show("Thêm lớp học bù thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm lớp học bù thất bại!", "Lỗi",
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
                // Kiểm tra đã chọn lớp học bù chưa
                if (string.IsNullOrWhiteSpace(txtMakeupID.Text))
                {
                    MessageBox.Show("Vui lòng chọn lớp học bù cần cập nhật!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng lớp học bù cập nhật
                MakeupClassDTO makeupClass = new MakeupClassDTO
                {
                    MakeupID = txtMakeupID.Text.Trim(),
                    OriginalScheduleID = txtOriginalScheduleID.Text.Trim(),
                    RoomID = txtRoomID.Text.Trim(),
                    MakeupDate = dtpMakeupDate.Value,
                    Session = cboSession.Text,
                    Status = cboStatus.Text,
                    CreatedBy = currentUserID,
                    Notes = txtNotes.Text.Trim()
                };

                // Cập nhật lớp học bù
                bool result = makeupClassBUS.UpdateMakeupClass(makeupClass);
                if (result)
                {
                    MessageBox.Show("Cập nhật lớp học bù thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật lớp học bù thất bại!", "Lỗi",
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
                // Kiểm tra đã chọn lớp học bù chưa
                if (string.IsNullOrWhiteSpace(txtMakeupID.Text))
                {
                    MessageBox.Show("Vui lòng chọn lớp học bù cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học bù này?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa lớp học bù
                    bool deleteResult = makeupClassBUS.DeleteMakeupClass(txtMakeupID.Text.Trim());
                    if (deleteResult)
                    {
                        MessageBox.Show("Xóa lớp học bù thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa lớp học bù thất bại!", "Lỗi",
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
            txtMakeupID.Text = string.Empty;
            txtOriginalScheduleID.Text = string.Empty;
            txtRoomID.Text = string.Empty;
            dtpMakeupDate.Value = DateTime.Today;
            cboSession.SelectedIndex = -1;
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
                    LoadData();
                    return;
                }

                List<MakeupClassDTO> searchResults = new List<MakeupClassDTO>();
                string searchBy = cboSearchBy.Text;

                // Tìm kiếm theo tiêu chí
                switch (searchBy)
                {
                    case "MakeupID":
                        searchResults = makeupClassBUS.GetMakeupClassByID(searchValue);
                        break;
                    case "OriginalScheduleID":
                        searchResults = makeupClassBUS.GetMakeupClassesByScheduleID(searchValue);
                        break;
                    case "RoomID":
                        searchResults = makeupClassBUS.GetMakeupClassesByRoomID(searchValue);
                        break;
                    case "Status":
                        searchResults = makeupClassBUS.GetMakeupClassesByStatus(searchValue);
                        break;
                    default:
                        searchResults = makeupClassBUS.GetAllMakeupClasses();
                        break;
                }

                dgvMakeupClasses.DataSource = searchResults;
                lblTotalRecords.Text = $"Tổng số: {searchResults.Count} lớp học bù";
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
            LoadData();
            ClearForm();
        }
    }
}
