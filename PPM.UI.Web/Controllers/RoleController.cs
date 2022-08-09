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
    public class RoleController : Controller
    {
        // GET: Role
        AppDbContextEntities db = new AppDbContextEntities();
        RoleDomain obj = new RoleDomain();

        public ActionResult RoleDashboard()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("RoleLogin", "Role");
        }

        public ActionResult Reset()
        {
            ModelState.Clear();
            return RedirectToAction("RoleLogin", "Role");
        }

        //GET: Project
        [HttpGet]
        public ActionResult Role()
        {
            return View(new RoleModel());
        }

        //GET: Project
        [HttpGet]
        public ActionResult Autherize()
        {
            return View(new RoleModel());
        }

        [HttpPost]
        public ActionResult AddRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                obj.AddRoles(model);
                db.SaveChanges();
            }

            //var role = obj.Listrole();
            //ViewBag.RoleModel = new SelectList(role, "RoleId", "RoleName");

            ModelState.Clear();

            return View("RoleList", obj.ListAll());
        }

        public ActionResult RoleList()
        {
            var res = obj.ListAll();
            return View(res);
        }

        [HttpGet]
        public ActionResult GetRole(int id)
        {
            var res = obj.ListByRoleid(id);
            return View(res);
        }

        public ActionResult DeleteRole(int id)
        {
            obj.DeleteByRoleid(id);
            var list = obj.ListAll();
            return View("RoleList", list);
        }

        [HttpGet]
        public ActionResult EditRole(int id)
        {
            RoleModel r = db.Roles.Single(x => x.RoleId == id);
            return View(r);
        }

        [HttpPost]
        public ActionResult EditRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                obj.UpdateRole(model);
                ModelState.Clear();
                return View("RoleList", obj.ListAll());
            }
            else
            {
                return View("AddRole");
            }
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}