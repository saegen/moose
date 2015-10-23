using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLib;
using DataLib.Models.Identity;

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
                string content = DAL.getContent(elementId);
                if (!string.IsNullOrWhiteSpace(content))
                {
                    DAL.deleteContent(elementId);
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

            DAL.addContent(elementId, toStore);

            Assert.AreEqual(toStore, DAL.getContent(elementId));

            try
            {
                DAL.addContent(elementId, toStore);
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
            DAL.addContent(elementId, toStore);
            Assert.AreEqual(DAL.getContent(elementId), toStore);
            DAL.updateContent(elementId, update);
            Assert.AreEqual(DAL.getContent(elementId), update);
        }

        [TestMethod]
        public void getAdmin()
        {
            var stop = testUser;
            var admin = DAL.getAdminUser(adminUserId);
            Assert.IsNotNull(admin);
        }

        [TestMethod]
        public void addUser()
        {
            try
            {
                DAL.addUser(testUser);
            }
            catch (Exception ae)
            {
                Assert.IsTrue(ae.Message.Contains("User already exists"));
            }
            Assert.IsNotNull(DAL.getUser(testUserId));
            DAL.deleteUser(testUserId);
            Assert.IsNull(DAL.getUser(testUserId));
        }
    }
}
