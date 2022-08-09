using System.Text.RegularExpressions;
using PPM_Model;
using PPM_EntityFrameWork;
using System.Linq;
using System.Collections.Generic;

namespace PPM_Domain
{
    public class AddEmpDomain
    {
        AddEmpToProjList objAdd = new AddEmpToProjList();
        
        public string AddEmpToProject(AddEmpToProjModel addEmp)
        {
            if (objAdd.ListAll().Any(p => p.ProjectId == addEmp.ProjectId && p.EmployeeId==addEmp.EmployeeId))
            {
                return("Mapping Allready exist");
            }
            else
            {
                objAdd.AddEmpToProj(addEmp);
                return "Successfully Added";
            }

        }

        //List All
        public IEnumerable<AddEmpToProjModel> ListAll()
        {
            return objAdd.ListAll();
        }

        //List By Id
        public AddEmpToProjModel ListByEmpid(int rId)
        {
            return objAdd.ListByempId(rId);
        }


        public IEnumerable<AddEmpToProjModel> ListEmp()
        {
            return objAdd.List();
        }

        public List<ProjEmpMap> GetProjectsByEmployee(int id)
        {
            return objAdd.GetEmployeeProjects(id);
        }
    }
}

