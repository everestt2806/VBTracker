using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBTracker.DTO
{
    public class RoleDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        // Constructor mặc định
        public RoleDTO() { }

        // Constructor có tham số
        public RoleDTO(int roleID, string roleName)
        {
            RoleID = roleID;
            RoleName = roleName;
        }
    }

}
