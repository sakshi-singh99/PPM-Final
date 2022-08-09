using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPM_Model;
using PPM_Domain;
using PPM_EntityFrameWork;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;

namespace PPM.UI.Web.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        AppDbContextEntities db = new AppDbContextEntities();
        ProjectDomain obj = new ProjectDomain();
        //GET: Project
        [HttpGet]
        public ActionResult Project()
        {
            return View(new ProjectModel());
        }

        [HttpPost]
        public ActionResult AddProject(ProjectModel model)
        {
            string status = null;
            if (ModelState.IsValid)
            {
                obj.AddProj(model);
                db.SaveChanges();
            }
            ModelState.Clear();
                return View("ProjectList", obj.ListAll());
       
        }

        public ActionResult ProjectList()
        {
            var res = obj.ListAll();
            return View(res);
        }

        [HttpGet]
        public ActionResult EditProject(int id)
        {
            ProjectModel p = db.Projects.Single(x => x.ProjectId == id);
            return View(p);
        }

        [HttpPost]
        public ActionResult EditProject(ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                obj.UpdateProj(model);
                ModelState.Clear();
                 return View("ProjectList", obj.ListAll());
            }
            else
            {
                return View("AddProject");
            }
        }
        public ActionResult DeleteProject(int id)
        {
            obj.DeleteByPid(id);
            var list = obj.ListAll();
            return View("ProjectList", list);
        }

        // GET: ProjectModels/Create
        public ActionResult Create()
        {
            return View();
        }

    }
}