using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GameOfLife.tests
{
    [TestClass]
    public class worldTests
    {
        [TestMethod]
        public void EnsureWorldClassisInstantiated()
        {
            World world = new World(5);
            Assert.AreEqual(2, world.nomber);           
        }

        [TestMethod]
        public void EnsureWorldDictionaryHasRightSpaces()
        {
            World world = new World(5);
            bool ContainsFirstSpace = world.worldSpots.ContainsKey("0,0");
            Assert.IsTrue(ContainsFirstSpace);
        }
        [TestMethod]
        public void EnsureWorldDictionaryHasLastSpace()
        {
            World world = new World(5);
            bool ContainsLastSpace = world.worldSpots.ContainsKey("4,4");
            Assert.IsTrue(ContainsLastSpace);
        }
    }
}
