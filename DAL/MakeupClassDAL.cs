using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class MakeupClassDAL
    {
        public List<MakeupClassDTO> GetAll()
        {
            List<MakeupClassDTO> makeupClasses = new List<MakeupClassDTO>();
            string query = "SELECT * FROM MakeupClasses";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                makeupClasses.Add(new MakeupClassDTO
                {
                    MakeupClassID = row["MakeupClassID"].ToString(),
                    OriginalClassID = row["OriginalClassID"].ToString(),
                    RoomID = row["RoomID"].ToString(),
                    LecturerID = row["LecturerID"].ToString(),
                    MakeupDate = Convert.ToDateTime(row["MakeupDate"]),
                    Session = row["Session"].ToString(),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return makeupClasses;
        }

        public List<MakeupClassDTO> GetByLecturerID(string lecturerID)
        {
            string query = "SELECT * FROM MakeupClasses WHERE LecturerID = @LecturerID";
            SqlParameter[] parameters = { new SqlParameter("@LecturerID", lecturerID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<MakeupClassDTO> makeupClasses = new List<MakeupClassDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                makeupClasses.Add(new MakeupClassDTO
                {
                    MakeupClassID = row["MakeupClassID"].ToString(),
                    OriginalClassID = row["OriginalClassID"].ToString(),
                    RoomID = row["RoomID"].ToString(),
                    LecturerID = row["LecturerID"].ToString(),
                    MakeupDate = Convert.ToDateTime(row["MakeupDate"]),
                    Session = row["Session"].ToString(),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return makeupClasses;
        }

        public List<MakeupClassDTO> GetByOriginalClassID(string originalClassID)
        {
            string query = "SELECT * FROM MakeupClasses WHERE OriginalClassID = @OriginalClassID";
            SqlParameter[] parameters = { new SqlParameter("@OriginalClassID", originalClassID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<MakeupClassDTO> makeupClasses = new List<MakeupClassDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                makeupClasses.Add(new MakeupClassDTO
                {
                    MakeupClassID = row["MakeupClassID"].ToString(),
                    OriginalClassID = row["OriginalClassID"].ToString(),
                    RoomID = row["RoomID"].ToString(),
                    LecturerID = row["LecturerID"].ToString(),
                    MakeupDate = Convert.ToDateTime(row["MakeupDate"]),
                    Session = row["Session"].ToString(),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return makeupClasses;
        }

        public MakeupClassDTO GetByID(string makeupClassID)
        {
            string query = "SELECT * FROM MakeupClasses WHERE MakeupClassID = @MakeupClassID";
            SqlParameter[] parameters = { new SqlParameter("@MakeupClassID", makeupClassID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new MakeupClassDTO
                {
                    MakeupClassID = row["MakeupClassID"].ToString(),
                    OriginalClassID = row["OriginalClassID"].ToString(),
                    RoomID = row["RoomID"].ToString(),
                    LecturerID = row["LecturerID"].ToString(),
                    MakeupDate = Convert.ToDateTime(row["MakeupDate"]),
                    Session = row["Session"].ToString(),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                };
            }

            return null;
        }

        public bool Insert(MakeupClassDTO makeupClass)
        {
            string query = @"INSERT INTO MakeupClasses 
                            (MakeupClassID, OriginalClassID, RoomID, LecturerID, MakeupDate, Session, Status, Notes, CreatedDate, UpdatedDate) 
                            VALUES 
                            (@MakeupClassID, @OriginalClassID, @RoomID, @LecturerID, @MakeupDate, @Session, @Status, @Notes, @CreatedDate, @UpdatedDate)";

            SqlParameter[] parameters = {
                new SqlParameter("@MakeupClassID", makeupClass.MakeupClassID),
                new SqlParameter("@OriginalClassID", makeupClass.OriginalClassID),
                new SqlParameter("@RoomID", makeupClass.RoomID),
                new SqlParameter("@LecturerID", makeupClass.LecturerID),
                new SqlParameter("@MakeupDate", makeupClass.MakeupDate),
                new SqlParameter("@Session", makeupClass.Session),
                new SqlParameter("@Status", makeupClass.Status),
                new SqlParameter("@Notes", makeupClass.Notes ?? (object)DBNull.Value),
                new SqlParameter("@CreatedDate", DateTime.Now),
                new SqlParameter("@UpdatedDate", DateTime.Now)
            };

            int result = DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool Update(MakeupClassDTO makeupClass)
        {
            string query = @"UPDATE MakeupClasses 
                            SET OriginalClassID = @OriginalClassID, 
                                RoomID = @RoomID, 
                                LecturerID = @LecturerID, 
                                MakeupDate = @MakeupDate, 
                                Session = @Session, 
                                Status = @Status, 
                                Notes = @Notes, 
                                UpdatedDate = @UpdatedDate 
                            WHERE MakeupClassID = @MakeupClassID";

            SqlParameter[] parameters = {
                new SqlParameter("@MakeupClassID", makeupClass.MakeupClassID),
                new SqlParameter("@OriginalClassID", makeupClass.OriginalClassID),
                new SqlParameter("@RoomID", makeupClass.RoomID),
                new SqlParameter("@LecturerID", makeupClass.LecturerID),
                new SqlParameter("@MakeupDate", makeupClass.MakeupDate),
                new SqlParameter("@Session", makeupClass.Session),
                new SqlParameter("@Status", makeupClass.Status),
                new SqlParameter("@Notes", makeupClass.Notes ?? (object)DBNull.Value),
                new SqlParameter("@UpdatedDate", DateTime.Now)
            };

            int result = DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool Delete(string makeupClassID)
        {
            string query = "DELETE FROM MakeupClasses WHERE MakeupClassID = @MakeupClassID";
            SqlParameter[] parameters = { new SqlParameter("@MakeupClassID", makeupClassID) };

            int result = DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}
