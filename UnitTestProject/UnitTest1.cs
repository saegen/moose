using System;
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

            DAL.AddContent(elementId, toStore);

            Assert.AreEqual<string>(toStore, DAL.getContent(elementId));
        }

        [TestMethod]
        public void TestRolesExists()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                bool t = false;
                foreach (var appRole in db.Roles)
                {
                    t = true;
                }
                Assert.IsTrue(t, "Det finns inga Roler!");
            }

        }       

    }
}
