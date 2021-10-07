using BusinessLogicInterfaces;
using Domain;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
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
            Assert.IsTrue(result is NoContentResult);
            mock.VerifyAll();

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
            Project project = new Project()
            {
                Name = "project3",
                Id = 1
            };


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
            mock.Setup(b => b.GetBugs(1)).Returns(bugsExpected);
            mock.Setup(b => b.Add(project)).Returns(project);
            var controller = new ProjectController(mock.Object);

            controller.Post(project);
            var result = controller.GetBugs(1);
            var okResult = result as OkObjectResult;
            var bugsResult = okResult.Value as IEnumerable<Bug>;

            mock.VerifyAll();
            CollectionAssert.AreEqual(bugsExpected, (System.Collections.ICollection)bugsResult, new BugComparer());
        }
        [TestMethod]
        public void GetBugsQuantity()
        {
            Project project = new Project()
            {
                Id = 1,
                Name = "project",
                Bugs = new List<Bug>()
                    {
                     new Bug(){
                         Name = "Bug",
                         Id = 0,
                     },
                     new Bug(){
                          Name = "Project2",
                          Id = 1
                     }
                }
            };

            int cantExpected = project.Bugs.Count();
            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetBugsQuantity(project.Id)).Returns(new BugsQuantity(cantExpected));
            var controller = new ProjectController(mock.Object);

            var result = controller.GetBugsQuantity(project.Id);
            var okResult = result as OkObjectResult;
            var cantResult = okResult.Value as BugsQuantity;

            mock.VerifyAll();
            Assert.AreEqual(cantExpected, cantResult.quantity);
        }

        [TestMethod]
        public void GetAllDevelopers()
        {
            List<Developer> devsExpected = new List<Developer>()
            {
                new Developer(){
                Name = "Ivan",
                Lastname = "monja",
                Username = "Ivo",
                Password = "456738",
                Email = "ivi@gmail.com"

                },
                new Developer(){
                Name = "Agustina",
                Lastname = "didios",
                Username = "Agus",
                Password = "rosadopastel",
                Email = "hell@yahoo.com"
                }
            };

            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
                Developers = devsExpected
            };


            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetDevelopers(project.Id)).Returns(devsExpected);
            mock.Setup(b => b.Add(project)).Returns(project);
            var controller = new ProjectController(mock.Object);

            controller.Post(project);
            var result = controller.GetDevelopers(project.Id);
            var okResult = result as OkObjectResult;
            var devsResult = okResult.Value as IEnumerable<Developer>;

            mock.VerifyAll();
            CollectionAssert.AreEqual(devsExpected, (System.Collections.ICollection)devsResult, new UserComparer());
        }

        [TestMethod]
        public void GetAllTesters()
        {
            List<Tester> testersExpected = new List<Tester>()
            {
                new Tester(){
                 Name = "Ivan",
                Lastname = "monja",
                Username = "Ivo",
                Password = "456738",
                Email = "ivi@gmail.com"

                },
                new Tester(){
                  Name = "Agustina",
                Lastname = "didios",
                Username = "Agus",
                Password = "rosadopastel",
                Email = "hell@yahoo.com"
                }
            };

            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
                Testers = testersExpected
            };


            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetTesters(project.Id)).Returns(testersExpected);
            mock.Setup(b => b.Add(project)).Returns(project);
            var controller = new ProjectController(mock.Object);

            controller.Post(project);
            var result = controller.GetTesters(project.Id);
            var okResult = result as OkObjectResult;
            var testersResult = okResult.Value as IEnumerable<Tester>;

            mock.VerifyAll();
            CollectionAssert.AreEqual(testersExpected, (System.Collections.ICollection)testersResult, new UserComparer());
        }

        [TestMethod]
        public void AddDeveloperToProject()
        {
            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
            };

            Developer devExpected = new Developer()
            {
                Id = 2,
                Name = "Agustina",
                Lastname = "didios",
                Username = "Agus",
                Password = "rosadopastel",
                Email = "hell@yahoo.com"
            };


            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.AddDeveloperToProject(project.Id, devExpected.Id)).Returns(devExpected);
            var controller = new ProjectController(mock.Object);

            var result = controller.AddDeveloperToProject(project.Id, devExpected.Id);
            var okResult = result as OkObjectResult;
            var devResult = okResult.Value as Developer;

            mock.VerifyAll();
            Assert.AreEqual(devExpected, devResult);
        }

        [TestMethod]
        public void AddTesterToProject()
        {
            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
            };

            Tester testerExpected = new Tester()
            {
                Id = 2,
                Name = "Agustina",
                Lastname = "didios",
                Username = "Agus",
                Password = "rosadopastel",
                Email = "hell@yahoo.com"
            };


            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.AddTesterToProject(project.Id, testerExpected.Id)).Returns(testerExpected);
            var controller = new ProjectController(mock.Object);

            var result = controller.AddTesterToProject(project.Id, testerExpected.Id);
            var okResult = result as OkObjectResult;
            var testerResult = okResult.Value as Tester;

            mock.VerifyAll();
            Assert.AreEqual(testerExpected, testerResult);
        }

        [TestMethod]
        public void DeleteDeveloperFromProject()
        {
            Project project = new Project()
            {
                Id = 1,
            };

            Developer dev = new Developer()
            {
                Id = 2,
                Name = "Agustina",
                Lastname = "didios",
                Username = "Agus",
                Password = "rosadopastel",
                Email = "hell@yahoo.com"
            };
            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.RemoveDeveloperFromProject(project.Id, dev.Id)).Returns(new ResponseMessage("Deleted from project"));
            var controller = new ProjectController(mock.Object);

            var result = controller.RemoveDeveloperFromProject(project.Id, dev.Id);
            var okResult = result as OkObjectResult;
            var devResult = okResult.Value as ResponseMessage;

            mock.VerifyAll();
            Assert.IsTrue(devResult is ResponseMessage);
        }

        [TestMethod]
        public void DeleteTesterFromProject()
        {
            Project project = new Project()
            {
                Id = 1,
            };

            Tester tester = new Tester()
            {
                Id = 2,
                Name = "Agustina",
                Lastname = "didios",
                Username = "Agus",
                Password = "rosadopastel",
                Email = "hell@yahoo.com"
            };
            var mock = new Mock<IProjectBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.RemoveTesterFromProject(project.Id, tester.Id)).Returns(new ResponseMessage("Deleted from project"));
            var controller = new ProjectController(mock.Object);

            var result = controller.RemoveTesterFromProject(project.Id, tester.Id);
            var okResult = result as OkObjectResult;
            var testerResult = okResult.Value as ResponseMessage;

            mock.VerifyAll();
            Assert.IsTrue(testerResult is ResponseMessage);
        }
    }
}
