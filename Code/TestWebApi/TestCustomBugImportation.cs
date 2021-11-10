using BusinessLogicInterfaces;
using CustomBugImportation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

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

            var result = controller.GetCustomImportersInfo(); ;
            var okResult = result as OkObjectResult;
            var actualImportersInfo = okResult.Value as IEnumerable<ImporterInfo>;


            mock.VerifyAll();
            CollectionAssert.AreEquivalent(expectedImportersInfo, (System.Collections.ICollection)actualImportersInfo);
        }
    }
}
