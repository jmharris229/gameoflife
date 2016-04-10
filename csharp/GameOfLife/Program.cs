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
            World newWorld = new World(30);
            Neighborhoods neighborhoods = new Neighborhoods();
            Rules rules = new Rules();

            //initial message to screen
            Console.WriteLine("Please select an option");
            Console.WriteLine("1 - Block");
            Console.WriteLine("2 - Honeycomb");
            Console.WriteLine("3 - Three Cell Oscillator");
            Console.WriteLine("4 - Toad");
            Console.WriteLine("5 - Random");

            int x = int.Parse(Console.ReadLine());
            string keyMessage = "Press any key to start your game";     
            switch (x)
            {
                case 1:
                    World blockWorld = neighborhoods.block(newWorld);
                    rules.displayGrid(blockWorld);
                    Console.WriteLine(keyMessage);
                    Console.ReadKey();
                    rules.startGame(blockWorld);
                    break;
                case 2:
                    World honeyCombWorld = neighborhoods.honeyComb(newWorld);
                    rules.displayGrid(honeyCombWorld);
                    Console.WriteLine(keyMessage);
                    Console.ReadKey();
                    rules.startGame(honeyCombWorld);
                    break;
                case 3:
                    World threeCellOsWorld = neighborhoods.threeCellOscillator(newWorld);
                    rules.displayGrid(threeCellOsWorld);
                    Console.WriteLine(keyMessage);
                    Console.ReadKey();
                    rules.startGame(threeCellOsWorld);
                    break;
                case 4:
                    World toad = neighborhoods.toad(newWorld);
                    rules.displayGrid(toad);
                    Console.WriteLine(keyMessage);
                    Console.ReadKey();
                    rules.startGame(toad);
                    break;
                case 5:
                    World random = neighborhoods.random(newWorld);
                    rules.displayGrid(random);
                    Console.WriteLine(keyMessage);
                    Console.ReadKey();
                    rules.startGame(random);
                    break;                
                default:
                    World defaultRandom = neighborhoods.random(newWorld);
                    rules.displayGrid(defaultRandom);
                    Console.WriteLine(keyMessage);
                    Console.ReadKey();
                    rules.startGame(defaultRandom);
                    break;
            }     
        }
    }
}
