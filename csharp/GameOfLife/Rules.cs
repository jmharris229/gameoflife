using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Rules
    {
        public int days { get; set; }
        int x { get; set; }
        int y { get; set; }
        int stopper { get; set; }
        public Rules()
        {
            days = 0;
            x = 0;
            y = 0;
            stopper = 0;
        }

        public void startGame(World filledWorld)
        {
            while (stopper < 5)
            {
                for (int row = 0; row < filledWorld.worldSpots.GetLength(0); row++)
                {
                    for (int col = 0; col < filledWorld.worldSpots.GetLength(1) ; col++)
                    {
                        int neighbors = countNeighbors(row, col, filledWorld); //counts the neighbors around instance of cell
                        updateLimboWorld(row, col, neighbors, filledWorld); //sets the value in limbo world at coordinate
                    }
                }
                filledWorld.worldSpots = (int[,]) filledWorld.limboWorldSpots.Clone();
                Array.Clear(filledWorld.limboWorldSpots, 0, filledWorld.limboWorldSpots.Length);
                displayGrid(filledWorld);              
            }
        }

        public int countNeighbors(int row, int col, World world)
        {
            bool top = false;
            bool right = false;
            bool bottom = false;
            bool left = false;

            if(row == 0) { top = true; };
            if(col == 0) { left = true; };
            if (row == Math.Sqrt(world.worldSpots.Length)-1) { bottom = true; };
            if (col == Math.Sqrt(world.worldSpots.Length)-1) { right = true; };
            
            int counter = 0;

            if (!top)
            {
                if (world.worldSpots[row -1, col] == 1) //top center
                {
                    counter++;
                }
            }
            if (!(top || right))
            {
                if (world.worldSpots[row - 1, col +1] == 1) //top right
                {
                    counter++;
                }
            }
            if (!right)
            {
                if (world.worldSpots[row, col+1] == 1) //middle right
                {
                    counter++;
                }
            }
            if (!(bottom|| right))
            {
                if (world.worldSpots[row + 1, col + 1] == 1) //right bottom
                {
                    counter++;
                }
            }
            if (!bottom)
            {
                if (world.worldSpots[row +1, col] == 1) //middle bottom
                {
                    counter++;
                }
            }
            if (!(bottom || left))
            {
                if (world.worldSpots[row + 1, col - 1] == 1) // bottom left
                {
                    counter++;
                }
            }
            if (!left)
            {
                if (world.worldSpots[row, col-1] == 1) //middle left
                {
                    counter++;
                }
            }
            if (!(top || left))
            {
                if (world.worldSpots[row - 1, col - 1] == 1) //top left
                {
                    counter++;
                }
            }
            return counter;
        }

        public void updateLimboWorld(int row, int col, int neighbors, World world)
        {
            if (world.worldSpots[row, col] == 1)
            {
                if (neighbors < 2) //first rule - if less than 2 cell dies
                {
                    world.limboWorldSpots[row, col] = 0;
                }
                if (neighbors == 2 || neighbors == 3) //second rule - if 2 or 3 neighbors, lives on
                {
                    world.limboWorldSpots[row, col] = 1;
                }
                if (neighbors > 3) //rule 3 - dies if more than 3 neighbors
                {
                    world.limboWorldSpots[row, col] = 0;
                }
            }
            else
            {
                if (neighbors == 3) //rule 4 - if dead cell and 3 live neighbors, revive
                {
                    world.limboWorldSpots[row, col] = 1;
                }
            }
        }

        public void displayGrid(World updatedWorld)
        {
           Console.Clear();


            for (int row = 0; row < updatedWorld.worldSpots.GetLength(0); row++)
            {
                for (int col = 0; col < updatedWorld.worldSpots.GetLength(1); col++)
                {
                    if (updatedWorld.worldSpots[row,col] == 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            days++;
            Console.WriteLine("\r{0} days", days);
            //stopper++;
            //Console.ReadKey();

        }
    }
}
