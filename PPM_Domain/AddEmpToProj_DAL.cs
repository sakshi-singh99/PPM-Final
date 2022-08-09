using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PPM_Model;


namespace PPM_DAL
{
    public class AddEmpToProjDal
    {
        private static List<AddEmpToProjModel> _addEmpToProj { get; set; } = new List<AddEmpToProjModel>();
        public IEnumerable<AddEmpToProjModel> AddEmpToProjList
        {
            get { return _addEmpToProj; }
        }


        public string AddEmpToProj(AddEmpToProjModel addEmp)
        {
            _addEmpToProj.Add(addEmp);
            return "Successfully Added";
        }
        public void DelProj(int pId)
        {
            var searchProjectId = _addEmpToProj.FirstOrDefault(i => i.ProjectId == pId);
            _addEmpToProj.Remove(searchProjectId);
        }

        public void Delemp(int eId)
        {
            var searchProjectId = _addEmpToProj.FirstOrDefault(i => i.EmployeeId == eId);
            _addEmpToProj.Remove(searchProjectId);
        }
    }
}
