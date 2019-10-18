using Microsoft.AspNet.Identity.EntityFramework;

namespace MinneapolisMachines.App.Models.Accounts
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}