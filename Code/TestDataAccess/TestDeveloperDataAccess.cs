using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using BusinessLogic;
using BusinessLogicInterfaces;
using Domain;
using Domain.Utils;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;

namespace TestDataAccess
{
    [TestClass]
    public class TestDeveloperDataAccess
    {

        private readonly DbConnection connection;
        private readonly DeveloperDataAccess devDataAccess;
        private readonly BugManagerContext bugManagerContext;
        private readonly DbContextOptions<BugManagerContext> contextOptions;

        public TestDeveloperDataAccess()
        {
            connection = new SqliteConnection("Filename=:memory:");
            contextOptions = new DbContextOptionsBuilder<BugManagerContext>().UseSqlite(connection).Options;
            bugManagerContext = new BugManagerContext(contextOptions);
            devDataAccess = new DeveloperDataAccess(bugManagerContext);
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

            Developer devSaved = devDataAccess.Create(new Developer()
            {
                Username = "developerPedro",
                Name = "Pedro",
                Lastname = "López",
                Password = "fransico234",
                Email = "pedrooo2@hotmail.com"
            });

            Assert.AreEqual(0, new UserComparer().Compare(expectedDev, devSaved));

        }



        [TestMethod]
        public void QuantityBugsResolved()
        {
            bugManagerContext.Add(new Project()
            {
                Name = "project",
                Id = 2
            });
            bugManagerContext.SaveChanges();

            Developer expectedDev = new Developer
            {
                Id = 2,
                Username = "developerPedro",
                Name = "Pedro",
                Lastname = "López",
                Password = "fransico234",
                Email = "pedrooo2@hotmail.com"

            };
            devDataAccess.Create(expectedDev);
            bugManagerContext.Add(new Bug()
            {
                CompletedById = 2,
                Id = 1,
                ProjectId = 2
            });
            bugManagerContext.Add(new Bug()
            {
                CompletedById = 2,
                Id = 2,
                ProjectId = 2
            });
            bugManagerContext.Add(new Bug()
            {
                Id = 3,
                ProjectId = 2

            });
            bugManagerContext.SaveChanges();
            int expectedQuantity = 2;

            int result = devDataAccess.GetQuantityBugsResolved(expectedDev.Id);

            Assert.AreEqual(expectedQuantity, result);
        }

    }
}
