using System;

namespace VBTracker.DTO
{
    public class GradeDTO
    {
        public string GradeID { get; set; }
        public string StudentID { get; set; }
        public string ClassID { get; set; }
        public string AssignmentType { get; set; }
        public decimal Score { get; set; }
        public decimal MaxScore { get; set; }
        public decimal Weight { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string GradedBy { get; set; }
        public DateTime? GradedDate { get; set; }
        public string Comments { get; set; }

        // Constructor mặc định
        public GradeDTO() { }

        // Constructor có tham số
        public GradeDTO(string gradeID, string studentID, string classID, string assignmentType, decimal score, decimal maxScore, decimal weight, DateTime? submissionDate, string gradedBy, DateTime? gradedDate, string comments)
        {
            GradeID = gradeID;
            StudentID = studentID;
            ClassID = classID;
            AssignmentType = assignmentType;
            Score = score;
            MaxScore = maxScore;
            Weight = weight;
            SubmissionDate = submissionDate;
            GradedBy = gradedBy;
            GradedDate = gradedDate;
            Comments = comments;
        }
    }
}
