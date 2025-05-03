using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class MakeupAttendanceDAL
    {
        public List<MakeupAttendanceDTO> GetAll()
        {
            List<MakeupAttendanceDTO> makeupAttendances = new List<MakeupAttendanceDTO>();
            string query = "SELECT * FROM MakeupAttendance";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                makeupAttendances.Add(new MakeupAttendanceDTO
                {
                    MakeupAttendanceID = row["MakeupAttendanceID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    MakeupClassID = row["MakeupClassID"].ToString(),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"].ToString(),
                    AttendanceTime = Convert.ToDateTime(row["AttendanceTime"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return makeupAttendances;
        }

        public List<MakeupAttendanceDTO> GetByMakeupClassID(string makeupClassID)
        {
            string query = "SELECT * FROM MakeupAttendance WHERE MakeupClassID = @MakeupClassID";
            SqlParameter[] parameters = { new SqlParameter("@MakeupClassID", makeupClassID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<MakeupAttendanceDTO> makeupAttendances = new List<MakeupAttendanceDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                makeupAttendances.Add(new MakeupAttendanceDTO
                {
                    MakeupAttendanceID = row["MakeupAttendanceID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    MakeupClassID = row["MakeupClassID"].ToString(),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"].ToString(),
                    AttendanceTime = Convert.ToDateTime(row["AttendanceTime"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return makeupAttendances;
        }

        public List<MakeupAttendanceDTO> GetByStudentID(string studentID)
        {
            string query = "SELECT * FROM MakeupAttendance WHERE StudentID = @StudentID";
            SqlParameter[] parameters = { new SqlParameter("@StudentID", studentID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<MakeupAttendanceDTO> makeupAttendances = new List<MakeupAttendanceDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                makeupAttendances.Add(new MakeupAttendanceDTO
                {
                    MakeupAttendanceID = row["MakeupAttendanceID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    MakeupClassID = row["MakeupClassID"].ToString(),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"].ToString(),
                    AttendanceTime = Convert.ToDateTime(row["AttendanceTime"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return makeupAttendances;
        }

        public MakeupAttendanceDTO GetByID(string makeupAttendanceID)
        {
            string query = "SELECT * FROM MakeupAttendance WHERE MakeupAttendanceID = @MakeupAttendanceID";
            SqlParameter[] parameters = { new SqlParameter("@MakeupAttendanceID", makeupAttendanceID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new MakeupAttendanceDTO
                {
                    MakeupAttendanceID = row["MakeupAttendanceID"].ToString(),
                    StudentID = row["StudentID"].ToString(),
                    MakeupClassID = row["MakeupClassID"].ToString(),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"].ToString(),
                    AttendanceTime = Convert.ToDateTime(row["AttendanceTime"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                };
            }

            return null;
        }

        public bool Insert(MakeupAttendanceDTO makeupAttendance)
        {
            string query = @"INSERT INTO MakeupAttendance 
                            (MakeupAttendanceID, StudentID, MakeupClassID, Status, Notes, AttendanceTime, CreatedDate, UpdatedDate) 
                            VALUES 
                            (@MakeupAttendanceID, @StudentID, @MakeupClassID, @Status, @Notes, @AttendanceTime, @CreatedDate, @UpdatedDate)";

            SqlParameter[] parameters = {
                new SqlParameter("@MakeupAttendanceID", makeupAttendance.MakeupAttendanceID),
                new SqlParameter("@StudentID", makeupAttendance.StudentID),
                new SqlParameter("@MakeupClassID", makeupAttendance.MakeupClassID),
                new SqlParameter("@Status", makeupAttendance.Status),
                new SqlParameter("@Notes", makeupAttendance.Notes ?? (object)DBNull.Value),
                new SqlParameter("@AttendanceTime", makeupAttendance.AttendanceTime),
                new SqlParameter("@CreatedDate", DateTime.Now),
                new SqlParameter("@UpdatedDate", DateTime.Now)
            };

            int result = DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool Update(MakeupAttendanceDTO makeupAttendance)
        {
            string query = @"UPDATE MakeupAttendance 
                            SET StudentID = @StudentID, 
                                MakeupClassID = @MakeupClassID, 
                                Status = @Status, 
                                Notes = @Notes, 
                                AttendanceTime = @AttendanceTime, 
                                UpdatedDate = @UpdatedDate 
                            WHERE MakeupAttendanceID = @MakeupAttendanceID";

            SqlParameter[] parameters = {
                new SqlParameter("@MakeupAttendanceID", makeupAttendance.MakeupAttendanceID),
                new SqlParameter("@StudentID", makeupAttendance.StudentID),
                new SqlParameter("@MakeupClassID", makeupAttendance.MakeupClassID),
                new SqlParameter("@Status", makeupAttendance.Status),
                new SqlParameter("@Notes", makeupAttendance.Notes ?? (object)DBNull.Value),
                new SqlParameter("@AttendanceTime", makeupAttendance.AttendanceTime),
                new SqlParameter("@UpdatedDate", DateTime.Now)
            };

            int result = DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool Delete(string makeupAttendanceID)
        {
            string query = "DELETE FROM MakeupAttendance WHERE MakeupAttendanceID = @MakeupAttendanceID";
            SqlParameter[] parameters = { new SqlParameter("@MakeupAttendanceID", makeupAttendanceID) };

            int result = DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}
