using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDomain
{
    [TestClass]
    public class TestAdmin
    {
        private User admin;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            admin = new Admin()
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
            developer.ID = 1;
            int expected = 1;
            Assert.AreEqual(expected, developer.ID);
        }

        [TestMethod]
        public void NameGetSet()
        {
            developer.Name = "Ivan";
            string expected = "Ivan";
            Assert.AreEqual(expected, developer.Name);
        }

        [TestMethod]
        public void LastnameGetSet()
        {
            developer.Lastname = "Monjardin";
            string expected = "Monjardin";
            Assert.AreEqual(expected, developer.Lastname);
        }

        [TestMethod]
        public void UsernameGetSet()
        {
            developer.Username = "ivom";
            string expected = "ivom";
            Assert.AreEqual(expected, developer.Username);
        }

        [TestMethod]
        public void PasswordGetSet()
        {
            developer.Password = "myPasscode";
            string expected = "myPasscode";
            Assert.AreEqual(expected, developer.Password);
        }
    }
}
