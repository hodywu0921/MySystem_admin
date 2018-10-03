using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySystem_admin.Models
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string GroupId { get; set; }
        public string FactoryId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string RoleId { get; set; }
        public string Email { get; set; }
    }
}