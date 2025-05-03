using System;
using VBTracker.BUS;
using VBTracker.DAL;
using VBTracker.DTO;

namespace VBTracker.BUS
{
    public class AuthenticationBUS
    {
        private StudentDAL studentDAL;
        private LecturerDAL lecturerDAL;

        public AuthenticationBUS()
        {
            studentDAL = new StudentDAL();
            lecturerDAL = new LecturerDAL();
        }

        public bool Login(string username, string password)
        {
            // Kiểm tra đăng nhập với tài khoản sinh viên
            StudentDTO student = studentDAL.GetStudentByUsername(username);
            if (student != null && VerifyPassword(password, student.Password))
            {
                UserSession.Instance.CreateSession(
                    student.StudentID,
                    student.Username,
                    student.FullName,
                    student.Email,
                    "Student"
                );
                return true;
            }

            // Kiểm tra đăng nhập với tài khoản giảng viên
            LecturerDTO lecturer = lecturerDAL.GetLecturerByUsername(username);
            if (lecturer != null && VerifyPassword(password, lecturer.Password))
            {
                UserSession.Instance.CreateSession(
                    lecturer.LecturerID,
                    lecturer.Username,
                    lecturer.FullName,
                    lecturer.Email,
                    "Lecturer"
                );
                return true;
            }

            return false;
        }

        public void Logout()
        {
            UserSession.Instance.ClearSession();
        }

        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            // Trong thực tế, bạn nên sử dụng hàm băm mật khẩu và so sánh
            // Ví dụ đơn giản: return BCrypt.Net.BCrypt.Verify(inputPassword, storedPassword);
            return inputPassword == storedPassword;
        }
    }
}
