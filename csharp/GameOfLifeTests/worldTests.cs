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
            Assert.IsNotNull(world.worldSpots);    
        }

        [TestMethod]
        public void EnsureWorldCreatingCorrectNumberSpaces()
        {
            World world = new World(5);
            Assert.AreEqual(25, world.worldSpots.Length);
        }

        [TestMethod]
        public void EnsureWorldSpotsHasFirstSpace()
        {
            World world = new World(5);
            Assert.AreEqual(0, world.worldSpots[0, 0]);
        }
        [TestMethod]
        public void EnsureWorldSpotsHasLastSpace()
        {
            World world = new World(5);
            Assert.AreEqual(0, world.worldSpots[4, 4]);
        }
        [TestMethod]
        public void EnsureWorldSpaceNotDefinedisZero()
        {
            World world = new World(5);
            Assert.AreEqual(0, world.worldSpots[2, 2]);
        }
    }
}
