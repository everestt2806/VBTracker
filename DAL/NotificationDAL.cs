using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class NotificationDAL
    {
        public List<NotificationDTO> GetAll()
        {
            List<NotificationDTO> notifications = new List<NotificationDTO>();
            string query = "SELECT * FROM Notifications";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                notifications.Add(new NotificationDTO
                {
                    NotificationID = row["NotificationID"].ToString(),
                    Title = row["Title"].ToString(),
                    Content = row["Content"].ToString(),
                    CreatedBy = row["CreatedBy"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    ClassID = row["ClassID"]?.ToString(),
                    Priority = row["Priority"].ToString(),
                    ExpiryDate = row["ExpiryDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["ExpiryDate"]),
                    IsGlobal = Convert.ToBoolean(row["IsGlobal"])
                });
            }

            return notifications;
        }

        public NotificationDTO GetById(string notificationId)
        {
            string query = "SELECT * FROM Notifications WHERE NotificationID = @NotificationID";
            SqlParameter[] parameters = { new SqlParameter("@NotificationID", notificationId) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new NotificationDTO
                {
                    NotificationID = row["NotificationID"].ToString(),
                    Title = row["Title"].ToString(),
                    Content = row["Content"].ToString(),
                    CreatedBy = row["CreatedBy"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    ClassID = row["ClassID"]?.ToString(),
                    Priority = row["Priority"].ToString(),
                    ExpiryDate = row["ExpiryDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["ExpiryDate"]),
                    IsGlobal = Convert.ToBoolean(row["IsGlobal"])
                };
            }

            return null;
        }

        public bool Insert(NotificationDTO notification)
        {
            string query = "INSERT INTO Notifications (NotificationID, Title, Content, CreatedBy, CreatedDate, ClassID, Priority, ExpiryDate, IsGlobal) " +
                           "VALUES (@NotificationID, @Title, @Content, @CreatedBy, @CreatedDate, @ClassID, @Priority, @ExpiryDate, @IsGlobal)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@NotificationID", notification.NotificationID),
                new SqlParameter("@Title", notification.Title),
                new SqlParameter("@Content", notification.Content),
                new SqlParameter("@CreatedBy", notification.CreatedBy),
                new SqlParameter("@CreatedDate", notification.CreatedDate),
                new SqlParameter("@ClassID", notification.ClassID ?? (object)DBNull.Value),
                new SqlParameter("@Priority", notification.Priority),
                new SqlParameter("@ExpiryDate", notification.ExpiryDate ?? (object)DBNull.Value),
                new SqlParameter("@IsGlobal", notification.IsGlobal)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(NotificationDTO notification)
        {
            string query = "UPDATE Notifications SET Title = @Title, Content = @Content, CreatedBy = @CreatedBy, CreatedDate = @CreatedDate, " +
                           "ClassID = @ClassID, Priority = @Priority, ExpiryDate = @ExpiryDate, IsGlobal = @IsGlobal " +
                           "WHERE NotificationID = @NotificationID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@NotificationID", notification.NotificationID),
                new SqlParameter("@Title", notification.Title),
                new SqlParameter("@Content", notification.Content),
                new SqlParameter("@CreatedBy", notification.CreatedBy),
                new SqlParameter("@CreatedDate", notification.CreatedDate),
                new SqlParameter("@ClassID", notification.ClassID ?? (object)DBNull.Value),
                new SqlParameter("@Priority", notification.Priority),
                new SqlParameter("@ExpiryDate", notification.ExpiryDate ?? (object)DBNull.Value),
                new SqlParameter("@IsGlobal", notification.IsGlobal)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(string notificationId)
        {
            string query = "DELETE FROM Notifications WHERE NotificationID = @NotificationID";
            SqlParameter[] parameters = { new SqlParameter("@NotificationID", notificationId) };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
