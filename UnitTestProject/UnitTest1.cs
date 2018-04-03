using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLib;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class DALTest
    {

        private ApplicationUser user = new ApplicationUser() { Email = "unit@test.se", UserName = "Mr UnitTest"};
        private IdentityRole[] roles = { new IdentityRole("Admin") , new IdentityRole("Tester"), new IdentityRole("TesterToDelete") };

        [TestMethod]
        public async Task TestAddRole()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                foreach (var aRole in db.Roles)
                {
                    db.Roles.Remove(aRole);
                }
                db.SaveChanges();
                int count = await db.Roles.CountAsync();
                Assert.AreEqual(0, count,"Det var inte 0 roller i databasen");
                
                //AddOrUpdate med avseende på namn. Tar man inte med funktionen så kastar den på samma sätt som Add
                db.Roles.AddOrUpdate(r => r.Name, roles[0]);
                db.Roles.AddOrUpdate(r => r.Name, roles[1]);
                db.Roles.AddOrUpdate(r => r.Name, roles[2]);
                db.SaveChanges();
                count = await db.Roles.CountAsync();
                Assert.AreEqual(3, count, "Kunde inte lägga till 3 roller");

                    
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
