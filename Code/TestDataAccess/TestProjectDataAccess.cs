using System.Collections.Generic;
using System.Linq;

namespace TestDataAccess
{
    class TestProjectDataAccess
    {

        private readonly DbConnection connection;
        private readonly ProjectDataAccess projectDataAccess;
        private readonly ProjectManagerContext projectManagerContext;
        private readonly DbContextOptions<ProjectManagerContext> contextOptions;

        public TestProjectDataAccess()
        {
            connection = new SqliteConnection("Filename=:memory:");
            contextOptions = new DbContextOptionsBuilder<ProjectManagerContext>().UseSqlite(connection).Options;
            projectManagerContext = new ProjectManagerContext(contextOptions);
            projectDataAccess = new ProjectDataAccess(projectsManagerContext);
        }

        [TestInitialize]
        public void Setup()
        {
            connection.Open();
            projectManagerContext.Database.EnsureCreated();
        }

        [TestCleanup]
        public void CleanUp()
        {
            projectManagerContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAll()
        {
            var projectsExpected = new List<Project>
            {
                new Project
                {
                    Id = 0,
                    Name = "a"
                }
             };
            proejectManagerContext.Add(new Project
            {
                Id = 0,
                Name = "a"
            });
            projectManagerContext.SaveChanges();
            List<Project> projectDataBase = projectDataAccess.GetAll().ToList();

            Assert.AreEqual(1, projectDataBase.Count);
            CollectionAssert.AreEqual(projectExpected, projectDataBase, new ProjectComparer());
        }

        [TestMethod]
        public void Update()
        {
            Project project = proejectDataAccess.Create(new Project
            {
                Id = 1,
                Name = "b"
            });

            var projectUpdated = new Project
            {
                Id = 1,
                Name = "a"
            };

            projectDataAccess.Update(project.Id, projectUpdated);

            var projectSaved = projectDataAccess.GetById(1);

            Assert.AreEqual(0, new ProjectComparer().Compare(projectUpdated, projectSaved));

        }

        [TestMethod]
        public void Create()
        {
            Project expectedProject = new Project()
            {
                Id = 1,
                Name = "project1"
            };

            projectDataAccess.Create(new Project()
            {
                Id = 1,
                Name = "Error"
            });

            var projectSaved = projectDataAccess.GetById(1);
            Assert.AreEqual(0, new ProjectComparer().Compare(expectedProject, projectSaved));

        }

        [TestMethod]
        public void Delete()
        {
            Project notExpectedProject = new Project()
            {
                Id = 1,
                Name = "NotAProject"
            };
            projectDataAccess.Create(notExpectedProject);
            projectDataAccess.Delete(notExpectedProject.Id);
            var projectsSaved = projectDataAccess.GetAll().ToList();

            CollectionAssert.DoesNotContain(projectsSaved, notExpectedProject);

        }
    }
}
