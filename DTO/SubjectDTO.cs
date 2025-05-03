namespace VBTracker.DTO
{
    public class SubjectDTO
    {
        public string SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }

        // Constructor mặc định
        public SubjectDTO() { }

        // Constructor có tham số
        public SubjectDTO(string subjectID, string subjectName, int credits)
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
            Credits = credits;
        }
    }
}
