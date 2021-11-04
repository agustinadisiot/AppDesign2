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


    }

}
