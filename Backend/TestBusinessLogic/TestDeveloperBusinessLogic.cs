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
using DTO;

namespace TestDeveloperBusinessLogic
{
    [TestClass]
    public class TestDeveloperBusinessLogic
    {


        [TestMethod]
        public void CreateDeveloper()
        {
            Developer dev = new Developer()
            {
                Id = 1,
                Username = "pablito",
                Name = "Pedro",
                Lastname = "Rodriguez",
                Password = "asdfsdf3242",
                Email = "pedro@hotmail.com",
                Cost = 3
            };

            var mock = new Mock<IDeveloperDataAccess>(MockBehavior.Strict);
            mock.Setup(d => d.Create(It.IsAny<Developer>())).Returns<Developer>(d => d);
            var devBusinessLogic = new DeveloperBusinessLogic(mock.Object);

            var devResult = devBusinessLogic.Add(new DeveloperDTO(dev));
            mock.VerifyAll();

            Assert.AreEqual(devResult, new DeveloperDTO(dev));
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
        public void VerifyRole()
        {
            string token = "asdfdasf";
            var mock = new Mock<IDeveloperDataAccess>(MockBehavior.Strict);
            mock.Setup(m => m.VerifyRole(token)).Returns(true);
            var testerBusinessLogic = new DeveloperBusinessLogic(mock.Object);

            var isRole = testerBusinessLogic.VerifyRole(token);
            mock.VerifyAll();

            Assert.IsTrue(isRole);
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

            Assert.ThrowsException<ValidationException>(() => developerBusinessLogic.Add(new DeveloperDTO(invalidDeveloper)));
            mock.Verify(m => m.Create(invalidDeveloper), Times.Never);
        }

        [TestMethod]
        public void VerifyRoleNotValid()
        {
            string token = "23423423";
            var mock = new Mock<IDeveloperDataAccess>(MockBehavior.Strict);
            mock.Setup(m => m.VerifyRole(token)).Returns(false);
            var devBusinessLogic = new DeveloperBusinessLogic(mock.Object);

            var isRole = devBusinessLogic.VerifyRole(token);
            mock.VerifyAll();

            Assert.IsFalse(isRole);
        }
    }
}
