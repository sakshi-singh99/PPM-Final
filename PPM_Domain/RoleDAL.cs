using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PPM_Model;
using PPM.Contracts;

namespace PPM_DAL
{
    public class RoleDal : IRoleOperation
    {
        private static List<RoleModel> _role { get; set; } = new List<RoleModel>();

        public IEnumerable <RoleModel> RoleList
        {
            get { return _role; }
        }


        //Add Role
        public string AddRole(RoleModel role)
        {
           // Regex regexRId = new Regex(@"^([1-9][0-9]{0,3})$");
            Regex regexRname = new Regex("^[A-Z][a-zA-Z ]*$");
            //if (!regexRId.Match(role.RoleId).Success)
            //{
            //    return "Invalid Id !!";      
            //}
            if (!regexRname.Match(role.RoleName).Success)
            {
                return "Invalid Name !!";
            }
            else
            {
                _role.Add(role);
                return "Successfully Added";
            }
        }

        //List By Id
        public RoleModel ListByRid(int rId)
        {
            var searchRoleId = _role.FirstOrDefault(i => i.RoleId == rId);
            return searchRoleId;
        }

        //Delete
        public void DeleteByRid(int rId)
        {
            EmployeeDal obj = new EmployeeDal();
            var searchRoleId = _role.FirstOrDefault(i => i.RoleId == rId);
            
                _role.Remove(searchRoleId);
                obj.DeleteByEid(rId);
            
        }


        public IEnumerable<RoleModel> ListAll()
        {
            return _role;
        }
    }
}

