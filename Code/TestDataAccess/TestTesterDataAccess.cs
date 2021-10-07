using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using BusinessLogic;
using Domain;
using Domain.Utils;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;

namespace TestDataAccess
{
    [TestClass]
    public class TestTesterDataAccess
    {

        private readonly DbConnection connection;
        private readonly TesterDataAccess testerDataAccess;
        private readonly BugManagerContext bugManagerContext;
        private readonly DbContextOptions<BugManagerContext> contextOptions;

        public TestTesterDataAccess()
        {
            connection = new SqliteConnection("Filename=:memory:");
            contextOptions = new DbContextOptionsBuilder<BugManagerContext>().UseSqlite(connection).Options;
            bugManagerContext = new BugManagerContext(contextOptions);
            testerDataAccess = new TesterDataAccess(bugManagerContext);
        }

        [TestInitialize]
        public void Setup()
        {
            connection.Open();
            bugManagerContext.Database.EnsureCreated();
        }

        [TestCleanup]
        public void CleanUp()
        {
            bugManagerContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public void Create()
        {
            Developer expectedDev = new Developer
            {
                Username = "developerPedro",
                Name = "Pedro",
                Lastname = "López",
                Password = "fransico234",
                Email = "pedrooo2@hotmail.com"

            };

            Tester devSaved = testerDataAccess.Create(new Tester()
            {
                Username = "testerPedro",
                Name = "Pedro",
                Lastname = "López",
                Password = "fransico234",
                Email = "pedrooo2@hotmail.com"
            });

            Assert.AreEqual(0, new UserComparer().Compare(expectedDev, devSaved));

        }

        [TestMethod]
        public void CreateTesterNull()
        {
            Assert.ThrowsException<NonexistentUserException>(() => testerDataAccess.Create(null));
        }

        [TestMethod]
        public void FilterBugsByStatus()
        {

            List<Bug> bugsExpected = new List<Bug>()
            {
                new Bug()
                {
                    Id = 1,
                    Name = "bug1",
                    IsActive = true,
                    ProjectId = 23,
                },
                new Bug()
                {
                    Id = 2,
                    Name = "bug2",
                    IsActive = true,
                    ProjectId = 24,

                },
            };
            Project project1 = new Project()
            {
                Name = "project",
                Id = 23,

            };
            bugManagerContext.Add(project1);

            Project project2 = new Project()
            {
                Name = "project",
                Id = 24,

            };
            bugManagerContext.Add(project2);
            bugManagerContext.SaveChanges();

            bugManagerContext.Add(new Bug()
            {
                Id = 1,
                Name = "bug1",
                IsActive = true,
                ProjectId = 23,

            });
            bugManagerContext.Add(new Bug()
            {
                Id = 2,
                Name = "bug2",
                IsActive = true,
                ProjectId = 24,

            });
            bugManagerContext.SaveChanges();

            Tester tester = new Tester()
            {
                Id = 45,
                Name = "Agus",
                Username = "agustina",
                Projects = { project1, project2 }
            };

            bugManagerContext.Add(tester);
            bugManagerContext.SaveChanges();


            List<Bug> bugsResult = testerDataAccess.GetBugsByStatus(tester.Id, true);
            CollectionAssert.AreEqual(bugsExpected, bugsResult, new BugComparer());

        }

        [TestMethod]
        public void FilterBugsByName()
        {
            List<Bug> bugsExpected = new List<Bug>()
            {
                new Bug()
                {
                    Id = 1,
                    Name = "bug1",
                    ProjectId = 23,

                },
                new Bug()
                {
                    Id = 2,
                    Name = "bug1",
                    ProjectId = 24,

                },
            };
            Tester tester = new Tester()
            {
                Name = "Agus",
                Username = "agustina",
            };

            bugManagerContext.Add(tester);
            bugManagerContext.SaveChanges();
            bugManagerContext.Add(new Project()
            {
                Name = "project",
                Id = 23,
                Testers = new List<Tester>() { tester }
            });
            bugManagerContext.Add(new Project()
            {
                Name = "project",
                Id = 24,
                Testers = new List<Tester>() { tester }

            });
            bugManagerContext.SaveChanges();

            bugManagerContext.Add(new Bug()
            {
                Id = 1,
                Name = "bug1",
                ProjectId = 23,


            });
            bugManagerContext.Add(new Bug()
            {
                Id = 2,
                Name = "bug1",
                ProjectId = 24,

            });
            bugManagerContext.SaveChanges();


            List<Bug> bugsResult = testerDataAccess.GetBugsByName(tester.Id, "bug1");
            CollectionAssert.AreEqual(bugsExpected, bugsResult, new BugComparer());
        }

        [TestMethod]
        public void FilterBugsByProject()
        {
            List<Bug> bugsExpected = new List<Bug>()
            {
                new Bug()
                {
                    Id = 1,
                    Name = "bug3",
                    ProjectId = 23
                },
                new Bug()
                {
                    Id = 2,
                    Name = "bug4",
                    ProjectId = 23
                },
            };
            Tester tester = new Tester()
            {
                Name = "Agus",
                Username = "agustina",
            };

            bugManagerContext.Add(tester);
            bugManagerContext.SaveChanges();
            bugManagerContext.Add(new Project()
            {
                Name = "project",
                Id = 23,
                Testers = new List<Tester>() { tester }

            });
            bugManagerContext.SaveChanges();

            bugManagerContext.Add(new Bug()
            {
                Id = 1,
                Name = "bug3",
                ProjectId = 23

            });
            bugManagerContext.Add(new Bug()
            {
                Id = 2,
                Name = "bug4",
                ProjectId = 23

            });
            bugManagerContext.SaveChanges();


            List<Bug> bugsResult = testerDataAccess.GetBugsByProject(tester.Id, 23);
            CollectionAssert.AreEqual(bugsExpected, bugsResult, new BugComparer());
        }

    }
}
