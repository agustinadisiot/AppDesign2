using ExtensibleBugImporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CustomBugImportation;
using System.Xml;

namespace TestExtensibleBugImporter
{
    [TestClass]
    public class TestImporterFileParser
    {
        const string baseDirectory = "../../../../Reflection/CustomBugImportationTestImporters/TestFiles/";
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


    }

}
