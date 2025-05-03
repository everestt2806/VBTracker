using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class StudentDAL
    {
        public List<StudentDTO> GetAll()
        {
            List<StudentDTO> students = new List<StudentDTO>();
            string query = "SELECT * FROM Students";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                students.Add(new StudentDTO
                {
                    StudentID = row["StudentID"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    Major = row["Major"].ToString(),
                    Gender = row["Gender"].ToString(),
                    Hometown = row["Hometown"].ToString(),
                    DOB = Convert.ToDateTime(row["DOB"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return students;
        }
        public List<StudentDTO> SearchStudentsByName(string name)
        {
            string query = "SELECT * FROM Students WHERE FullName LIKE @FullName";
            SqlParameter[] parameters = { new SqlParameter("@FullName", "%" + name + "%") };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<StudentDTO> students = new List<StudentDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                students.Add(new StudentDTO
                {
                    StudentID = row["StudentID"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    Major = row["Major"].ToString(),
                    Gender = row["Gender"].ToString(),
                    Hometown = row["Hometown"].ToString(),
                    DOB = Convert.ToDateTime(row["DOB"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return students;
        }

        public List<StudentDTO> FilterStudentsByMajor(string major)
        {
            string query = "SELECT * FROM Students WHERE Major = @Major";
            SqlParameter[] parameters = { new SqlParameter("@Major", major) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<StudentDTO> students = new List<StudentDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                students.Add(new StudentDTO
                {
                    StudentID = row["StudentID"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    Major = row["Major"].ToString(),
                    Gender = row["Gender"].ToString(),
                    Hometown = row["Hometown"].ToString(),
                    DOB = Convert.ToDateTime(row["DOB"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return students;
        }


        public StudentDTO GetStudentByID(string studentId)
        {
            string query = "SELECT * FROM Students WHERE StudentID = @StudentID";
            SqlParameter[] parameters = { new SqlParameter("@StudentID", studentId) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new StudentDTO
                {
                    StudentID = row["StudentID"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    Major = row["Major"].ToString(),
                    Gender = row["Gender"].ToString(),
                    Hometown = row["Hometown"].ToString(),
                    DOB = Convert.ToDateTime(row["DOB"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                };
            }

            return null;
        }

        public bool Insert(StudentDTO student)
        {
            string query = "INSERT INTO Students (StudentID, FullName, Email, PhoneNumber, Major, Gender, Hometown, DOB, Username, Password, CreatedDate, UpdatedDate) " +
                           "VALUES (@StudentID, @FullName, @Email, @PhoneNumber, @Major, @Gender, @Hometown, @DOB, @Username, @Password, @CreatedDate, @UpdatedDate)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@StudentID", student.StudentID),
                new SqlParameter("@FullName", student.FullName),
                new SqlParameter("@Email", student.Email),
                new SqlParameter("@PhoneNumber", student.PhoneNumber),
                new SqlParameter("@Major", student.Major),
                new SqlParameter("@Gender", student.Gender),
                new SqlParameter("@Hometown", student.Hometown),
                new SqlParameter("@DOB", student.DOB),
                new SqlParameter("@Username", student.Username),
                new SqlParameter("@Password", student.Password),
                new SqlParameter("@CreatedDate", student.CreatedDate),
                new SqlParameter("@UpdatedDate", student.UpdatedDate)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(StudentDTO student)
        {
            string query = "UPDATE Students SET FullName = @FullName, Email = @Email, PhoneNumber = @PhoneNumber, Major = @Major, " +
                           "Gender = @Gender, Hometown = @Hometown, DOB = @DOB, Username = @Username, Password = @Password, " +
                           "CreatedDate = @CreatedDate, UpdatedDate = @UpdatedDate WHERE StudentID = @StudentID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@StudentID", student.StudentID),
                new SqlParameter("@FullName", student.FullName),
                new SqlParameter("@Email", student.Email),
                new SqlParameter("@PhoneNumber", student.PhoneNumber),
                new SqlParameter("@Major", student.Major),
                new SqlParameter("@Gender", student.Gender),
                new SqlParameter("@Hometown", student.Hometown),
                new SqlParameter("@DOB", student.DOB),
                new SqlParameter("@Username", student.Username),
                new SqlParameter("@Password", student.Password),
                new SqlParameter("@CreatedDate", student.CreatedDate),
                new SqlParameter("@UpdatedDate", student.UpdatedDate)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(string studentId)
        {
            string query = "DELETE FROM Students WHERE StudentID = @StudentID";
            SqlParameter[] parameters = { new SqlParameter("@StudentID", studentId) };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public StudentDTO GetStudentByUsername(string username)
        {
            string query = "SELECT * FROM Students WHERE Username = @Username";
            SqlParameter[] parameters = { new SqlParameter("@Username", username) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new StudentDTO
                {
                    StudentID = row["StudentID"].ToString(),
                    Username = row["Username"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Email = row["Email"].ToString(),
                    Password = row["Password"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                };
            }

            return null; // Nếu không tìm thấy sinh viên
        }


    }
}
