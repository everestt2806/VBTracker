namespace VBTracker.DTO
{
    public class LecturerDTO
    {
        public string LecturerID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // Constructor mặc định
        public LecturerDTO() { }

        // Constructor có tham số
        public LecturerDTO(string lecturerID, string fullName, string email, string phoneNumber,
                           string username, string password, DateTime createdDate, DateTime updatedDate)
        {
            LecturerID = lecturerID;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Username = username;
            Password = password;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }
    }

}
