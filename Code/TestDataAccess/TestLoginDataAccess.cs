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
    public class TestLoginDataAccess
    {

        private readonly DbConnection connection;
        private readonly LoginDataAccess loginDataAccess;
        private readonly BugManagerContext bugManagerContext;
        private readonly DbContextOptions<BugManagerContext> contextOptions;

        public TestLoginDataAccess()
        {
            connection = new SqliteConnection("Filename=:memory:");
            contextOptions = new DbContextOptionsBuilder<BugManagerContext>().UseSqlite(connection).Options;
            bugManagerContext = new BugManagerContext(contextOptions);
            loginDataAccess = new LoginDataAccess(bugManagerContext);
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

        [DataTestMethod]
        [DataRow("asdlfk")]
        [DataRow("as8df8asdf")]
        [DataRow("3423k423j42k342m34")]
        public void SaveLogin(string expectedToken)
        {
            LoginToken token = new LoginToken { Token = expectedToken };

            loginDataAccess.SaveLogin(token);

            bool exists = bugManagerContext.Sessions.Any(s => s.Token == expectedToken);
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void VerifyValidAdminCredentials()
        {
            bugManagerContext.Add(new Admin()
            {
                Username = "administradorPedro",
                Name = "Pedro",
                Lastname = "López",
                Password = "fransico234",
                Email = "pedrooo2@hotmail.com"
            });
            bugManagerContext.SaveChanges();

            bool valid = loginDataAccess.VerifyUser("administradorPedro", "fransico234");

            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void VerifyNotValidAdminCredentials()
        {
            bugManagerContext.Add(new Admin()
            {
                Username = "administradorPedro",
                Name = "Pedro",
                Lastname = "López",
                Password = "fransico234",
                Email = "pedrooo2@hotmail.com"
            });
            bugManagerContext.SaveChanges();

            bool valid = loginDataAccess.VerifyUser("administradorPedro", "contraseñaIncorrecta");

            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void VerifyValidTesterCredentials()
        {
            bugManagerContext.Add(new Tester()
            {
                Username = "Juan",
                Name = "Holaaa",
                Lastname = "Rodi",
                Password = "qewrty123",
                Email = "juaaan@gmail.com"
            });
            bugManagerContext.SaveChanges();

            bool valid = loginDataAccess.VerifyUser("Juan", "qewrty123");

            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void VerifyValidDevCredentials()
        {
            bugManagerContext.Add(new Developer()
            {
                Username = "dev123",
                Name = "Jose",
                Lastname = "Perez",
                Password = "123dev",
                Email = "juaaan@gmail.com"
            });
            bugManagerContext.SaveChanges();

            bool valid = loginDataAccess.VerifyUser("dev123", "123dev");

            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void VerifyNotValidTesterCredentials()
        {
            bugManagerContext.Add(new Tester()
            {
                Username = "Juan",
                Name = "Holaaa",
                Lastname = "Rodi",
                Password = "qewrty123",
                Email = "juaaan@gmail.com"
            });
            bugManagerContext.SaveChanges();

            bool valid = loginDataAccess.VerifyUser("Juan", "qewrty124");

            Assert.IsFalse(valid);
        }



        [TestMethod]
        public void VerifyNotValidDevCredentials()
        {
            bugManagerContext.Add(new Developer()
            {
                Username = "dev123",
                Name = "Jose",
                Lastname = "Perez",
                Password = "123dev",
                Email = "juaaan@gmail.com"
            });
            bugManagerContext.SaveChanges();

            bool valid = loginDataAccess.VerifyUser("dev123", "sdfasdfasd");

            Assert.IsFalse(valid);
        }


        [TestMethod]
        public void VerifyNonExistingUser()
        {
            bool valid = loginDataAccess.VerifyUser("administradorPedro", "contraseñaIncorrecta");

            Assert.IsFalse(valid);
        }
    }
}
