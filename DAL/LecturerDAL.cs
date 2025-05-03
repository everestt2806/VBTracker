using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class LecturerDAL
    {
        private DatabaseConnection dbConnection;

        public LecturerDAL()
        {
            dbConnection = DatabaseConnection.Instance;
        }

        public List<LecturerDTO> GetAllLecturers()
        {
            string query = "SELECT * FROM Lecturers";
            DataTable dataTable = dbConnection.ExecuteQuery(query);

            List<LecturerDTO> lecturers = new List<LecturerDTO>();
            foreach (DataRow row in dataTable.Rows)
            {
                LecturerDTO lecturer = new LecturerDTO
                {
                    LecturerID = row["LecturerID"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString()
                };
                lecturers.Add(lecturer);
            }

            return lecturers;
        }

        public LecturerDTO GetLecturerByID(string lecturerID)
        {
            string query = "SELECT * FROM Lecturers WHERE LecturerID = @LecturerID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LecturerID", lecturerID)
            };

            DataTable dataTable = dbConnection.ExecuteQuery(query, parameters);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new LecturerDTO
                {
                    LecturerID = row["LecturerID"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString()
                };
            }

            return null;
        }

        public LecturerDTO GetLecturerByUsername(string username)
        {
            string query = "SELECT * FROM Lecturers WHERE Username = @Username";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Username", username)
            };

            DataTable dataTable = dbConnection.ExecuteQuery(query, parameters);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new LecturerDTO
                {
                    LecturerID = row["LecturerID"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString()
                };
            }

            return null;
        }

        public bool AddLecturer(LecturerDTO lecturer)
        {
            string query = @"INSERT INTO Lecturers (LecturerID, FullName, Email, PhoneNumber, Username, Password) 
                           VALUES (@LecturerID, @FullName, @Email, @PhoneNumber, @Username, @Password)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LecturerID", lecturer.LecturerID),
                new SqlParameter("@FullName", lecturer.FullName),
                new SqlParameter("@Email", lecturer.Email),
                new SqlParameter("@PhoneNumber", lecturer.PhoneNumber ?? (object)DBNull.Value),
                new SqlParameter("@Username", lecturer.Username),
                new SqlParameter("@Password", lecturer.Password)
            };

            int rowsAffected = dbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public bool UpdateLecturer(LecturerDTO lecturer)
        {
            string query = @"UPDATE Lecturers 
                           SET FullName = @FullName, 
                               Email = @Email, 
                               PhoneNumber = @PhoneNumber, 
                               Username = @Username, 
                               Password = @Password 
                           WHERE LecturerID = @LecturerID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LecturerID", lecturer.LecturerID),
                new SqlParameter("@FullName", lecturer.FullName),
                new SqlParameter("@Email", lecturer.Email),
                new SqlParameter("@PhoneNumber", lecturer.PhoneNumber ?? (object)DBNull.Value),
                new SqlParameter("@Username", lecturer.Username),
                new SqlParameter("@Password", lecturer.Password)
            };

            int rowsAffected = dbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public bool DeleteLecturer(string lecturerID)
        {
            string query = "DELETE FROM Lecturers WHERE LecturerID = @LecturerID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LecturerID", lecturerID)
            };

            int rowsAffected = dbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
    }
}
