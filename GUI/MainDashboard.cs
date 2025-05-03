using System;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Forms;
using VBTracker.GUI.Auth;

namespace VBTracker.GUI
{
    public partial class MainDashboard : Form
    {
        private Form activeForm = null;
        private Button currentButton = null;

        public MainDashboard()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            // Thiết lập giao diện ban đầu
            this.Text = "VBTracker - Hệ thống quản lý điểm danh";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            // Hiển thị form Home mặc định
            //OpenChildForm(new HomeForm());
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = Color.FromArgb(0, 150, 136); // Teal color
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(45, 52, 54); // Dark background
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //OpenChildForm(new HomeForm());
        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //OpenChildForm(new ClassesForm());
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //OpenChildForm(new AttendanceForm());
        }

        private void btnMakeupClasses_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new MakeupClassesForm());
        }

        private void btnMakeupAttendance_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new MakeupAttendanceForm());
        }

        private void btnAbsenceRequests_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new AbsenceRequestsForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //OpenChildForm(new ReportsForm());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //OpenChildForm(new SettingsForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                // Hiển thị form đăng nhập
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }
    }
}
