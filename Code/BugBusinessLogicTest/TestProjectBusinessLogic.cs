using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBugBusinessLogic
{
    [TestClass]
    public class TestProjectBusinessLogic
    {
        private ProjectBusinessLogic bugBusinessLogic;
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
        public void DeleteProjectNotFound()
        {
            string nameProjectToDelete = "Empty project";

            Assert.ThrowsException<NonexistentProjectException>(() => projectBusinessLogic.Delete(nameProjectToDelete));
        }

        [TestMethod]
        public void DeleteProject()
        {
            projectBusinessLogic.Projects = projects;
            string nameProjectToDelete = "Web API";
            projectBusinessLogic.Delete(nameProjectToDelete);

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
        public void GetAllProjects()
        {
            projectBusinessLogic.Projects = projects;

            Assert.IsTrue(projects.SequenceEqual(projectBusinessLogic.GetAll()));
        }

        [TestMethod]
        public void UpdateProjectNotFound()
        {
            string nameProjectToUpdate = "Nonexistent Project";

            Assert.ThrowsException<NonexistentProjectException>(() => projectBusinessLogic.Update(nameProjectToUpdate, project));
        }

        [TestMethod]
        public void UpdateProject()
        {
            projectBusinessLogic.Projects = projects;
            string nameProjectToUpdate = "Web API";

            Project projectModified = new Project()
            {
                Name = "Web API Mod",
                Testers = testers,
                Developers = developers,
                bugs = bugs
            };

            projectBusinessLogic.Update(nameProjectToUpdate, projectModified);

            Assert.AreNotEqual(project, projectModified);
        }
    }
}
