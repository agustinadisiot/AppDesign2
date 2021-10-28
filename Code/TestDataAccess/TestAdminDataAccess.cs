using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Domain;
using Domain.Utils;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using RepositoryInterfaces;

namespace TestDataAccess
{
    [TestClass]
    public class TestAdminDataAccess : TestUserDataAccess<Admin>
    {
        public TestAdminDataAccess() : base()
        {
            userDataAccess = new AdminDataAccess(bugManagerContext);
            user = new Admin();
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

            Admin adminSaved = userDataAccess.Create(new Admin()
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
