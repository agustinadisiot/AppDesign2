using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace TestDomain
{
    [TestClass]
    public class TestBug
    {
        private Bug bug;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            bug = new Bug()
            {
                Name = "Bug1",
                Description = "Cuando el servidor se cierra y estoy en login se rompe",
                Version = "12.4.5"
            };
        }
        [TestMethod]
        public void NameGetSet()
        {
            bug.Name = "bug1";
            string expected = "bug1";
            Assert.AreEqual(expected, bug.Name);
        }

        [TestMethod]
        public void DescriptionGetSet()
        {
            bug.Description = "No se pudo hacer la conexion con el data access";
            string expected = "No se pudo hacer la conexion con el data access";
            Assert.AreEqual(expected, bug.Description);
        }

        [TestMethod]
        public void VersionGetSet()
        {
            bug.Version = "14.2.1";
            string expected = "14.2.1";
            Assert.AreEqual(expected, bug.Version);
        }

        [TestMethod]
        public void IdGetSet()
        {
            bug.ID = 1;
            int expected = 1;
            Assert.AreEqual(expected, bug.ID);
        }

        [TestMethod]
        public void IsActive()
        {
            Assert.IsTrue(bug.IsActive);
        }

        [TestMethod]
        public void NullDeveloper()
        {
            Assert.IsNull(bug.CompletedBy);
        }

    }
}
