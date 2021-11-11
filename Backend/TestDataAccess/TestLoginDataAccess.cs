﻿using System.Collections.Generic;
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
        [DataRow("asdlfk", "jose")]
        [DataRow("as8df8asdf", "admin1")]
        [DataRow("3423k423j42k342m34", "devName")]
        public void SaveLogin(string expectedToken, string username)
        {
            LoginToken token = new LoginToken
            {
                Token = expectedToken,
                Username = username
            };

            loginDataAccess.SaveLogin(token);

            bool exists = bugManagerContext.Sessions.Any(s => s.Token == expectedToken
                                                        && s.Username == username);
            Assert.IsTrue(exists);
        }
    }
}