using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using VBTracker.DAL;
using VBTracker.DTO;

namespace VBTracker.BUS
{
    public class StudentBUS
    {
        private StudentDAL studentDAL;

        public StudentBUS()
        {
            studentDAL = new StudentDAL();
        }

        public List<StudentDTO> GetAllStudents()
        {
            return studentDAL.GetAll();
        }

        public StudentDTO GetStudentByID(string studentID)
        {
            if (string.IsNullOrEmpty(studentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            return studentDAL.GetStudentByID(studentID);
        }

        public StudentDTO GetStudentByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Tên đăng nhập không được để trống");

            return studentDAL.GetStudentByUsername(username);
        }

        //public StudentDTO Login(string username, string password)
        //{
        //    if (string.IsNullOrEmpty(username))
        //        throw new ArgumentException("Tên đăng nhập không được để trống");

        //    if (string.IsNullOrEmpty(password))
        //        throw new ArgumentException("Mật khẩu không được để trống");

        //    return studentDAL.Login(username, password);
        //}

        public bool AddStudent(StudentDTO student)
        {
            ValidateStudentData(student);

            // Kiểm tra mã sinh viên đã tồn tại chưa
            if (studentDAL.GetStudentByID(student.StudentID) != null)
                throw new Exception("Mã sinh viên đã tồn tại");

            // Kiểm tra email đã tồn tại chưa
            List<StudentDTO> allStudents = studentDAL.GetAll();
            if (allStudents.Exists(s => s.Email.Equals(student.Email, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Email đã được sử dụng");

            // Kiểm tra username đã tồn tại chưa
            if (allStudents.Exists(s => s.Username.Equals(student.Username, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Tên đăng nhập đã được sử dụng");

            // Kiểm tra định dạng mã sinh viên
            if (!IsValidStudentID(student.StudentID))
                throw new ArgumentException("Mã sinh viên không đúng định dạng (phải có dạng 5x1HXXXX)");

            return studentDAL.Insert(student);
        }

        public bool UpdateStudent(StudentDTO student)
        {
            ValidateStudentData(student);

            // Kiểm tra sinh viên tồn tại
            StudentDTO existingStudent = studentDAL.GetStudentByID(student.StudentID);
            if (existingStudent == null)
                throw new Exception("Sinh viên không tồn tại");

            // Kiểm tra email đã tồn tại chưa (trừ email của chính sinh viên này)
            List<StudentDTO> allStudents = studentDAL.GetAll();
            if (allStudents.Exists(s => s.Email.Equals(student.Email, StringComparison.OrdinalIgnoreCase) &&
                                       !s.StudentID.Equals(student.StudentID)))
                throw new Exception("Email đã được sử dụng");

            // Kiểm tra username đã tồn tại chưa (trừ username của chính sinh viên này)
            if (allStudents.Exists(s => s.Username.Equals(student.Username, StringComparison.OrdinalIgnoreCase) &&
                                       !s.StudentID.Equals(student.StudentID)))
                throw new Exception("Tên đăng nhập đã được sử dụng");

            return studentDAL.Update(student);
        }

        public bool DeleteStudent(string studentID)
        {
            if (string.IsNullOrEmpty(studentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            // Kiểm tra sinh viên tồn tại
            StudentDTO existingStudent = studentDAL.GetStudentByID(studentID);
            if (existingStudent == null)
                throw new Exception("Sinh viên không tồn tại");

            // TODO: Kiểm tra các ràng buộc khác trước khi xóa (ví dụ: sinh viên đã đăng ký lớp học)

            return studentDAL.Delete(studentID);
        }

        public List<StudentDTO> SearchStudentsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new List<StudentDTO>();

            return studentDAL.SearchStudentsByName(name);
        }

        public List<StudentDTO> FilterStudentsByMajor(string major)
        {
            if (string.IsNullOrEmpty(major))
                return new List<StudentDTO>();

            return studentDAL.FilterStudentsByMajor(major);
        }

        // Lấy danh sách các chuyên ngành
        public List<string> GetAllMajors()
        {
            List<string> majors = new List<string>();
            List<StudentDTO> students = studentDAL.GetAll();

            foreach (var student in students)
            {
                if (!string.IsNullOrEmpty(student.Major) && !majors.Contains(student.Major))
                {
                    majors.Add(student.Major);
                }
            }

            return majors;
        }

        // Thay đổi mật khẩu
        public bool ChangePassword(string studentID, string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(studentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            if (string.IsNullOrEmpty(oldPassword))
                throw new ArgumentException("Mật khẩu cũ không được để trống");

            if (string.IsNullOrEmpty(newPassword))
                throw new ArgumentException("Mật khẩu mới không được để trống");

            if (newPassword.Length < 6)
                throw new ArgumentException("Mật khẩu mới phải có ít nhất 6 ký tự");

            // Kiểm tra sinh viên tồn tại
            StudentDTO student = studentDAL.GetStudentByID(studentID);
            if (student == null)
                throw new Exception("Sinh viên không tồn tại");

            // Kiểm tra mật khẩu cũ
            if (!student.Password.Equals(oldPassword))
                throw new Exception("Mật khẩu cũ không đúng");

            // Cập nhật mật khẩu mới
            student.Password = newPassword;
            return studentDAL.Update(student);
        }

        private void ValidateStudentData(StudentDTO student)
        {
            if (student == null)
                throw new ArgumentNullException("Dữ liệu sinh viên không được để trống");

            if (string.IsNullOrEmpty(student.StudentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            if (string.IsNullOrEmpty(student.FullName))
                throw new ArgumentException("Họ tên không được để trống");

            if (string.IsNullOrEmpty(student.Email))
                throw new ArgumentException("Email không được để trống");

            if (string.IsNullOrEmpty(student.PhoneNumber))
                throw new ArgumentException("Số điện thoại không được để trống");

            if (string.IsNullOrEmpty(student.Major))
                throw new ArgumentException("Chuyên ngành không được để trống");

            if (string.IsNullOrEmpty(student.Gender))
                throw new ArgumentException("Giới tính không được để trống");

            if (string.IsNullOrEmpty(student.Hometown))
                throw new ArgumentException("Quê quán không được để trống");

            if (student.DOB == DateTime.MinValue)
                throw new ArgumentException("Ngày sinh không hợp lệ");

            if (string.IsNullOrEmpty(student.Username))
                throw new ArgumentException("Tên đăng nhập không được để trống");

            if (string.IsNullOrEmpty(student.Password))
                throw new ArgumentException("Mật khẩu không được để trống");

            // Kiểm tra định dạng email
            if (!IsValidEmail(student.Email))
                throw new ArgumentException("Email không đúng định dạng");

            // Kiểm tra định dạng số điện thoại
            if (!IsValidPhoneNumber(student.PhoneNumber))
                throw new ArgumentException("Số điện thoại không đúng định dạng");

            // Kiểm tra tuổi hợp lệ (từ 16 đến 100 tuổi)
            int age = DateTime.Now.Year - student.DOB.Year;
            if (DateTime.Now.DayOfYear < student.DOB.DayOfYear)
                age--;

            if (age < 16 || age > 100)
                throw new ArgumentException("Tuổi phải từ 16 đến 100");

            // Kiểm tra mật khẩu (ít nhất 6 ký tự)
            if (student.Password.Length < 6)
                throw new ArgumentException("Mật khẩu phải có ít nhất 6 ký tự");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.EndsWith("@student.tdtu.edu.vn");
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Kiểm tra số điện thoại Việt Nam (10 số, bắt đầu bằng 0)
            return Regex.IsMatch(phoneNumber, @"^0\d{9}$");
        }

        private bool IsValidStudentID(string studentID)
        {
            // Kiểm tra mã sinh viên có định dạng 5x1HXXXX
            return Regex.IsMatch(studentID, @"^5x1H\d{4}$");
        }
    }
}
