using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Program
    {
        static void Main(string[] args)
        {
            World newWorld = new World(10);
            Neighborhoods neighborhoods = new Neighborhoods();
            Rules rules = new Rules();
            Console.WriteLine("Please select an option");
            Console.WriteLine("1 - block");
            Console.WriteLine("2 - oscillator");
            int x = int.Parse(Console.ReadLine());       
            switch (x)
            {
                case 1:
                    World blockWorld = neighborhoods.block(newWorld);
                    rules.startGame(blockWorld);
                    break;
                case 2:
                    World threeCellOsWorld = neighborhoods.ThreeCellOscillator(newWorld);
                    rules.startGame(threeCellOsWorld);
                    break;
                default:

                    break;
            }     
        }
    }
}
