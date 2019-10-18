using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MinneapolisMachines.App.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinneapolisMachines.App.Controllers
{
    public class AccountController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUserViewModel userFormData)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            if (ModelState.IsValid)
            {
                userManager.Create(new AppUser()
                {
                    FirstName = userFormData.FirstName,
                    LastName = userFormData.LastName,
                    Email = userFormData.Email,
                    PasswordHash = userFormData.Password
                });

                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "Invalid");
            return View(userFormData);
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: Logout
        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Account");
        }
    }
}