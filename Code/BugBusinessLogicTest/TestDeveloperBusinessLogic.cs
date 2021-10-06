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

    }
}
