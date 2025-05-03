using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class StudentNotificationDAL
    {
        private DatabaseConnection dbConnection;

        public StudentNotificationDAL()
        {
            dbConnection = DatabaseConnection.Instance;
        }

        public List<StudentNotificationDTO> GetStudentNotificationsByStudentID(string studentID)
        {
            string query = @"SELECT sn.*, n.Title as NotificationTitle, s.FullName as StudentName
                           FROM StudentNotifications sn
                           INNER JOIN Notifications n ON sn.NotificationID = n.NotificationID
                           INNER JOIN Students s ON sn.StudentID = s.StudentID
                           WHERE sn.StudentID = @StudentID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", studentID)
            };

            DataTable dataTable = dbConnection.ExecuteQuery(query, parameters);

            List<StudentNotificationDTO> studentNotifications = new List<StudentNotificationDTO>();
            foreach (DataRow row in dataTable.Rows)
            {
                StudentNotificationDTO studentNotification = new StudentNotificationDTO
                {
                    ID = row["ID"].ToString(),
                    NotificationID = row["NotificationID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ReadStatus = Convert.ToBoolean(row["ReadStatus"]),
                    ReadDate = row["ReadDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["ReadDate"]),
                    NotificationTitle = row["NotificationTitle"].ToString(),
                    StudentName = row["StudentName"].ToString()
                };
                studentNotifications.Add(studentNotification);
            }

            return studentNotifications;
        }

        public StudentNotificationDTO GetStudentNotificationByID(string id)
        {
            string query = @"SELECT sn.*, n.Title as NotificationTitle, s.FullName as StudentName
                           FROM StudentNotifications sn
                           INNER JOIN Notifications n ON sn.NotificationID = n.NotificationID
                           INNER JOIN Students s ON sn.StudentID = s.StudentID
                           WHERE sn.ID = @ID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            };

            DataTable dataTable = dbConnection.ExecuteQuery(query, parameters);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new StudentNotificationDTO
                {
                    ID = row["ID"].ToString(),
                    NotificationID = row["NotificationID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ReadStatus = Convert.ToBoolean(row["ReadStatus"]),
                    ReadDate = row["ReadDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["ReadDate"]),
                    NotificationTitle = row["NotificationTitle"].ToString(),
                    StudentName = row["StudentName"].ToString()
                };
            }

            return null;
        }

        public List<StudentNotificationDTO> GetStudentNotificationsByNotificationID(string notificationID)
        {
            string query = @"SELECT sn.*, n.Title as NotificationTitle, s.FullName as StudentName
                           FROM StudentNotifications sn
                           INNER JOIN Notifications n ON sn.NotificationID = n.NotificationID
                           INNER JOIN Students s ON sn.StudentID = s.StudentID
                           WHERE sn.NotificationID = @NotificationID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NotificationID", notificationID)
            };

            DataTable dataTable = dbConnection.ExecuteQuery(query, parameters);

            List<StudentNotificationDTO> studentNotifications = new List<StudentNotificationDTO>();
            foreach (DataRow row in dataTable.Rows)
            {
                StudentNotificationDTO studentNotification = new StudentNotificationDTO
                {
                    ID = row["ID"].ToString(),
                    NotificationID = row["NotificationID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ReadStatus = Convert.ToBoolean(row["ReadStatus"]),
                    ReadDate = row["ReadDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["ReadDate"]),
                    NotificationTitle = row["NotificationTitle"].ToString(),
                    StudentName = row["StudentName"].ToString()
                };
                studentNotifications.Add(studentNotification);
            }

            return studentNotifications;
        }

        public bool AddStudentNotification(StudentNotificationDTO studentNotification)
        {
            string query = @"INSERT INTO StudentNotifications (ID, NotificationID, StudentID, ReadStatus, ReadDate) 
                           VALUES (@ID, @NotificationID, @StudentID, @ReadStatus, @ReadDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", studentNotification.ID),
                new SqlParameter("@NotificationID", studentNotification.NotificationID),
                new SqlParameter("@StudentID", studentNotification.StudentID),
                new SqlParameter("@ReadStatus", studentNotification.ReadStatus),
                new SqlParameter("@ReadDate", studentNotification.ReadDate ?? (object)DBNull.Value)
            };

            int rowsAffected = dbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public bool UpdateStudentNotification(StudentNotificationDTO studentNotification)
        {
            string query = @"UPDATE StudentNotifications 
                           SET NotificationID = @NotificationID, 
                               StudentID = @StudentID, 
                               ReadStatus = @ReadStatus, 
                               ReadDate = @ReadDate 
                           WHERE ID = @ID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", studentNotification.ID),
                new SqlParameter("@NotificationID", studentNotification.NotificationID),
                new SqlParameter("@StudentID", studentNotification.StudentID),
                new SqlParameter("@ReadStatus", studentNotification.ReadStatus),
                new SqlParameter("@ReadDate", studentNotification.ReadDate ?? (object)DBNull.Value)
            };

            int rowsAffected = dbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public bool DeleteStudentNotification(string id)
        {
            string query = "DELETE FROM StudentNotifications WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            };

            int rowsAffected = dbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public bool DeleteStudentNotificationsByNotificationID(string notificationID)
        {
            string query = "DELETE FROM StudentNotifications WHERE NotificationID = @NotificationID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NotificationID", notificationID)
            };

            int rowsAffected = dbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public bool DeleteStudentNotificationsByStudentID(string studentID)
        {
            string query = "DELETE FROM StudentNotifications WHERE StudentID = @StudentID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", studentID)
            };

            int rowsAffected = dbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
    }
}
