using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
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
        public void FilterBugsByStatus()
        {
            List<Bug> bugsExpected = new List<Bug>()
            {
                new Bug()
                {
                    Name = "bug1",
                    IsActive = true
                },
                new Bug()
                {
                    Name = "bug2",
                    IsActive = true
                },
            };

            bugManagerContext.Add(new Bug()
            {
                Name = "bug1",
                IsActive = true
            });
            bugManagerContext.Add(new Bug()
            {
                Name = "bug2",
                IsActive = true
            });
            bugManagerContext.SaveChanges();

            int idTester = 1;

            List<Bug> bugsResult = testerDataAccess.GetBugsByStatus(idTester, true);
            Assert.IsTrue(bugsExpected.SequenceEqual(bugsResult));
        }

        [TestMethod]
        public void FilterBugsByName()
        {
            List<Bug> bugsExpected = new List<Bug>()
            {
                new Bug()
                {
                    Name = "bug1",
                },
                new Bug()
                {
                    Name = "bug1",
                },
            };
            bugManagerContext.Add(new Bug()
            {
                Name = "bug1"
            });
            bugManagerContext.Add(new Bug()
            {
                Name = "bug1"
            });
            bugManagerContext.SaveChanges();

            int idTester = 1;

            List<Bug> bugsResult = testerDataAccess.GetBugsByName(idTester, "bug1");
            Assert.IsTrue(bugsExpected.SequenceEqual(bugsResult));
        }

        [TestMethod]
        public void FilterBugsByProject()
        {
            List<Bug> bugsExpected = new List<Bug>()
            {
                new Bug()
                {
                    ProjectId = 3,
                },
                new Bug()
                {
                    ProjectId = 3,
                },
            };

            bugManagerContext.Add(new Bug()
            {
                ProjectId = 3,

            });
            bugManagerContext.Add(new Bug()
            {
                ProjectId = 3,

            });
            bugManagerContext.SaveChanges();

            int idTester = 1;

            List<Bug> bugsResult = testerDataAccess.GetBugsByProject(idTester, 3);
            Assert.IsTrue(bugsExpected.SequenceEqual(bugsResult));
        }
    }
}
