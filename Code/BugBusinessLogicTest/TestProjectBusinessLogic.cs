using BusinessLogic;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TestProjectBusinessLogic
{
    [TestClass]
    public class TestProjectBusinessLogic
    {
        private ProjectBusinessLogic projectBusinessLogic;
        private List<Project> projects;
        private Project project;

        private List<Tester> testers;
        private List<Developer> developers;
        private List<Bug> bugs;


        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            projectBusinessLogic = new ProjectBusinessLogic();

            project = new Project()
            {
                ID = 0,
                Name = "Web API"
            };

            projects = new List<Project>()
            {
                project
            };

            bugs = new List<Bug>();
            testers = new List<Tester>();
            developers = new List<Developer>();

        }


        [TestMethod]
        public void CreateProject()
        {
            projectBusinessLogic.Add(project);
            projects.Add(project);

            Assert.IsTrue(projects.SequenceEqual(projectBusinessLogic.Projects));
        }

        [TestMethod]
        public void DeleteProjectByNameNotFound()
        {
            string nameProjectToDelete = "Empty project";

            Assert.ThrowsException<NonexistentProjectException>(() => projectBusinessLogic.DeleteByName(nameProjectToDelete));
        }

        [TestMethod]
        public void DeleteProjectByName()
        {
            projectBusinessLogic.Projects = projects;
            string nameProjectToDelete = "Web API";
            projectBusinessLogic.DeleteByName(nameProjectToDelete);

            Assert.IsTrue(projects.SequenceEqual(projectBusinessLogic.Projects));
        }

        [TestMethod]
        public void DeleteProjectByIdNotFound()
        {
            int idProjectToDelete = 1;

            Assert.ThrowsException<NonexistentProjectException>(() => projectBusinessLogic.Delete(idProjectToDelete));
        }

        [TestMethod]
        public void DeleteProjectById()
        {
            projectBusinessLogic.Projects = projects;
            int idProjectToDelete = 0;
            projectBusinessLogic.Delete(idProjectToDelete);

            Assert.IsTrue(projects.SequenceEqual(projectBusinessLogic.Projects));
        }

        [TestMethod]
        public void GetByNameNotFound()
        {
            string nameProject = "No project";

            Assert.ThrowsException<NonexistentProjectException>(() => projectBusinessLogic.GetByName(nameProject));
        }

        [TestMethod]
        public void GetByName()
        {
            projectBusinessLogic.Add(project);
            string nameProject = "Web API";

            Assert.AreEqual(project, projectBusinessLogic.GetByName(nameProject));
        }

        [TestMethod]
        public void GetById()
        {
            projectBusinessLogic.Add(project);
            int idProject = 0;

            Assert.AreEqual(project, projectBusinessLogic.GetById(idProject));
        }

        [TestMethod]
        public void GetAllProjects()
        {
            projectBusinessLogic.Projects = projects;

            Assert.IsTrue(projects.SequenceEqual(projectBusinessLogic.GetAll()));
        }

        [TestMethod]
        public void UpdateProjectByNameNotFound()
        {
            string nameProjectToUpdate = "Nonexistent Project";

            Assert.ThrowsException<NonexistentProjectException>(() => projectBusinessLogic.UpdateByName(nameProjectToUpdate, project));
        }

        [TestMethod]
        public void UpdateProjectByName()
        {
            projectBusinessLogic.Projects = projects;
            string nameProjectToUpdate = "Web API";

            Project projectModified = new Project()
            {
                Name = "Web API Mod",
                Testers = testers,
                Developers = developers,
                Bugs = bugs
            };

            projectBusinessLogic.UpdateByName(nameProjectToUpdate, projectModified);

            Assert.AreNotEqual(project, projectModified);
        }

        [TestMethod]
        public void UpdateProjectByIdNotFound()
        {
            int idProjectToUpdate = 1;

            Assert.ThrowsException<NonexistentProjectException>(() => projectBusinessLogic.Update(idProjectToUpdate, project));
        }

        [TestMethod]
        public void UpdateProjectById()
        {
            projectBusinessLogic.Projects = projects;
            int idProjectToUpdate = 0;

            Project projectModified = new Project()
            {
                Name = "Web API Mod",
                Testers = testers,
                Developers = developers,
                Bugs = bugs
            };

            projectBusinessLogic.Update(idProjectToUpdate, projectModified);

            Assert.AreEqual(project, projectModified);
        }
    }
}
