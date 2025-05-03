using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class ClassDAL
    {
        public List<ClassDTO> GetAll()
        {
            List<ClassDTO> classes = new List<ClassDTO>();
            string query = "SELECT * FROM Classes";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                classes.Add(new ClassDTO
                {
                    ClassID = row["ClassID"].ToString(),
                    SubjectID = row["SubjectID"].ToString(),
                    SemesterID = row["SemesterID"].ToString(),
                    LecturerID = row["LecturerID"].ToString(),
                    ClassName = row["ClassName"].ToString(),
                    MaxStudents = Convert.ToInt32(row["MaxStudents"]),
                    Status = row["Status"].ToString(),
                    Description = row["Description"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return classes;
        }

        public ClassDTO GetById(string classId)
        {
            string query = "SELECT * FROM Classes WHERE ClassID = @ClassID";
            SqlParameter[] parameters = { new SqlParameter("@ClassID", classId) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new ClassDTO
                {
                    ClassID = row["ClassID"].ToString(),
                    SubjectID = row["SubjectID"].ToString(),
                    SemesterID = row["SemesterID"].ToString(),
                    LecturerID = row["LecturerID"].ToString(),
                    ClassName = row["ClassName"].ToString(),
                    MaxStudents = Convert.ToInt32(row["MaxStudents"]),
                    Status = row["Status"].ToString(),
                    Description = row["Description"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                };
            }

            return null;
        }

        public bool Insert(ClassDTO classObj)
        {
            string query = "INSERT INTO Classes (ClassID, SubjectID, SemesterID, LecturerID, ClassName, MaxStudents, Status, Description, CreatedDate, UpdatedDate) " +
                           "VALUES (@ClassID, @SubjectID, @SemesterID, @LecturerID, @ClassName, @MaxStudents, @Status, @Description, @CreatedDate, @UpdatedDate)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ClassID", classObj.ClassID),
                new SqlParameter("@SubjectID", classObj.SubjectID),
                new SqlParameter("@SemesterID", classObj.SemesterID),
                new SqlParameter("@LecturerID", classObj.LecturerID),
                new SqlParameter("@ClassName", classObj.ClassName),
                new SqlParameter("@MaxStudents", classObj.MaxStudents),
                new SqlParameter("@Status", classObj.Status),
                new SqlParameter("@Description", classObj.Description ?? (object)DBNull.Value),
                new SqlParameter("@CreatedDate", classObj.CreatedDate),
                new SqlParameter("@UpdatedDate", classObj.UpdatedDate)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(ClassDTO classObj)
        {
            string query = "UPDATE Classes SET SubjectID = @SubjectID, SemesterID = @SemesterID, LecturerID = @LecturerID, ClassName = @ClassName, " +
                           "MaxStudents = @MaxStudents, Status = @Status, Description = @Description, UpdatedDate = @UpdatedDate WHERE ClassID = @ClassID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ClassID", classObj.ClassID),
                new SqlParameter("@SubjectID", classObj.SubjectID),
                new SqlParameter("@SemesterID", classObj.SemesterID),
                new SqlParameter("@LecturerID", classObj.LecturerID),
                new SqlParameter("@ClassName", classObj.ClassName),
                new SqlParameter("@MaxStudents", classObj.MaxStudents),
                new SqlParameter("@Status", classObj.Status),
                new SqlParameter("@Description", classObj.Description ?? (object)DBNull.Value),
                new SqlParameter("@UpdatedDate", classObj.UpdatedDate)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(string classId)
        {
            string query = "DELETE FROM Classes WHERE ClassID = @ClassID";
            SqlParameter[] parameters = { new SqlParameter("@ClassID", classId) };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public ClassDTO GetClassByID(string classID)
        {
            string query = "SELECT * FROM Classes WHERE ClassID = @ClassID";
            SqlParameter[] parameters = { new SqlParameter("@ClassID", classID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new ClassDTO
                {
                    ClassID = row["ClassID"].ToString(),
                    ClassName = row["ClassName"].ToString(),
                    LecturerID = row["LecturerID"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = row["UpdatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UpdatedDate"])
                };
            }

            return null; // Trả về null nếu không tìm thấy lớp học
        }

        public List<ClassDTO> GetClassesByLecturerID(string lecturerID)
        {
            List<ClassDTO> classes = new List<ClassDTO>();
            string query = "SELECT * FROM Classes WHERE LecturerID = @LecturerID";
            SqlParameter[] parameters = { new SqlParameter("@LecturerID", lecturerID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                classes.Add(new ClassDTO
                {
                    ClassID = row["ClassID"].ToString(),
                    ClassName = row["ClassName"].ToString(),
                    LecturerID = row["LecturerID"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = row["UpdatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return classes;
        }

        public List<ClassDTO> GetAllClasses()
        {
            List<ClassDTO> classes = new List<ClassDTO>();
            string query = "SELECT * FROM Classes";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                classes.Add(new ClassDTO
                {
                    ClassID = row["ClassID"].ToString(),
                    ClassName = row["ClassName"].ToString(),
                    LecturerID = row["LecturerID"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = row["UpdatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return classes;
        }


        public List<ClassDTO> GetClassesByStudentID(string studentID)
        {
            string query = @"
                SELECT c.ClassID, c.ClassName, c.LecturerID, c.CreatedDate, c.UpdatedDate
                FROM Classes c
                INNER JOIN StudentClasses sc ON c.ClassID = sc.ClassID
                WHERE sc.StudentID = @StudentID";

            SqlParameter[] parameters = { new SqlParameter("@StudentID", studentID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<ClassDTO> classes = new List<ClassDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                ClassDTO classDTO = new ClassDTO
                {
                    ClassID = row["ClassID"].ToString(),
                    ClassName = row["ClassName"].ToString(),
                    LecturerID = row["LecturerID"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = row["UpdatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UpdatedDate"])
                };

                classes.Add(classDTO);
            }

            return classes;
        }

       
    }
}
