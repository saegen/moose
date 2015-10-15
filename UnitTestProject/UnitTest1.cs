using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLib;

namespace UnitTestProject
{
    [TestClass]
    public class DALTest
    {
        [TestMethod]
        public void TestAddContent()
        {
            string toStore = "contentToSave";
            string elementId = "htmlId";

            DAL.addContent(elementId, toStore);

            Assert.AreEqual(toStore, DAL.getContent(elementId));

            try
            {
                DAL.addContent(elementId, toStore);
                Assert.Fail("Inget exception kastades ");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Id already exists", ae.Message);
            }
        }

        [TestMethod]
        public void TestUpdateContent()
        {
        }
    }
}
