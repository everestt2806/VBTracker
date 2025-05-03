using System;
using System.Collections.Generic;
using VBTracker.DAL;
using VBTracker.DTO;

namespace VBTracker.BUS
{
    public class ClassEnrollmentBUS
    {
        private ClassEnrollmentDAL enrollmentDAL;
        private StudentDAL studentDAL;
        private ClassDAL classDAL;

        public ClassEnrollmentBUS()
        {
            enrollmentDAL = new ClassEnrollmentDAL();
            studentDAL = new StudentDAL();
            classDAL = new ClassDAL();
        }

        public List<ClassEnrollmentDTO> GetEnrollmentsByClassID(string classID)
        {
            if (string.IsNullOrEmpty(classID))
                throw new ArgumentException("Mã lớp học không được để trống");

            return enrollmentDAL.GetEnrollmentsByClassID(classID);
        }

        public List<ClassEnrollmentDTO> GetEnrollmentsByStudentID(string studentID)
        {
            if (string.IsNullOrEmpty(studentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            return enrollmentDAL.GetEnrollmentsByStudentID(studentID);
        }

        public ClassEnrollmentDTO GetEnrollmentByID(string enrollmentID)
        {
            if (string.IsNullOrEmpty(enrollmentID))
                throw new ArgumentException("Mã đăng ký không được để trống");

            return enrollmentDAL.GetEnrollmentByID(enrollmentID);
        }

        public ClassEnrollmentDTO GetEnrollmentByStudentAndClass(string studentID, string classID)
        {
            if (string.IsNullOrEmpty(studentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            if (string.IsNullOrEmpty(classID))
                throw new ArgumentException("Mã lớp học không được để trống");

            return enrollmentDAL.GetEnrollmentByStudentAndClass(studentID, classID);
        }

        public bool AddEnrollment(ClassEnrollmentDTO enrollment)
        {
            ValidateEnrollmentData(enrollment);

            // Kiểm tra mã đăng ký đã tồn tại chưa
            if (enrollmentDAL.GetEnrollmentByID(enrollment.EnrollmentID) != null)
                throw new Exception("Mã đăng ký đã tồn tại");

            // Kiểm tra sinh viên tồn tại
            if (studentDAL.GetStudentByID(enrollment.StudentID) == null)
                throw new Exception("Sinh viên không tồn tại");

            // Kiểm tra lớp học tồn tại
            ClassDTO classDTO = classDAL.GetClassByID(enrollment.ClassID);
            if (classDTO == null)
                throw new Exception("Lớp học không tồn tại");

            // Kiểm tra sinh viên đã đăng ký lớp học này chưa
            if (enrollmentDAL.GetEnrollmentByStudentAndClass(enrollment.StudentID, enrollment.ClassID) != null)
                throw new Exception("Sinh viên đã đăng ký lớp học này");

            // Kiểm tra lớp học còn chỗ không
            int currentEnrollments = enrollmentDAL.GetEnrollmentsByClassID(enrollment.ClassID).Count;
            if (currentEnrollments >= classDTO.MaxStudents)
                throw new Exception("Lớp học đã đủ số lượng sinh viên tối đa");

            // Kiểm tra trạng thái lớp học
            if (classDTO.Status != "Active")
                throw new Exception("Lớp học không trong trạng thái hoạt động");

            // Nếu không có ngày đăng ký, đặt là ngày hiện tại
            if (enrollment.EnrollmentDate == DateTime.MinValue)
                enrollment.EnrollmentDate = DateTime.Now;

            // Nếu không có trạng thái, đặt là "Enrolled"
            if (string.IsNullOrEmpty(enrollment.Status))
                enrollment.Status = "Enrolled";

            return enrollmentDAL.Insert(enrollment);
        }

        public bool UpdateEnrollment(ClassEnrollmentDTO enrollment)
        {
            ValidateEnrollmentData(enrollment);

            // Kiểm tra đăng ký tồn tại
            ClassEnrollmentDTO existingEnrollment = enrollmentDAL.GetEnrollmentByID(enrollment.EnrollmentID);
            if (existingEnrollment == null)
                throw new Exception("Đăng ký không tồn tại");

            // Kiểm tra sinh viên tồn tại
            if (studentDAL.GetStudentByID(enrollment.StudentID) == null)
                throw new Exception("Sinh viên không tồn tại");

            // Kiểm tra lớp học tồn tại
            if (classDAL.GetClassByID(enrollment.ClassID) == null)
                throw new Exception("Lớp học không tồn tại");

            return enrollmentDAL.Update(enrollment);
        }

        public bool DeleteEnrollment(string enrollmentID)
        {
            if (string.IsNullOrEmpty(enrollmentID))
                throw new ArgumentException("Mã đăng ký không được để trống");

            // Kiểm tra đăng ký tồn tại
            ClassEnrollmentDTO existingEnrollment = enrollmentDAL.GetEnrollmentByID(enrollmentID);
            if (existingEnrollment == null)
                throw new Exception("Đăng ký không tồn tại");

            return enrollmentDAL.Delete(enrollmentID);
        }

        // Hủy đăng ký lớp học
        public bool DropClass(string studentID, string classID)
        {
            if (string.IsNullOrEmpty(studentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            if (string.IsNullOrEmpty(classID))
                throw new ArgumentException("Mã lớp học không được để trống");

            // Kiểm tra đăng ký tồn tại
            ClassEnrollmentDTO enrollment = enrollmentDAL.GetEnrollmentByStudentAndClass(studentID, classID);
            if (enrollment == null)
                throw new Exception("Sinh viên chưa đăng ký lớp học này");

            // Cập nhật trạng thái đăng ký
            enrollment.Status = "Dropped";

            return enrollmentDAL.Update(enrollment);
        }

        private void ValidateEnrollmentData(ClassEnrollmentDTO enrollment)
        {
            if (enrollment == null)
                throw new ArgumentNullException("Dữ liệu đăng ký không được để trống");

            if (string.IsNullOrEmpty(enrollment.EnrollmentID))
                throw new ArgumentException("Mã đăng ký không được để trống");

            if (string.IsNullOrEmpty(enrollment.StudentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            if (string.IsNullOrEmpty(enrollment.ClassID))
                throw new ArgumentException("Mã lớp học không được để trống");

            // Kiểm tra trạng thái hợp lệ
            if (!string.IsNullOrEmpty(enrollment.Status) &&
                enrollment.Status != "Enrolled" &&
                enrollment.Status != "Dropped" &&
                enrollment.Status != "Completed")
                throw new ArgumentException("Trạng thái đăng ký không hợp lệ (Enrolled, Dropped, Completed)");

            // Kiểm tra điểm tổng kết hợp lệ (nếu có)
            if (enrollment.FinalGrade.HasValue && (enrollment.FinalGrade < 0 || enrollment.FinalGrade > 10))
                throw new ArgumentException("Điểm tổng kết phải nằm trong khoảng từ 0 đến 10");
        }
    }
}
