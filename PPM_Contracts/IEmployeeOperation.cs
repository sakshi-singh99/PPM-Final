using System.Collections.Generic;
using PPM_Model;

namespace PPM.Contracts
{
    public interface IEmployeeOperation
    {
        string AddEmployee(EmployeeModel employee);
        EmployeeModel ListByEid(int eId);
        void DeleteByEid(int eId);
        IEnumerable<EmployeeModel> ListAll();
    }
}
