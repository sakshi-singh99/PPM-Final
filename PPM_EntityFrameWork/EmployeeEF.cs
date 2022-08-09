using PPM_Model;
using PPM.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace PPM_EntityFrameWork
{
    public class EmployeeList : IEmployeeOperation
    {
        //Add
        public string AddEmployee(EmployeeModel employee)
        {
            using (var db = new AppDbContextEntities())
            {
                var employees = new EmployeeModel
                {
                    EmpId = employee.EmpId,
                    EmpFirstName = employee.EmpFirstName,
                    EmpLastName = employee.EmpLastName,
                    EmpEmail = employee.EmpEmail,
                    EmpPassword = employee.EmpPassword,
                    EmpMobile = employee.EmpMobile,
                    EmpAddress = employee.EmpAddress,
                    EmpRoleId = employee.EmpRoleId

                };
                db.Employees.Add(employees);
                db.SaveChanges();
            }
            return "Added Successfully";
        }


        //List All
        public IEnumerable<EmployeeModel> ListAll()
        {
            using (var db = new AppDbContextEntities())
            {
                var employees = new List<EmployeeModel>();
                var allEmployees = db.Employees.ToList();
                if (allEmployees?.Any() == true)
                {
                    foreach (var employee in allEmployees)
                    {
                        employees.Add(new EmployeeModel()
                        {
                            EmpId = employee.EmpId,
                            EmpFirstName = employee.EmpFirstName,
                            EmpLastName = employee.EmpLastName,
                            EmpEmail = employee.EmpEmail,
                            EmpMobile = employee.EmpMobile,
                            EmpAddress = employee.EmpAddress,
                            EmpRoleId = employee.EmpRoleId

                        });
                    }
                }
                return employees;
            }
        }

        //List By ID
        public EmployeeModel ListByEid(int eId)
        {
            using (var db = new AppDbContextEntities())
            {
                var employees = new List<EmployeeModel>();
                var employee = db.Employees.Where(s => s.EmpId == eId).FirstOrDefault<EmployeeModel>();
                if (employee != null)
                {
                    employees.Add(new EmployeeModel()
                    {
                        EmpId = employee.EmpId,
                        EmpFirstName = employee.EmpFirstName,
                        EmpLastName = employee.EmpLastName,
                        EmpEmail = employee.EmpEmail,
                        EmpMobile = employee.EmpMobile,
                        EmpAddress = employee.EmpAddress,
                        EmpRoleId = employee.EmpRoleId,
                    });
                }
                return employee;
            }
        }

        //Delete by ID
        public void DeleteByEid(int eId)
        {
            using (var db = new AppDbContextEntities())
            {
                var employee = db.Employees.Where(s => s.EmpId == eId).FirstOrDefault<EmployeeModel>();
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }

        public List<EmployeeModel> GetEmployeesByRole(int roleId)
        {
            using (var db = new AppDbContextEntities())
            {
                return db.Employees.Where(x => x.EmpRoleId == roleId).ToList();
            }
        }

        public void UpdateEmployee(EmployeeModel model)
        {
            using (var db = new AppDbContextEntities())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public EmployeeModel AutherizeEmp(EmployeeModel model)
        {
            using(var db = new AppDbContextEntities())
            {
                var userDetail = db.Employees.Where(x => x.EmpEmail == model.EmpEmail && x.EmpPassword == model.EmpPassword).FirstOrDefault();
                //if (userDetail == null)
                //{
                //    throw new System.Exception("Wrong Credential");
                //}
                return userDetail;
            }
        }    
        public IEnumerable<EmployeeModel> List()
        {
            using(var db = new AppDbContextEntities())
            {
               List<EmployeeModel>r = db.Employees.ToList();
             
                return r;
            }
        }

    }
}

