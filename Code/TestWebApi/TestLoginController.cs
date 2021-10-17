using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using BusinessLogicInterfaces;
using BusinessLogicInterfaces.Utils;
using Domain;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;


namespace TestWebApi
{
    [TestClass]
    public class TestLoginController
    {

        [TestMethod]
        public void Login()
        {
            string username = "admin";
            string password = "Juana1223#@";

            var mock = new Mock<ILoginBusinessLogic>(MockBehavior.Strict);
            string guid = "adsfasdfasdfasdf";
            mock.Setup(l => l.Login(username, password)).Returns(new LoginToken { Token = guid });
            var controller = new LoginController(mock.Object);


            var result = controller.Login(new LoginDTO { 
            Username = username,
            Password = password
            });
            var okResult = result as OkObjectResult;
            var loginResult = okResult.Value as LoginToken;

            mock.VerifyAll();
            Assert.AreEqual(loginResult.Token, guid);
        }
    }
};




