using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace TestDataAccess
{
    [TestClass]
    public class TestBugDataAccess
    {

        private readonly DbConnection connection;
        private readonly BugDataAccess bugDataAccess;
        private readonly VidlyContext vidlyContext;
        private readonly DbContextOptions<VidlyContext> contextOptions;

        public TestBugDataAccess()
        {
            connection = new SqliteConnection("Filename=:memory:");
            contextOptions = new DbContextOptionsBuilder<VidlyContext>().UseSqlite(connection).Options;
            vidlyContext = new VidlyContext(contextOptions);
            bugDataAccess = new BugDataAccess(vidlyContext);
        }

        [TestInitialize]
        public void Setup()
        {
            connection.Open();
            vidlyContext.Database.EnsureCreated();
        }

        [TestCleanup]
        public void CleanUp()
        {
            vidlyContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllBugsTest()
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
            vidlyContext.Add(new Bug
            {
                Id = 1,
                Name = "b",
                Description = "a",
                Version = "1.0",
                IsActive = true
            });
            vidlyContext.SaveChanges();
            List<Bug> bugDataBase = bugDataAccess.GetAll().ToList();

            Assert.AreEqual(1, bugDataBase.Count());
            CollectionAssert.AreEqual(bugsExpected, bugDataBase, new BugComparer());
        }

        [TestMethod]
        public void UpdateBugsTest()
        {
            using (var context = new VidlyContext(contextOptions))
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
                Id = 0,
                Name = "a",
                Description = "a",
                Version = "1.0",
                IsActive = true
            };

            bugDataAccess.UpdateAll(bugUpdated);

            using (var context = new VidlyContext(contextOptions))
            {
                var bugSaved = context.Set<Bug>().First(bug => bug.Id == 1);

                Assert.AreEqual(0, new BugComparer().Compare(bugUpdated, bugSaved));
            }
        }
    }
}
