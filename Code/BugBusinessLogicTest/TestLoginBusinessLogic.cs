using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using BusinessLogic;
using RepositoryInterfaces;
using Moq;
using System.Security.Authentication;

namespace TestLoginBusinessLogic
{
    [TestClass]
    public class TestLoginBusinessLogic
    {

        [DataTestMethod]
        [DataRow("admin", "Juana1223#@")]
        [DataRow("dev12", "devvvv")]
        [DataRow("Pedro", "testqetrty")]
        public void LoginTokenNotEmpty(string username, string password)
        {

            var mock = new Mock<ILoginDataAccess>(MockBehavior.Strict);

            mock.Setup(l => l.VerifyUser(username, password)).Returns(true);
            mock.Setup(l => l.SaveLogin(It.IsAny<LoginToken>()));
            var loginBusinessLogic = new LoginBusinessLogic(mock.Object);

            LoginToken token = loginBusinessLogic.Login(username, password);
            mock.VerifyAll();
            Assert.IsTrue(token.Token.Length > 0);
        }

        [DataTestMethod]
        [DataRow("admin", "Juana1223#@")]
        [DataRow("dev12", "devvvv")]
        [DataRow("Pedro", "testqetrty")]
        public void LoginTokenDifferentEachLogin(string username, string password)
        {

            var mock = new Mock<ILoginDataAccess>(MockBehavior.Strict);

            mock.Setup(l => l.VerifyUser(username, password)).Returns(true);
            mock.Setup(l => l.SaveLogin(It.IsAny<LoginToken>()));
            var loginBusinessLogic = new LoginBusinessLogic(mock.Object);

            LoginToken first = loginBusinessLogic.Login(username, password);
            LoginToken second = loginBusinessLogic.Login(username, password);
            mock.VerifyAll();
            Assert.IsTrue(first.Token != second.Token);
        }

        [TestMethod]
        public void LoginTokenDifferentEachLoginDifferentAccounts()
        {

            var mock = new Mock<ILoginDataAccess>(MockBehavior.Strict);

            mock.Setup(l => l.VerifyUser("admin", "Juana1223#@")).Returns(true);
            mock.Setup(l => l.VerifyUser("dev12", "devvvv")).Returns(true);
            mock.Setup(l => l.SaveLogin(It.IsAny<LoginToken>()));
            var loginBusinessLogic = new LoginBusinessLogic(mock.Object);

            LoginToken first = loginBusinessLogic.Login("admin", "Juana1223#@");
            LoginToken second = loginBusinessLogic.Login("dev12", "devvvv");
            mock.VerifyAll();
            Assert.IsTrue(first.Token != second.Token);
        }

        [TestMethod]
        public void LoginNotVerify()
        {
            var mock = new Mock<ILoginDataAccess>(MockBehavior.Strict);

            mock.Setup(l => l.VerifyUser("admin", "Juana1223#@")).Returns(false);
            var loginBusinessLogic = new LoginBusinessLogic(mock.Object);

            Assert.ThrowsException<AuthenticationException>(() => loginBusinessLogic.Login("admin", "Juana1223#@"));
        }
    }
}
