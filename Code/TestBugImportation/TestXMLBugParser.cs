using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Xml;

namespace TestBugImportation
{
    [TestClass]
    public class TestXMLBugParser
    {
        const string baseDirectory = "./TestFiles/XMLTestFiles/";
        [TestMethod]
        public void ImportOneBug()
        {
            string fullPath = baseDirectory + "OneBug.xml";
            List<Bug> actualBugs = BugParserXML.GetBugs(fullPath);

            List<Bug> expectedBugs = new List<Bug>()
            {
                new Bug(){
                Name = "Error en el envío de correo",
                Description = "El error se produce cuando el usuario no tiene un correo asignado",
                Version = "1.0",
                IsActive = true,
                CompletedBy = null,
                Id = 1,
                Project = "Nombre del Proyecto"
                }
            };

            CollectionAssert.AreEquivalent(expectedBugs, actualBugs);
        }


        [TestMethod]
        public void ImportTwoBugs()
        {
            string fullPath = baseDirectory + "TwoBugs.xml";
            List<Bug> actualBugs = BugParserXML.GetBugs(fullPath);

            List<Bug> expectedBugs = new List<Bug>()
            {
                new Bug(){
                Name = "Error en el envío de correo",
                Description = "El error se produce cuando el usuario no tiene un correo asignado",
                Version = "1.0",
                IsActive = true,
                CompletedBy = null,
                Id = 1,
                Project = "Nombre del Proyecto"
                },
                new Bug()
                {
                 Name = "Error en el envío de correo 2",
                Description = "El error se produce cuando el usuario no tiene un correo asignado 2",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                Project = "Nombre del Proyecto",
                Id = 2
                }
            };

            CollectionAssert.AreEquivalent(expectedBugs, actualBugs);
        }

        [TestMethod]
        public void ImportThreeBugs()
        {
            string fullPath = baseDirectory + "ThreeBugs.xml";
            List<Bug> actualBugs = BugParserXML.GetBugs(fullPath);

            List<Bug> expectedBugs = new List<Bug>()
            {
                new Bug(){
                Name = "Error en el envío de correo",
                Description = "El error se produce cuando el usuario no tiene un correo asignado",
                Version = "1.0",
                IsActive = true,
                CompletedBy = null,
                Id = 1,
                Project = "Nombre del Proyecto"
                },
                new Bug()
                {
                 Name = "Error en el envío de correo 2",
                Description = "El error se produce cuando el usuario no tiene un correo asignado 2",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                Project = "Nombre del Proyecto",
                Id = 2
                },
                ,
                new Bug()
                {
                 Name = "Error en el envío de correo 3",
                Description = "El error se produce cuando el usuario no tiene un correo asignado 3",
                Version = "2",
                IsActive = true,
                CompletedBy = null,
                Project = "Nombre del Proyecto",
                Id = 2
                }
            };

            CollectionAssert.AreEquivalent(expectedBugs, actualBugs);
        }

        [TestMethod]
        public void ImportNoBugs()
        {
            string fullPath = baseDirectory + "NoBugs.xml";
            List<Bug> actualBugs = BugParserXML.GetBugs(fullPath);


            Assert.IsTrue(actualBugs.Count == 0);

            Assert.ThrowsException<NonexistentBugException>(() => bugBusinessLogic.Delete(idbugToDelete));
        }

        [TestMethod]
        public void InvalidXML()
        {
            string fullPath = baseDirectory + "InvalidXML.xml";
            Assert.ThrowsException<XmlException>(() => BugParserXML.GetBugs(fullPath);

        }

        [TestMethod]
        public void InvalidBugs()
        {// TODO testear cada propiedad? 
            string fullPath = baseDirectory + "InvalidBugs.xml";
            Assert.ThrowsException<XmlException>(() => BugParserXML.GetBugs(fullPath);

        }


    }

}
