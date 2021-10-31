using Domain;
using ExtensibleBugImporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Xml;

namespace TestExtensibleBugImporter
{
    [TestClass]
    public class TestFileParser
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
            string fullPath = baseDirectory + "OneEmptyImporter/";
            List<ImporterInfo> actualImporters = extensibleBugImporter.GetAvailableImporters();

            List<ImporterInfo> expectedImporters = new List<ImporterInfo>
            {
                new ImporterInfo {
                                ImporterName = "EmptyImporter",
                                Params = new List<Parameter>{}
                }
            };

            CollectionAssert.AreEqual(expectedImporters, actualImporters /*, new BugComparer()*/ );
        }


    }

}
