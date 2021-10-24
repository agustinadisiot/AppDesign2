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
    public class TestAdminDataAccess
    {

        private readonly DbConnection connection;
        private readonly AdminDataAccess adminDataAccess;
        private readonly BugManagerContext bugManagerContext;
        private readonly DbContextOptions<BugManagerContext> contextOptions;

        public TestAdminDataAccess()
        {
            connection = new SqliteConnection("Filename=:memory:");
            contextOptions = new DbContextOptionsBuilder<BugManagerContext>().UseSqlite(connection).Options;
            bugManagerContext = new BugManagerContext(contextOptions);
            adminDataAccess = new AdminDataAccess(bugManagerContext);
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
            Admin expectedAdmin = new Admin
            {
                Username = "administradorPedro",
                Name = "Pedro",
                Lastname = "López",
                Password = "fransico234",
                Email = "pedrooo2@hotmail.com"

            };

            Admin adminSaved = adminDataAccess.Create(new Admin()
            {
                Username = "administradorPedro",
                Name = "Pedro",
                Lastname = "López",
                Password = "fransico234",
                Email = "pedrooo2@hotmail.com"
            });

            Assert.AreEqual(0, new UserComparer().Compare(expectedAdmin, adminSaved));

        }
    }
}
