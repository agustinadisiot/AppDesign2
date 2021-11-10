using BusinessLogicInterfaces;
using CustomBugImportation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApi
{
    [TestClass]
    public class TestCustomBugImportation
    {
        [TestMethod]
        public void GetImporters()
        {

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

            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetCustomImportersInfo());
            var controller = new BugController(mock.Object);

            List<ImporterInfo> actualImportersInfo = controller.GetCustomImportersInfo();

            mock.VerifyAll();
            CollectionAssert.AreEquivalent(expectedImportersInfo, actualImportersInfo);
        }
    }
}
