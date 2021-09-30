using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System.Collections.Generic;
using System.Linq;

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
        private List<Bug> bugs1;
        private List<Bug> bugs2;
        private List<Bug> emptyBugs;


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
            bugs1 = new List<Bug>() {
                bug1
            };
            bugs2 = new List<Bug>() {
                bug2
            };
            emptyBugs = new List<Bug>();
        }

        
        [TestMethod]
        public void CreateBug()
        {
            BugBusinessLogic.AddBug(bug);

            Assert.IsTrue(bugs.SequenceEqual(BugBusinessLogic.Bugs));
        }

        [TestMethod]
        public void DeleteBugNotFound()
        {
            BugBusinessLogic.Bugs = emptyBugs;
            int idbugToDelete = 1;
            
            Assert.ThrowsException<ExceptionNonexistentBug>(() => BugBusinessLogic.DeleteBug(idbugToDelete));
        }

        [TestMethod]
        public void DeleteBug()
        {
            BugBusinessLogic.Bugs = bugs;
            int idbugToDelete = 0;
            BugBusinessLogic.DeleteBug(idbugToDelete);

            Assert.IsTrue(bugs.SequenceEqual(BugBusinessLogic.Bugs));
        }

        public void GetById()
        {
            int idBug = 0;

            Assert.AreEqual(bug, BugBusinessLogic.GetById(idBug));
        }

        public void GetAll()
        {
            BugBusinessLogic.Bugs = bugs;

            Assert.IsTrue(bugs.SequenceEqual(BugBusinessLogic.GetAll()));
        }

        public void UpdateBugNotFound()
        {
            int idbugToUpdate = 2;

            Assert.ThrowsException<ExceptionNonexistentBug>(() => BugBusinessLogic.UpdateBug(idbugToUpdate, bug1));
        }

        public void UpdateBug()
        {
            BugBusinessLogic.Bugs = bugs;
            int idbugToUpdate = 0;

            Bug bugModified = new Bug()
            {
                Name = "bugMod",
                Description = "No funciona el boton aceptar",
                Version = "12.2.2."
            };

            BugBusinessLogic.UpdateBug(idbugToUpdate, bugModified);

            Assert.AreEqual(bug, bugModified);
        }
    }
}
