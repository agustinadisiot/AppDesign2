using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using RepositoryInterfaces;
using Domain.Utils;
using Moq;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicInterfaces;

namespace TestBugImportationBusinessLogic
{
    [TestClass]
    public class TestBugImportationBusinessLogic
    {
        [TestMethod]
        public void ImportBugXMl()
        {

            Bug bug1 = new Bug()
            {
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                Id = 0
            };

            Bug bug2 = new Bug()
            {
                Name = "button",
                Description = "Upload not working",
                Version = "1.4.5",
                IsActive = false,
                CompletedBy = null,
                Id = 1
            };

            Bug bug3 = new Bug()
            {
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "6.2",
                IsActive = true,
                CompletedBy = null,
                Id = 2
            };

            string path = "file.xml";
            List<Bug> expectedBugs = new List<Bug>() { bug1, bug2, bug3 };
            List<Bug> actualBugs = new List<Bug>() { };
            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Create(bug1)).Callback(() => actualBugs.Add(bug1));
            mock.Setup(b => b.Create(bug2)).Callback(() => actualBugs.Add(bug2));
            mock.Setup(b => b.Create(bug3)).Callback(() => actualBugs.Add(bug3));
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            var result = bugBusinessLogic.ImportBugs(path, ImportCompany.XML);

            CollectionAssert.AreEquivalent(expectedBugs, actualBugs);
        }

    }
}
