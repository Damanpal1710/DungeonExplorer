using System;
using System.Media;

namespace DungeonExplorer
{
internal class Game
{
// make variables for player and room
private Player p;  // p is for player
private Room r;    // r is for room
    // constructor to start the game
    public Game()
    {

        string roomDesc = "You are in a dark dungeon room. There's a torch on the wall and what looks like an old chest in the corner.";
        r = new Room(roomDesc);
        
        Console.WriteLine("Welcome to Dungeon Explorer!");
        Console.WriteLine("---------------------------");
        Console.Write("What is your name?: ");
        string name = Console.ReadLine();
        
        p = new Player(name, 100);
        
        // print welcome message
        Console.WriteLine("Hello " + name + "!");
    }

    // main game method
    public void Start()
    {
        bool gameIsRunning = true;

        // main game loop
        while (gameIsRunning == true)
        {
            // print menu options
            Console.WriteLine("");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("----------------------");
            Console.WriteLine("1) Look at room");
            Console.WriteLine("2) See my stuff");
            Console.WriteLine("3) Get item");
            Console.WriteLine("4) Exit game");
            
            // get player choice
            string playerChoice = Console.ReadLine();

            if (playerChoice == "1")
            {
                // show room description
                string desc = r.GetDescription();
                Console.WriteLine("");
                Console.WriteLine(desc);
            }
            else if (playerChoice == "2")
            {
                // show player status
                Console.WriteLine("");
                Console.WriteLine("Your status:");
                Console.WriteLine("Name: " + p.Name);
                Console.WriteLine("HP: " + p.Health);
                Console.WriteLine("Your items: " + p.InventoryContents());
            }
            else if (playerChoice == "3")
            {
                // pick up key
                Console.WriteLine("");
                p.PickUpItem("Old Key");
                Console.WriteLine("You got an Old Key!");
            }
            else if (playerChoice == "4")
            {
                // exit game
                gameIsRunning = false;
                Console.WriteLine("");
                Console.WriteLine("Bye bye!");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Please pick 1, 2, 3 or 4!");
            }
        }
    }
}
}