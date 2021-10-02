using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDomain
{
    [TestClass]
    public class TestTester
    {
        private User tester;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            tester = new Tester()
            {
                Id = 0,
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
            tester.Id = 1;
            int expected = 1;
            Assert.AreEqual(expected, tester.Id);
        }

        [TestMethod]
        public void NameGetSet()
        {
            tester.Name = "Ivan";
            string expected = "Ivan";
            Assert.AreEqual(expected, tester.Name);
        }

        [TestMethod]
        public void LastnameGetSet()
        {
            tester.Lastname = "Monjardin";
            string expected = "Monjardin";
            Assert.AreEqual(expected, tester.Lastname);
        }

        [TestMethod]
        public void UsernameGetSet()
        {
            tester.Username = "ivom";
            string expected = "ivom";
            Assert.AreEqual(expected, tester.Username);
        }

        [TestMethod]
        public void PasswordGetSet()
        {
            tester.Password = "myPasscode";
            string expected = "myPasscode";
            Assert.AreEqual(expected, tester.Password);
        }

    }
}

