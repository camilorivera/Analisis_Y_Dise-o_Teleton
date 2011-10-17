using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProjectTeleton
{
    
    
    /// <summary>
    ///This is a test class for LoginTest and is intended
    ///to contain all LoginTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LoginTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion




        /// <summary>
        ///A test for validateUser
        ///</summary>
        [TestMethod()]
        public void validateUserTest()
        {
            string userName = "Nelson"; // TODO: Initialize to an appropriate value
            string password = "nelson"; // TODO: Initialize to an appropriate value
            Login target = new Login(userName, password); // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.validateUser("Tegucigalpa");
            Assert.AreEqual(expected, actual);
            
        }
    }
}
