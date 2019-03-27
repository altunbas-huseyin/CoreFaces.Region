using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Region.UnitTest
{
    [TestClass]
    public class CityServiceTest : BaseTest
    {
        [TestMethod]
        public void DropTable()
        {
            bool result = _cityService.DropTables();
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void EnsureCreated()
        {
            bool result = _cityService.EnsureCreated();
            Assert.AreEqual(result, true);
        }
    }
}
