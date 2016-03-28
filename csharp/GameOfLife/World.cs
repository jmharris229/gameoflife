using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameOfLife
{
    public class World
    {


        public Dictionary<string, bool> worldSpots { get; set; }
        public int nomber = 2;

        public World(int size)
        {
            worldSpots = new Dictionary<string, bool>();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    worldSpots.Add(i+","+j, false);
                    j++;
                }
                i++;
            }
            Console.WriteLine("hello");
        }

    }
}
