using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSite.Controllers;
using DataLib.Models.Identity;
using DataLib;

namespace UnitTestProject
{
    [TestClass]
    public class DALTest
    {
        private string toStore = "contentToSave";
        private string elementId = "htmlId";
        string adminUserId = "a5a27cee-df8c-438d-9b3b-66ddab5a5973";
        string testUserId = Guid.Empty.ToString();
        private DataLibUser testUser;
        private DAL testDAL = new DAL();


        [TestInitialize]
        public void Initialize()
        {
            testUser = new DataLibUser("testUserName", testUserId);
            deleteContent();
        }

        [TestCleanup]
        public void CleanUp()
        {
            deleteContent();
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
    }
}
