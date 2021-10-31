using BusinessLogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;

namespace TestWebApi
{
    [TestClass]
    public class TestWorkController
    {
        [TestMethod]
        public void Create()
        {
            Work workExpected = new Work()
            {
                Name = "implement menu",
                Cost = 2,
                Time = 4,
                Id = 3
            };

            var mock = new Mock<IWorkBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.Add(workExpected)).Returns(workExpected);
            var controller = new WorkController(mock.Object);

            var result = controller.Post(workExpected);
            var okResult = result as OkObjectResult;
            var workResult = okResult.Value as Work;

            mock.VerifyAll();
            Assert.AreEqual(workExpected, workResult);
        }

        [TestMethod]
        public void GetWork()
        {
            Work workExpected = new Work()
            {
                Name = "Login and create user",
                Cost = 2,
                Time = 4,
                Id = 3
            };

            var mock = new Mock<IWorkBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetById(workExpected.Id)).Returns(workExpected);
            var controller = new WorkController(mock.Object);

            var result = controller.Get(workExpected.Id);
            var okResult = result as OkObjectResult;
            var workResult = okResult.Value as Work;

            mock.VerifyAll();
            Assert.AreEqual(workExpected, workResult);
        }
    }
}
