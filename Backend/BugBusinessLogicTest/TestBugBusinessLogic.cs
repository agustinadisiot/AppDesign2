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

namespace TestBugBusinessLogic
{
    [TestClass]
    public class TestBugBusinessLogic
    {
        private Bug bug;
        private BugDTO bugDTO;

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
                IsActive = true,
                CompletedById = 0,
                Time = 3,
                Project = new Project()
                {
                    Id = 3,
                    Name = "project"
                }
            };

        }


        [TestMethod]
        public void CreateBug()
        {
            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Create(bug)).Returns(bug);
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            var bugResult = bugBusinessLogic.Add(new BugDTO(bug));
            mock.VerifyAll();

            Assert.AreEqual(bugResult, new BugDTO(bug));
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
            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.GetById(bug.Id)).Returns(bug);
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            var result = bugBusinessLogic.GetById(bug.Id);

            Assert.AreEqual(new BugDTO(bug), result);
        }

        [TestMethod]
        public void GetAll()
        {
            List<Bug> bugsExpected = new List<Bug>()
            {
                new Bug()
                {
                     Id = 0,
                Name = "Bug1",
                Description = "Cuando el servidor se cierra y estoy en login se rompe",
                Version = "12.4.5",
                ProjectId = 3,
                IsActive = true,
                CompletedById = 0,
                Time = 3,
                Project = new Project()
                {
                    Id = 3,
                    Name = "project"
                }
                }, 
                new Bug()
                {
                    Id = 1,
                Name = "Bug1",
                Description = "Cuando el servidor se cierra y estoy en login se rompe",
                Version = "12.4.5",
                ProjectId = 3,
                IsActive = true,
                CompletedById = 0,
                Time = 3,
                Project = new Project()
                {
                    Id = 3,
                    Name = "project"
                }
                },
                 new Bug()
                {
                    Id = 2,
                Name = "Bug1",
                Description = "Cuando el servidor se cierra y estoy en login se rompe",
                Version = "12.4.5",
                ProjectId = 4,
                IsActive = true,
                CompletedById = 0,
                Time = 3,
                Project = new Project()
                {
                    Id = 4,
                    Name = "project"
                }
                },
            };

            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.GetAll()).Returns(bugsExpected);
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            var result = bugBusinessLogic.GetAll();

            Assert.IsTrue(bugsExpected.ConvertAll(b=>new BugDTO(b)).SequenceEqual(result));
        }

        [TestMethod]
        public void UpdateBug()
        {
            int idbugToUpdate = 0;

            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Update(idbugToUpdate, bug)).Returns(bug);
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            var bugResult = bugBusinessLogic.Update(idbugToUpdate, new BugDTO(bug));

            mock.VerifyAll();

            Assert.AreEqual(bugResult, new BugDTO(bug));
        }

        [TestMethod]
        public void CreateInvalidBug()
        {
            Bug invalidBug = new Bug()
            {
                Id = 0,
                Version = "12.4.5",
                ProjectId = 3,
                IsActive = true,
                CompletedById = 0,
                Time = 3,
                Project = new Project()
                {
                    Id = 3,
                    Name = "project"
                }
            };

            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Create(invalidBug)).Returns(invalidBug);
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            Assert.ThrowsException<ValidationException>(()=> bugBusinessLogic.Add(new BugDTO(invalidBug)));
            mock.Verify(m => m.Create(invalidBug), Times.Never);

        }
    }
}
