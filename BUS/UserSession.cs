using System;

namespace VBTracker.BUS
{
    public class UserSession
    {
        private static UserSession _instance;
        private static readonly object _lock = new object();

        public string UserID { get; private set; }
        public string Username { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; } // "Student" hoặc "Lecturer"
        public bool IsLoggedIn { get; private set; }
        public DateTime LoginTime { get; private set; }

        private UserSession() { }
        public static UserSession CurrentUser => Instance;

        public static UserSession Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserSession();
                        }
                    }
                }
                return _instance;
            }
        }

        public void CreateSession(string userID, string username, string fullName, string email, string role)
        {
            UserID = userID;
            Username = username;
            FullName = fullName;
            Email = email;
            Role = role;
            IsLoggedIn = true;
            LoginTime = DateTime.Now;
        }

        public void ClearSession()
        {
            UserID = null;
            Username = null;
            FullName = null;
            Email = null;
            Role = null;
            IsLoggedIn = false;
            LoginTime = DateTime.MinValue;
        }

        public bool IsStudent()
        {
            return Role == "Student";
        }

        public bool IsLecturer()
        {
            return Role == "Lecturer";
        }
    }
}
