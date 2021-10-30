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
            mock.Setup(t => t.Create(tester)).Returns(tester);
            var testerBusinessLogic = new TesterBusinessLogic(mock.Object);

            var testerResult = testerBusinessLogic.Add(tester);
            mock.VerifyAll();

            Assert.AreEqual(testerResult, tester);
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

            var mock = new Mock<ITesterDataAccess>(MockBehavior.Strict);
            mock.Setup(t => t.GetBugsByStatus(idTester, true)).Returns(bugsExpected);
            var testerBusinessLogic = new TesterBusinessLogic(mock.Object);


            var bugsResult = testerBusinessLogic.GetBugsByStatus(idTester, true);

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
            var mock = new Mock<ITesterDataAccess>(MockBehavior.Strict);
            mock.Setup(t => t.GetBugsByName(idTester, "bug1")).Returns(bugsExpected);
            var testerBusinessLogic = new TesterBusinessLogic(mock.Object);


            var bugsResult = testerBusinessLogic.GetBugsByName(idTester, "bug1");

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
            var mock = new Mock<ITesterDataAccess>(MockBehavior.Strict);
            mock.Setup(t => t.GetBugsByProject(idTester, 3)).Returns(bugsExpected);
            var testerBusinessLogic = new TesterBusinessLogic(mock.Object);

            var bugsResult = testerBusinessLogic.GetBugsByProject(idTester, 3);

            mock.VerifyAll();
            Assert.IsTrue(bugsExpected.SequenceEqual(bugsResult));
        }

        [TestMethod]
        public void VerifyRole()
        {
            string token = "asdfdasf";
            var mock = new Mock<ITesterDataAccess>(MockBehavior.Strict);
            mock.Setup(m => m.VerifyRole(token)).Returns(true);
            var testerBusinessLogic = new TesterBusinessLogic(mock.Object);

            var isRole = testerBusinessLogic.VerifyRole(token);
            mock.VerifyAll();

            Assert.IsTrue(isRole);
        }

        [TestMethod]
        public void VerifyRoleNotValid()
        {
            string token = "23423423";
            var mock = new Mock<ITesterDataAccess>(MockBehavior.Strict);
            mock.Setup(m => m.VerifyRole(token)).Returns(false);
            var testerBusinessLogic = new TesterBusinessLogic(mock.Object);

            var isRole = testerBusinessLogic.VerifyRole(token);
            mock.VerifyAll();

            Assert.IsFalse(isRole);
        }
    }
}
