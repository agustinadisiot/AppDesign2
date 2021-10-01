using BusinessLogic;
using Dnp.Data.Objects;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace TestWebApi
{
    [TestClass]
    public class TestBugController
    {
        [TestMethod]
        public void GetAll()
        {
            List<Bug> bugsToReturn = new List<Bug>()
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

            var mock = new Mock<IBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetAll()).Returns(bugsToReturn);
            var controller = new BugController(mock.Object);

        }
    }
}

