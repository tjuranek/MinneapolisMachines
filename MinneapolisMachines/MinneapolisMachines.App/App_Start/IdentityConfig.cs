using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using MinneapolisMachines.App.Models.Accounts;
using Owin;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace MinneapolisMachines.App.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new AppDbContext());
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Accounts/Login")
            });
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            AppRoleManager RoleManager = serviceProvider.GetRequiredService<AppRoleManager>();
            AppUserManager UserManager = serviceProvider.GetRequiredService<AppUserManager>();

            string[] roleNames = { "Admin", "Sales", "Disabled" };
            IdentityResult roleResult;

            foreach (string role in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new AppRole(role));
                }
            }
        }
    }
}