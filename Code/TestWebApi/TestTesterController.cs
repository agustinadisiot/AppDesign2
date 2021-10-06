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
    public class TestTesterController
    {

        [TestMethod]
        public void Create()
        {
            Tester testerExpected = new Tester()
            {
                Username = "jose",
                Name = "Joselito",
                Lastname = "López",
                Password = "josephe3#@",
                Email = "jose.lopez@gmail.com"

            };

            var mock = new Mock<ITesterBusinessLogic>(MockBehavior.Strict);
            mock.Setup(t => t.Add(testerExpected)).Returns(testerExpected);
            var controller = new TesterController(mock.Object);

            var result = controller.Post(testerExpected);
            var okResult = result as OkObjectResult;
            var devResult = okResult.Value as Tester;

            mock.VerifyAll();
            Assert.AreEqual(testerExpected, devResult);
        }
    }
};




