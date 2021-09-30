using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestDomain
{
    [TestClass]
    public class TestProject
    {
        // private Project project;
        //private List<Tester> testers;
        //private List<Developer> developers;
        private List<Bug> bugs;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            project = new Project()
            {
                Name = "Project",
            };
        }
        [TestMethod]
        public void NameGetSet()
        {
            project.Name = "Project1";
            string expected = "Project1";
            Assert.AreEqual(expected, project.Name);
        }

        public void GetTestersEmpty()
        {
            List<Tester> expectedTesters = new List<Tester>();
            Assert.IsTrue(expectedTesters.SequenceEqual(project.Testers));
        }

        public void GetSetTesters()
        {
            Tester tester = new Tester();
            List<Tester> expectedTesters = new List<Tester>();
            expectedTesters.Add(tester);
            project.Testers = expectedTesters;
            Assert.IsTrue(expectedTesters.SequenceEqual(project.Testers));
        }

        public void GetDevelopersEmpty()
        {
            List<Developer> expectedDeveloper = new List<Developer>();
            Assert.IsTrue(expectedDeveloper.SequenceEqual(project.Developer));
        }

        public void GetSetDevelopers()
        {
            Developer dev = new Developer();
            List<Developer> expectedDeveloper = new List<Developer>();
            expectedDeveloper.Add(dev);
            project.Developer = expectedDeveloper;
            Assert.IsTrue(expectedDeveloper.SequenceEqual(project.Developer));
        }

        public void GetBugsEmpty()
        {
            Bug expectedBugs = new List<Bug>();
            Assert.IsTrue(expectedBugs.SequenceEqual(project.Bugs));
        }

        public void GetSetBugs()
        {
            Bug bug = new Bug();
            Bug expectedBugs = new List<Bug>();
            expectedBugs.Add(bug);
            project.Bugs = expectedBugs;
            Assert.IsTrue(expectedBugs.SequenceEqual(project.Bugs));
        }

    }
}
