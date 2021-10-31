using BusinessLogic;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBusinessLogic
{
    [TestClass]
    public class TestWorkBusinessLogic
    {
        private Work work;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            work = new Work()
            {
                Id = 1,
                Name = "work1",
                Cost = 3,
                Time = 2
            };

        }
        [TestMethod]
        public void CreateWork()
        {
            var mock = new Mock<IWorkDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Create(work)).Returns(work);
            var workBusinessLogic = new WorkBusinessLogic(mock.Object);

            var workResult = workBusinessLogic.Add(work);
            mock.VerifyAll();

            Assert.AreEqual(workResult, work);
        }

        [TestMethod]
        public void GetById()
        {
            Work workExpected = new Work()
            {
                Name = "Login",
                Time = 3,
                Cost = 2,
                Id = 1
            };

            var mock = new Mock<IWorkDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.GetById(workExpected.Id)).Returns(workExpected);
            var workBusinessLogic = new WorkBusinessLogic(mock.Object);

            var result = workBusinessLogic.GetById(workExpected.Id);

            Assert.AreEqual(workExpected, result);
        }

        [TestMethod]
        public void CreateInvalidWork()
        {
            Work invalidWork = new Work()
            {
                Name = "invalid work",
                Cost = 2,
            };

            var mock = new Mock<IWorkDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Create(invalidWork)).Returns(invalidWork);
            var workBusinessLogic = new WorkBusinessLogic(mock.Object);

            Assert.ThrowsException<ValidationException>(() => workBusinessLogic.Add(invalidWork));
            mock.Verify(m => m.Create(invalidWork), Times.Never);

        }
    }
}
