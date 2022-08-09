using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PPM_EntityFrameWork;
using PPM_Model;


namespace PPM_Domain
{
    public class EmployeeDomain
    {
        EmployeeList objemp = new EmployeeList();
        AddEmpToProjList objMap = new AddEmpToProjList();
        public string AddEmp(EmployeeModel employee)
        {
            
            if (objemp.ListAll().Any(p => p.EmpEmail == employee.EmpEmail))
            {
                return("Employee Allready exist");
            }
            else
            {
                objemp.AddEmployee(employee);
                return "Sucessfully Added";
            }
        }

        //List By Id
        public EmployeeModel ListByEmpid(int eId)
        {
            return objemp.ListByEid(eId);
        }

        //Delete
        public void DeleteByEmpid(int eId)
        {
            var employee = objemp.ListByEid(eId);
            if (objMap.GetMappingInfo().Any(x => x.EmployeeId == eId))
            {
                //throw("Remove dependencies before deleting employee");
            }
            else if (employee == null)
            {
                //return("Employee does not exist");
            }
            else
            {
                objemp.DeleteByEid(eId);
            }
        }

        //List All
        public IEnumerable<EmployeeModel> ListAll()
        {
            return objemp.ListAll();
        }

        public void UpdateEmp(EmployeeModel model)
        {
            objemp.UpdateEmployee(model);
        }

        public EmployeeModel AutherizeEmployee(EmployeeModel model)
        {
           return objemp.AutherizeEmp(model);
        }

        public IEnumerable<EmployeeModel> ListEmp()
        {
            return objemp.List();
        }
    }
}
