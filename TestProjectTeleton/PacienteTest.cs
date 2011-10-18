using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProjectTeleton
{
    
    
    /// <summary>
    ///This is a test class for PacienteTest and is intended
    ///to contain all PacienteTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PacienteTest
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
        ///A test for guardarPaciente
        ///</summary>
        [TestMethod()]
        public void guardarPacienteTest()
        {
            Paciente target = new Paciente(); // TODO: Initialize to an appropriate value
            string nombres = "Vicente";// string.Empty; // TODO: Initialize to an appropriate value
            string primerApellido = "Gonzales";// string.Empty; // TODO: Initialize to an appropriate value
            string segundoApellido = "Gonzales"; // TODO: Initialize to an appropriate value
            string fechaNac = "4/5/1987"; // TODO: Initialize to an appropriate value
            bool sexo = true; // TODO: Initialize to an appropriate value
            string fechaIngreso = "4/2/2010"; // TODO: Initialize to an appropriate value
            string cedula = "0501199823456"; // TODO: Initialize to an appropriate value
            string direccion = "Los Castaños"; // TODO: Initialize to an appropriate value
            string lugarNac = "San Pedro"; // TODO: Initialize to an appropriate value
            string estado = "Cortes"; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            //actual = target.guardarPaciente(nombres, primerApellido, segundoApellido, fechaNac, sexo, fechaIngreso, cedula, direccion, lugarNac, estado);
            //Assert.AreEqual(expected, actual);            
        }
    }
}
