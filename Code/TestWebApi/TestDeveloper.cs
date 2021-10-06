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
    public class TestDeveloperController
    {

        [TestMethod]
        public void Create()
        {
            Developer devExpected = new Developer()
            {
                Username = "juana",
                Name = "Juana",
                Lastname = "López",
                Password = "Juana1223#@",
                Email = "juana.perez@gmail.com"

            };

            var mock = new Mock<IDeveloperBusinessLogic>(MockBehavior.Strict);
            mock.Setup(a => a.Add(devExpected)).Returns(devExpected);
            var controller = new DeveloperController(mock.Object);

            var result = controller.Post(devExpected);
            var okResult = result as OkObjectResult;
            var devResult = okResult.Value as Admin;

            mock.VerifyAll();
            Assert.AreEqual(devExpected, adminResult);
        }
    }
};




