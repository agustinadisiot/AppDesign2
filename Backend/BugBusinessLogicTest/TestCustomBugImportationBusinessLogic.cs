using BusinessLogic;
using CustomBugImportation;
using CustomBugImporter;
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
    public class TestCustomBugImportationBusinessLogic
    {

        [TestMethod]
        public void ImportBug()
        {
            ImportedBug importedBug1 = new ImportedBug()
            {
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                ProjectId = 3,
                IsActive = true,
                ProjectName = "project",
                CompletedById = 0,
                Time = 4,
            }; 

            Bug bug1 = new Bug()
            {
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                ProjectId = 3,
                IsActive = true,
                CompletedBy = null,
                Id = 0,
                CompletedById = 0,
                Time = 4,
                Project = new Project()
                {
                    Id = 3,
                    Name = "project"
                }
            };

            ImportedBug importedBug2 = new ImportedBug()
            {
                Name = "button",
                Description = "Upload not working",
                Version = "1.4.5",
                ProjectId = 2,
                IsActive = false,
                CompletedById = 0,
                Time = 4,
                ProjectName = "project2"
            };
            Bug bug2 = new Bug()
            {
                Name = "button",
                Description = "Upload not working",
                Version = "1.4.5",
                ProjectId = 2,
                IsActive = false,
                CompletedBy = null,
                Id = 1,
                CompletedById = 0,
                Time = 4,
                Project = new Project()
                {
                    Id = 2,
                    Name = "project2"
                }
            };


            string importerName = "Importer1";
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter(){
                    Name = "path",
                    Type = ParameterType.STRING,
                    Value = "example.com"
                },
                new Parameter(){
                    Name = "port",
                    Type = ParameterType.INTEGER,
                    Value = "80"
                }
            };

            List<ImportedBug> importedBugs = new List<ImportedBug>() { importedBug1, importedBug2 };
            List<Bug> expectedBugs = new List<Bug>() { bug1, bug2 };
            List<Bug> actualBugs = new List<Bug>() { };

            var importerMock = new Mock<ICustomBugImporter>(MockBehavior.Strict);
            importerMock.Setup(i => i.ImportBugs(importerName, parameters, null)).Returns(importedBugs);


            var mock = new Mock<IBugDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Create(It.IsAny<Bug>)).Returns(bug1);
            mock.Setup(b => b.Create(bug2)).Returns(bug2);
            var bugBusinessLogic = new BugBusinessLogic(mock.Object);

            bugBusinessLogic.ImportBugsCustom(importerName, parameters, importerMock.ob);

            mock.VerifyAll();
            importerMock.VerifyAll();
        }

       


    }
}
