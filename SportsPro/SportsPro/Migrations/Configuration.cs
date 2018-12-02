namespace SportsPro.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SportsPro.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SportsPro.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SportsPro.Models.ApplicationDbContext";
        }

        protected override void Seed(SportsPro.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // add admin role
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "admin" });

            if (!System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Launch();

            if (context == null)
            {
                Debug.WriteLine($"{context}");
            }
            else
            {
                Debug.WriteLine($"not null");
                Debug.WriteLine($"{context.Users}");
            }

            foreach (var item in context.Users)
            {
                Debug.WriteLine($"{item.UserName}");
            }

            // add initial admin to system (add new user and assign admin role)
            if (!context.Users.Any(u => u.UserName == "jreesep@mtsu.edu"))
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser { UserName = "jreesep@mtsu.edu", Email = "jreesep@mtsu.edu" };

                manager.Create(user, "P@ssw0rd");
                manager.AddToRole(user.Id, "admin");
            }

            // add tech role
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "technician" });

            // add initial tech to system (add new user and assign tech role)
            if (!context.Users.Any(u => u.UserName == "jperry@mtsu.edu"))
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser { UserName = "jperry@mtsu.edu", Email = "jperry@mtsu.edu" };

                manager.Create(user, "Techn1ci@n");
                manager.AddToRole(user.Id, "technician");
            }
        }
    }
}
