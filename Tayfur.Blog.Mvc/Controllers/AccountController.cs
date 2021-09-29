using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tayfur.Blog.Mvc.Services.Utility;
using Tayfur.Blog.Service.Abstract;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Mvc.Controllers
{
    /// <summary>
    /// This class manages the users of the application.
    /// </summary>
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAdminService adminService;
        public AccountController(IAdminService adminService)
        {
            this.adminService = adminService; 
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            //MyLogger.GetInstance().Info("Entering the login controller. Login method");

            if (ModelState.IsValid)
            {
                //BlogContext context = new BlogContext()

                //var admin = context.Admins.Where(user => user.Email.ToLower() ==
                //     model.Email.ToLower() && user.Password == model.Password).SingleOrDefault();

                var admin = adminService.LoginUser(model);

                    if (admin != null)
                    {
                        //Session.Add("UserName", admin.FirstName + " " + admin.LastName);
                        FormsAuthentication.SetAuthCookie(admin.Id.ToString(), false);
                        MyLogger.GetInstance().Info("Exit login controller. Login success!");
                        return RedirectToAction("Index", "Admin");
                    }
                    ModelState.AddModelError("", "hatalı e-posta ya da şifre girdiniz.");
                    MyLogger.GetInstance().Info("Exit login controller. Login failure!");
                    return View();
                
            }
            ModelState.AddModelError("", "hatalı e-posta ya da şifre girdiniz.");
            return View(model);

        }
        public ActionResult LogOut()
        {
            //session.remove("userid");
            //session.remove("username");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Account");
        }
    }
}