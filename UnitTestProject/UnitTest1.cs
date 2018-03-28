﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLib;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Migrations;

namespace UnitTestProject
{
    [TestClass]
    public class DALTest
    {

        private ApplicationUser user = new ApplicationUser() { Email = "unit@test.se", UserName = "Mr UnitTest"};
        private IdentityRole[] roles = { new IdentityRole("Admin") , new IdentityRole("Tester"), new IdentityRole("TesterToDelete") };

        [TestMethod]
        public void TestAddRole()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                    //AddOrUpdate med avseende på namn. Tar man inte med funktionen så kastar den på samma sätt som Add
                    db.Roles.AddOrUpdate(r => r.Name, roles[0]);
                    db.Roles.AddOrUpdate(r => r.Name, roles[1]);
                    db.Roles.AddOrUpdate(r => r.Name, roles[2]);
                    db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAddUser()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //AddOrUpdate med avseende på namn. Tar man inte med funktionen så kastar den på samma sätt som Add
                db.Users.AddOrUpdate(u => u.UserName, user);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAddContent()
        {
            string toStore = "contentToSave";
            string elementId = "htmlId";

            DAL.addContent(elementId, toStore);

            Assert.AreEqual<string>(toStore, DAL.getContent(elementId));
        }

        [TestMethod]
        public void TestIdentityDB()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                bool t = false;
                foreach (var appRole in db.Roles)
                {
                    t = true;
                    Console.WriteLine("appRole: " + appRole.ToString());
                }
                Assert.IsTrue(t, "Det finns inga Roler!");
                t = false;
                foreach (var user in db.Users)
                {
                    t = true;
                    Console.WriteLine("UserName: " + user.UserName);
                    foreach (var role in user.Roles)
                    {
                        Console.WriteLine("UserRole" + role.ToString());
                    }
                }
                Assert.IsTrue(t, "Det finns inga Användare!");
            }

        }    
        //[TestMethod]
        //public async System.Threading.Tasks.Task TestUpdateContentAsync()
        //{
        //    RegisterViewModel model = new RegisterViewModel()
        //    {
        //        Email = "test@mail.com",
        //        Password = "pws",
        //        ConfirmPassword = "pws"
        //    };

        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        user.Roles.Add()
        //        db.Users.Add(user);
                
        //    }

        //    IdentitySample.Models

                
                
        //        var result = await UserManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        //            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        //            await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
        //            ViewBag.Link = callbackUrl;
        //            return View("DisplayEmail");
        //        }
        //    Assert.Fail("Blev inge bra nå");
            

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}
    }
}
