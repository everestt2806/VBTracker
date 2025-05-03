using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class ClassEnrollmentDAL
    {
        public List<ClassEnrollmentDTO> GetAll()
        {
            List<ClassEnrollmentDTO> enrollments = new List<ClassEnrollmentDTO>();
            string query = "SELECT * FROM ClassEnrollments";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                enrollments.Add(new ClassEnrollmentDTO
                {
                    EnrollmentID = row["EnrollmentID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ClassID = row["ClassID"].ToString(),
                    EnrollmentDate = Convert.ToDateTime(row["EnrollmentDate"]),
                    Status = row["Status"].ToString(),
                    FinalGrade = row["FinalGrade"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["FinalGrade"])
                });
            }

            return enrollments;
        }
        public List<ClassEnrollmentDTO> GetEnrollmentsByClassID(string classID)
        {
            string query = "SELECT * FROM ClassEnrollments WHERE ClassID = @ClassID";
            SqlParameter[] parameters = { new SqlParameter("@ClassID", classID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<ClassEnrollmentDTO> enrollments = new List<ClassEnrollmentDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                enrollments.Add(new ClassEnrollmentDTO
                {
                    EnrollmentID = row["EnrollmentID"].ToString(),
                    ClassID = row["ClassID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    EnrollmentDate = Convert.ToDateTime(row["EnrollmentDate"])
                });
            }

            return enrollments;
        }
        public List<ClassEnrollmentDTO> GetEnrollmentsByStudentID(string studentID)
        {
            string query = "SELECT * FROM ClassEnrollments WHERE StudentID = @StudentID";
            SqlParameter[] parameters = { new SqlParameter("@StudentID", studentID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<ClassEnrollmentDTO> enrollments = new List<ClassEnrollmentDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                enrollments.Add(new ClassEnrollmentDTO
                {
                    EnrollmentID = row["EnrollmentID"].ToString(),
                    ClassID = row["ClassID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    EnrollmentDate = Convert.ToDateTime(row["EnrollmentDate"])
                });
            }

            return enrollments;
        }


        public ClassEnrollmentDTO GetEnrollmentByStudentAndClass(string studentID, string classID)
        {
            string query = "SELECT * FROM ClassEnrollments WHERE StudentID = @StudentID AND ClassID = @ClassID";
            SqlParameter[] parameters =
            {
        new SqlParameter("@StudentID", studentID),
        new SqlParameter("@ClassID", classID)
    };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new ClassEnrollmentDTO
                {
                    EnrollmentID = row["EnrollmentID"].ToString(),
                    ClassID = row["ClassID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    EnrollmentDate = Convert.ToDateTime(row["EnrollmentDate"])
                };
            }

            return null; // Nếu không tìm thấy kết quả
        }


        public ClassEnrollmentDTO GetEnrollmentByID(string enrollmentId)
        {
            string query = "SELECT * FROM ClassEnrollments WHERE EnrollmentID = @EnrollmentID";
            SqlParameter[] parameters = { new SqlParameter("@EnrollmentID", enrollmentId) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new ClassEnrollmentDTO
                {
                    EnrollmentID = row["EnrollmentID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    ClassID = row["ClassID"].ToString(),
                    EnrollmentDate = Convert.ToDateTime(row["EnrollmentDate"]),
                    Status = row["Status"].ToString(),
                    FinalGrade = row["FinalGrade"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["FinalGrade"])
                };
            }

            return null;
        }

        public bool Insert(ClassEnrollmentDTO enrollment)
        {
            string query = "INSERT INTO ClassEnrollments (EnrollmentID, StudentID, ClassID, EnrollmentDate, Status, FinalGrade) " +
                           "VALUES (@EnrollmentID, @StudentID, @ClassID, @EnrollmentDate, @Status, @FinalGrade)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@EnrollmentID", enrollment.EnrollmentID),
                new SqlParameter("@StudentID", enrollment.StudentID),
                new SqlParameter("@ClassID", enrollment.ClassID),
                new SqlParameter("@EnrollmentDate", enrollment.EnrollmentDate),
                new SqlParameter("@Status", enrollment.Status),
                new SqlParameter("@FinalGrade", enrollment.FinalGrade ?? (object)DBNull.Value)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(ClassEnrollmentDTO enrollment)
        {
            string query = "UPDATE ClassEnrollments SET StudentID = @StudentID, ClassID = @ClassID, EnrollmentDate = @EnrollmentDate, " +
                           "Status = @Status, FinalGrade = @FinalGrade WHERE EnrollmentID = @EnrollmentID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@EnrollmentID", enrollment.EnrollmentID),
                new SqlParameter("@StudentID", enrollment.StudentID),
                new SqlParameter("@ClassID", enrollment.ClassID),
                new SqlParameter("@EnrollmentDate", enrollment.EnrollmentDate),
                new SqlParameter("@Status", enrollment.Status),
                new SqlParameter("@FinalGrade", enrollment.FinalGrade ?? (object)DBNull.Value)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(string enrollmentId)
        {
            string query = "DELETE FROM ClassEnrollments WHERE EnrollmentID = @EnrollmentID";
            SqlParameter[] parameters = { new SqlParameter("@EnrollmentID", enrollmentId) };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
