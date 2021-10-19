using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestDomain
{
    [TestClass]
    public class TestWork
    {
        private Work work;
        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            work = new Work()
            {
                Name = "Work",
            };
        }
        [TestMethod]
        public void NameGetSet()
        {
            work.Name = "work1";
            string expected = "work1";
            Assert.AreEqual(expected, work.Name);
        }

        [TestMethod]
        public void CostGetSet()
        {
            work.Cost = 4;
            int expected = 4;
            Assert.AreEqual(expected, work.Cost);
        }

        [TestMethod]
        public void TimeGetSet()
        {
            work.Time = 3;
            int expected = 3;
            Assert.AreEqual(expected, work.Time);
        }
    }
}
