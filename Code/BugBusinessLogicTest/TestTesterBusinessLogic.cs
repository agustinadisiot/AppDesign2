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

namespace TestTesterBusinessLogic
{
    [TestClass]
    public class TestTesterBusinessLogic
    {


        [TestMethod]
        public void CreateTester()
        {
            Tester tester = new Tester
            {
                Id = 1,
                Username = "pablito",
                Name = "Pedro",
                Lastname = "Rodriguez",
                Password = "asdfsdf3242",
                Email = "pedro@hotmail.com"

            };
            var mock = new Mock<ITesterDataAccess>(MockBehavior.Strict);
            mock.Setup(d => d.Create(tester)).Returns(tester);
            var testerBusinessLogic = new TesterBusinessLogic(mock.Object);

            var testerResult = testerBusinessLogic.Add(tester);
            mock.VerifyAll();

            Assert.AreEqual(testerResult, tester);
        }

    }
}
