using Domain;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TestDTOviejo
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
    }
}
