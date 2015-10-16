using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLib;

namespace UnitTestProject
{
    [TestClass]
    public class DALTest
    {
        private string toStore = "contentToSave";
        string elementId = "htmlId";

        [TestInitialize]
        public void Initialize()
        {
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
            Assert.AreEqual(DAL.getContent(elementId),update);
        }
    }
}
