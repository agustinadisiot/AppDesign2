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
            mock.Setup(d => d.Add(devExpected)).Returns(devExpected);
            var controller = new DeveloperController(mock.Object);

            var result = controller.Post(devExpected);
            var okResult = result as OkObjectResult;
            var devResult = okResult.Value as Developer;

            mock.VerifyAll();
            Assert.AreEqual(devExpected, devResult);
        }

        [TestMethod]
        public void QuantityBugsResolved()
        {
            int idDev = 1;
            int cantBugsResolved = 1;

            var mock = new Mock<IDeveloperBusinessLogic>(MockBehavior.Strict);
            mock.Setup(d => d.GetQuantityBugsResolved(idDev)).Returns(cantBugsResolved);
            var controller = new DeveloperController(mock.Object);

            var result = controller.GetQuantityBugsResolved(idDev);
            var okResult = result as OkObjectResult;
            var cantResult = okResult.Value as BugsQuantity;

            mock.VerifyAll();
            Assert.AreEqual(cantBugsResolved, cantResult.quantity);
        }

        [TestMethod]
        public void QuantityBugsResolvedDevNotFound()
        {
            int idDev = 1;

            var mock = new Mock<IDeveloperBusinessLogic>(MockBehavior.Strict);
            mock.Setup(d => d.GetQuantityBugsResolved(idDev)).Throws(new NonexistentUserException());
            var controller = new DeveloperController(mock.Object);

            Assert.ThrowsException<NonexistentUserException>(() => controller.GetQuantityBugsResolved(idDev));
        }
    }
};




