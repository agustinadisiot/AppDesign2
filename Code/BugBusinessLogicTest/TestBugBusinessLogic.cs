using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;

namespace TestBugBusinessLogic
{
    [TestClass]
    public class TestBugBusinessLogic
    {
        private BugBusinessLogic bugBusinessLogic;
        private Bug bug;
        private Bug bug1;
        private Bug bug2;
        private List<Bug> bugs;


        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            bugBusinessLogic = new BugBusinessLogic();

            bug = new Bug()
            {
                ID = 0,
                Name = "Bug1",
                Description = "Cuando el servidor se cierra y estoy en login se rompe",
                Version = "12.4.5"
            };

            bug1 = new Bug() { ID = 1 };
            bug2 = new Bug() { ID = 2 };

            bugs = new List<Bug>() {
                bug
            };

        }

        
        [TestMethod]
        public void CreateBug()
        {
            bugBusinessLogic.Add(bug);

            Assert.IsTrue(bugs.SequenceEqual(bugBusinessLogic.Bugs));
        }

        [TestMethod]
        public void DeleteBugNotFound()
        {
            int idbugToDelete = 1;
            
            Assert.ThrowsException<NonexistentBugException>(() => bugBusinessLogic.Delete(idbugToDelete));
        }

        [TestMethod]
        public void DeleteBug()
        {
            bugBusinessLogic.Bugs = bugs;
            int idbugToDelete = 0;
            bugBusinessLogic.Delete(idbugToDelete);

            Assert.IsTrue(bugs.SequenceEqual(bugBusinessLogic.Bugs));
        }

        [TestMethod]
        public void GetById()
        {
            bugBusinessLogic.Add(bug);
            int idBug = 0;

            Assert.AreEqual(bug, bugBusinessLogic.GetById(idBug));
        }

        [TestMethod]
        public void GetAll()
        {
            bugBusinessLogic.Bugs = bugs;

            Assert.IsTrue(bugs.SequenceEqual(bugBusinessLogic.GetAll()));
        }

        [TestMethod]
        public void UpdateBugNotFound()
        {
            int idbugToUpdate = 2;

            Assert.ThrowsException<NonexistentBugException>(() =>  bugBusinessLogic.Update(idbugToUpdate, bug1));
        }

        [TestMethod]
        public void UpdateBug()
        {
            bugBusinessLogic.Bugs = bugs;
            int idbugToUpdate = 0;

            Bug bugModified = new Bug()
            {
                ID = 0,
                Name = "bugMod",
                Description = "No funciona el boton aceptar",
                Version = "12.2.2."
            };

            bugBusinessLogic.Update(idbugToUpdate, bugModified);

            Assert.AreEqual(bug, bugModified);
        }
    }
}
