using BusinessLogic;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepositoryInterfaces;

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

    }
}
