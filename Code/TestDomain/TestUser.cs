using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDomain
{
    [TestClass]
    public class TestUser
    {
        private User user;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            user = new User()
            {
                ID = 0,
                Username = "agustinadisiot",
                Name = "Agustina",
                Lastname = "Disiot",
                Password = "thisIsNotActuallyMyPassword",
                Email = "agus@email.com",
            };
        }

        [TestMethod]
        public void IdGetSet()
        {
            user.ID = 1;
            int expected = 1;
            Assert.AreEqual(expected, user.ID);
        }

        [TestMethod]
        public void NameGetSet()
        {
            user.Name = "Ivan";
            string expected = "Ivan";
            Assert.AreEqual(expected, user.Name);
        }

        [TestMethod]
        public void LastnameGetSet()
        {
            user.Lastname = "Monjardin";
            string expected = "Monjardin";
            Assert.AreEqual(expected, user.Lastname);
        }

        [TestMethod]
        public void UsernameGetSet()
        {
            user.Username = "ivom";
            string expected = "ivom";
            Assert.AreEqual(expected, user.Username);
        }

        [TestMethod]
        public void PasswordGetSet()
        {
            user.Password = "myPasscode";
            string expected = "myPasscode";
            Assert.AreEqual(expected, user.Password);
        }

    }
}
