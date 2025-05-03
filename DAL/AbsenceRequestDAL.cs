using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class AbsenceRequestDAL
    {
        public List<AbsenceRequestDTO> GetAll()
        {
            List<AbsenceRequestDTO> absenceRequests = new List<AbsenceRequestDTO>();
            string query = "SELECT * FROM AbsenceRequests";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                absenceRequests.Add(new AbsenceRequestDTO
                {
                    RequestID = row["RequestID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    RequestDate = Convert.ToDateTime(row["RequestDate"]),
                    AbsenceDate = Convert.ToDateTime(row["AbsenceDate"]),
                    Reason = row["Reason"].ToString(),
                    Status = row["Status"].ToString(),
                    ApproverID = row["ApproverID"] != DBNull.Value ? row["ApproverID"].ToString() : null,
                    ApprovalDate = row["ApprovalDate"] != DBNull.Value ? Convert.ToDateTime(row["ApprovalDate"]) : (DateTime?)null,
                    Comments = row["Comments"] != DBNull.Value ? row["Comments"].ToString() : null,
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return absenceRequests;
        }

        public List<AbsenceRequestDTO> GetByStudentID(string studentID)
        {
            string query = "SELECT * FROM AbsenceRequests WHERE StudentID = @StudentID";
            SqlParameter[] parameters = { new SqlParameter("@StudentID", studentID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<AbsenceRequestDTO> absenceRequests = new List<AbsenceRequestDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                absenceRequests.Add(new AbsenceRequestDTO
                {
                    RequestID = row["RequestID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    RequestDate = Convert.ToDateTime(row["RequestDate"]),
                    AbsenceDate = Convert.ToDateTime(row["AbsenceDate"]),
                    Reason = row["Reason"].ToString(),
                    Status = row["Status"].ToString(),
                    ApproverID = row["ApproverID"] != DBNull.Value ? row["ApproverID"].ToString() : null,
                    ApprovalDate = row["ApprovalDate"] != DBNull.Value ? Convert.ToDateTime(row["ApprovalDate"]) : (DateTime?)null,
                    Comments = row["Comments"] != DBNull.Value ? row["Comments"].ToString() : null,
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return absenceRequests;
        }

        public List<AbsenceRequestDTO> GetByApproverID(string approverID)
        {
            string query = "SELECT * FROM AbsenceRequests WHERE ApproverID = @ApproverID";
            SqlParameter[] parameters = { new SqlParameter("@ApproverID", approverID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<AbsenceRequestDTO> absenceRequests = new List<AbsenceRequestDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                absenceRequests.Add(new AbsenceRequestDTO
                {
                    RequestID = row["RequestID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    RequestDate = Convert.ToDateTime(row["RequestDate"]),
                    AbsenceDate = Convert.ToDateTime(row["AbsenceDate"]),
                    Reason = row["Reason"].ToString(),
                    Status = row["Status"].ToString(),
                    ApproverID = row["ApproverID"] != DBNull.Value ? row["ApproverID"].ToString() : null,
                    ApprovalDate = row["ApprovalDate"] != DBNull.Value ? Convert.ToDateTime(row["ApprovalDate"]) : (DateTime?)null,
                    Comments = row["Comments"] != DBNull.Value ? row["Comments"].ToString() : null,
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return absenceRequests;
        }

        public List<AbsenceRequestDTO> GetByStatus(string status)
        {
            string query = "SELECT * FROM AbsenceRequests WHERE Status = @Status";
            SqlParameter[] parameters = { new SqlParameter("@Status", status) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<AbsenceRequestDTO> absenceRequests = new List<AbsenceRequestDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                absenceRequests.Add(new AbsenceRequestDTO
                {
                    RequestID = row["RequestID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    RequestDate = Convert.ToDateTime(row["RequestDate"]),
                    AbsenceDate = Convert.ToDateTime(row["AbsenceDate"]),
                    Reason = row["Reason"].ToString(),
                    Status = row["Status"].ToString(),
                    ApproverID = row["ApproverID"] != DBNull.Value ? row["ApproverID"].ToString() : null,
                    ApprovalDate = row["ApprovalDate"] != DBNull.Value ? Convert.ToDateTime(row["ApprovalDate"]) : (DateTime?)null,
                    Comments = row["Comments"] != DBNull.Value ? row["Comments"].ToString() : null,
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return absenceRequests;
        }

        public AbsenceRequestDTO GetByID(string requestID)
        {
            string query = "SELECT * FROM AbsenceRequests WHERE RequestID = @RequestID";
            SqlParameter[] parameters = { new SqlParameter("@RequestID", requestID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new AbsenceRequestDTO
                {
                    RequestID = row["RequestID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    RequestDate = Convert.ToDateTime(row["RequestDate"]),
                    AbsenceDate = Convert.ToDateTime(row["AbsenceDate"]),
                    Reason = row["Reason"].ToString(),
                    Status = row["Status"].ToString(),
                    ApproverID = row["ApproverID"] != DBNull.Value ? row["ApproverID"].ToString() : null,
                    ApprovalDate = row["ApprovalDate"] != DBNull.Value ? Convert.ToDateTime(row["ApprovalDate"]) : (DateTime?)null,
                    Comments = row["Comments"] != DBNull.Value ? row["Comments"].ToString() : null,
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                };
            }

            return null;
        }

        public bool Insert(AbsenceRequestDTO absenceRequest)
        {
            string query = @"INSERT INTO AbsenceRequests 
                            (RequestID, StudentID, ScheduleID, RequestDate, AbsenceDate, Reason, Status, ApproverID, ApprovalDate, Comments, CreatedDate, UpdatedDate) 
                            VALUES 
                            (@RequestID, @StudentID, @ScheduleID, @RequestDate, @AbsenceDate, @Reason, @Status, @ApproverID, @ApprovalDate, @Comments, @CreatedDate, @UpdatedDate)";

            SqlParameter[] parameters = {
                new SqlParameter("@RequestID", absenceRequest.RequestID),
                new SqlParameter("@StudentID", absenceRequest.StudentID),
                new SqlParameter("@ScheduleID", absenceRequest.ScheduleID),
                new SqlParameter("@RequestDate", absenceRequest.RequestDate),
                new SqlParameter("@AbsenceDate", absenceRequest.AbsenceDate),
                new SqlParameter("@Reason", absenceRequest.Reason),
                new SqlParameter("@Status", absenceRequest.Status),
                new SqlParameter("@ApproverID", absenceRequest.ApproverID ?? (object)DBNull.Value),
                new SqlParameter("@ApprovalDate", absenceRequest.ApprovalDate ?? (object)DBNull.Value),
                new SqlParameter("@Comments", absenceRequest.Comments ?? (object)DBNull.Value),
                new SqlParameter("@CreatedDate", DateTime.Now),
                new SqlParameter("@UpdatedDate", DateTime.Now)
            };

            int result = DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool Update(AbsenceRequestDTO absenceRequest)
        {
            string query = @"UPDATE AbsenceRequests 
                            SET StudentID = @StudentID, 
                                ScheduleID = @ScheduleID, 
                                RequestDate = @RequestDate, 
                                AbsenceDate = @AbsenceDate, 
                                Reason = @Reason, 
                                Status = @Status, 
                                ApproverID = @ApproverID, 
                                ApprovalDate = @ApprovalDate, 
                                Comments = @Comments, 
                                UpdatedDate = @UpdatedDate 
                            WHERE RequestID = @RequestID";

            SqlParameter[] parameters = {
                new SqlParameter("@RequestID", absenceRequest.RequestID),
                new SqlParameter("@StudentID", absenceRequest.StudentID),
                new SqlParameter("@ScheduleID", absenceRequest.ScheduleID),
                new SqlParameter("@RequestDate", absenceRequest.RequestDate),
                new SqlParameter("@AbsenceDate", absenceRequest.AbsenceDate),
                new SqlParameter("@Reason", absenceRequest.Reason),
                new SqlParameter("@Status", absenceRequest.Status),
                new SqlParameter("@ApproverID", absenceRequest.ApproverID ?? (object)DBNull.Value),
                new SqlParameter("@ApprovalDate", absenceRequest.ApprovalDate ?? (object)DBNull.Value),
                new SqlParameter("@Comments", absenceRequest.Comments ?? (object)DBNull.Value),
                new SqlParameter("@UpdatedDate", DateTime.Now)
            };

            int result = DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool Delete(string requestID)
        {
            string query = "DELETE FROM AbsenceRequests WHERE RequestID = @RequestID";
            SqlParameter[] parameters = { new SqlParameter("@RequestID", requestID) };

            int result = DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        /// <summary>
        /// Lấy các đơn xin nghỉ thuộc các lớp học của giảng viên
        /// </summary>
        /// <param name="lecturerID">Mã giảng viên</param>
        /// <returns>Danh sách đơn xin nghỉ</returns>
        public List<AbsenceRequestDTO> GetByLecturerID(string lecturerID)
        {
            string query = @"SELECT ar.* 
                            FROM AbsenceRequests ar
                            JOIN Schedules s ON ar.ScheduleID = s.ScheduleID
                            JOIN Classes c ON s.ClassID = c.ClassID
                            WHERE c.LecturerID = @LecturerID";

            SqlParameter[] parameters = { new SqlParameter("@LecturerID", lecturerID) };
            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<AbsenceRequestDTO> absenceRequests = new List<AbsenceRequestDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                absenceRequests.Add(new AbsenceRequestDTO
                {
                    RequestID = row["RequestID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    RequestDate = Convert.ToDateTime(row["RequestDate"]),
                    AbsenceDate = Convert.ToDateTime(row["AbsenceDate"]),
                    Reason = row["Reason"].ToString(),
                    Status = row["Status"].ToString(),
                    ApproverID = row["ApproverID"] != DBNull.Value ? row["ApproverID"].ToString() : null,
                    ApprovalDate = row["ApprovalDate"] != DBNull.Value ? Convert.ToDateTime(row["ApprovalDate"]) : (DateTime?)null,
                    Comments = row["Comments"] != DBNull.Value ? row["Comments"].ToString() : null,
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return absenceRequests;
        }

        /// <summary>
        /// Lấy các đơn xin nghỉ thuộc các lớp học của giảng viên theo trạng thái
        /// </summary>
        /// <param name="lecturerID">Mã giảng viên</param>
        /// <param name="status">Trạng thái đơn</param>
        /// <returns>Danh sách đơn xin nghỉ</returns>
        public List<AbsenceRequestDTO> GetByLecturerIDAndStatus(string lecturerID, string status)
        {
            string query = @"SELECT ar.* 
                            FROM AbsenceRequests ar
                            JOIN Schedules s ON ar.ScheduleID = s.ScheduleID
                            JOIN Classes c ON s.ClassID = c.ClassID
                            WHERE c.LecturerID = @LecturerID AND ar.Status = @Status";

            SqlParameter[] parameters = {
                new SqlParameter("@LecturerID", lecturerID),
                new SqlParameter("@Status", status)
            };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<AbsenceRequestDTO> absenceRequests = new List<AbsenceRequestDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                absenceRequests.Add(new AbsenceRequestDTO
                {
                    RequestID = row["RequestID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    RequestDate = Convert.ToDateTime(row["RequestDate"]),
                    AbsenceDate = Convert.ToDateTime(row["AbsenceDate"]),
                    Reason = row["Reason"].ToString(),
                    Status = row["Status"].ToString(),
                    ApproverID = row["ApproverID"] != DBNull.Value ? row["ApproverID"].ToString() : null,
                    ApprovalDate = row["ApprovalDate"] != DBNull.Value ? Convert.ToDateTime(row["ApprovalDate"]) : (DateTime?)null,
                    Comments = row["Comments"] != DBNull.Value ? row["Comments"].ToString() : null,
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return absenceRequests;
        }

        /// <summary>
        /// Lấy các đơn xin nghỉ đang chờ phê duyệt
        /// </summary>
        /// <returns>Danh sách đơn xin nghỉ đang chờ phê duyệt</returns>
        public List<AbsenceRequestDTO> GetPendingRequests()
        {
            return GetByStatus("Pending");
        }

        /// <summary>
        /// Lấy các đơn xin nghỉ đang chờ phê duyệt của giảng viên
        /// </summary>
        /// <param name="lecturerID">Mã giảng viên</param>
        /// <returns>Danh sách đơn xin nghỉ đang chờ phê duyệt</returns>
        public List<AbsenceRequestDTO> GetPendingRequestsByLecturerID(string lecturerID)
        {
            return GetByLecturerIDAndStatus(lecturerID, "Pending");
        }

        /// <summary>
        /// Phê duyệt đơn xin nghỉ
        /// </summary>
        /// <param name="requestID">Mã đơn xin nghỉ</param>
        /// <param name="approverID">Mã người phê duyệt</param>
        /// <param name="comments">Ghi chú</param>
        /// <returns>Kết quả thực hiện</returns>
        public bool ApproveRequest(string requestID, string approverID, string comments)
        {
            string query = @"UPDATE AbsenceRequests 
                            SET Status = 'Approved', 
                                ApproverID = @ApproverID, 
                                ApprovalDate = @ApprovalDate, 
                                Comments = @Comments, 
                                UpdatedDate = @UpdatedDate 
                            WHERE RequestID = @RequestID";

            SqlParameter[] parameters = {
                new SqlParameter("@RequestID", requestID),
                new SqlParameter("@ApproverID", approverID),
                new SqlParameter("@ApprovalDate", DateTime.Now),
                new SqlParameter("@Comments", comments ?? (object)DBNull.Value),
                new SqlParameter("@UpdatedDate", DateTime.Now)
            };

            int result = DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        /// <summary>
        /// Từ chối đơn xin nghỉ
        /// </summary>
        /// <param name="requestID">Mã đơn xin nghỉ</param>
        /// <param name="approverID">Mã người từ chối</param>
        /// <param name="comments">Ghi chú</param>
        /// <returns>Kết quả thực hiện</returns>
        public bool RejectRequest(string requestID, string approverID, string comments)
        {
            string query = @"UPDATE AbsenceRequests 
                            SET Status = 'Rejected', 
                                ApproverID = @ApproverID, 
                                ApprovalDate = @ApprovalDate, 
                                Comments = @Comments, 
                                UpdatedDate = @UpdatedDate 
                            WHERE RequestID = @RequestID";

            SqlParameter[] parameters = {
                new SqlParameter("@RequestID", requestID),
                new SqlParameter("@ApproverID", approverID),
                new SqlParameter("@ApprovalDate", DateTime.Now),
                new SqlParameter("@Comments", comments ?? (object)DBNull.Value),
                new SqlParameter("@UpdatedDate", DateTime.Now)
            };

            int result = DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        /// <summary>
        /// Lấy các đơn xin nghỉ theo khoảng thời gian
        /// </summary>
        /// <param name="fromDate">Từ ngày</param>
        /// <param name="toDate">Đến ngày</param>
        /// <returns>Danh sách đơn xin nghỉ</returns>
        public List<AbsenceRequestDTO> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            string query = "SELECT * FROM AbsenceRequests WHERE AbsenceDate BETWEEN @FromDate AND @ToDate";
            SqlParameter[] parameters = {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<AbsenceRequestDTO> absenceRequests = new List<AbsenceRequestDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                absenceRequests.Add(new AbsenceRequestDTO
                {
                    RequestID = row["RequestID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    RequestDate = Convert.ToDateTime(row["RequestDate"]),
                    AbsenceDate = Convert.ToDateTime(row["AbsenceDate"]),
                    Reason = row["Reason"].ToString(),
                    Status = row["Status"].ToString(),
                    ApproverID = row["ApproverID"] != DBNull.Value ? row["ApproverID"].ToString() : null,
                    ApprovalDate = row["ApprovalDate"] != DBNull.Value ? Convert.ToDateTime(row["ApprovalDate"]) : (DateTime?)null,
                    Comments = row["Comments"] != DBNull.Value ? row["Comments"].ToString() : null,
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return absenceRequests;
        }

        /// <summary>
        /// Lấy các đơn xin nghỉ theo lớp học
        /// </summary>
        /// <param name="classID">Mã lớp học</param>
        /// <returns>Danh sách đơn xin nghỉ</returns>
        public List<AbsenceRequestDTO> GetByClassID(string classID)
        {
            string query = @"SELECT ar.* 
                            FROM AbsenceRequests ar
                            JOIN Schedules s ON ar.ScheduleID = s.ScheduleID
                            WHERE s.ClassID = @ClassID";

            SqlParameter[] parameters = { new SqlParameter("@ClassID", classID) };
            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<AbsenceRequestDTO> absenceRequests = new List<AbsenceRequestDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                absenceRequests.Add(new AbsenceRequestDTO
                {
                    RequestID = row["RequestID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    RequestDate = Convert.ToDateTime(row["RequestDate"]),
                    AbsenceDate = Convert.ToDateTime(row["AbsenceDate"]),
                    Reason = row["Reason"].ToString(),
                    Status = row["Status"].ToString(),
                    ApproverID = row["ApproverID"] != DBNull.Value ? row["ApproverID"].ToString() : null,
                    ApprovalDate = row["ApprovalDate"] != DBNull.Value ? Convert.ToDateTime(row["ApprovalDate"]) : (DateTime?)null,
                    Comments = row["Comments"] != DBNull.Value ? row["Comments"].ToString() : null,
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return absenceRequests;
        }

        /// <summary>
        /// Đếm số lượng đơn xin nghỉ theo trạng thái
        /// </summary>
        /// <param name="status">Trạng thái đơn</param>
        /// <returns>Số lượng đơn</returns>
        public int CountByStatus(string status)
        {
            string query = "SELECT COUNT(*) FROM AbsenceRequests WHERE Status = @Status";
            SqlParameter[] parameters = { new SqlParameter("@Status", status) };

            return Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(query, parameters));
        }

        /// <summary>
        /// Lấy thông tin chi tiết đơn xin nghỉ kèm theo thông tin sinh viên và lịch học
        /// </summary>
        /// <param name="requestID">Mã đơn xin nghỉ</param>
        /// <returns>Thông tin chi tiết đơn xin nghỉ</returns>
        public DataTable GetDetailedRequestInfo(string requestID)
        {
            string query = @"SELECT ar.*, s.*, st.FullName as StudentName, l.FullName as LecturerName, c.ClassName
                            FROM AbsenceRequests ar
                            JOIN Schedules s ON ar.ScheduleID = s.ScheduleID
                            JOIN Students st ON ar.StudentID = st.StudentID
                            JOIN Classes c ON s.ClassID = c.ClassID
                            LEFT JOIN Lecturers l ON c.LecturerID = l.LecturerID
                            WHERE ar.RequestID = @RequestID";

            SqlParameter[] parameters = { new SqlParameter("@RequestID", requestID) };
            return DatabaseConnection.Instance.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Lấy đơn xin nghỉ theo mã đơn
        /// </summary>
        /// <param name="requestID">Mã đơn xin nghỉ</param>
        /// <returns>Danh sách đơn xin nghỉ</returns>
        public List<AbsenceRequestDTO> GetByRequestID(string requestID)
        {
            string query = "SELECT * FROM AbsenceRequests WHERE RequestID = @RequestID";
            SqlParameter[] parameters = { new SqlParameter("@RequestID", requestID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<AbsenceRequestDTO> absenceRequests = new List<AbsenceRequestDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                absenceRequests.Add(new AbsenceRequestDTO
                {
                    RequestID = row["RequestID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    RequestDate = Convert.ToDateTime(row["RequestDate"]),
                    AbsenceDate = Convert.ToDateTime(row["AbsenceDate"]),
                    Reason = row["Reason"].ToString(),
                    Status = row["Status"].ToString(),
                    ApproverID = row["ApproverID"] != DBNull.Value ? row["ApproverID"].ToString() : null,
                    ApprovalDate = row["ApprovalDate"] != DBNull.Value ? Convert.ToDateTime(row["ApprovalDate"]) : (DateTime?)null,
                    Comments = row["Comments"] != DBNull.Value ? row["Comments"].ToString() : null,
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return absenceRequests;
        }

        /// <summary>
        /// Lấy các đơn xin nghỉ theo mã lịch học
        /// </summary>
        /// <param name="scheduleID">Mã lịch học</param>
        /// <returns>Danh sách đơn xin nghỉ</returns>
        public List<AbsenceRequestDTO> GetByScheduleID(string scheduleID)
        {
            string query = "SELECT * FROM AbsenceRequests WHERE ScheduleID = @ScheduleID";
            SqlParameter[] parameters = { new SqlParameter("@ScheduleID", scheduleID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<AbsenceRequestDTO> absenceRequests = new List<AbsenceRequestDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                absenceRequests.Add(new AbsenceRequestDTO
                {
                    RequestID = row["RequestID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    RequestDate = Convert.ToDateTime(row["RequestDate"]),
                    AbsenceDate = Convert.ToDateTime(row["AbsenceDate"]),
                    Reason = row["Reason"].ToString(),
                    Status = row["Status"].ToString(),
                    ApproverID = row["ApproverID"] != DBNull.Value ? row["ApproverID"].ToString() : null,
                    ApprovalDate = row["ApprovalDate"] != DBNull.Value ? Convert.ToDateTime(row["ApprovalDate"]) : (DateTime?)null,
                    Comments = row["Comments"] != DBNull.Value ? row["Comments"].ToString() : null,
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return absenceRequests;
        }

    }
}

