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

        public World ThreeCellOscillator(World existingWorld)
        {
            Rules rules = new Rules();
            int row = 3;
            int col = 3;
            existingWorld.worldSpots[row, col] = 1;
            existingWorld.worldSpots[row -1, col] = 1;
            existingWorld.worldSpots[row +1, col] = 1;

            return existingWorld;
        }
    }
}
