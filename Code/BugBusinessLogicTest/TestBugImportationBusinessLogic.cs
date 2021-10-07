using BugParser;
using BusinessLogic;
using Domain;
using Domain.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepositoryInterfaces;
using System.Collections.Generic;

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

            var parserMock = new Mock<IBugParser>(MockBehavior.Strict);
            parserMock.Setup(p => p.GetBugs(path)).Returns(expectedBugs);

            var factoryMock = new Mock<IParserFactory>(MockBehavior.Strict);
            factoryMock.Setup(b => b.GetBugParser(ImportCompany.XML)).Returns(parserMock.Object);


            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Create(bug1)).Returns(bug1);
            mock.Setup(b => b.Create(bug2)).Returns(bug2);
            mock.Setup(b => b.Create(bug3)).Returns(bug3);
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            bugBusinessLogic.ImportBugs(path, ImportCompany.XML, factoryMock.Object);

            mock.VerifyAll();
            parserMock.VerifyAll();
            factoryMock.VerifyAll();
        }

    }
}

