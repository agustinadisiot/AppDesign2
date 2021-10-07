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

        [TestMethod]
        public void FilterBugsByStatus()
        {
            List<Bug> bugsExpected = new List<Bug>()
            {
                new Bug()
                {
                    Name = "bug1",
                    IsActive = true
                },
                new Bug()
                {
                    Name = "bug2",
                    IsActive = true
                },
            };
            int idTester = 1;
            var mock = new Mock<ITesterBusinessLogic>(MockBehavior.Strict);
            mock.Setup(t => t.GetBugsByStatus(idTester,true)).Returns(bugsExpected);
            var controller = new TesterController(mock.Object);

            var result = controller.GetBugsByStatus(idTester, true);
            var okResult = result as OkObjectResult;
            var bugsResult = okResult.Value as List<Bug>;

            mock.VerifyAll();
            Assert.AreEqual(bugsExpected, bugsResult);
        }
    }
};




