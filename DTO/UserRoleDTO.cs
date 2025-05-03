using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBTracker.DTO
{
    public class UserRoleDTO
    {
        public int UserRoleID { get; set; }
        public string UserID { get; set; } // Có thể là StudentID hoặc LecturerID
        public int RoleID { get; set; }

        // Constructor mặc định
        public UserRoleDTO() { }

        // Constructor có tham số
        public UserRoleDTO(int userRoleID, string userID, int roleID)
        {
            UserRoleID = userRoleID;
            UserID = userID;
            RoleID = roleID;
        }
    }

}
