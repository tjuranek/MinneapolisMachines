using System.Web;
using System.Web.Mvc;
using System.Linq;
using MinneapolisMachines.App.Models.Accounts;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace MinneapolisMachines.App.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login 
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(User model)
        { 
            using (var db = new AccountDbContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Email == model.Email);

                if (user != null && new PasswordHasher().VerifyHashedPassword(user.Password, model.Password) != PasswordVerificationResult.Failed)
                {
                    var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, db.Roles.FirstOrDefault(r => r.RoleId == user.RoleId).Name)
                    }, "ApplicationCookie");

                    var context = Request.GetOwinContext();
                    var authManager = context.Authentication;

                    authManager.SignIn(identity);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        // GET: Logout
        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(AccountViewModel model)
        {
            using (var db = new AccountDbContext())
            {
                db.Users.Add(new User()
                {
                    UserId = model.User.UserId,
                    RoleId = model.Role.RoleId,
                    FirstName = model.User.FirstName,
                    LastName = model.User.LastName,
                    Email = model.User.Email,
                    Password = new PasswordHasher().HashPassword(model.User.Password)
                });

                db.SaveChanges();
            }

            return RedirectToAction("Users");
        }
    }
}