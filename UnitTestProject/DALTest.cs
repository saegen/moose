using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSite.Controllers;
using DataLib.Models.Identity;
using DataLib;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class DALTest
    {
        private string toStore = "contentToSave";
        private string elementId = "htmlId";
        string adminUserId = "a5a27cee-df8c-438d-9b3b-66ddab5a5973";
        string testUserId; // = Guid.Empty.ToString();
        private DataLibUser testUser;
        private DAL testDAL = new DAL();


        [TestInitialize]
        public void Initialize()
        {
            testUser = new DataLibUser() { UserName= "testUserName", Email= "testUserName@email.com" };
            testUserId = testUser.Id;
            var testUserFromDB = testDAL.getUserByName(testUser.UserName);
            if (testUserFromDB != null)
            {
                testUserId = testUserFromDB.Id;
                testDAL.deleteUser(testUserId);
                Assert.IsNull(testDAL.getUser(testUserId));
            }
            deleteContent();
        }

        [TestCleanup]
        public void CleanUp()
        {
            deleteContent();
            var testUserFromDB = testDAL.getUserByName(testUser.UserName);
            if (testUserFromDB != null)
            {
                testDAL.deleteUser(testUserId);
                Assert.IsNull(testDAL.getUser(testUserId));
            }
        }

        private void deleteContent()
        {
            try
            {
                string content = testDAL.getContent(elementId);
                if (!string.IsNullOrWhiteSpace(content))
                {
                    testDAL.deleteContent(elementId);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void TestManagers()
        {
            DataModel context = DataModel.Create();
            Assert.IsNotNull(context);
            var roleStore = new RoleStore<DataLibRole>(context);
            Assert.IsNotNull(roleStore);
            var roleManager = new RoleManager<DataLibRole>(roleStore);
            Assert.IsNotNull(roleManager);
            //var aRole = roleManager.Roles.First();
            var userStore = new UserStore<DataLibUser>(context);
            Assert.IsNotNull(userStore);
            var userManager = new UserManager<DataLibUser>(userStore);
            Assert.IsNotNull(roleStore);
            var userMgrResult = userManager.Create(this.testUser, "password");

            if (!userMgrResult.Succeeded)
            {
                Assert.Fail("Failed to set up User for TestBase.");
            }

            var testUser = context.Users.Find(this.testUser.Id);

            if (testUser == null)
            {
                Assert.Fail("The User: " + testUser.UserName + " was not found in the database.");
            }

            try
            {
                var result = roleManager.Create(new DataLibRole { Name = "TestRole" });
                if (!result.Succeeded)
                {
                    Assert.Fail("Kunde inte skapa rollen: TestRole");
                }
                else
                {
                    userManager.AddToRole(testUser.Id, "TestRole");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("The User: " + testUser.UserName + " was not found in the database." + ex.Message );
            }
            
            

        }

        [TestMethod]
        public void TestAddContent()
        {

            testDAL.addContent(elementId, toStore);

            Assert.AreEqual(toStore, testDAL.getContent(elementId));

            try
            {
                testDAL.addContent(elementId, toStore);
                Assert.Fail("Inget exception kastades ");
            }
            catch (ArgumentException ae)
            {
                Assert.IsTrue(ae.Message.Contains("Id already exists"));
            }
        }

        [TestMethod]
        public void TestUpdateContent()
        {
            string update = "UpdatedContent";
            testDAL.addContent(elementId, toStore);
            Assert.AreEqual(testDAL.getContent(elementId), toStore);
            testDAL.updateContent(elementId, update);
            Assert.AreEqual(testDAL.getContent(elementId), update);
        }

        [TestMethod]
        public void getAdmin()
        {
            var stop = testUser;
            var admin = testDAL.getAdminUser(adminUserId);
            Assert.IsNotNull(admin);
        }

        [TestMethod]
        public void addUser()
        {
            try
            {
                testDAL.addUser(testUser);
            }
            catch (Exception ae)
            {
                Assert.IsTrue(ae.Message.Contains("User already exists"));
            }
            Assert.IsNotNull(testDAL.getUser(testUserId));
            testDAL.deleteUser(testUserId);
            Assert.IsNull(testDAL.getUser(testUserId));
        }

        [TestMethod]
        public void TestGetUsers()
        {
            string names = "";
            var users = testDAL.getUsers();
            foreach (var user in users)
            {
                
                names += user.UserName + " ";
                
            }
            Assert.IsFalse(string.IsNullOrEmpty(names));
        }

        [TestMethod]
        public void TestGetRoles()
        {
            string names = "";
            var roles = testDAL.getRoles();
            foreach (var role in roles)
            {

                names += role.Name + " ";

            }
            Assert.IsFalse(string.IsNullOrEmpty(names));
        }
    }
}