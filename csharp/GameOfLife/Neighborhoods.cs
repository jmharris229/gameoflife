using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Neighborhoods
    {
        public World block(World existingWorld)
        {
            int col = 3;
            int row = 3;
            existingWorld.worldSpots[col, row] = 1;
            existingWorld.worldSpots[col, row+1] = 1;
            existingWorld.worldSpots[col+1, row] = 1;
            existingWorld.worldSpots[col+1, row+1] = 1;

            return existingWorld;
        }

        public World honeyComb(World existingWorld)
        {
            int row = 5;
            int col = 5;

            existingWorld.worldSpots[row, col] = 1; //far left middle , base
            existingWorld.worldSpots[row - 1, col + 1] = 1; // base up one over one
            existingWorld.worldSpots[row - 1, col + 2] = 1; //base up one over two
            existingWorld.worldSpots[row, col + 3] = 1; //base over three
            existingWorld.worldSpots[row + 1, col + 2] = 1; //base down one over two
            existingWorld.worldSpots[row + 1, col + 1] = 1; //base down one over one

            return existingWorld;
        }

        public World ThreeCellOscillator(World existingWorld)
        {
            int row = 3;
            int col = 3;
            existingWorld.worldSpots[row, col] = 1;
            existingWorld.worldSpots[row - 1, col] = 1;
            existingWorld.worldSpots[row + 1, col] = 1;

            return existingWorld;
        }

        public World toad(World existingWorld)
        {
            int row = 5;
            int col = 5;

            existingWorld.worldSpots[row, col] = 1; //top row left, base
            existingWorld.worldSpots[row, col+1] = 1; //top row middle
            existingWorld.worldSpots[row, col+2] = 1; //top row right
            existingWorld.worldSpots[row+1, col-1] = 1; //bottom row left
            existingWorld.worldSpots[row+1, col] = 1; //bottom row middle
            existingWorld.worldSpots[row+1, col+1] = 1; //bottom row right

            return existingWorld;
        }




    }
}
