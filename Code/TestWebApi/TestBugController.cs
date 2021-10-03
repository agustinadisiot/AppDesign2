using System.Collections.Generic;
using System.Linq;
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
    public class TestBugController
    {
        [TestMethod]
        public void GetAll()
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

            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetAll()).Returns(bugsExpected);
            var controller = new BugController(mock.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var bugsResult = okResult.Value as IEnumerable<Bug>;

            mock.VerifyAll();
            CollectionAssert.AreEqual(bugsExpected, (System.Collections.ICollection)bugsResult, new BugComparer());
        }

        [TestMethod]
        public void Create()
        {
            Bug bugExpected = new Bug()
            {
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                Id = 0
            };

            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.Add(bugExpected)).Returns(bugExpected);
            var controller = new BugController(mock.Object);

            var result = controller.Post(bugExpected);
            var okResult = result as OkObjectResult;
            var bugResult = okResult.Value as Bug;

            mock.VerifyAll();
            Assert.AreEqual(bugExpected, bugResult);
        }

        [TestMethod]
        public void GetBug()
        {
            Bug bugExpected = new Bug()
            {
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                Id = 0
            };

            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetById(bugExpected.Id)).Returns(bugExpected);
            var controller = new BugController(mock.Object);

            var result = controller.Get(bugExpected.Id);
            var okResult = result as OkObjectResult;
            var bugResult = okResult.Value as Bug;

            mock.VerifyAll();
            Assert.AreEqual(bugExpected, bugResult);
        }

        [TestMethod]
        public void Delete()
        {
            Bug bugExpected = new Bug()
            {
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                Id = 0
            };

            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.Delete(bugExpected.Id));
            var controller = new BugController(mock.Object);

            var result = controller.Delete(bugExpected);

            mock.VerifyAll();

            var bugs = controller.Get();
            var okResultBugs = bugs as OkObjectResult;
            var allBugs = okResultBugs.Value as IEnumerable<Bug>;

            Assert.IsFalse(allBugs.Contains(bugExpected));
        }

        [TestMethod]
        public void Update()
        {
            Bug bugExpected = new Bug()
            {
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                Id = 0
            };

            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetById(bugExpected.Id)).Returns(bugExpected);
            var controller = new BugController(mock.Object);

            var result = controller.Update(bugExpected.Id);
            var okResult = result as OkObjectResult;
            var bugResult = okResult.Value as Bug;

            mock.VerifyAll();
            Assert.AreEqual(bugExpected, bugResult);
        }
    }
}

