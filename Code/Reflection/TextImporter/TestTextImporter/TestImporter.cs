using CustomBugImportation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TextImporter;

namespace TestTextImporter
{
    [TestClass]
    public class TestImporter
    {
        const string baseDirectory = "../../../TestFiles/";
        private Importer textImporter;

        [TestInitialize]
        public void CreateImporterInstance()
        {
            textImporter = new Importer();
        }

        [TestMethod]
        public void GetImporterInfo()
        {
            ImporterInfo actualImporterInfo = textImporter.GetImporterInfo();

            var expectedImporterInfo = new ImporterInfo
            {
                ImporterName = "Positional Text Importer",
                Params = new List<Parameter>
                {
                    new Parameter(){
                    Name = "Folder path",
                    Type = ParameterType.STRING,
                },
                new Parameter(){
                    Name = "File Name",
                    Type = ParameterType.INTEGER,
                }
                }
            };

            Assert.AreEqual(expectedImporterInfo, actualImporterInfo);
        }



        [TestMethod]
        public void ImportOneBug()
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter(){
                    Name = "Folder path",
                    Type = ParameterType.STRING,
                    Value = baseDirectory
                },
                new Parameter(){
                    Name = "File Name",
                    Type = ParameterType.INTEGER,
                    Value = "1"
                }
            };
            List<ImportedBug> actualBugs = textImporter.ImportBugs(parameters);

            List<ImportedBug> expectedBugs = new List<ImportedBug>()
            {
                new ImportedBug(){
                Name = "Bug1",
                Description = "This is the first bug from the json",
                Version = "1.00",
                IsActive = true,
                ProjectId = 3,
                ProjectName = "The Project",
                Time = 100
                }
            };
            Assert.IsTrue(actualBugs.SequenceEqual(expectedBugs));
        }
    }
}
