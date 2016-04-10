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
                blockWorld.worldSpots = (int[,]) blockWorld.limboWorldSpots.Clone();
                Array.Clear(blockWorld.limboWorldSpots, 0, blockWorld.limboWorldSpots.Length);
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

            World OsWorld = neighborhoods.threeCellOscillator(world);
            int neighborsAmount = rules.countNeighbors(3, 3, OsWorld);
            Assert.AreEqual(2, neighborsAmount);
        }
        [TestMethod]
        public void countTheLiveCellsOnOsc()
        {
            World world = new World(7);
            Rules rules = new Rules();
            Neighborhoods neighborhoods = new Neighborhoods();

            World OsWorld = neighborhoods.threeCellOscillator(world);
            Assert.IsTrue(OsWorld.worldSpots[3, 3] == 1);
            Assert.IsTrue(OsWorld.worldSpots[2, 3] == 1);
            Assert.IsTrue(OsWorld.worldSpots[4, 3] == 1);

        }
        [TestMethod]
        public void countTheLiveCellsOnOscAtIterator()
        {
            World world = new World(7);
            Rules rules = new Rules();
            Neighborhoods neighborhoods = new Neighborhoods();

            World oscWorld = neighborhoods.threeCellOscillator(world);
            while (rules.days < 5)
            {
                for (int row = 0; row < oscWorld.worldSpots.GetLength(0); row++)
                {
                    for (int col = 0; col < oscWorld.worldSpots.GetLength(1); col++)
                    {
                        int neighbors = rules.countNeighbors(row, col, oscWorld); //counts the neighbors around instance of cell
                        rules.updateLimboWorld(row, col, neighbors, oscWorld); //sets the value in limbo world at coordinate

                    }
                }
                oscWorld.worldSpots = (int[,])oscWorld.limboWorldSpots.Clone();
                Array.Clear(oscWorld.limboWorldSpots, 0, oscWorld.limboWorldSpots.Length);
                rules.days++;
            }

            World OsWorld = neighborhoods.threeCellOscillator(world);
            Assert.IsTrue(OsWorld.worldSpots[3, 3] == 1);
            Assert.IsTrue(OsWorld.worldSpots[3, 2] == 1);
            Assert.IsTrue(OsWorld.worldSpots[3, 4] == 1);

        }
        [TestMethod]
        public void checkToadDay0Position()
        {
            World world = new World(15);
            Rules rules = new Rules();
            Neighborhoods neighborhoods = new Neighborhoods();

            World toadWorld = neighborhoods.toad(world);

            Assert.IsTrue(toadWorld.worldSpots[5, 5] == 1);
            Assert.IsTrue(toadWorld.worldSpots[5, 6] == 1);
            Assert.IsTrue(toadWorld.worldSpots[5, 7] == 1);
            Assert.IsTrue(toadWorld.worldSpots[6, 4] == 1);
            Assert.IsTrue(toadWorld.worldSpots[6, 5] == 1);
            Assert.IsTrue(toadWorld.worldSpots[6, 6] == 1);
        }
        [TestMethod]
        public void checkToadDay1Position()
        {
            World world = new World(15);
            Rules rules = new Rules();
            Neighborhoods neighborhoods = new Neighborhoods();

            World toadWorld = neighborhoods.toad(world);

            while (rules.days < 1)
            {
                for (int row = 0; row < toadWorld.worldSpots.GetLength(0); row++)
                {
                    for (int col = 0; col < toadWorld.worldSpots.GetLength(1); col++)
                    {
                        int neighbors = rules.countNeighbors(row, col, toadWorld); //counts the neighbors around instance of cell
                        rules.updateLimboWorld(row, col, neighbors, toadWorld); //sets the value in limbo world at coordinate
                    }
                }

                toadWorld.worldSpots = (int[,])toadWorld.limboWorldSpots.Clone();
                Array.Clear(toadWorld.limboWorldSpots, 0, toadWorld.limboWorldSpots.Length);
                rules.days++;
            }

            //orig base 5,5
            Assert.IsTrue(toadWorld.worldSpots[5, 4] == 1); // toad day 1 base. one to left
            Assert.IsTrue(toadWorld.worldSpots[6, 4] == 1); // one down, one left
            Assert.IsTrue(toadWorld.worldSpots[7, 5] == 1); // two down 
            Assert.IsTrue(toadWorld.worldSpots[4, 6] == 1); // one up, one right
            Assert.IsTrue(toadWorld.worldSpots[5, 7] == 1); // two right
            Assert.IsTrue(toadWorld.worldSpots[6, 7] == 1); // one down, two right

        }
        [TestMethod]
        public void checkToadDay2Position()
        {
            World world = new World(15);
            Rules rules = new Rules();
            Neighborhoods neighborhoods = new Neighborhoods();

            World toadWorld = neighborhoods.toad(world);

            while (rules.days < 2)
            {
                for (int row = 0; row < toadWorld.worldSpots.GetLength(0); row++)
                {
                    for (int col = 0; col < toadWorld.worldSpots.GetLength(1); col++)
                    {
                        int neighbors = rules.countNeighbors(row, col, toadWorld); //counts the neighbors around instance of cell
                        rules.updateLimboWorld(row, col, neighbors, toadWorld); //sets the value in limbo world at coordinate
                    }
                }
                toadWorld.worldSpots = (int[,])toadWorld.limboWorldSpots.Clone();
                Array.Clear(toadWorld.limboWorldSpots, 0, toadWorld.limboWorldSpots.Length);
                rules.days++;
            }

            // back to orig base 5,5
            Assert.IsTrue(toadWorld.worldSpots[5, 5]  ==1);
            Assert.IsTrue(toadWorld.worldSpots[5, 6] == 1);
            Assert.IsTrue(toadWorld.worldSpots[5, 7] == 1);
            Assert.IsTrue(toadWorld.worldSpots[6, 4] == 1);
            Assert.IsTrue(toadWorld.worldSpots[6, 5] == 1);
            Assert.IsTrue(toadWorld.worldSpots[6, 6] == 1);

        }
        [TestMethod]
        public void checkHoneyCombDay0Position()
        {
            World world = new World(15);
            Rules rules = new Rules();
            Neighborhoods neighborhoods = new Neighborhoods();

            World honeyCombWorld = neighborhoods.honeyComb(world);

            // back to orig base 5,5
            Assert.IsTrue(honeyCombWorld.worldSpots[5, 5] == 1);
            Assert.IsTrue(honeyCombWorld.worldSpots[4, 6] == 1);
            Assert.IsTrue(honeyCombWorld.worldSpots[4, 7] == 1);
            Assert.IsTrue(honeyCombWorld.worldSpots[5, 8] == 1);
            Assert.IsTrue(honeyCombWorld.worldSpots[6, 7] == 1);
            Assert.IsTrue(honeyCombWorld.worldSpots[6, 6] == 1);
        }
        [TestMethod]
        public void checkHoneyCombDay1Position()
        {
            World world = new World(15);
            Rules rules = new Rules();
            Neighborhoods neighborhoods = new Neighborhoods();

            World honeycombWorld = neighborhoods.honeyComb(world);

            while (rules.days < 1)
            {
                for (int row = 0; row < honeycombWorld.worldSpots.GetLength(0); row++)
                {
                    for (int col = 0; col < honeycombWorld.worldSpots.GetLength(1); col++)
                    {
                        int neighbors = rules.countNeighbors(row, col, honeycombWorld); //counts the neighbors around instance of cell
                        rules.updateLimboWorld(row, col, neighbors, honeycombWorld); //sets the value in limbo world at coordinate
                    }
                }

                honeycombWorld.worldSpots = (int[,])honeycombWorld.limboWorldSpots.Clone();
                Array.Clear(honeycombWorld.limboWorldSpots, 0, honeycombWorld.limboWorldSpots.Length);
                rules.days++;
            }

            //orig base 5,5
            Assert.IsTrue(honeycombWorld.worldSpots[5, 5] == 1);
            Assert.IsTrue(honeycombWorld.worldSpots[4, 6] == 1);
            Assert.IsTrue(honeycombWorld.worldSpots[4, 7] == 1);
            Assert.IsTrue(honeycombWorld.worldSpots[5, 8] == 1);
            Assert.IsTrue(honeycombWorld.worldSpots[6, 7] == 1);
            Assert.IsTrue(honeycombWorld.worldSpots[6, 6] == 1);
        }
        [TestMethod]
        public void checkHoneyCombDay2Position()
        {
            World world = new World(15);
            Rules rules = new Rules();
            Neighborhoods neighborhoods = new Neighborhoods();

            World honeycombWorld = neighborhoods.honeyComb(world);

            while (rules.days < 2)
            {
                for (int row = 0; row < honeycombWorld.worldSpots.GetLength(0); row++)
                {
                    for (int col = 0; col < honeycombWorld.worldSpots.GetLength(1); col++)
                    {
                        int neighbors = rules.countNeighbors(row, col, honeycombWorld); //counts the neighbors around instance of cell
                        rules.updateLimboWorld(row, col, neighbors, honeycombWorld); //sets the value in limbo world at coordinate
                    }
                }

                honeycombWorld.worldSpots = (int[,])honeycombWorld.limboWorldSpots.Clone();
                Array.Clear(honeycombWorld.limboWorldSpots, 0, honeycombWorld.limboWorldSpots.Length);
                rules.days++;
            }

            //orig base 5,5
            Assert.IsTrue(honeycombWorld.worldSpots[5, 5] == 1);
            Assert.IsTrue(honeycombWorld.worldSpots[4, 6] == 1);
            Assert.IsTrue(honeycombWorld.worldSpots[4, 7] == 1);
            Assert.IsTrue(honeycombWorld.worldSpots[5, 8] == 1);
            Assert.IsTrue(honeycombWorld.worldSpots[6, 7] == 1);
            Assert.IsTrue(honeycombWorld.worldSpots[6, 6] == 1);
        }
    }

}
