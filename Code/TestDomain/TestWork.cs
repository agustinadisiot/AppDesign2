using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain
{
    [TestClass]
    public class TestWork
    {
        private Work work;
        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            work = new Work()
            {
                Name = "Project",
            };
        }
        [TestMethod]
        public void NameGetSet()
        {
            work.Name = "Project1";
            string expected = "Project1";
            Assert.AreEqual(expected, project.Name);
        }

        [TestMethod]
        public void GetTestersEmpty()
        {
            List<Tester> expectedTesters = new List<Tester>();
            Assert.IsTrue(expectedTesters.SequenceEqual(project.Testers));
        }

        [TestMethod]
        public void GetSetTesters()
        {
            Tester tester = new Tester();
            List<Tester> expectedTesters = new List<Tester>();
            expectedTesters.Add(tester);
            project.Testers = expectedTesters;
            Assert.IsTrue(expectedTesters.SequenceEqual(project.Testers));
        }

        [TestMethod]
        public void GetDevelopersEmpty()
        {
            List<Developer> expectedDeveloper = new List<Developer>();
            Assert.IsTrue(expectedDeveloper.SequenceEqual(project.Developers));
        }

        [TestMethod]
        public void GetSetDevelopers()
        {
            Developer dev = new Developer();
            List<Developer> expectedDeveloper = new List<Developer>();
            expectedDeveloper.Add(dev);
            project.Developers = expectedDeveloper;
            Assert.IsTrue(expectedDeveloper.SequenceEqual(project.Developers));
        }

        [TestMethod]
        public void GetBugsEmpty()
        {
            List<Bug> expectedBugs = new List<Bug>();
            Assert.IsTrue(expectedBugs.SequenceEqual(project.Bugs));
        }

        [TestMethod]
        public void GetSetBugs()
        {
            Bug bug = new Bug();
            List<Bug> expectedBugs = new List<Bug>();
            expectedBugs.Add(bug);
            project.Bugs = expectedBugs;
            Assert.IsTrue(expectedBugs.SequenceEqual(project.Bugs));
        }

    }
}
