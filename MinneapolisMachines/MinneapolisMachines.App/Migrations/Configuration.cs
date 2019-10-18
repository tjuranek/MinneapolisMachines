namespace MinneapolisMachines.App.Migrations
{
    using MinneapolisMachines.App.Models.Accounts;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.Accounts.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppDbContext context)
        {
            //context.Roles.AddOrUpdate(r => r.Name,
            //    new AppRole { Name = "Admin" },
            //    new AppRole { Name = "Sales" },
            //    new AppRole { Name = "Disabled" }
            //);

            //context.Users.AddOrUpdate(u => u.FirstName,
            //    new AppUser { FirstName = "Thomas", LastName = "Juranek", Email = "thomas@juranek.com" }
            //);
        }
    }
}
