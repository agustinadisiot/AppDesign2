using Domain;
using Domain.Utils;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataAccess
{
    [TestClass]
    public class TestWorkDataAccess
    {
        private readonly DbConnection connection;
        private readonly WorkDataAccess workDataAccess;
        private readonly LoginDataAccess loginDataAccess;
        private readonly BugManagerContext bugManagerContext;
        private readonly DbContextOptions<BugManagerContext> contextOptions;

        public TestWorkDataAccess()
        {
            connection = new SqliteConnection("Filename=:memory:");
            contextOptions = new DbContextOptionsBuilder<BugManagerContext>().UseSqlite(connection).Options;
            bugManagerContext = new BugManagerContext(contextOptions);
            workDataAccess = new WorkDataAccess(bugManagerContext);
            loginDataAccess = new LoginDataAccess(bugManagerContext);
        }

        [TestInitialize]
        public void Setup()
        {
            connection.Open();
            bugManagerContext.Database.EnsureCreated();

            Project project = new Project()
            {
                Id = 1,
                Name = "project1"
            };
            bugManagerContext.Projects.Add(project);
            bugManagerContext.SaveChanges();

        }

        [TestCleanup]
        public void CleanUp()
        {
            bugManagerContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public void Create()
        {
            bugManagerContext.Add(new Project()
            {
                Name = "project",
                Id = 2
            });
            bugManagerContext.SaveChanges();
            Work expectedWork = new Work()
            {
                Id = 1,
                Name = "Work1",
                Cost = 4,
                Time = 2,
                ProjectId = 2
            };

            workDataAccess.Create(new Work()
            {
                Id = 1,
                Name = "Work1",
                Cost = 4,
                Time = 2,
                ProjectId = 2

            });

            var workSaved = workDataAccess.GetById(1);
            Assert.AreEqual(0, new WorkComparer().Compare(expectedWork, workSaved));

        }

        [TestMethod]
        public void GetNonExistant()
        {
            Assert.ThrowsException<NonexistentWorkException>(() => workDataAccess.GetById(90));
        }

        [TestMethod]
        public void GetAll()
        {
            string token = "sdfg-uytr-fds-dsdf";
            string username = "jose";
            int id = 3;

            Admin admin = new Admin()
            {
                Username = username,
                Name = "ivan",
                Email = "dfgh@fghj.com",
                Id = id,
                Lastname = "dfgh",
                Password = "122334"
            };

            LoginToken loginToken = new LoginToken
            {
                Token = token,
                Username = username
            };

            bugManagerContext.Add(admin);
            loginDataAccess.SaveLogin(loginToken);

            var worksExpected = new List<Work>
            {
                new Work
                {
                    Id = 1,
                    Name = "a",
                    ProjectId = 1,
                    Cost = 3,
                    Time = 3
        }
    };
            bugManagerContext.Add(new Work
            {
                Id = 1,
                Name = "a",
                ProjectId = 1,
                Cost = 3,
                Time = 3,
            });
            bugManagerContext.SaveChanges();
            List<Work> workDataBase = workDataAccess.GetAll(token).ToList();

            Assert.AreEqual(1, workDataBase.Count);
            CollectionAssert.AreEqual(worksExpected, workDataBase, new WorkComparer());
        }
    }
}
