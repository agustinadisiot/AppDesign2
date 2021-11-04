using ExtensibleBugImporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CustomBugImportation;
using System.Linq;

namespace TestExtensibleBugImporter
{
    [TestClass]
    public class TestImporterFileParser
    {
        const string baseDirectory = "../../../TestFiles/";
        private ExtensibleBugImporterManager extensibleBugImporter;
        [TestInitialize]
        public void CreateBugParserInstance()
        {
            extensibleBugImporter = new ExtensibleBugImporterManager();
        }

        [TestMethod]
        public void GetAllImportersOneImporter()
        {
            string fullPath = baseDirectory + "OneEmptyImporter";
            List<ImporterInfo> actualImportersInfo = extensibleBugImporter.GetAvailableImporters(fullPath);

            List<ImporterInfo> expectedImportersInfo = new List<ImporterInfo>
            {
                new ImporterInfo {
                                ImporterName = "Empty Importer",
                                Params = new List<Parameter>{}
                }
            };

            CollectionAssert.AreEquivalent(expectedImportersInfo, actualImportersInfo);
        }

        [TestMethod]
        public void GetAllImportersTwoImpoters()
        {
            string fullPath = baseDirectory + "TwoEmptyImporters";
            List<ImporterInfo> actualImportersInfo = extensibleBugImporter.GetAvailableImporters(fullPath);

            List<ImporterInfo> expectedImportersInfo = new List<ImporterInfo>
            {
                new ImporterInfo {
                                ImporterName = "Empty Importer",
                                Params = new List<Parameter>{}
                },
                new ImporterInfo {
                                ImporterName = "Empty Importer 2",
                                Params = new List<Parameter>{}
                }
            };

            CollectionAssert.AreEquivalent(expectedImportersInfo, actualImportersInfo);
        }

        [TestMethod]
        public void GetTwoBugs()
        {
            string fullPath = baseDirectory + "TwoBugsImporter";
            List<ImportedBug> importedBugs = extensibleBugImporter.ImportBugs("TwoBugsImporter", null, fullPath);

            List<ImportedBug> expectedBugs = new List<ImportedBug>
            {
                new ImportedBug(){
                    Name = "Bug1",
                    Description = "The first bug",
                    IsActive = true,
                    ProjectName =  "The mega project"
                },
                new ImportedBug(){
                    Name = "Bug2",
                    Description = "The second bug",
                    Time = 67,
                    ProjectId =  2
                }
            };

            Assert.IsTrue(expectedBugs.SequenceEqual(importedBugs));
        }


        [TestMethod]
        public void GetTwoBugsWithEmptyImporters()
        {
            string fullPath = baseDirectory + "TwoBugsImporterAndEmpty";
            List<ImportedBug> importedBugs = extensibleBugImporter.ImportBugs("TwoBugsImporter", null, fullPath);

            List<ImportedBug> expectedBugs = new List<ImportedBug>
            {
                new ImportedBug(){
                    Name = "Bug1",
                    Description = "The first bug",
                    IsActive = true,
                    ProjectName =  "The mega project"
                },
                new ImportedBug(){
                    Name = "Bug2",
                    Description = "The second bug",
                    Time = 67,
                    ProjectId =  2
                }
            };

            Assert.IsTrue(expectedBugs.SequenceEqual(importedBugs));
        }

        [TestMethod]
        public void GetBugsFailedImporter()
        {
            string fullPath = baseDirectory + "FailedImporter";
            List<ImportedBug> importedBugs = extensibleBugImporter.ImportBugs("FailedImporter", null, fullPath);
            Assert.IsTrue(importedBugs.Count == 0);
        }

        [TestMethod]
        public void GetBugImporterWithParams()
        {
            string fullPath = baseDirectory + "ImporterWithParams";

            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter(){
                    Name = "path",
                    ParameterType = ParameterType.STRING
                },
                new Parameter(){
                    Name = "port",
                    ParameterType = ParameterType.INTEGER
                }
            };

            List<ImportedBug> importedBugs = extensibleBugImporter.ImportBugs("ImporterWithParams", parameters, fullPath);

            List<ImportedBug> expectedBugs = new List<ImportedBug>
            {
                new ImportedBug(){
                    Name = "Bug1",
                    Description = "The first bug",
                    IsActive = true,
                    ProjectName =  "The mega project"
                },
                new ImportedBug(){
                    Name = "Bug2",
                    Description = "The second bug",
                    Time = 67,
                    ProjectId =  2
                },
                new ImportedBug(){
                    Name = "Bug3",
                    Description = "The third bug",
                    IsActive = false,
                    CompletedById =  2,
                    Version = "1.0.0"
                }
            };

            Assert.IsTrue(expectedBugs.SequenceEqual(importedBugs));
        }
    }

}
