using PPM_Model;
using System.Data.Entity;
using PPM.Contracts;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PPM_EntityFrameWork
{

    public class RoleList : IRoleOperation
    {
        //Add
        public string AddRole(RoleModel role)
        {
            using (var db = new AppDbContextEntities())
            {
                var roles = new RoleModel
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                };
                db.Roles.Add(roles);
                db.SaveChanges();
            }
            return "Added Successfully";
        }


        //List All
        public IEnumerable<RoleModel> ListAll()
        {
            using (var db = new AppDbContextEntities())
            {
                var roles = new List<RoleModel>();
                var allRoles = db.Roles.ToList();
                if (allRoles?.Any() == true)
                {
                    foreach (var role in allRoles)
                    {
                        roles.Add(new RoleModel()
                        {
                            RoleId = role.RoleId,
                            RoleName = role.RoleName,
                        });
                    }
                }
                return roles;
            }
        }

        //List By ID
        public RoleModel ListByRid(int rId)
        {
            using (var db = new AppDbContextEntities())
            {
                var roles = new List<RoleModel>();
                var role = db.Roles.Where(s => s.RoleId == rId).FirstOrDefault<RoleModel>();
                if (role != null)
                {
                    roles.Add(new RoleModel()
                    {
                        RoleId = role.RoleId,
                        RoleName = role.RoleName,
                    });
                }
                return role;
            }
        }

        public string[] ListByRname(string rName)
        {
            using (var db = new AppDbContextEntities())
            {
                //var roles = new List<RoleModel>();
                //var role = db.Roles.Where(s => s.RoleName == rName).FirstOrDefault<RoleModel>();
                //if (role != null)
                //{
                //    roles.Add(new RoleModel()
                //    { 
                //        RoleId = role.RoleId,
                //        RoleName = role.RoleName,
                //        RoleEmail = role.RoleEmail,
                //        RolePassword = role.RolePassword
                //    });
                //}
                //return role;
                var result = (from role in db.Roles where role.RoleName == rName select role.RoleName).ToArray();
                return result;
            }

        }

        //Delete by ID
        public void DeleteByRid(int rId)
        {
            using (var db = new AppDbContextEntities())
            {
                var role = db.Roles.Where(s => s.RoleId == rId).FirstOrDefault<RoleModel>();
                db.Roles.Remove(role);
                db.SaveChanges();
            }
        }

        public void UpdateRole(RoleModel model)
        {
            using (var db = new AppDbContextEntities())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        //public RoleModel AutherizeRole(RoleModel model)
        //{
        //    using (var db = new AppDbContextEntities())
        //    {
        //        var userDetail = db.Roles.Where(x => x.RoleEmail == model.RoleEmail && 
        //        x.RolePassword == model.RolePassword).FirstOrDefault();
        //        return userDetail;
        //    }
        //}

        public IEnumerable<RoleModel> List()
        {
            using (var db = new AppDbContextEntities())
            {
                List<RoleModel> r = db.Roles.ToList();

                return r;
            }
        }
    }
}
