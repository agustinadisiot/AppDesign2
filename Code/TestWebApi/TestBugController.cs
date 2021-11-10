using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using BusinessLogicInterfaces;
using Domain.Utils;
using DTO;
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
            List<BugDTO> bugsExpected = new List<BugDTO>()
            {
                new BugDTO(){
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                Id = 0,
                CompletedById = 0
                },
                new BugDTO(){
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                Id = 1,
                CompletedById = 0
                }
            };

            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetAll()).Returns(bugsExpected);
            var controller = new BugController(mock.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var bugsResult = okResult.Value as IEnumerable<BugDTO>;

            mock.VerifyAll();
            CollectionAssert.AreEqual(bugsExpected, (System.Collections.ICollection)bugsResult, new BugComparer()); //bugdtocomparer
        }

        [TestMethod]
        public void Create()
        {
            BugDTO bugExpected = new BugDTO()
            {
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedById = 0,
                Id = 0
            };

            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.Add(bugExpected)).Returns(bugExpected);
            var controller = new BugController(mock.Object);

            var result = controller.Post(bugExpected);
            var okResult = result as OkObjectResult;
            var bugResult = okResult.Value as BugDTO;

            mock.VerifyAll();
            Assert.AreEqual(bugExpected, bugResult);
        }

        [TestMethod]
        public void GetBug()
        {
            BugDTO bugExpected = new BugDTO()
            {
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedById = 0,
                Id = 0
            };

            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetById(bugExpected.Id)).Returns(bugExpected);
            var controller = new BugController(mock.Object);

            var result = controller.Get(bugExpected.Id);
            var okResult = result as OkObjectResult;
            var bugResult = okResult.Value as BugDTO;

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

            Assert.IsTrue(result is NoContentResult);
            mock.VerifyAll();
        }

        [TestMethod]
        public void Update()
        {
            BugDTO bugExpected = new BugDTO()
            {
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedById = 0,
                Id = 0
            };

            BugDTO bugModified = new BugDTO()
            {
                Name = "Bug number 4",
                Description = "Email verification not working",
                Version = "1",
                IsActive = true,
                CompletedById = 0,
                Id = 0
            };

            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.Update(bugExpected.Id, bugModified)).Returns(bugExpected);
            var controller = new BugController(mock.Object);

            var result = controller.Update(bugExpected.Id, bugModified);
            var okResult = result as OkObjectResult;
            var bugResult = okResult.Value as BugDTO;

            mock.VerifyAll();
            Assert.AreEqual(bugExpected, bugResult);
        }
    }
}

