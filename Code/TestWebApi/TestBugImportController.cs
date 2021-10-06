using System.Collections.Generic;
using System.Linq;
using BugParser;
using BusinessLogic;
using BusinessLogicInterfaces;
using Domain;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;


namespace TestWebApi
{
    [TestClass]
    public class TestBugImportController
    {


        [TestMethod]
        public void ImportXML()
        {
            List<Bug> bugsExpected = new List<Bug>()
            {
                new Bug(){
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                Id = 0
                },
                new Bug(){
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                Id = 1
                }
            };

            string path = "file.xml";


            var parserMock = new Mock<IBugParser>(MockBehavior.Strict);
            parserMock.Setup(p => p.GetBugs(path)).Returns(bugsExpected);

            var factoryMock = new Mock<IBugParserFactory>(MockBehavior.Strict);
            factoryMock.Setup(b => b.GetParser(ImportCompany.XML).Returns(bugsExpected);

            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.ImportBugs(path, ImportCompany.XML)).Returns(bugsExpected);
            var controller = new BugController(mock.Object);

            var result = controller.ImportBugs(path, ImportCompany.XML);
            var okResult = result as OkObjectResult;
            var bugsResult = okResult.Value as IEnumerable<Bug>;

            mock.VerifyAll();
            CollectionAssert.AreEqual(bugsExpected, (System.Collections.ICollection)bugsResult, new BugComparer());
        }

    }
}

