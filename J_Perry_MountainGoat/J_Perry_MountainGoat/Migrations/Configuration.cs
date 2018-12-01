namespace MGO.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using MGO.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Dynamic;

    internal sealed class Configuration : DbMigrationsConfiguration<MGO.Models.ApplicationDbContext>
    {
        private enum MGOroles
        {
            employee,
            manager
        }

        private string[] roles = Enum.GetNames(typeof(MGOroles));

        private class MGOManager
        {
            public string Email { get; }
            public string Password { get; }
            public string Role { get; }

            public MGOManager(string _email, string _password, MGOroles _role)
            {
                Email = _email;
                Password = _password;
                Role = Enum.GetName(typeof(MGOroles), _role);
            }
        }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MGO.Models.ApplicationDBContext";
        }

        protected override void Seed(MGO.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
            var newManager = new MGOManager("manager1@mountaingoatoutfitters.com", "#1Manager!", MGOroles.manager);

            foreach (var role in roles)
            {
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = role });
            }

            if (!context.Users.Any(u => u.UserName == newManager.Email))
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser
                {
                    UserName = newManager.Email,
                    Email = newManager.Email
                };

                manager.Create(user, newManager.Password);
                manager.AddToRole(user.Id, newManager.Role);
            }
        }
    }
}
