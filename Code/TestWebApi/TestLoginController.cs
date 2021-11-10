using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using BusinessLogicInterfaces;
using Domain;
using Domain.Utils;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;


namespace TestWebApi
{
    [TestClass]
    public class TestLoginController
    {

        [DataTestMethod]
        [DataRow("admin", "Juana1223#@", "adsfasdfasdfasdf")]
        [DataRow("dev12", "devvvv", "3hjg2jh34234")]
        [DataRow("Pedro", "testqetrty", "zxcmvnwn1312m312,3")]
        public void Login(string username, string password, string guid)
        {

            var mock = new Mock<ILoginBusinessLogic>(MockBehavior.Strict);
            mock.Setup(l => l.Login(username, password)).Returns(new LoginToken { Token = guid });
            var controller = new LoginController(mock.Object);


            var result = controller.Login(new LoginDTO
            {
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




