using PPM_Domain;
using PPM_EntityFrameWork;
using PPM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPM.UI.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        AppDbContextEntities db = new AppDbContextEntities();
        EmployeeDomain obj = new EmployeeDomain();
        RoleDomain objrole = new RoleDomain();


        [HttpGet]
        public ActionResult Employee()
        {
            var emplist = objrole.Listrole();
            ViewBag.EmployeeModel = new SelectList(emplist, "RoleId", "RoleName");
            return View(new EmployeeModel());
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                obj.AddEmp(model);
                obj.ListAll();
                db.SaveChanges();
            }
            ModelState.Clear();


            return View("EmployeeList", obj.ListAll());
        }


        public ActionResult EmployeeList()
        {
            var res = obj.ListAll();
            return View(res);
        }

        [HttpGet]
        public ActionResult GetEmployee(int id)
        {
            var res = obj.ListByEmpid(id);
            return View(res);
        }

        public ActionResult DeleteEmployee(int id)
        {
            obj.DeleteByEmpid(id);
            var list = obj.ListAll();
            return View("EmployeeList", list);
        }


        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            EmployeeModel e = db.Employees.Single(x => x.EmpId == id);
            var emplist = objrole.Listrole();
            ViewBag.EmployeeModel = new SelectList(emplist, "RoleId", "RoleName");
            return View(e);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                obj.UpdateEmp(model);

                ModelState.Clear();

                return View("EmployeeList", obj.ListAll());
            }
            else
            {
                return View("AddEmployee");
            }
        }
    }
}