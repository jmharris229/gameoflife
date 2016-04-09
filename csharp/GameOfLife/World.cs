using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameOfLife
{
    public class World
    {
        public int[,] worldSpots { get; set; }
        public int[,] limboWorldSpots { get; set; }

        public World(int size)
        {
            worldSpots = new int[size, size];
            limboWorldSpots = new int[size, size];
        }

    }
}
