using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace TestBugBusinessLogic
{
    [TestClass]
    public class TestBugBusinessLogic
    {
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
                bug1,
                bug2
            };
        }

        
        [TestMethod]
        public void CreateBug()
        {
            bug.AddBug(bug);

            List<Bug> bugs = new List<Bug>()
            { 
                bug
             };
            Assert.IsTrue(bugs.SequenceEqual(bug.Bugs));
        }

        [TestMethod]
        public void DeleteBug()
        {
            List<Bug> expectedBugs = new List<Bug>();
            expectedBugs.Add(bug2);

            bug.Bugs = bugs;
            int idbugToDelete = 1;
            bug.DeleteBug(idbugToDelete);

            Assert.IsTrue(expectedBugs.SequenceEqual(bug.Bugs));
        }

        public void GetById()
        {
            bug.Bugs = bugs;
            int idBug = 0;

            Assert.AreEqual(bug, bug.GetById(idBug));
        }


    }
}
