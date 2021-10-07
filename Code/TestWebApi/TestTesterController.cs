using BusinessLogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
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
            mock.Setup(t => t.GetBugsByStatus(idTester, true)).Returns(bugsExpected);
            var controller = new TesterController(mock.Object);

            var result = controller.GetBugsByStatus(idTester, true);
            var okResult = result as OkObjectResult;
            var bugsResult = okResult.Value as List<Bug>;

            mock.VerifyAll();
            Assert.IsTrue(bugsExpected.SequenceEqual(bugsResult));
        }

        [TestMethod]
        public void FilterBugsByName()
        {
            List<Bug> bugsExpected = new List<Bug>()
            {
                new Bug()
                {
                    Name = "bug1",
                },
                new Bug()
                {
                    Name = "bug1",
                },
            };
            int idTester = 1;
            var mock = new Mock<ITesterBusinessLogic>(MockBehavior.Strict);
            mock.Setup(t => t.GetBugsByName(idTester, "bug1")).Returns(bugsExpected);
            var controller = new TesterController(mock.Object);

            var result = controller.GetBugsByName(idTester, "bug1");
            var okResult = result as OkObjectResult;
            var bugsResult = okResult.Value as List<Bug>;

            mock.VerifyAll();
            Assert.IsTrue(bugsExpected.SequenceEqual(bugsResult));
        }

        [TestMethod]
        public void FilterBugsByProject()
        {
            List<Bug> bugsExpected = new List<Bug>()
            {
                new Bug()
                {
                    ProjectId = 3,
                },
                new Bug()
                {
                    ProjectId = 3,
                },
            };
            int idTester = 1;
            var mock = new Mock<ITesterBusinessLogic>(MockBehavior.Strict);
            mock.Setup(t => t.GetBugsByProject(idTester, 3)).Returns(bugsExpected);
            var controller = new TesterController(mock.Object);

            var result = controller.GetBugsByProject(idTester, 3);
            var okResult = result as OkObjectResult;
            var bugsResult = okResult.Value as List<Bug>;

            mock.VerifyAll();
            Assert.IsTrue(bugsExpected.SequenceEqual(bugsResult));
        }
    }
};




