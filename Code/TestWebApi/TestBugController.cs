using BusinessLogicInterfaces;
using Domain;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
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
            int idBugToDelete = 0;
            ResponseMessage responseExpected = new ResponseMessage("Deleted successfully");
            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.Delete(idBugToDelete)).Returns(responseExpected);
            var controller = new BugController(mock.Object);

            var result = controller.Delete(idBugToDelete);
            var okResult = result as OkObjectResult;
            var ResponseResult = okResult.Value as ResponseMessage;

            mock.VerifyAll();

            Assert.AreEqual(ResponseResult.responseMessage, responseExpected.responseMessage);
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

            Bug bugModified = new Bug()
            {
                Name = "Bug number 4",
                Description = "Email verification not working",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                Id = 0
            };

            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.Update(bugExpected.Id, bugModified)).Returns(bugExpected);
            var controller = new BugController(mock.Object);

            var result = controller.Update(bugExpected.Id, bugModified);
            var okResult = result as OkObjectResult;
            var bugResult = okResult.Value as Bug;

            mock.VerifyAll();
            Assert.AreEqual(bugExpected, bugResult);
        }
    }
}

