using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class AttendanceDAL
    {
        public List<AttendanceDTO> GetAll()
        {
            List<AttendanceDTO> attendances = new List<AttendanceDTO>();
            string query = "SELECT * FROM Attendance";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                attendances.Add(new AttendanceDTO
                {
                    AttendanceID = row["AttendanceID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    AttendanceDate = Convert.ToDateTime(row["AttendanceDate"]),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"]?.ToString(),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return attendances;
        }

        public AttendanceDTO GetById(string attendanceId)
        {
            string query = "SELECT * FROM Attendance WHERE AttendanceID = @AttendanceID";
            SqlParameter[] parameters = { new SqlParameter("@AttendanceID", attendanceId) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new AttendanceDTO
                {
                    AttendanceID = row["AttendanceID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    AttendanceDate = Convert.ToDateTime(row["AttendanceDate"]),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"]?.ToString(),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                };
            }

            return null;
        }

        public bool Insert(AttendanceDTO attendance)
        {
            string query = "INSERT INTO Attendance (AttendanceID, StudentID, ScheduleID, AttendanceDate, Status, Notes, UpdatedDate) " +
                           "VALUES (@AttendanceID, @StudentID, @ScheduleID, @AttendanceDate, @Status, @Notes, @UpdatedDate)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@AttendanceID", attendance.AttendanceID),
                new SqlParameter("@StudentID", attendance.StudentID),
                new SqlParameter("@ScheduleID", attendance.ScheduleID),
                new SqlParameter("@AttendanceDate", attendance.AttendanceDate),
                new SqlParameter("@Status", attendance.Status),
                new SqlParameter("@Notes", attendance.Notes ?? (object)DBNull.Value),
                new SqlParameter("@UpdatedDate", attendance.UpdatedDate)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(AttendanceDTO attendance)
        {
            string query = "UPDATE Attendance SET StudentID = @StudentID, ScheduleID = @ScheduleID, AttendanceDate = @AttendanceDate, " +
                           "Status = @Status, Notes = @Notes, UpdatedDate = @UpdatedDate WHERE AttendanceID = @AttendanceID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@AttendanceID", attendance.AttendanceID),
                new SqlParameter("@StudentID", attendance.StudentID),
                new SqlParameter("@ScheduleID", attendance.ScheduleID),
                new SqlParameter("@AttendanceDate", attendance.AttendanceDate),
                new SqlParameter("@Status", attendance.Status),
                new SqlParameter("@Notes", attendance.Notes ?? (object)DBNull.Value),
                new SqlParameter("@UpdatedDate", attendance.UpdatedDate)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(string attendanceId)
        {
            string query = "DELETE FROM Attendance WHERE AttendanceID = @AttendanceID";
            SqlParameter[] parameters = { new SqlParameter("@AttendanceID", attendanceId) };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public List<AttendanceDTO> GetAttendanceByScheduleID(string scheduleID)
        {
            List<AttendanceDTO> attendances = new List<AttendanceDTO>();
            string query = "SELECT * FROM Attendance WHERE ScheduleID = @ScheduleID";
            SqlParameter[] parameters = { new SqlParameter("@ScheduleID", scheduleID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                attendances.Add(new AttendanceDTO
                {
                    AttendanceID = row["AttendanceID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    AttendanceDate = Convert.ToDateTime(row["AttendanceDate"]),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"]?.ToString(),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return attendances;
        }

        public AttendanceDTO GetAttendanceByID(string attendanceID)
        {
            string query = "SELECT * FROM Attendance WHERE AttendanceID = @AttendanceID";
            SqlParameter[] parameters = { new SqlParameter("@AttendanceID", attendanceID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new AttendanceDTO
                {
                    AttendanceID = row["AttendanceID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    AttendanceDate = Convert.ToDateTime(row["AttendanceDate"]),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"]?.ToString(),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                };
            }

            return null; // Trả về null nếu không tìm thấy bản ghi
        }

        public List<AttendanceDTO> GetAttendanceByStudentID(string studentID)
        {
            List<AttendanceDTO> attendances = new List<AttendanceDTO>();
            string query = "SELECT * FROM Attendance WHERE StudentID = @StudentID";
            SqlParameter[] parameters = { new SqlParameter("@StudentID", studentID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                attendances.Add(new AttendanceDTO
                {
                    AttendanceID = row["AttendanceID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ScheduleID = row["ScheduleID"].ToString(),
                    AttendanceDate = Convert.ToDateTime(row["AttendanceDate"]),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"]?.ToString(),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return attendances;
        }


    }
}
