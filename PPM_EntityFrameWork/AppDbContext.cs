using PPM_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_EntityFrameWork
{
    public class AppDbContextEntities : DbContext
    { 
        public AppDbContextEntities() : base("conStr")
        {

        }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<AddEmpToProjModel> AddEmp { get; set; }

    }
}
