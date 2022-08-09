using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPM.UI.Web.Models
{
    public class CurrentUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}