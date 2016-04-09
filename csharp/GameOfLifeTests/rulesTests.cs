using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.tests
{
    [TestClass]
    public class testRules
    {
        [TestMethod]
        public void countTheNeighborsOnBlock()
        {
            World world = new World(7);
            Rules rules = new Rules();
            Neighborhoods neighborhoods = new Neighborhoods();

            World blockWorld = neighborhoods.block(world);
            int neighborsAmount = rules.countNeighbors(3,3,blockWorld);
            Assert.AreEqual(3, neighborsAmount);                       
        }
        [TestMethod]
        public void countTheNeighborsOnDeadCellonBlock()
        {
            World world = new World(7);
            Rules rules = new Rules();
            Neighborhoods neighborhoods = new Neighborhoods();

            World blockWorld = neighborhoods.block(world);
            int neighborsAmount = rules.countNeighbors(3, 2, blockWorld);
            Assert.AreEqual(0, world.worldSpots[4,2]);            
        }
        [TestMethod]
        public void CountLiveCellsOnIterationOnBlock()
        {
            World world = new World(7);
            Rules rules = new Rules();
            Neighborhoods neighborhoods = new Neighborhoods();
            World blockWorld = neighborhoods.block(world);
            int counter = 0;
            while (rules.days < 5)
            {
                for (int row = 0; row < blockWorld.worldSpots.GetLength(0); row++)
                {
                    for (int col = 0; col < blockWorld.worldSpots.GetLength(1); col++)
                    {
                        int neighbors = rules.countNeighbors(row, col, blockWorld); //counts the neighbors around instance of cell
                        rules.updateLimboWorld(row, col, neighbors, blockWorld); //sets the value in limbo world at coordinate
                        rules.days++;
                    }
                }
                blockWorld.worldSpots = blockWorld.limboWorldSpots;
            }
            for (int row = 0; row < blockWorld.worldSpots.GetLength(0); row++)
            {
                for (int col = 0; col < blockWorld.worldSpots.GetLength(1); col++)
                {
                    if(blockWorld.worldSpots[row,col] == 1)
                    {
                        counter++;
                    }
                }
            }

            Assert.AreEqual(4, counter);

        }
        [TestMethod]
        public void countTheNeighborsOnOsc()
        {
            World world = new World(7);
            Rules rules = new Rules();
            Neighborhoods neighborhoods = new Neighborhoods();

            World OsWorld = neighborhoods.ThreeCellOscillator(world);
            int neighborsAmount = rules.countNeighbors(3, 3, OsWorld);
            Assert.AreEqual(2, neighborsAmount);
        }
        [TestMethod]
        public void countTheLiveCellsOnOsc()
        {
            World world = new World(7);
            Rules rules = new Rules();
            Neighborhoods neighborhoods = new Neighborhoods();

            World OsWorld = neighborhoods.ThreeCellOscillator(world);
            Assert.IsTrue(OsWorld.worldSpots[3, 3] == 1);
            Assert.IsTrue(OsWorld.worldSpots[2, 3] == 1);
            Assert.IsTrue(OsWorld.worldSpots[4, 3] == 1);

        }
    }

}
