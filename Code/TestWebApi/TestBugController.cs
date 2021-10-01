<<<<<<< HEAD
using System.Collections.Generic;
using BusinessLogic;
using BusinessLogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestWebApi.Utils;
using WebApi.Controllers;


=======
using BusinessLogic;
using Dnp.Data.Objects;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
>>>>>>> 5d59545... Adds web api first tests. Stage red

namespace TestWebApi
{
    [TestClass]
    public class TestBugController
    {
        [TestMethod]
        public void GetAll()
        {
<<<<<<< HEAD
            List<Bug> bugExpected = new List<Bug>()
=======
            List<Bug> bugsToReturn = new List<Bug>()
>>>>>>> 5d59545... Adds web api first tests. Stage red
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

<<<<<<< HEAD
            var mock = new Mock<IBugBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetAll()).Returns(bugExpected);
            var controller = new BugController(mock.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var bugsResult = okResult.Value as IEnumerable<Bug>;

            mock.VerifyAll();
            CollectionAssert.AreEqual(bugExpected, (System.Collections.ICollection)bugsResult, new BugComparer());
=======
            var mock = new Mock<IBusinessLogic>(MockBehavior.Strict);
            mock.Setup(b => b.GetAll()).Returns(bugsToReturn);
            var controller = new BugController(mock.Object);

>>>>>>> 5d59545... Adds web api first tests. Stage red
        }
    }
}

