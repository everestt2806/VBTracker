using System;

namespace VBTracker.DTO
{
    public class AbsenceRequestDTO
    {
        public string RequestID { get; set; }
        public string StudentID { get; set; }
        public string ScheduleID { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime AbsenceDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public string ApproverID { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
