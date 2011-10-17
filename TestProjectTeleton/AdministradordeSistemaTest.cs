using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProjectTeleton
{
    
    
    /// <summary>
    ///This is a test class for AdministradordeSistemaTest and is intended
    ///to contain all AdministradordeSistemaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AdministradordeSistemaTest
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
        ///A test for crearPermiso
        ///</summary>
        [TestMethod()]
        public void crearPermisoTest()
        {
            AdministradordeSistema target = new AdministradordeSistema(); // TODO: Initialize to an appropriate value
            string name = "Codig";// TODO: Initialize to an appropriate value
            string description = "Nada"; // TODO: Initialize to an appropriate value
            bool flag=true;
            try
            {
                target.crearPermiso(name, description);
            }
            catch
            {
                flag=false;
            }
            Assert.IsTrue(flag);
        }

        /// <summary>
        ///A test for crearRol
        ///</summary>
        [TestMethod()]
        public void crearRolTest()
        {
            AdministradordeSistema target = new AdministradordeSistema(); // TODO: Initialize to an appropriate value
            string description = "Codigo a ver que onda"; // TODO: Initialize to an appropriate value
            List<string> licences = new List<string>(); // TODO: Initialize to an appropriate value
            licences.Add("Codigo");
            licences.Add("Codi");
            bool flag = true;
            try
            {
                target.crearRol(description, licences, 1);
            }
            catch (Exception)
            {
                flag = false;
            }
            Assert.IsTrue(flag);

        }

        /// <summary>
        ///A test for eliminarPermiso
        ///</summary>
        [TestMethod()]
        public void eliminarPermisoTest()
        {
            AdministradordeSistema target = new AdministradordeSistema(); // TODO: Initialize to an appropriate value
            string identity = "Test"; // TODO: Initialize to an appropriate value
            bool flag = true;
            try
            {
                target.eliminarPermiso(identity);
            }
            catch (Exception)
            {
                flag = false;
            }
            Assert.IsTrue(flag);

        }

        /// <summary>
        ///A test for eliminarRol
        ///</summary>
        [TestMethod()]
        public void eliminarRolTest()
        {
            AdministradordeSistema target = new AdministradordeSistema(); // TODO: Initialize to an appropriate value
            long identity = 18; // TODO: Initialize to an appropriate value
            bool flag=true;
            try
            {
                target.eliminarRol(identity);
            }
            catch (Exception)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }

        /// <summary>
        ///A test for editarRol
        ///</summary>
        [TestMethod()]
        public void editarRolTest()
        {
            AdministradordeSistema target = new AdministradordeSistema(); // TODO: Initialize to an appropriate value
            long identity = 18; // TODO: Initialize to an appropriate value
            string description = "Algo"; // TODO: Initialize to an appropriate value
            List<string> grants = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> revokes = new List<string>(); // TODO: Initialize to an appropriate value
            grants.Add("Codi");
            revokes.Add("otro1");
            bool flag = true;
            try
            {
                target.editarRol(identity, description, grants, revokes, 2);
            }
            catch(Exception)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }
    }
}
