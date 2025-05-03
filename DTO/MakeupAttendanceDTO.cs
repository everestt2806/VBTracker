using System;

namespace VBTracker.DTO
{
    public class MakeupAttendanceDTO
    {
        public string MakeupAttendanceID { get; set; }
        public string StudentID { get; set; }
        public string MakeupClassID { get; set; }
        public string Status { get; set; } // Present, Absent, Late
        public string Notes { get; set; }
        public DateTime AttendanceTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
