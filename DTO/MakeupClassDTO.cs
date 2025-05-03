using System;

namespace VBTracker.DTO
{
    public class MakeupClassDTO
    {
        public string MakeupClassID { get; set; }
        public string OriginalClassID { get; set; }
        public string RoomID { get; set; }
        public string LecturerID { get; set; }
        public DateTime MakeupDate { get; set; }
        public string Session { get; set; } // Morning, Afternoon, Evening
        public string Status { get; set; } // Scheduled, Completed, Cancelled
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
