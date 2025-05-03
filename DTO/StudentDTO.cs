using System;

namespace VBTracker.DTO
{
    public class StudentDTO
    {
        public string StudentID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Major { get; set; }
        public string Gender { get; set; }
        public string Hometown { get; set; }
        public DateTime DOB { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // Constructor mặc định
        public StudentDTO() { }

        // Constructor có tham số
        public StudentDTO(string studentID, string fullName, string email, string phoneNumber, string major,
                          string gender, string hometown, DateTime dob, string username, string password,
                          DateTime createdDate, DateTime updatedDate)
        {
            StudentID = studentID;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Major = major;
            Gender = gender;
            Hometown = hometown;
            DOB = dob;
            Username = username;
            Password = password;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }
    }

}
