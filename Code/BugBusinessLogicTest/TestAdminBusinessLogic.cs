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

namespace TestAdminBusinessLogic
{
    [TestClass]
    public class TestAdminBusinessLogic
    {


        [TestMethod]
        public void CreateAdmin()
        {
            Admin admin = new Admin
            {
                Id = 1,
                Username = "admin",
                Name = "Pedro",
                Lastname = "Rodriguez",
                Password = "asdfsdf3242",
                Email = "pedrooo@hotmail.com"

            };
            var mock = new Mock<IAdminDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Create(admin)).Returns(admin);
            var adminBusinessLogic = new AdminBusinessLogic(mock.Object);

            var adminResult = adminBusinessLogic.Add(admin);
            mock.VerifyAll();

            Assert.AreEqual(adminResult, admin);
        }

        [TestMethod]
        public void VerifyRole()
        {
            string token = "asdfdasf";
            var mock = new Mock<IAdminDataAccess>(MockBehavior.Strict);
            mock.Setup(m => m.VerifyRole(token)).Returns(true);
            var adminBusinessLogic = new AdminBusinessLogic(mock.Object);

            var isRole = adminBusinessLogic.VerifyRole(token);
            mock.VerifyAll();

            Assert.IsTrue(isRole);
        }

        [TestMethod]
        public void VerifyRoleNotValid()
        {
            string token = "23423423";
            var mock = new Mock<IAdminDataAccess>(MockBehavior.Strict);
            mock.Setup(m => m.VerifyRole(token)).Returns(false);
            var adminBusinessLogic = new AdminBusinessLogic(mock.Object);

            var isRole = adminBusinessLogic.VerifyRole(token);
            mock.VerifyAll();

            Assert.IsFalse(isRole);
        }

    }
}
