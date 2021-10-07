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
            mock.Setup(d => d.GetQuantityBugsResolved(idDev)).Returns(new BugsQuantity(cantBugsResolved));
            var devBusinessLogic = new DeveloperBusinessLogic(mock.Object);

            var result = devBusinessLogic.GetQuantityBugsResolved(idDev);

            mock.VerifyAll();
            Assert.AreEqual(cantBugsResolved, result.quantity);
        }

        [TestMethod]
        public void QuantityBugsResolvedDevNotFound()
        {
            int idDev = 1;

            var mock = new Mock<IDeveloperDataAccess>(MockBehavior.Strict);
            mock.Setup(d => d.GetQuantityBugsResolved(idDev)).Throws(new NonexistentUserException());
            var devBusinessLogic = new DeveloperBusinessLogic(mock.Object);

            Assert.ThrowsException<NonexistentUserException>(() => devBusinessLogic.GetQuantityBugsResolved(idDev));
        }

    }
}
