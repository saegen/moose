namespace WebSite.Migrations
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebSite.DataModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebSite.DataModel context)
        {
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        //public static void InitializeIdentityForEF(DataModelContext db)
        //{
            
        //    var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
        //    const string name = "admin@example.com";
        //    const string password = "Admin@123456";
        //    //const string adminRole = "Admin";
        //    //Inniterar databasen med Rollerna från Common.UserRole. OBS! Initierar med Namnet ej värdet
        //    foreach (var roleField in typeof(UserRole).GetFields(BindingFlags.Public | BindingFlags.Static))
        //    {
        //        var roleName = roleField.GetValue(null).ToString();
        //        var role = roleManager.FindByName(roleName);
        //        if (role == null)
        //        {
        //            role = new IdentityRole(roleName);
        //            var roleresult = roleManager.Create(role);
        //        }
        //    }
        //    //Orginal
        //    //Create Role Admin if it does not exist
        //    //var role = roleManager.FindByName(roleName);
        //    //if (role == null) {
        //    //    role = new IdentityRole(roleName);
        //    //    var roleresult = roleManager.Create(role);
        //    //}


        //    var user = userManager.FindByName(name);
        //    if (user == null)
        //    {
        //        user = new DataLibUser { UserName = name, Email = name };
        //        var result = userManager.Create(user, password);
        //        result = userManager.SetLockoutEnabled(user.Id, false);
        //    }

        //    // Add user admin to Role Admin if not already added
        //    var rolesForUser = userManager.GetRoles(user.Id);
        //    if (!rolesForUser.Contains(UserRole.Admin))
        //    {
        //        var result = userManager.AddToRole(user.Id, UserRole.Admin);
        //    }
        //}
    }
}
