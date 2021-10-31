using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Xml;

namespace TestExtensibleBugImporter
{
    [TestClass]
    public class TestFileParser
    {
        const string baseDirectory = "../../../TestFiles/";
        [TestInitialize]
        public void CreateBugParserInstance()
        {
            extensibleBugImporter = new ExtensibleBugImporter();
        }
        [TestMethod]
        public void GetAllImportersOneImporter()
        {
            string fullPath = baseDirectory + "OneImporer/";
            List<ImporterInfo> importers = extensibleBugImporter.GetAvailableImporters();

            List<ImporterInfo> expectedImporters = new List<ImporterInfo>
            {
                new ImporterInfo {
                                ImporterName,
                                new List<Params>{

                                }
            }
            CollectionAssert.AreEqual(expectedBugs, actualBugs, new BugComparer());
        }


    }

}
