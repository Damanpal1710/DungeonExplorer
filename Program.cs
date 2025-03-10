using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************");
            Console.WriteLine("* DUNGEON EXPLORER *");
            Console.WriteLine("*******************");
            Console.WriteLine("");

            Game myGame = new Game();
            
            // start the game
            myGame.Start();

            Console.WriteLine("");
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}