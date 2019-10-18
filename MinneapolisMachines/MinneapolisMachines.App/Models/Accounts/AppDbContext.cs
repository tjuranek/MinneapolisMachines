using Microsoft.AspNet.Identity.EntityFramework;

namespace MinneapolisMachines.App.Models.Accounts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() : base("name=dbConnection") { }
    }
}