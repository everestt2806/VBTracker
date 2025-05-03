using System;
using System.Collections.Generic;
using VBTracker.DAL;
using VBTracker.DTO;

namespace VBTracker.BUS
{
    public class LecturerBUS
    {
        private LecturerDAL lecturerDAL;

        public LecturerBUS()
        {
            lecturerDAL = new LecturerDAL();
        }

        public List<LecturerDTO> GetAllLecturers()
        {
            return lecturerDAL.GetAllLecturers();
        }

        public LecturerDTO GetLecturerByID(string lecturerID)
        {
            if (string.IsNullOrEmpty(lecturerID))
                throw new ArgumentException("Mã giảng viên không được để trống");

            return lecturerDAL.GetLecturerByID(lecturerID);
        }

        public LecturerDTO GetLecturerByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Tên đăng nhập không được để trống");

            return lecturerDAL.GetLecturerByUsername(username);
        }

        public bool AddLecturer(LecturerDTO lecturer)
        {
            ValidateLecturerData(lecturer);

            // Kiểm tra mã giảng viên đã tồn tại chưa
            if (lecturerDAL.GetLecturerByID(lecturer.LecturerID) != null)
                throw new Exception("Mã giảng viên đã tồn tại");

            // Kiểm tra email đã tồn tại chưa
            List<LecturerDTO> allLecturers = lecturerDAL.GetAllLecturers();
            if (allLecturers.Exists(l => l.Email.Equals(lecturer.Email, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Email đã được sử dụng");

            // Kiểm tra username đã tồn tại chưa
            if (allLecturers.Exists(l => l.Username.Equals(lecturer.Username, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Tên đăng nhập đã được sử dụng");

            return lecturerDAL.AddLecturer(lecturer);
        }

        public bool UpdateLecturer(LecturerDTO lecturer)
        {
            ValidateLecturerData(lecturer);

            // Kiểm tra giảng viên tồn tại
            LecturerDTO existingLecturer = lecturerDAL.GetLecturerByID(lecturer.LecturerID);
            if (existingLecturer == null)
                throw new Exception("Giảng viên không tồn tại");

            // Kiểm tra email đã tồn tại chưa (trừ email của chính giảng viên này)
            List<LecturerDTO> allLecturers = lecturerDAL.GetAllLecturers();
            if (allLecturers.Exists(l => l.Email.Equals(lecturer.Email, StringComparison.OrdinalIgnoreCase) &&
                                        !l.LecturerID.Equals(lecturer.LecturerID)))
                throw new Exception("Email đã được sử dụng");

            // Kiểm tra username đã tồn tại chưa (trừ username của chính giảng viên này)
            if (allLecturers.Exists(l => l.Username.Equals(lecturer.Username, StringComparison.OrdinalIgnoreCase) &&
                                        !l.LecturerID.Equals(lecturer.LecturerID)))
                throw new Exception("Tên đăng nhập đã được sử dụng");

            return lecturerDAL.UpdateLecturer(lecturer);
        }
        public bool DeleteLecturer(string lecturerID)
        {
            if (string.IsNullOrEmpty(lecturerID))
                throw new ArgumentException("Mã giảng viên không được để trống");

            // Kiểm tra giảng viên tồn tại
            LecturerDTO existingLecturer = lecturerDAL.GetLecturerByID(lecturerID);
            if (existingLecturer == null)
                throw new Exception("Giảng viên không tồn tại");

            // TODO: Kiểm tra các ràng buộc khác trước khi xóa (ví dụ: giảng viên đang dạy lớp học)

            return lecturerDAL.DeleteLecturer(lecturerID);
        }

        private void ValidateLecturerData(LecturerDTO lecturer)
        {
            if (lecturer == null)
                throw new ArgumentNullException("Dữ liệu giảng viên không được để trống");

            if (string.IsNullOrEmpty(lecturer.LecturerID))
                throw new ArgumentException("Mã giảng viên không được để trống");

            if (string.IsNullOrEmpty(lecturer.FullName))
                throw new ArgumentException("Họ tên không được để trống");

            if (string.IsNullOrEmpty(lecturer.Email))
                throw new ArgumentException("Email không được để trống");

            if (string.IsNullOrEmpty(lecturer.Username))
                throw new ArgumentException("Tên đăng nhập không được để trống");

            if (string.IsNullOrEmpty(lecturer.Password))
                throw new ArgumentException("Mật khẩu không được để trống");

            // Kiểm tra định dạng email
            if (!IsValidEmail(lecturer.Email))
                throw new ArgumentException("Email không đúng định dạng");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

