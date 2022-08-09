using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PPM_Model;
using PPM_EntityFrameWork;

namespace PPM_Domain
{
    public class RoleDomain
    {
        RoleList objrole = new RoleList();
        EmployeeList objemp = new EmployeeList();



        //Add Role
        public string AddRoles(RoleModel role)
        {
            Regex regexRId = new Regex(@"^([1-9][0-9]{0,3})$");
            Regex regexRname = new Regex("^[A-Z][a-zA-Z ]*$");
            if (!regexRname.Match(role.RoleName).Success)
            {
                throw new System.Exception("Invalid Name !!");
            }
            if (objrole.ListAll().Any(p => p.RoleName == role.RoleName))
            {
                throw new System.Exception("Role Allready exist");
            }
            else
            {
                objrole.AddRole(role);
                return("Successfully Added....");
            }
        }

        //List All
        public IEnumerable<RoleModel> ListAll()
        {
            return objrole.ListAll();
        }

        //List By Id
        public RoleModel ListByRoleid(int rId)
        {
            return objrole.ListByRid(rId);
        }

        public string[] ListByRoleName(string rName)
        {
            return objrole.ListByRname(rName);
        }


        //Delete
        public string DeleteByRoleid(int rId)
        {
            var role = objrole.ListByRid(rId);
            if (role == null)
            {
                return("Role does not exist");
            }
            else if (objemp.GetEmployeesByRole(rId).Count() > 0)
            {
                return("Remove dependencies before deleting role");
            }
            else
            {
                objrole.DeleteByRid(rId);
                return "Role Deleted successfully";
            }
        }

        public void UpdateRole(RoleModel model)
        {
            objrole.UpdateRole(model);
        }

        //public RoleModel AutherizeRoles(RoleModel model)
        //{
        //    return objrole.AutherizeRole(model);
        //}

        public IEnumerable<RoleModel> Listrole()
        {
            return objrole.List();
        }
    }
}
