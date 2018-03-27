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

            Assert.AreEqual<string>(toStore, DAL.getContent(elementId));
        }

        [TestMethod]
        public void TestUpdateContent()
        {
            throw new NotImplementedException();
        }
    }
}
