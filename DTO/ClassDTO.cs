namespace VBTracker.DTO
{
    public class ClassDTO
    {
        public string ClassID { get; set; }
        public string SubjectID { get; set; }
        public string SemesterID { get; set; }
        public string LecturerID { get; set; }
        public string ClassName { get; set; }
        public int MaxStudents { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // Constructor mặc định
        public ClassDTO() { }

        // Constructor có tham số
        public ClassDTO(string classID, string subjectID, string semesterID, string lecturerID,
                        string className, int maxStudents, string status, string description,
                        DateTime createdDate, DateTime updatedDate)
        {
            ClassID = classID;
            SubjectID = subjectID;
            SemesterID = semesterID;
            LecturerID = lecturerID;
            ClassName = className;
            MaxStudents = maxStudents;
            Status = status;
            Description = description;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }
    }

}
