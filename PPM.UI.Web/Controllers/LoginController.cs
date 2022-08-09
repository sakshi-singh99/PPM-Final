using PPM.UI.Web.Models;
using PPM_Domain;
using PPM_EntityFrameWork;
using PPM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PPM.UI.Web.Controllers
{
    public class LoginController : Controller
    {
        EmployeeDomain obj = new EmployeeDomain();
        RoleDomain roleobj = new RoleDomain();

        // GET: Login
        public ActionResult Login()
        {
            return View(new EmployeeModel());
        }

        [HttpPost]
        public ActionResult Autherize(EmployeeModel model)
        {
            obj.AutherizeEmployee(model);
            if (obj.AutherizeEmployee(model) == null)
            {
                ViewBag.ErrorMessage = "Invalid Email or Password!";
                return View("Login", model);
                //return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.EmpEmail, false);
                HttpCookie cookie = new HttpCookie("UserInfo");
                cookie.Values.Add("EmpId", obj.AutherizeEmployee(model).EmpId.ToString());
                Response.Cookies.Add(cookie);
                HttpCookie cookiee = new HttpCookie("UserInfoo");
                //HttpCookie cookie2 = new HttpCookie("EmpRoleId", obj.AutherizeEmployee(model).EmpRoleId.ToString());
                cookiee.Values.Add("EmpRoleId", obj.AutherizeEmployee(model).EmpRoleId.ToString());
                Response.Cookies.Add(cookiee);
                return RedirectToAction("Dashboard", "Login");
            }
             
        }
        [Authorize]
        public ActionResult Dashboard()
        {
            CurrentUser currentUser = new CurrentUser();
            if(Request.Cookies["UserInfo"] != null)
            {
                string currentUserId = Request.Cookies["UserInfo"].Values.Get("EmpId");
                var emp = obj.ListByEmpid(Convert.ToInt32(currentUserId));
                string currentRoleId = Request.Cookies["UserInfoo"].Values.Get("EmpRoleId");
                var r = roleobj.ListByRoleid(Convert.ToInt32(currentRoleId));


                currentUser.Id = emp.EmpId.ToString();
                currentUser.FirstName = emp.EmpFirstName;
                currentUser.LastName = emp.EmpLastName;
                currentUser.Mobile = emp.EmpMobile;
                currentUser.Email = emp.EmpEmail;
                currentUser.Address = emp.EmpAddress;
                currentUser.RoleId = emp.EmpRoleId.ToString();
                currentUser.RoleName = r.RoleName;
            }
            else if (Request.Cookies["UserInfo"] == null) 
            {
                Logout();
            }

                return View(currentUser); 
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

        public ActionResult Reset()
        {
            ModelState.Clear();
            return RedirectToAction("Login", "Login");
        }

        //public ActionResult Ppm()
        //{
        //    return View();
        //}
    }
}