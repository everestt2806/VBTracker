using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class ScheduleDAL
    {
        public List<ScheduleDTO> GetAll()
        {
            List<ScheduleDTO> schedules = new List<ScheduleDTO>();
            string query = "SELECT * FROM Schedules";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                schedules.Add(new ScheduleDTO
                {
                    ScheduleID = row["ScheduleID"].ToString(),
                    ClassID = row["ClassID"].ToString(),
                    RoomID = row["RoomID"].ToString(),
                    DayOfWeek = row["DayOfWeek"].ToString(),
                    Session = row["Session"].ToString(),
                    WeekStart = Convert.ToInt32(row["WeekStart"]),
                    WeekEnd = Convert.ToInt32(row["WeekEnd"])
                });
            }

            return schedules;
        }

        public ScheduleDTO GetScheduleByID(string scheduleId)
        {
            string query = "SELECT * FROM Schedules WHERE ScheduleID = @ScheduleID";
            SqlParameter[] parameters = { new SqlParameter("@ScheduleID", scheduleId) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new ScheduleDTO
                {
                    ScheduleID = row["ScheduleID"].ToString(),
                    ClassID = row["ClassID"].ToString(),
                    RoomID = row["RoomID"].ToString(),
                    DayOfWeek = row["DayOfWeek"].ToString(),
                    Session = row["Session"].ToString(),
                    WeekStart = Convert.ToInt32(row["WeekStart"]),
                    WeekEnd = Convert.ToInt32(row["WeekEnd"])
                };
            }

            return null;
        }
        public List<ScheduleDTO> GetSchedulesByClassID(string classID)
        {
            string query = "SELECT * FROM Schedules WHERE ClassID = @ClassID";
            SqlParameter[] parameters = { new SqlParameter("@ClassID", classID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<ScheduleDTO> schedules = new List<ScheduleDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                schedules.Add(new ScheduleDTO
                {
                    ScheduleID = row["ScheduleID"].ToString(),
                    ClassID = row["ClassID"].ToString(),
                    RoomID = row["RoomID"].ToString(),
                    DayOfWeek = row["DayOfWeek"].ToString(),
                    Session = row["Session"].ToString(),
                    WeekStart = Convert.ToInt32(row["WeekStart"]),
                    WeekEnd = Convert.ToInt32(row["WeekEnd"])
                });
            }

            return schedules;
        }

        public List<ScheduleDTO> GetSchedulesByRoomID(string roomID)
        {
            string query = "SELECT * FROM Schedules WHERE RoomID = @RoomID";
            SqlParameter[] parameters = { new SqlParameter("@RoomID", roomID) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            List<ScheduleDTO> schedules = new List<ScheduleDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                schedules.Add(new ScheduleDTO
                {
                    ScheduleID = row["ScheduleID"].ToString(),
                    ClassID = row["ClassID"].ToString(),
                    RoomID = row["RoomID"].ToString(),
                    DayOfWeek = row["DayOfWeek"].ToString(),
                    Session = row["Session"].ToString(),
                    WeekStart = Convert.ToInt32(row["WeekStart"]),
                    WeekEnd = Convert.ToInt32(row["WeekEnd"])
                });
            }

            return schedules;
        }


        public bool Insert(ScheduleDTO schedule)
        {
            string query = "INSERT INTO Schedules (ScheduleID, ClassID, RoomID, DayOfWeek, Session, WeekStart, WeekEnd) " +
                           "VALUES (@ScheduleID, @ClassID, @RoomID, @DayOfWeek, @Session, @WeekStart, @WeekEnd)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ScheduleID", schedule.ScheduleID),
                new SqlParameter("@ClassID", schedule.ClassID),
                new SqlParameter("@RoomID", schedule.RoomID),
                new SqlParameter("@DayOfWeek", schedule.DayOfWeek),
                new SqlParameter("@Session", schedule.Session),
                new SqlParameter("@WeekStart", schedule.WeekStart),
                new SqlParameter("@WeekEnd", schedule.WeekEnd)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(ScheduleDTO schedule)
        {
            string query = "UPDATE Schedules SET ClassID = @ClassID, RoomID = @RoomID, DayOfWeek = @DayOfWeek, " +
                           "Session = @Session, WeekStart = @WeekStart, WeekEnd = @WeekEnd WHERE ScheduleID = @ScheduleID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ScheduleID", schedule.ScheduleID),
                new SqlParameter("@ClassID", schedule.ClassID),
                new SqlParameter("@RoomID", schedule.RoomID),
                new SqlParameter("@DayOfWeek", schedule.DayOfWeek),
                new SqlParameter("@Session", schedule.Session),
                new SqlParameter("@WeekStart", schedule.WeekStart),
                new SqlParameter("@WeekEnd", schedule.WeekEnd)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(string scheduleId)
        {
            string query = "DELETE FROM Schedules WHERE ScheduleID = @ScheduleID";
            SqlParameter[] parameters = { new SqlParameter("@ScheduleID", scheduleId) };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
