using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_Model
{
   public class MapModel
    {
        public MapModel()
        {
        }

        public MapModel(int projectId, string projectName,
    DateTime projectStartDate, DateTime projectEndDate, int empId, string empFirstName, string empLastName, string empEmail, string empMobile, string empAddress, string empRoleId, int roleId, string roleName)
        {
            ProjectId = projectId;
            ProjectName = projectName;
            ProjectStartDate = projectStartDate;
            ProjectEndDate = projectEndDate;
            EmpId = empId;
            EmpFirstName = empFirstName;
            EmpLastName = empLastName;
            EmpEmail = empEmail;
            EmpMobile = empMobile;
            EmpAddress = empAddress;
            EmpRoleId = empRoleId;
            RoleId = roleId;
            RoleName = roleName;

        }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpEmail { get; set; }
        public string EmpAddress { get; set; }
        public string EmpMobile { get; set; }
        public string EmpRoleId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
