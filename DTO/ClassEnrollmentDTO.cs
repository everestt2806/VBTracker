using System;

namespace VBTracker.DTO
{
    public class ClassEnrollmentDTO
    {
        public string EnrollmentID { get; set; }
        public string StudentID { get; set; }
        public string ClassID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }
        public decimal? FinalGrade { get; set; }

        //Bảng liên kết
        public string StudentName { get; set; }
        public string ClassName { get; set; }
    }
}
