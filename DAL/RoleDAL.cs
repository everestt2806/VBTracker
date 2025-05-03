using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class RoleDAL
    {
        public List<RoleDTO> GetAll()
        {
            List<RoleDTO> roles = new List<RoleDTO>();
            string query = "SELECT * FROM Roles";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                roles.Add(new RoleDTO
                {
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString()
                });
            }

            return roles;
        }

        public RoleDTO GetById(int roleId)
        {
            string query = "SELECT * FROM Roles WHERE RoleID = @RoleID";
            SqlParameter[] parameters = { new SqlParameter("@RoleID", roleId) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new RoleDTO
                {
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString()
                };
            }

            return null;
        }

        public bool Insert(RoleDTO role)
        {
            string query = "INSERT INTO Roles (RoleName) VALUES (@RoleName)";
            SqlParameter[] parameters = { new SqlParameter("@RoleName", role.RoleName) };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(RoleDTO role)
        {
            string query = "UPDATE Roles SET RoleName = @RoleName WHERE RoleID = @RoleID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@RoleID", role.RoleID),
                new SqlParameter("@RoleName", role.RoleName)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int roleId)
        {
            string query = "DELETE FROM Roles WHERE RoleID = @RoleID";
            SqlParameter[] parameters = { new SqlParameter("@RoleID", roleId) };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
