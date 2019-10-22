using System.Data.Entity;

namespace MinneapolisMachines.App.Models.Accounts
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext () : base("dbConnection") { }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}