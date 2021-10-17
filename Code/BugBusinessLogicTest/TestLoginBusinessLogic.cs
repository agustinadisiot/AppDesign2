using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using RepositoryInterfaces;
using Domain.Utils;
using Moq;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicInterfaces;
using BusinessLogicInterfaces.Utils;

namespace TestLoginBusinessLogic
{
    [TestClass]
    public class TestLoginBusinessLogic
    {
        [DataTestMethod]
        [DataRow("admin", "Juana1223#@", "adsfasdfasdfasdf")]
        [DataRow("dev12", "devvvv", "3hjg2jh34234")]
        [DataRow("Pedro", "testqetrty", "zxcmvnwn1312m312,3")]
        public void Login(string username, string password, string guid)
        {

            var mock = new Mock<ILoginDataAccess>(MockBehavior.Strict);
            mock.Setup(l => l.Login(username, password)).Returns(new LoginToken { Token = guid });
            var loginBusinessLogic = new LoginBusinessLogic(mock.Object);

            LoginToken loginResult = loginBusinessLogic.Login(username, password);
            mock.VerifyAll();
            Assert.AreEqual(loginResult.Token, guid);
        }
    }
}
