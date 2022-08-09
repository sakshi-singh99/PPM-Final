using System.Collections.Generic;
using System.Linq;
using PPM_Model;
using PPM.Contracts;

namespace PPM_DAL
{
    public class EmployeeDal : IEmployeeOperation
    {
        private static List<EmployeeModel> _employee { get; set; } = new List<EmployeeModel>();
        public IEnumerable<EmployeeModel> EmployeeList
        {
            get { return _employee; }
        }

        //Add Employee
        public string AddEmployee(EmployeeModel employee)
        {
                _employee.Add(employee);
                return "Sucessfully Added";
        }

        //List By Id
        public EmployeeModel ListByEid(int eId)
        {
            var searchEmployeeId = _employee.FirstOrDefault(i => i.EmpId == eId);
            return searchEmployeeId;
        }

        //Delete
        public void DeleteByEid(int eId)
        {
           // AddEmpToProjDal obj = new AddEmpToProjDal();
            var searchEmployeeId = _employee.FirstOrDefault(i => i.EmpId == eId);
                _employee.Remove(searchEmployeeId);
               // obj.Delemp(eId);
        }

        public IEnumerable<EmployeeModel> ListAll()
        {
            return _employee;
        }
    }
}
