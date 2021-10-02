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
    public class TestBugDataAccess
    {

        private readonly DbConnection connection;
        private readonly BugDataAccess bugDataAccess;
        private readonly BugManagerContext bugManagerContext;
        private readonly DbContextOptions<BugManagerContext> contextOptions;

        public TestBugDataAccess()
        {
            connection = new SqliteConnection("Filename=:memory:");
            contextOptions = new DbContextOptionsBuilder<BugManagerContext>().UseSqlite(connection).Options;
            bugManagerContext = new BugManagerContext(contextOptions);
            bugDataAccess = new BugDataAccess(bugManagerContext);
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
        public void GetAll()
        {
            var bugsExpected = new List<Bug>
            {
                new Bug
                {
                    Id = 0,
                    Name = "a",
                    Description = "a",
                    Version = "1.0",
                    IsActive = true
        }
    };
            bugManagerContext.Add(new Bug
            {
                Id = 0,
                Name = "a",
                Description = "a",
                Version = "1.0",
                IsActive = true
            });
            bugManagerContext.SaveChanges();
            List<Bug> bugDataBase = bugDataAccess.GetAll().ToList();

            Assert.AreEqual(1, bugDataBase.Count);
            CollectionAssert.AreEqual(bugsExpected, bugDataBase, new BugComparer());
        }

        [TestMethod]
        public void Update()
        {
            using (var context = new BugManagerContext(contextOptions))
            {
                context.Add(new Bug
                {
                    Id = 1,
                    Name = "b",
                    Description = "a",
                    Version = "1.0",
                    IsActive = true
                });
                context.SaveChanges();
            }

            var bugUpdated = new Bug
            {
                Id = 1,
                Name = "a",
                Description = "a",
                Version = "1.0",
                IsActive = true
            };

            bugDataAccess.Update(bugUpdated);

            using (var context = new BugManagerContext(contextOptions))
            {
                var bugSaved = context.Set<Bug>().First(bug => bug.Id == 1);

                Assert.AreEqual(0, new BugComparer().Compare(bugUpdated, bugSaved));
            }
        }


        [TestMethod]
        public void Create()
        {
            Bug expectedBug = new Bug()
            {
                Id = 1,
                Name = "Error",
                Description = "Erorr critico",
                Version = "2.0",
                IsActive = true
            };
            using (var context = new BugManagerContext(contextOptions))
            {
                context.Add(new Bug
                {
                    Id = 1,
                    Name = "Error",
                    Description = "Erorr critico",
                    Version = "2.0",
                    IsActive = true
                });
                context.SaveChanges();
            }

            using (var context = new BugManagerContext(contextOptions))
            {
                var bugSaved = bugDataAccess.GetById(1);
                Assert.AreEqual(0, new BugComparer().Compare(expectedBug, bugSaved));
            }
        }
    }
}
