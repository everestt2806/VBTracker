namespace VBTracker.DTO
{
    public class ScheduleDTO
    {
        public string ScheduleID { get; set; }
        public string ClassID { get; set; }
        public string RoomID { get; set; }
        public string DayOfWeek { get; set; }
        public string Session { get; set; }
        public int WeekStart { get; set; }
        public int WeekEnd { get; set; }

        // Constructor mặc định
        public ScheduleDTO() { }

        // Constructor có tham số
        public ScheduleDTO(string scheduleID, string classID, string roomID, string dayOfWeek,
                           string session, int weekStart, int weekEnd)
        {
            ScheduleID = scheduleID;
            ClassID = classID;
            RoomID = roomID;
            DayOfWeek = dayOfWeek;
            Session = session;
            WeekStart = weekStart;
            WeekEnd = weekEnd;
        }
    }

}
