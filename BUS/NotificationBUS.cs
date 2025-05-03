using System;
using System.Collections.Generic;
using VBTracker.DAL;
using VBTracker.DTO;

namespace VBTracker.BUS
{
    public class NotificationBUS
    {
        private NotificationDAL notificationDAL;
        private StudentNotificationDAL studentNotificationDAL;
        private LecturerDAL lecturerDAL;
        private ClassDAL classDAL;
        private ClassEnrollmentDAL enrollmentDAL;

        public NotificationBUS()
        {
            notificationDAL = new NotificationDAL();
            studentNotificationDAL = new StudentNotificationDAL();
            lecturerDAL = new LecturerDAL();
            classDAL = new ClassDAL();
            enrollmentDAL = new ClassEnrollmentDAL();
        }

        public List<NotificationDTO> GetAllNotifications()
        {
            return notificationDAL.GetAll();
        }

        //public List<NotificationDTO> GetNotificationsByLecturerID(string lecturerID)
        //{
        //    if (string.IsNullOrEmpty(lecturerID))
        //        throw new ArgumentException("Mã giảng viên không được để trống");

        //    return notificationDAL.GetNotificationsByLecturerID(lecturerID);
        //}

        //public List<NotificationDTO> GetNotificationsByClassID(string classID)
        //{
        //    if (string.IsNullOrEmpty(classID))
        //        throw new ArgumentException("Mã lớp học không được để trống");

        //    return notificationDAL.GetNotificationsByClassID(classID);
        //}

        public NotificationDTO GetNotificationByID(string notificationID)
        {
            if (string.IsNullOrEmpty(notificationID))
                throw new ArgumentException("Mã thông báo không được để trống");

            return notificationDAL.GetById(notificationID);
        }

        public bool AddNotification(NotificationDTO notification)
        {
            ValidateNotificationData(notification);

            // Kiểm tra mã thông báo đã tồn tại chưa
            if (notificationDAL.GetById(notification.NotificationID) != null)
                throw new Exception("Mã thông báo đã tồn tại");

            // Kiểm tra giảng viên tồn tại
            if (lecturerDAL.GetLecturerByID(notification.CreatedBy) == null)
                throw new Exception("Giảng viên không tồn tại");

            // Kiểm tra lớp học tồn tại (nếu có)
            if (!string.IsNullOrEmpty(notification.ClassID) && classDAL.GetClassByID(notification.ClassID) == null)
                throw new Exception("Lớp học không tồn tại");

            // Thêm thông báo
            bool result = notificationDAL.Insert(notification);

            // Nếu thêm thành công và là thông báo cho một lớp cụ thể
            if (result && !string.IsNullOrEmpty(notification.ClassID))
            {
                // Lấy danh sách sinh viên trong lớp
                List<ClassEnrollmentDTO> enrollments = enrollmentDAL.GetEnrollmentsByClassID(notification.ClassID);

                // Tạo thông báo cho từng sinh viên
                foreach (ClassEnrollmentDTO enrollment in enrollments)
                {
                    StudentNotificationDTO studentNotification = new StudentNotificationDTO
                    {
                        ID = GenerateStudentNotificationID(),
                        NotificationID = notification.NotificationID,
                        StudentID = enrollment.StudentID,
                        ReadStatus = false,
                        ReadDate = null
                    };

                    studentNotificationDAL.AddStudentNotification(studentNotification);
                }
            }

            return result;
        }

        public bool UpdateNotification(NotificationDTO notification)
        {
            ValidateNotificationData(notification);

            // Kiểm tra thông báo tồn tại
            NotificationDTO existingNotification = notificationDAL.GetById(notification.NotificationID);
            if (existingNotification == null)
                throw new Exception("Thông báo không tồn tại");

            // Kiểm tra giảng viên tồn tại
            if (lecturerDAL.GetLecturerByID(notification.CreatedBy) == null)
                throw new Exception("Giảng viên không tồn tại");

            // Kiểm tra lớp học tồn tại (nếu có)
            if (!string.IsNullOrEmpty(notification.ClassID) && classDAL.GetClassByID(notification.ClassID) == null)
                throw new Exception("Lớp học không tồn tại");

            return notificationDAL.Update(notification);
        }

        public bool DeleteNotification(string notificationID)
        {
            if (string.IsNullOrEmpty(notificationID))
                throw new ArgumentException("Mã thông báo không được để trống");

            // Kiểm tra thông báo tồn tại
            NotificationDTO existingNotification = notificationDAL.GetById(notificationID);
            if (existingNotification == null)
                throw new Exception("Thông báo không tồn tại");

            // Xóa các thông báo sinh viên liên quan
            studentNotificationDAL.DeleteStudentNotificationsByNotificationID(notificationID);

            // Xóa thông báo
            return notificationDAL.Delete(notificationID);
        }

        // Lấy danh sách thông báo cho sinh viên
        public List<StudentNotificationDTO> GetNotificationsByStudentID(string studentID)
        {
            if (string.IsNullOrEmpty(studentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            return studentNotificationDAL.GetStudentNotificationsByStudentID(studentID);
        }

        // Đánh dấu thông báo đã đọc
        public bool MarkNotificationAsRead(string studentNotificationID)
        {
            if (string.IsNullOrEmpty(studentNotificationID))
                throw new ArgumentException("Mã thông báo sinh viên không được để trống");

            StudentNotificationDTO studentNotification = studentNotificationDAL.GetStudentNotificationByID(studentNotificationID);
            if (studentNotification == null)
                throw new Exception("Thông báo sinh viên không tồn tại");

            studentNotification.ReadStatus = true;
            studentNotification.ReadDate = DateTime.Now;

            return studentNotificationDAL.UpdateStudentNotification(studentNotification);
        }

        private void ValidateNotificationData(NotificationDTO notification)
        {
            if (notification == null)
                throw new ArgumentNullException("Dữ liệu thông báo không được để trống");

            if (string.IsNullOrEmpty(notification.NotificationID))
                throw new ArgumentException("Mã thông báo không được để trống");

            if (string.IsNullOrEmpty(notification.Title))
                throw new ArgumentException("Tiêu đề thông báo không được để trống");

            if (string.IsNullOrEmpty(notification.Content))
                throw new ArgumentException("Nội dung thông báo không được để trống");

            if (string.IsNullOrEmpty(notification.CreatedBy))
                throw new ArgumentException("Người tạo thông báo không được để trống");

            if (notification.CreatedDate == DateTime.MinValue)
                throw new ArgumentException("Ngày tạo thông báo không hợp lệ");
        }

        // Tạo mã thông báo sinh viên mới
        private string GenerateStudentNotificationID()
        {
            // Trong thực tế, có thể sử dụng GUID hoặc một thuật toán tạo ID khác
            return "SN-" + Guid.NewGuid().ToString("N").Substring(0, 10);
        }
    }
}
