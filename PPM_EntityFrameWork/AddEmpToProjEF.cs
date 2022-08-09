using PPM_Contracts;
using PPM_Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PPM_EntityFrameWork
{
    public class AddEmpToProjList : IAddEmpToProjOperation
    {
        public IEnumerable<AddEmpToProjModel> AddEmpToProjectList => throw new NotImplementedException();

        public string AddEmpToProj(AddEmpToProjModel addEmpToProj)
        {
            using (var db = new AppDbContextEntities())
            {
                var addemp = new AddEmpToProjModel
                {
                    EmployeeId = addEmpToProj.EmployeeId,
                    ProjectId = addEmpToProj.ProjectId

                };
                db.AddEmp.Add(addemp);
                db.SaveChanges();
            }
            return "Added Successfully";
        }

        public IEnumerable<AddEmpToProjModel> ListAll()
        {
            using (var db = new AppDbContextEntities())
            {
                var map = new List<AddEmpToProjModel>();
                var allMap = db.AddEmp.ToList();
                if (allMap?.Any() == true)
                {
                    foreach (var maps in allMap)
                    {
                        map.Add(new AddEmpToProjModel()
                        {
                            ProjectId = maps.ProjectId,
                            EmployeeId = maps.EmployeeId
                        });
                    }
                }
                return map;
            }
        }

        //List By ID
        public AddEmpToProjModel ListByempId(int eId)
        {
            using (var db = new AppDbContextEntities())
            {
                var emp = new List<AddEmpToProjModel>();
                var role = db.AddEmp.Where(s => s.EmployeeId == eId).FirstOrDefault<AddEmpToProjModel>();
                if (role != null)
                {
                    emp.Add(new AddEmpToProjModel()
                    {
                        EmployeeId = role.EmployeeId,
                        ProjectId = role.ProjectId,
                    });
                }
                return role;
            }
        }

        public List<ProjEmpMap> GetEmployeeProjects(int id)
        {
            using (var db = new AppDbContextEntities())
            {
                var emp = db.Employees.First(x => x.EmpId == id);

                return db.Projects.Join(db.AddEmp
                    , x => x.ProjectId, y => y.ProjectId, (x, y) => new ProjEmpMap()
                    {
                        Id = y.Id,
                        ProjectId = x.ProjectId,
                        ProjectName = x.ProjectName,
                        ProjectStartDate = x.ProjectStartDate,
                        ProjectEndDate = x.ProjectEndDate,
                        EmployeeId = y.EmployeeId,
                        FirstName = emp.EmpFirstName,
                        LastName = emp.EmpLastName,
                        Email = emp.EmpEmail,
                        Address = emp.EmpAddress,
                        RoleId = emp.EmpRoleId,
                        Mobile = emp.EmpMobile
                    }).Where(x=>x.EmployeeId == id).ToList();
            }

        }

        public List<AddEmpToProjModel> GetMappingInfo()
        {
            using (var db = new AppDbContextEntities())
            {
                return db.AddEmp.ToList();
            }
        }
        public AddEmpToProjModel AutherizeMap(AddEmpToProjModel model)
        {
            using (var db = new AppDbContextEntities())
            {
                var userDetail = db.AddEmp.Where(x => x.EmployeeId == model.EmployeeId).FirstOrDefault();
                //if (userDetail == null)
                //{
                //    throw new System.Exception("Wrong Credential");
                //}
                return userDetail;
            }
        }

        public IEnumerable<AddEmpToProjModel> List()
        {
            using (var db = new AppDbContextEntities())
            {
                List<AddEmpToProjModel> r = db.AddEmp.ToList();

                return r;
            }
        }
    }
}
