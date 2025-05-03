using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class SubjectDAL
    {
        public List<SubjectDTO> GetAll()
        {
            List<SubjectDTO> subjects = new List<SubjectDTO>();
            string query = "SELECT * FROM Subjects";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                subjects.Add(new SubjectDTO
                {
                    SubjectID = row["SubjectID"].ToString(),
                    SubjectName = row["SubjectName"].ToString(),
                    Credits = Convert.ToInt32(row["Credits"])
                });
            }

            return subjects;
        }

        public SubjectDTO GetSubjectByID(string subjectId)
        {
            string query = "SELECT * FROM Subjects WHERE SubjectID = @SubjectID";
            SqlParameter[] parameters = { new SqlParameter("@SubjectID", subjectId) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new SubjectDTO
                {
                    SubjectID = row["SubjectID"].ToString(),
                    SubjectName = row["SubjectName"].ToString(),
                    Credits = Convert.ToInt32(row["Credits"])
                };
            }

            return null;
        }

        public bool Insert(SubjectDTO subject)
        {
            string query = "INSERT INTO Subjects (SubjectID, SubjectName, Credits) VALUES (@SubjectID, @SubjectName, @Credits)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@SubjectID", subject.SubjectID),
                new SqlParameter("@SubjectName", subject.SubjectName),
                new SqlParameter("@Credits", subject.Credits)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(SubjectDTO subject)
        {
            string query = "UPDATE Subjects SET SubjectName = @SubjectName, Credits = @Credits WHERE SubjectID = @SubjectID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@SubjectID", subject.SubjectID),
                new SqlParameter("@SubjectName", subject.SubjectName),
                new SqlParameter("@Credits", subject.Credits)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(string subjectId)
        {
            string query = "DELETE FROM Subjects WHERE SubjectID = @SubjectID";
            SqlParameter[] parameters = { new SqlParameter("@SubjectID", subjectId) };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
