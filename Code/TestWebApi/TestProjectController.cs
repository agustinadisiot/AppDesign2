using BusinessLogicInterfaces;
using Domain;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WebApi.Controllers;

namespace TestWebApi
{
    [TestClass]
    public class TestProjectController
    {
        [TestMethod]
        public void GetAll()
        {
            List<Project> projectsExpected = new List<Project>()
            {
                new Project(){
                    Name = "Project1",
                    Id = 0
                },
                new Project(){
                Name = "Project2",
                Id = 1
                }
            };

            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetAll()).Returns(projectsExpected);
            var controller = new ProjectController(mock.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var projectsResult = okResult.Value as IEnumerable<Project>;

            mock.VerifyAll();
            CollectionAssert.AreEqual(projectsExpected, (System.Collections.ICollection)projectsResult, new ProjectComparer());
        }

        [TestMethod]
        public void Create()
        {
            Project projectExpected = new Project()
            {
                Name = "Project",
                Id = 0
            };

            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.Add(projectExpected)).Returns(projectExpected);
            var controller = new ProjectController(mock.Object);

            var result = controller.Post(projectExpected);
            var okResult = result as OkObjectResult;
            var projectResult = okResult.Value as Project;

            mock.VerifyAll();
            Assert.AreEqual(projectExpected, projectResult);
        }

        [TestMethod]
        public void GetProject()
        {
            Project projectExpected = new Project()
            {
                Name = "Project1",
                Id = 0
            };

            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetById(projectExpected.Id)).Returns(projectExpected);
            var controller = new ProjectController(mock.Object);

            var result = controller.Get(projectExpected.Id);
            var okResult = result as OkObjectResult;
            var projectResult = okResult.Value as Project;

            mock.VerifyAll();
            Assert.AreEqual(projectExpected, projectResult);
        }

        [TestMethod]
        public void GetProjectByName()
        {
            Project projectExpected = new Project()
            {
                Name = "Project1",
                Id = 0
            };

            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetByName(projectExpected.Name)).Returns(projectExpected);
            var controller = new ProjectController(mock.Object);

            var result = controller.GetByName(projectExpected.Name);
            var okResult = result as OkObjectResult;
            var projectResult = okResult.Value as Project;

            mock.VerifyAll();
            Assert.AreEqual(projectExpected, projectResult);
        }

        [TestMethod]
        public void Delete()
        {
            Project projectExpected = new Project()
            {
                Name = "project3",
                Id = 0
            };

            List<Project> project = new List<Project>()
            {
                projectExpected,
                new Project()
                {
                    Name = "buttonProj",
                    Id = 1
                },
                 new Project()
                {
                    Name = "myProject",
                    Id = 2
                },
            };

            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.Delete(projectExpected.Id)).Returns(new ResponseMessage(""));
            var controller = new ProjectController(mock.Object);

            var result = controller.Delete(projectExpected.Id);
            var okResult = result as OkObjectResult;
            mock.VerifyAll();

            Assert.IsTrue(okResult.Value is ResponseMessage);
        }

        [TestMethod]
        public void Update()
        {
            Project projectExpected = new Project()
            {
                Name = "proyectoEnEspaniol",
                Id = 0
            };

            Project projectModified = new Project()
            {
                Name = "project number 4",
                Id = 0
            };

            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.Update(projectExpected.Id, projectModified)).Returns(projectExpected);
            var controller = new ProjectController(mock.Object);

            var result = controller.Update(projectExpected.Id, projectModified);
            var okResult = result as OkObjectResult;
            var projectResult = okResult.Value as Project;

            mock.VerifyAll();
            Assert.AreEqual(projectExpected, projectResult);
        }


        [TestMethod]
        public void GetAllBugs()
        {
            List<Bug> bugsExpected = new List<Bug>()
            {
                new Bug(){
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                Id = 0
                },
                new Bug(){
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                Id = 1
                }
            };

            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetBugs()).Returns(bugsExpected);
            var controller = new ProjectController(mock.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var bugsResult = okResult.Value as IEnumerable<Bug>;

            mock.VerifyAll();
            CollectionAssert.AreEqual(bugsExpected, (System.Collections.ICollection)bugsResult, new BugComparer());
        }

        [TestMethod]
        public void AddBug()
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

            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.AddBug(bugExpected)).Returns(bugExpected);
            var controller = new ProjectController(mock.Object);

            var result = controller.Post(bugExpected);
            var okResult = result as OkObjectResult;
            var bugResult = okResult.Value as Bug;

            mock.VerifyAll();
            Assert.AreEqual(bugExpected, bugResult);
        }
    }
}
