using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class SemesterDAL
    {
        public List<SemesterDTO> GetAll()
        {
            List<SemesterDTO> semesters = new List<SemesterDTO>();
            string query = "SELECT * FROM Semesters";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                semesters.Add(new SemesterDTO
                {
                    SemesterID = row["SemesterID"].ToString(),
                    SemesterName = row["SemesterName"].ToString()
                });
            }

            return semesters;
        }

        public SemesterDTO GetSemesterByID(string semesterId)
        {
            string query = "SELECT * FROM Semesters WHERE SemesterID = @SemesterID";
            SqlParameter[] parameters = { new SqlParameter("@SemesterID", semesterId) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new SemesterDTO
                {
                    SemesterID = row["SemesterID"].ToString(),
                    SemesterName = row["SemesterName"].ToString()
                };
            }

            return null;
        }

        public bool Insert(SemesterDTO semester)
        {
            string query = "INSERT INTO Semesters (SemesterID, SemesterName) VALUES (@SemesterID, @SemesterName)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@SemesterID", semester.SemesterID),
                new SqlParameter("@SemesterName", semester.SemesterName)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(SemesterDTO semester)
        {
            string query = "UPDATE Semesters SET SemesterName = @SemesterName WHERE SemesterID = @SemesterID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@SemesterID", semester.SemesterID),
                new SqlParameter("@SemesterName", semester.SemesterName)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(string semesterId)
        {
            string query = "DELETE FROM Semesters WHERE SemesterID = @SemesterID";
            SqlParameter[] parameters = { new SqlParameter("@SemesterID", semesterId) };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
