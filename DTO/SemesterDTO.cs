namespace VBTracker.DTO
{
    public class SemesterDTO
    {
        public string SemesterID { get; set; }
        public string SemesterName { get; set; }

        // Constructor mặc định
        public SemesterDTO() { }

        // Constructor có tham số
        public SemesterDTO(string semesterID, string semesterName)
        {
            SemesterID = semesterID;
            SemesterName = semesterName;
        }
    }
}
