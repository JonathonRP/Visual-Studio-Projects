namespace MGO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using MGO.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Diagnostics;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private readonly string[] roles = Enum.GetNames(typeof(MGORoles));

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MGO.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            foreach (var role in roles)
            {
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = role });
            }

            if (!context.Users.Any(u => u.UserName == "manager1@mountaingoatoutfitters.com"))
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                var user = new MGOManager()
                {
                    UserName = "manager1@mountaingoatoutfitters.com",
                    Email = "manager1@mountaingoatoutfitters.com"
                };

                manager.Create(user, "#1Manager!");
                manager.AddToRole(user.Id, user.Role);
            }
        }
    }
}
