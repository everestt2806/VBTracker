using System;

namespace VBTracker.DTO
{
    public class AttendanceDTO
    {
        public string AttendanceID { get; set; }
        public string StudentID { get; set; }
        public string ScheduleID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public DateTime UpdatedDate { get; set; }

        // Constructor mặc định
        public AttendanceDTO() { }

        // Constructor có tham số
        public AttendanceDTO(string attendanceID, string studentID, string scheduleID, DateTime attendanceDate,
                             string status, string notes, DateTime updatedDate)
        {
            AttendanceID = attendanceID;
            StudentID = studentID;
            ScheduleID = scheduleID;
            AttendanceDate = attendanceDate;
            Status = status;
            Notes = notes;
            UpdatedDate = updatedDate;
        }
    }

}
