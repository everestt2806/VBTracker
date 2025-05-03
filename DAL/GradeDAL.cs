using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class GradeDAL
    {
        public List<GradeDTO> GetAll()
        {
            List<GradeDTO> grades = new List<GradeDTO>();
            string query = "SELECT * FROM Grades";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                grades.Add(new GradeDTO
                {
                    GradeID = row["GradeID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ClassID = row["ClassID"].ToString(),
                    AssignmentType = row["AssignmentType"].ToString(),
                    Score = Convert.ToDecimal(row["Score"]),
                    MaxScore = Convert.ToDecimal(row["MaxScore"]),
                    Weight = Convert.ToDecimal(row["Weight"]),
                    SubmissionDate = row["SubmissionDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["SubmissionDate"]),
                    GradedBy = row["GradedBy"]?.ToString(),
                    GradedDate = row["GradedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["GradedDate"]),
                    Comments = row["Comments"]?.ToString()
                });
            }

            return grades;
        }

        public GradeDTO GetById(string gradeId)
        {
            string query = "SELECT * FROM Grades WHERE GradeID = @GradeID";
            SqlParameter[] parameters = { new SqlParameter("@GradeID", gradeId) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new GradeDTO
                {
                    GradeID = row["GradeID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ClassID = row["ClassID"].ToString(),
                    AssignmentType = row["AssignmentType"].ToString(),
                    Score = Convert.ToDecimal(row["Score"]),
                    MaxScore = Convert.ToDecimal(row["MaxScore"]),
                    Weight = Convert.ToDecimal(row["Weight"]),
                    SubmissionDate = row["SubmissionDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["SubmissionDate"]),
                    GradedBy = row["GradedBy"]?.ToString(),
                    GradedDate = row["GradedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["GradedDate"]),
                    Comments = row["Comments"]?.ToString()
                };
            }

            return null;
        }
        public List<GradeDTO> GetGradesByClassID(string classID)
        {
            string query = "SELECT * FROM Grades WHERE ClassID = @ClassID";
            SqlParameter[] parameters = { new SqlParameter("@ClassID", classID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<GradeDTO> grades = new List<GradeDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                grades.Add(new GradeDTO
                {
                    GradeID = row["GradeID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ClassID = row["ClassID"].ToString(),
                    AssignmentType = row["AssignmentType"].ToString(),
                    Score = Convert.ToDecimal(row["Score"]),
                    MaxScore = Convert.ToDecimal(row["MaxScore"]),
                    Weight = Convert.ToDecimal(row["Weight"]),
                    SubmissionDate = row["SubmissionDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["SubmissionDate"]),
                    GradedBy = row["GradedBy"]?.ToString(),
                    GradedDate = row["GradedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["GradedDate"]),
                    Comments = row["Comments"]?.ToString()
                });
            }

            return grades;
        }

        public List<GradeDTO> GetGradesByStudentID(string studentID)
        {
            string query = "SELECT * FROM Grades WHERE StudentID = @StudentID";
            SqlParameter[] parameters = { new SqlParameter("@StudentID", studentID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<GradeDTO> grades = new List<GradeDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                grades.Add(new GradeDTO
                {
                    GradeID = row["GradeID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ClassID = row["ClassID"].ToString(),
                    AssignmentType = row["AssignmentType"].ToString(),
                    Score = Convert.ToDecimal(row["Score"]),
                    MaxScore = Convert.ToDecimal(row["MaxScore"]),
                    Weight = Convert.ToDecimal(row["Weight"]),
                    SubmissionDate = row["SubmissionDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["SubmissionDate"]),
                    GradedBy = row["GradedBy"]?.ToString(),
                    GradedDate = row["GradedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["GradedDate"]),
                    Comments = row["Comments"]?.ToString()
                });
            }

            return grades;
        }


        public bool Insert(GradeDTO grade)
        {
            string query = "INSERT INTO Grades (GradeID, StudentID, ClassID, AssignmentType, Score, MaxScore, Weight, SubmissionDate, GradedBy, GradedDate, Comments) " +
                           "VALUES (@GradeID, @StudentID, @ClassID, @AssignmentType, @Score, @MaxScore, @Weight, @SubmissionDate, @GradedBy, @GradedDate, @Comments)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@GradeID", grade.GradeID),
                new SqlParameter("@StudentID", grade.StudentID),
                new SqlParameter("@ClassID", grade.ClassID),
                new SqlParameter("@AssignmentType", grade.AssignmentType),
                new SqlParameter("@Score", grade.Score),
                new SqlParameter("@MaxScore", grade.MaxScore),
                new SqlParameter("@Weight", grade.Weight),
                new SqlParameter("@SubmissionDate", grade.SubmissionDate ?? (object)DBNull.Value),
                new SqlParameter("@GradedBy", grade.GradedBy ?? (object)DBNull.Value),
                new SqlParameter("@GradedDate", grade.GradedDate ?? (object)DBNull.Value),
                new SqlParameter("@Comments", grade.Comments ?? (object)DBNull.Value)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(GradeDTO grade)
        {
            string query = "UPDATE Grades SET StudentID = @StudentID, ClassID = @ClassID, AssignmentType = @AssignmentType, Score = @Score, " +
                           "MaxScore = @MaxScore, Weight = @Weight, SubmissionDate = @SubmissionDate, GradedBy = @GradedBy, GradedDate = @GradedDate, Comments = @Comments " +
                           "WHERE GradeID = @GradeID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@GradeID", grade.GradeID),
                new SqlParameter("@StudentID", grade.StudentID),
                new SqlParameter("@ClassID", grade.ClassID),
                new SqlParameter("@AssignmentType", grade.AssignmentType),
                new SqlParameter("@Score", grade.Score),
                new SqlParameter("@MaxScore", grade.MaxScore),
                new SqlParameter("@Weight", grade.Weight),
                new SqlParameter("@SubmissionDate", grade.SubmissionDate ?? (object)DBNull.Value),
                new SqlParameter("@GradedBy", grade.GradedBy ?? (object)DBNull.Value),
                new SqlParameter("@GradedDate", grade.GradedDate ?? (object)DBNull.Value),
                new SqlParameter("@Comments", grade.Comments ?? (object)DBNull.Value)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(string gradeId)
        {
            string query = "DELETE FROM Grades WHERE GradeID = @GradeID";
            SqlParameter[] parameters = { new SqlParameter("@GradeID", gradeId) };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
