namespace VBTracker.DTO
{
    public class RoomDTO
    {
        public string RoomID { get; set; }
        public string RoomName { get; set; }

        // Constructor mặc định
        public RoomDTO() { }

        // Constructor có tham số
        public RoomDTO(string roomID, string roomName)
        {
            RoomID = roomID;
            RoomName = roomName;
        }
    }
}
