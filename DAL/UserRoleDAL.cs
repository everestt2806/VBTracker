using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class UserRoleDAL
    {
        public List<UserRoleDTO> GetAll()
        {
            List<UserRoleDTO> userRoles = new List<UserRoleDTO>();
            string query = "SELECT * FROM UserRoles";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                userRoles.Add(new UserRoleDTO
                {
                    UserRoleID = Convert.ToInt32(row["UserRoleID"]),
                    UserID = row["UserID"].ToString(),
                    RoleID = Convert.ToInt32(row["RoleID"])
                });
            }

            return userRoles;
        }

        public UserRoleDTO GetById(int userRoleId)
        {
            string query = "SELECT * FROM UserRoles WHERE UserRoleID = @UserRoleID";
            SqlParameter[] parameters = { new SqlParameter("@UserRoleID", userRoleId) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new UserRoleDTO
                {
                    UserRoleID = Convert.ToInt32(row["UserRoleID"]),
                    UserID = row["UserID"].ToString(),
                    RoleID = Convert.ToInt32(row["RoleID"])
                };
            }

            return null;
        }

        public bool Insert(UserRoleDTO userRole)
        {
            string query = "INSERT INTO UserRoles (UserID, RoleID) VALUES (@UserID, @RoleID)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserID", userRole.UserID),
                new SqlParameter("@RoleID", userRole.RoleID)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(UserRoleDTO userRole)
        {
            string query = "UPDATE UserRoles SET UserID = @UserID, RoleID = @RoleID WHERE UserRoleID = @UserRoleID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserRoleID", userRole.UserRoleID),
                new SqlParameter("@UserID", userRole.UserID),
                new SqlParameter("@RoleID", userRole.RoleID)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int userRoleId)
        {
            string query = "DELETE FROM UserRoles WHERE UserRoleID = @UserRoleID";
            SqlParameter[] parameters = { new SqlParameter("@UserRoleID", userRoleId) };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
