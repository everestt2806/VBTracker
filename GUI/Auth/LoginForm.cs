using System;
using System.Windows.Forms;
using VBTracker.BUS;
using VBTracker.GUI.LecturerArea;
using VBTracker.GUI.StudentArea;


namespace VBTracker.GUI.Auth
{
    public partial class LoginForm : Form
    {
        private AuthenticationBUS authBUS;

        public LoginForm()
        {
            InitializeComponent();
            authBUS = new AuthenticationBUS();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Kiểm tra nếu đã đăng nhập trước đó
            if (UserSession.Instance.IsLoggedIn)
            {
                OpenMainForm();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool loginSuccess = authBUS.Login(username, password);

            if (loginSuccess)
            {
                OpenMainForm();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenMainForm()
        {
            // Mở form chính tương ứng với vai trò người dùng
            if (UserSession.Instance.IsStudent())
            {
                StudentDashboard mainForm = new StudentDashboard();
                this.Hide();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
            else if (UserSession.Instance.IsLecturer())
            {
                LecturerDashboard mainForm = new LecturerDashboard();
                this.Hide();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
        }
    }
}
