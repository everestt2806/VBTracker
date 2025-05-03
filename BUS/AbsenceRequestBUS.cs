using System;
using System.Collections.Generic;
using VBTracker.DAL;
using VBTracker.DTO;

namespace VBTracker.BUS
{
    public class AbsenceRequestBUS
    {
        private AbsenceRequestDAL absenceRequestDAL;

        public AbsenceRequestBUS()
        {
            absenceRequestDAL = new AbsenceRequestDAL();
        }

        public List<AbsenceRequestDTO> GetAllAbsenceRequests()
        {
            return absenceRequestDAL.GetAll();
        }

        public List<AbsenceRequestDTO> GetAbsenceRequestByID(string requestID)
        {
            return absenceRequestDAL.GetByRequestID(requestID);
        }

        public List<AbsenceRequestDTO> GetAbsenceRequestsByStudentID(string studentID)
        {
            return absenceRequestDAL.GetByStudentID(studentID);
        }

        public List<AbsenceRequestDTO> GetAbsenceRequestsByScheduleID(string scheduleID)
        {
            return absenceRequestDAL.GetByScheduleID(scheduleID);
        }

        public List<AbsenceRequestDTO> GetAbsenceRequestsByStatus(string status)
        {
            return absenceRequestDAL.GetByStatus(status);
        }

        // Thêm phương thức mới để thay thế GetPendingRequestsByLecturerID
        public List<AbsenceRequestDTO> GetAbsenceRequestsByLecturerAndStatus(string lecturerID, string status)
        {
            // Phương thức này sẽ lấy tất cả các đơn xin nghỉ có trạng thái cụ thể
            // và thuộc các lớp học mà giảng viên này dạy
            return absenceRequestDAL.GetByLecturerIDAndStatus(lecturerID, status);
        }

        public List<AbsenceRequestDTO> FilterRequestsByLecturer(List<AbsenceRequestDTO> requests, string lecturerID)
        {
            // Lọc danh sách đơn xin nghỉ theo giảng viên
            // Giả sử chúng ta đã có danh sách lớp học của giảng viên
            List<string> lecturerClasses = GetLecturerClasses(lecturerID);

            // Lọc các đơn xin nghỉ thuộc các lớp học của giảng viên
            return requests.FindAll(r => IsRequestInLecturerClasses(r, lecturerClasses));
        }

        private List<string> GetLecturerClasses(string lecturerID)
        {
            // Lấy danh sách các lớp học của giảng viên
            // Đây là phương thức giả định, cần được thực hiện trong thực tế
            // Có thể gọi đến một DAO khác để lấy dữ liệu
            return new List<string>(); // Trả về danh sách trống tạm thời
        }

        private bool IsRequestInLecturerClasses(AbsenceRequestDTO request, List<string> lecturerClasses)
        {
            // Kiểm tra xem đơn xin nghỉ có thuộc lớp học của giảng viên không
            // Đây là phương thức giả định, cần được thực hiện trong thực tế
            return true; // Tạm thời trả về true
        }

        public bool AddAbsenceRequest(AbsenceRequestDTO request)
        {
            return absenceRequestDAL.Insert(request);
        }

        public bool UpdateAbsenceRequest(AbsenceRequestDTO request)
        {
            return absenceRequestDAL.Update(request);
        }

        public bool DeleteAbsenceRequest(string requestID)
        {
            return absenceRequestDAL.Delete(requestID);
        }

        public bool ApproveAbsenceRequest(string requestID, string approverID, string comments)
        {
            return absenceRequestDAL.ApproveRequest(requestID, approverID, comments);
        }

        public bool RejectAbsenceRequest(string requestID, string approverID, string comments)
        {
            return absenceRequestDAL.RejectRequest(requestID, approverID, comments);
        }

        /// <summary>
        /// Lấy danh sách các đơn xin nghỉ đang chờ phê duyệt
        /// </summary>
        /// <returns>Danh sách đơn xin nghỉ đang chờ phê duyệt</returns>
        public List<AbsenceRequestDTO> GetPendingRequests()
        {
            return absenceRequestDAL.GetPendingRequests();
        }

        /// <summary>
        /// Lấy danh sách các đơn xin nghỉ đang chờ phê duyệt của giảng viên
        /// </summary>
        /// <param name="lecturerID">Mã giảng viên</param>
        /// <returns>Danh sách đơn xin nghỉ đang chờ phê duyệt</returns>
        public List<AbsenceRequestDTO> GetPendingRequestsByLecturerID(string lecturerID)
        {
            return absenceRequestDAL.GetPendingRequestsByLecturerID(lecturerID);
        }

        /// <summary>
        /// Lấy danh sách các đơn xin nghỉ đang chờ phê duyệt của các lớp mà giảng viên hiện tại đang dạy
        /// </summary>
        /// <returns>Danh sách đơn xin nghỉ đang chờ phê duyệt</returns>
        public List<AbsenceRequestDTO> GetPendingRequestsForCurrentLecturer()
        {
            if (!UserSession.Instance.IsLecturer())
            {
                throw new UnauthorizedAccessException("Chỉ giảng viên mới có quyền truy cập danh sách đơn xin nghỉ đang chờ phê duyệt");
            }

            return absenceRequestDAL.GetPendingRequestsByLecturerID(UserSession.Instance.UserID);
        }

    }
}
