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

namespace TestDeveloperBusinessLogic
{
    [TestClass]
    public class TestDeveloperBusinessLogic
    {


        [TestMethod]
        public void CreateDeveloper()
        {
            Developer dev = new Developer
            {
                Id = 1,
                Username = "pablito",
                Name = "Pedro",
                Lastname = "Rodriguez",
                Password = "asdfsdf3242",
                Email = "pedro@hotmail.com"

            };
            var mock = new Mock<IDeveloperDataAccess>(MockBehavior.Strict);
            mock.Setup(d => d.Create(dev)).Returns(dev);
            var devBusinessLogic = new DeveloperBusinessLogic(mock.Object);

            var devResult = devBusinessLogic.Add(dev);
            mock.VerifyAll();

            Assert.AreEqual(devResult, dev);
        }

        [TestMethod]
        public void QuantityBugsResolved()
        {
            int idDev = 1;
            int cantBugsResolved = 1;

            var mock = new Mock<IDeveloperDataAccess>(MockBehavior.Strict);
            mock.Setup(d => d.GetQuantityBugsResolved(idDev)).Returns(cantBugsResolved);
            var devBusinessLogic = new DeveloperBusinessLogic(mock.Object);

            var result = devBusinessLogic.GetQuantityBugsResolved(idDev);

            mock.VerifyAll();
            Assert.AreEqual(cantBugsResolved, result);
        }

        [TestMethod]
        public void CreateInvalidDev()
        {
            Developer invalidDeveloper = new Developer
            {
                Id = 1,
                Username = "admin",
                Name = "Pedro",
                Lastname = "Rodriguez",
                Email = "pedrooo@hotmail.com"

            };

            var mock = new Mock<IDeveloperDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Create(invalidDeveloper)).Returns(invalidDeveloper);
            var developerBusinessLogic = new DeveloperBusinessLogic(mock.Object);

            Assert.ThrowsException<ValidationException>(() => developerBusinessLogic.Add(invalidDeveloper));
            mock.Verify(m => m.Create(invalidDeveloper), Times.Never);

        }

    }
}
