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

namespace TestBugBusinessLogic
{
    [TestClass]
    public class TestBugBusinessLogic
    {
        private Bug bug;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            bug = new Bug()
            {
                Id = 0,
                Name = "Bug1",
                Description = "Cuando el servidor se cierra y estoy en login se rompe",
                Version = "12.4.5",
                ProjectId = 3,
            };

        }


        [TestMethod]
        public void CreateBug()
        {
            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Create(bug)).Returns(bug);
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            var bugResult = bugBusinessLogic.Add(bug);
            mock.VerifyAll();

            Assert.AreEqual(bugResult, bug);
        }

        [TestMethod]
        public void DeleteBugNotFound()
        {
            int idbugToDelete = 1;

            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Delete(idbugToDelete)).Throws(new NonexistentBugException());
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            Assert.ThrowsException<NonexistentBugException>(() => bugBusinessLogic.Delete(idbugToDelete));
        }

        [TestMethod]
        public void DeleteBug()
        {
            int idbugToDelete = 0;
            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Delete(idbugToDelete)).Returns(new ResponseMessage("Deleted successfully"));
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            var result = bugBusinessLogic.Delete(idbugToDelete);
            mock.VerifyAll();
            Assert.IsTrue(result is ResponseMessage);
        }

        [TestMethod]
        public void GetById()
        {
            Bug bugExpected = new Bug()
            {
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                Id = 0
            };

            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.GetById(bugExpected.Id)).Returns(bugExpected);
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            var result = bugBusinessLogic.GetById(bugExpected.Id);

            Assert.AreEqual(bugExpected, result);
        }

        [TestMethod]
        public void GetAll()
        {
            List<Bug> bugsExpected = new List<Bug>()
            {
                new Bug()
                {
                     Name = "Not working button",
                     Description = "Upload button not working",
                     Version = "1",
                     IsActive = true,
                     CompletedBy = null,
                     Id = 0
                }, 
                new Bug()
                {
                    Name = "button",
                    Description = "Upload not working",
                    Version = "1.4.5",
                    IsActive = false,
                    CompletedBy = null,
                    Id = 1
                },
                 new Bug()
                {
                    Name = "Not working button",
                    Description = "Upload button not working",
                    Version = "6.2",
                    IsActive = true,
                    CompletedBy = null,
                    Id = 2
                },
            };

            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.GetAll()).Returns(bugsExpected);
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            var result = bugBusinessLogic.GetAll();

            Assert.IsTrue(bugsExpected.SequenceEqual(result));
        }

        [TestMethod]
        public void UpdateBugNotFound()
        {
            int idbugToUpdate = 1;

            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Update(idbugToUpdate, bug)).Throws(new NonexistentBugException());
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            Assert.ThrowsException<NonexistentBugException>(() => bugBusinessLogic.Update(idbugToUpdate, bug));
        }

        [TestMethod]
        public void UpdateBug()
        {
            int idbugToUpdate = 0;

            Bug bugModified = new Bug()
            {
                Id = 0,
                Name = "bugMod",
                Description = "No funciona el boton aceptar",
                Version = "12.2.2."
            };

            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Update(idbugToUpdate, bugModified)).Returns(bugModified);
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            var bugResult = bugBusinessLogic.Update(idbugToUpdate, bugModified);

            mock.VerifyAll();

            Assert.AreEqual(bugResult, bugModified);
        }

        [TestMethod]
        public void CreateInvalidBug()
        {
            Bug invalidBug = new Bug()
            {
                Name = "invalid bug",
                Description = "this is a bug",
                Version = "24.2.4"
            };

            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Create(invalidBug)).Returns(invalidBug);
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            Assert.ThrowsException<ValidationException>(()=> bugBusinessLogic.Add(invalidBug));
            mock.Verify(m => m.Create(invalidBug), Times.Never);

        }
    }
}
