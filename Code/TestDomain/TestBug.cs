using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System.Collections.Generic;

namespace TestDomain
{
    [TestClass]
    public class TestBug
    {
        private Bug bug;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            bug = new Bug()
            {
                Name = "Bug1",
                Description = "Cuando el servidor se cierra y estoy en login se rompe",
                Version = "12.4.5"
            };
        }
        [TestMethod]
        public void NameGetSet()
        {
            bug.Name = "bug1";
            string expected = "bug1";
            Assert.AreEqual(expected, bug.Name);
        }

        [TestMethod]
        public void DescriptionGetSet()
        {
            bug.Description = "No se pudo hacer la conexion con el data access";
            string expected = "No se pudo hacer la conexion con el data access";
            Assert.AreEqual(expected, bug.Description);
        }

        [TestMethod]
        public void VersionGetSet()
        {
            bug.Version = "14.2.1";
            string expected = "14.2.1";
            Assert.AreEqual(expected, bug.Version);
        }


        [TestMethod]
        public void ProjectsGet()
        {
            List<Project> expectedProjects = new List<Project> {
                new Project()
            {
                Name = "Project1",
            },
                new Project()
            {
                Name = "Project2",
            }
        };
            bug.Projects = expectedProjects;
            var actualProjects = bug.Projects;
            // TODO hacer comparable de project
            CollectionAssert.AreEqual(expectedProjects, actualProjects);
        }

        [TestMethod]
        public void ProjectsGetEmtpy()
        {
            var actualProjects = bug.Projects;
            Assert.IsTrue(actualProjects.Count == 0);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        public void IdGetSet(int id)
        {
            bug.ID = id;
            int expected = id;
            Assert.AreEqual(expected, bug.ID);
        }

        [TestMethod]
        public void IsActive()
        {
            Assert.IsTrue(bug.IsActive);
        }

        [TestMethod]
        public void NullDeveloper()
        {
            Assert.IsNull(bug.CompletedBy);
        }

    }
}
