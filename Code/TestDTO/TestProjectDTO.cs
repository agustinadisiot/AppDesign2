using Domain;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TestDTO
{
    [TestClass]
    public class TestProjectDTO
    {
        private ProjectDTO projectDTO;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        { 
            projectDTO = new ProjectDTO()
            {
                Name = "Project",
            };
        }

        [TestMethod]
        public void NameGetSet()
        {
            projectDTO.Name = "Project1";
            string expected = "Project1";
            Assert.AreEqual(expected, projectDTO.Name);
        }

        [TestMethod]
        public void FromProjectToDTO()
        {
            Project project = new Project()
            {
               Id= 3,
               Name = "project"
            };

            ProjectDTO projectDTO = new ProjectDTO(project);

            Assert.AreEqual(project.Id, projectDTO.Id);
        }

        [TestMethod]
        public void FromDTOtoProject()
        {
            ProjectDTO projectDTO = new ProjectDTO()
            {
                Id = 3,
                Name = "project"
            };

            Project project = projectDTO.ConvertToDomain();

            Assert.AreEqual(project.Id, projectDTO.Id);
        }
    }
}
