using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VBTracker.DTO;

namespace VBTracker.DAL
{
    public class RoomDAL
    {
        public List<RoomDTO> GetAll()
        {
            List<RoomDTO> rooms = new List<RoomDTO>();
            string query = "SELECT * FROM Rooms";

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                rooms.Add(new RoomDTO
                {
                    RoomID = row["RoomID"].ToString(),
                    RoomName = row["RoomName"].ToString()
                });
            }

            return rooms;
        }

        public RoomDTO GetById(string roomId)
        {
            string query = "SELECT * FROM Rooms WHERE RoomID = @RoomID";
            SqlParameter[] parameters = { new SqlParameter("@RoomID", roomId) };

            DataTable dataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new RoomDTO
                {
                    RoomID = row["RoomID"].ToString(),
                    RoomName = row["RoomName"].ToString()
                };
            }

            return null;
        }

        public bool Insert(RoomDTO room)
        {
            string query = "INSERT INTO Rooms (RoomID, RoomName) VALUES (@RoomID, @RoomName)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@RoomID", room.RoomID),
                new SqlParameter("@RoomName", room.RoomName)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(RoomDTO room)
        {
            string query = "UPDATE Rooms SET RoomName = @RoomName WHERE RoomID = @RoomID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@RoomID", room.RoomID),
                new SqlParameter("@RoomName", room.RoomName)
            };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(string roomId)
        {
            string query = "DELETE FROM Rooms WHERE RoomID = @RoomID";
            SqlParameter[] parameters = { new SqlParameter("@RoomID", roomId) };

            return DatabaseConnection.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
