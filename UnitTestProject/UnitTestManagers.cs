using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using DataLib;
using DataLib.Models.Identity;


namespace UnitTestProject
{
    /// <summary>
    /// Summary description for UnitTestManagers
    /// </summary>
    [TestClass]
    public class UnitTestManagers
    {
        public UnitTestManagers()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private void StacKSEed(DataModel context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<DataLibUser>(context);
            var userManager = new UserManager<DataLibUser>(userStore);
            var user = new DataLibUser { UserName = "sallen" };

            userManager.Create(user, "password");
            roleManager.Create(new IdentityRole { Name = "admin" });
            userManager.AddToRole(user.Id, "admin");
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }
    }
}
