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
        public void CreateInvalidAdmin()
        {
            Admin invalidAdmin = new Admin
            {
                Id = 1,
                Username = "admin",
                Name = "Pedro",
                Lastname = "Rodriguez",
                Email = "pedrooo@hotmail.com"

            };

            var mock = new Mock<IAdminDataAccess>(MockBehavior.Strict);
            mock.Setup(b => b.Create(invalidAdmin)).Returns(invalidAdmin);
            var adminBusinessLogic = new AdminBusinessLogic(mock.Object);

            Assert.ThrowsException<ValidationException>(() => adminBusinessLogic.Add(invalidAdmin));
            mock.Verify(m => m.Create(invalidAdmin), Times.Never);

        }
    }
}
