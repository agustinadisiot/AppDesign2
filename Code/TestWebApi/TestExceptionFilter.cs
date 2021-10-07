using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using BusinessLogicInterfaces;
using Domain;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;


namespace TestWebApi
{
    [TestClass]
    public class TestExceptionFilter
    {

        [TestMethod]
        public void ServerError()
        {
            var mock = new Mock<IAdminBusinessLogic>(MockBehavior.Strict);
            mock.Setup(a => a.Add(null)).Callback(() => throw new Exception());
            var controller = new AdminController(mock.Object);
            Admin adminExpected = null;
            var result = controller.Post(adminExpected);

            var errorResult = result as ObjectResult;
            var statusCode = errorResult.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(statusCode, 500);
        }
    }
};




