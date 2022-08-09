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
            //Regex regexEfname = new Regex("^[A-Z][a-zA-Z ]*$");
            //Regex regexElname = new Regex("^[A-Z][a-zA-Z ]*$");
            //Regex regexEemail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            //Regex regexEmobile = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})");
            //Regex regexEaddress = new Regex(@"^[A-Z][a-zA-Z ]*$");
            //if (!regexEfname.Match(employee.EmpFirstName).Success)
            //{
            //    throw new System.Exception("Invalid First Name !!");
            //}
            //if (!regexElname.Match(employee.EmpLastName).Success)
            //{
            //    throw new System.Exception("Invalid Last Name !!");
            //}
            //if (!regexEemail.Match(employee.EmpEmail).Success)
            //{
            //    throw new System.Exception("Invalid Email Id !!");
            //}
            //if (!regexEmobile.Match(employee.EmpMobile).Success)
            //{
            //    throw new System.Exception("Invalid Mobile Number !!");
            //}
            //if (!regexEaddress.Match(employee.EmpAddress).Success)
            //{
            //    throw new System.Exception("Invalid Address !!");
            //}
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
