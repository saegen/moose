namespace DataLib.Migrations
{
    using Models.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<DataLib.DataModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataLib.DataModel context)
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

        //private async void SeedUser(DataModel context)
        //{
        //    using (context)
        //    {
        //        var newUser = new DataLibUser() { UserName = "buzzlightyear@pixar.com", Email = "buzzlightyear@pixar.com" };

        //        var userManager = new UserManager<DataLibUser>(new UserStore<DataLibUser>(context));
        //        var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
        //        var result = await userManager.CreateAsync(newUser, "infinityandbeyond");


        //    }
        //}

        //private void StacKSEed(DataModel context)
        //{ 
        //    var roleStore = new RoleStore<IdentityRole>(context);
        //    var roleManager = new RoleManager<IdentityRole>(roleStore);
        //    var userStore = new UserStore<DataLibUser>(context);
        //    var userManager = new UserManager<DataLibUser>(userStore);
        //    var user = new DataLibUser { UserName = "sallen" };
            
        //    userManager.Create(user, "password");                    
        //    roleManager.Create(new IdentityRole { Name = "admin" });
        //    userManager.AddToRole(user.Id, "admin");
        //}
    }

    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes 
    //  public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext> //Cannot drop moose because its in use

    //public class ApplicationDbInitializer : CreateDatabaseIfNotExists<DataModel> // DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    //{
    //    protected override void Seed(DataModel context)
    //    {

    //        InitializeIdentityForEF(context);
    //        base.Seed(context);
    //    }

    //    //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
    //    public static void InitializeIdentityForEF(DataModel db)
    //    {
    //        var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
    //        var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
    //        const string name = "admin@example.com";
    //        const string password = "Admin@123456";
    //        //const string adminRole = "Admin";
    //        //Inniterar databasen med Rollerna från Common.UserRole. OBS! Initierar med Namnet ej värdet
    //        foreach (var roleField in typeof(UserRole).GetFields(BindingFlags.Public | BindingFlags.Static))
    //        {
    //            var roleName = roleField.GetValue(null).ToString();
    //            var role = roleManager.FindByName(roleName);
    //            if (role == null)
    //            {
    //                role = new IdentityRole(roleName);
    //                var roleresult = roleManager.Create(role);
    //            }
    //        }
    //        //Orginal
    //        //Create Role Admin if it does not exist
    //        //var role = roleManager.FindByName(roleName);
    //        //if (role == null) {
    //        //    role = new IdentityRole(roleName);
    //        //    var roleresult = roleManager.Create(role);
    //        //}


    //        var user = userManager.FindByName(name);
    //        if (user == null)
    //        {
    //            user = new DataLibUser { UserName = name, Email = name };
    //            var result = userManager.Create(user, password);
    //            result = userManager.SetLockoutEnabled(user.Id, false);
    //        }

    //        // Add user admin to Role Admin if not already added
    //        var rolesForUser = userManager.GetRoles(user.Id);
    //        if (!rolesForUser.Contains(UserRole.Admin))
    //        {
    //            var result = userManager.AddToRole(user.Id, UserRole.Admin);
    //        }
    //    }
    //}
}
