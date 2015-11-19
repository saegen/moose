﻿using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Reflection;
using WebSite.Common;

namespace WebSite.Models
{
    using DataLib;
    using DataLib.Models.Identity;
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<DataLibUser>
    {
        public ApplicationUserManager(IUserStore<DataLibUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<DataLibUser>(context.Get<DataModel>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<DataLibUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<DataLibUser>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<DataLibUser>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<DataLibUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }


    
    //public class ApplicationUserManager : UserManager<ApplicationUser>
    //{
    //    public ApplicationUserManager(IUserStore<ApplicationUser> store)
    //        : base(store)
    //    {
    //    }

    //    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
    //        IOwinContext context)
    //    {
    //        var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
    //        // Configure validation logic for usernames
    //        manager.UserValidator = new UserValidator<ApplicationUser>(manager)
    //        {
    //            AllowOnlyAlphanumericUserNames = false,
    //            RequireUniqueEmail = true
    //        };
    //        // Configure validation logic for passwords
    //        manager.PasswordValidator = new PasswordValidator
    //        {
    //            RequiredLength = 6,
    //            RequireNonLetterOrDigit = true,
    //            RequireDigit = true,
    //            RequireLowercase = true,
    //            RequireUppercase = true,
    //        };
    //        // Configure user lockout defaults
    //        manager.UserLockoutEnabledByDefault = true;
    //        manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //        manager.MaxFailedAccessAttemptsBeforeLockout = 5;
    //        // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
    //        // You can write your own provider and plug in here.
    //        manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser>
    //        {
    //            MessageFormat = "Your security code is: {0}"
    //        });
    //        manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
    //        {
    //            Subject = "SecurityCode",
    //            BodyFormat = "Your security code is {0}"
    //        });
    //        manager.EmailService = new EmailService();
    //        manager.SmsService = new SmsService();
    //        var dataProtectionProvider = options.DataProtectionProvider;
    //        if (dataProtectionProvider != null)
    //        {
    //            manager.UserTokenProvider =
    //                new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
    //        }
    //        return manager;
    //    }
    //}

    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole,string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<DataModel>()));
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }

    //// This is useful if you do not want to tear down the database each time you run the application.
    //// public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    //// This example shows you how to create a new database if the Model changes 
    ////  public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext> //Cannot drop moose because its in use
    //public class ApplicationDbInitializer : CreateDatabaseIfNotExists<DataModel> // DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    //{
    //    protected override void Seed(DataModel context) {

    //        InitializeIdentityForEF(context);
    //        base.Seed(context);
    //    }

    //    //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
    //    public static void InitializeIdentityForEF(DataModel db) {
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
    //        if (user == null) {
    //            user = new DataLibUser { UserName = name, Email = name };
    //            var result = userManager.Create(user, password);
    //            result = userManager.SetLockoutEnabled(user.Id, false);
    //        }

    //        // Add user admin to Role Admin if not already added
    //        var rolesForUser = userManager.GetRoles(user.Id);
    //        if (!rolesForUser.Contains(UserRole.Admin)) {
    //            var result = userManager.AddToRole(user.Id, UserRole.Admin);
    //        }
    //    }
    //}

    public class ApplicationSignInManager : SignInManager<DataLibUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) : 
            base(userManager, authenticationManager) { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(DataLibUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}