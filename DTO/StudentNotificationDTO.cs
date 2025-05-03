using System;

namespace VBTracker.DTO
{
    public class StudentNotificationDTO
    {
        public string ID { get; set; }
        public string NotificationID { get; set; }
        public string StudentID { get; set; }
        public bool ReadStatus { get; set; }
        public DateTime? ReadDate { get; set; }

        // Bảng liên kết
        public string NotificationTitle { get; set; }
        public string StudentName { get; set; }
    }
}
