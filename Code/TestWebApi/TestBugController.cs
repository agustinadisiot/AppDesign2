using System.Collections.Generic;
using BusinessLogic;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestWebApi.Utils;
using WebApi.Controllers;



namespace TestWebApi
{
    [TestClass]
    public class TestBugController
    {
        [TestMethod]
        public void GetAll()
        {
            List<Bug> bugExpected = new List<Bug>()
            {
                new Bug(){
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                ID = 0
                },
                new Bug(){
                Name = "Not working button",
                Description = "Upload button not working",
                Version = "1",
                IsActive = true,
                CompletedBy = null,
                ID = 1
                }
            };

            // TODO refactor a bug interfaces
            var mock = new Mock<IBusinessLogic<Bug>>(MockBehavior.Strict);
            mock.Setup(b => b.GetAll()).Returns(bugExpected);
            var controller = new BugController((IBusinessLogic<BugBusinessLogic>)mock.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var bugsResult = okResult.Value as IEnumerable<Bug>;

            mock.VerifyAll();
            CollectionAssert.AreEqual(bugExpected, (System.Collections.ICollection)bugsResult, new BugComparer());
        }
    }
}

