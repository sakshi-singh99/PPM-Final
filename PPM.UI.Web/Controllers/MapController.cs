using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPM_Model;
using PPM_Domain;
using PPM_EntityFrameWork;
using System.Web.Security;
using PPM.UI.Web.Models;

namespace PPM.UI.Web.Controllers
{
    [Authorize]
    public class MapController : Controller
    {
        AppDbContextEntities db = new AppDbContextEntities();
        AddEmpDomain obj = new AddEmpDomain();
        ProjectDomain objProj = new ProjectDomain();
        RoleDomain role = new RoleDomain();
        EmployeeDomain objEmp = new EmployeeDomain();

        // GET: Map

        [HttpGet]
        public ActionResult Map()
        {
            var emplist = objEmp.ListEmp();
            var projlist = objProj.ListEmp();
            ViewBag.Employee = new SelectList(emplist, "EmpId", "FullName");
            ViewBag.Project = new SelectList(projlist, "ProjectId", "ProjectName");
            return View(new AddEmpToProjModel());
        }

        [HttpPost]
        public ActionResult Add(AddEmpToProjModel model)
        {
            if (ModelState.IsValid)
            {
                obj.AddEmpToProject(model);
                db.SaveChanges();
            }
            ModelState.Clear();

            return View("List", obj.ListAll());
        }

        public ActionResult List()
        {
            var res = obj.ListAll();
            return View(res);
        }

        [Authorize]
        public ActionResult Dashboard()
        {
        
            if (Request.Cookies["UserInfo"] != null)
            {
                string currentUserId = Request.Cookies["UserInfo"].Values.Get("EmpId");
                
                List<ProjEmpMap> map = obj.GetProjectsByEmployee(Convert.ToInt32(currentUserId));
                if (map == null)
                {
                    ViewBag.Message = "No any project assigned yet ";
                }
                else
                {

                    return View(map);
                }
            }

            else if (Request.Cookies["UserInfo"] == null)
            {
                Logout();
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

    }
}