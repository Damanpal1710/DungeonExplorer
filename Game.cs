using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player p;
        private GameMap map;
        private Room currentRoom;
        private List<Monster> monstersInRoom;

        public Game()
        {
            // Create rooms
            map = new GameMap();
            Room room1 = new Room("You are in a dark dungeon room. There's a torch on the wall and an old chest.");
            Room room2 = new Room("A damp chamber with strange markings on the floor.");
            map.AddRoom("room1", room1);
            map.AddRoom("room2", room2);

            // Add items to rooms
            Weapon sword = new Weapon("Sword", 15);
            Potion potion = new Potion("Healing Potion", 25);
            room1.AddItem(sword);
            room2.AddItem(potion);

            // Create monsters
            monstersInRoom = new List<Monster>
            {
                new Monster("Goblin", 30, 5),
                new Monster("Dragon", 100, 20)
            };

            // Set current room
            currentRoom = room1;

            // Player setup
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine("---------------------------");
            Console.Write("What is your name?: ");
            string name = Console.ReadLine();
            p = new Player(name, 100);
            Console.WriteLine($"Hello {name}!");
        }

        public void Start()
        {
            bool gameIsRunning = true;
            while (gameIsRunning)
            {
                Console.WriteLine();
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("----------------------");
                Console.WriteLine("1) Look at room");
                Console.WriteLine("2) See my stuff");
                Console.WriteLine("3) Pick up item");
                Console.WriteLine("4) Fight monster");
                Console.WriteLine("5) Move to another room");
                Console.WriteLine("6) Show all weapons in my inventory (LINQ)");
                Console.WriteLine("7) Find the strongest monster here (LINQ)");
                Console.WriteLine("8) Exit game");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine(currentRoom.GetDescription());
                        break;
                    case "2":
                        Console.WriteLine($"Your items: {p.InventoryContents()}");
                        break;
                    case "3":
                        PickUpItem();
                        break;
                    case "4":
                        FightMonster();
                        break;
                    case "5":
                        MoveRoom();
                        break;
                    case "6":
                        ShowWeaponsWithLINQ();
                        break;
                    case "7":
                        ShowStrongestMonsterWithLINQ();
                        break;
                    case "8":
                        gameIsRunning = false;
                        Console.WriteLine("Bye bye!");
                        break;
                    default:
                        Console.WriteLine("Please pick a valid option!");
                        break;
                }
            }
        }

        private void PickUpItem()
        {
            var items = currentRoom.GetItems();
            if (items.Count == 0)
            {
                Console.WriteLine("No items to pick up.");
                return;
            }
            Console.WriteLine("Items in the room:");
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine($"{i + 1}) {items[i].Name}");

            Console.Write("Pick item number: ");
            if (int.TryParse(Console.ReadLine(), out int itemNum) && itemNum > 0 && itemNum <= items.Count)
            {
                Item item = items[itemNum - 1];
                item.Collect(p);
                currentRoom.RemoveItem(item);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        private void FightMonster()
        {
            if (monstersInRoom.Count == 0)
            {
                Console.WriteLine("No monsters here!");
                return;
            }
            Console.WriteLine("Monsters in the room:");
            for (int i = 0; i < monstersInRoom.Count; i++)
                Console.WriteLine($"{i + 1}) {monstersInRoom[i].Name} (HP: {monstersInRoom[i].Health})");

            Console.Write("Choose monster number to attack: ");
            if (int.TryParse(Console.ReadLine(), out int monsterNum) && monsterNum > 0 && monsterNum <= monstersInRoom.Count)
            {
                Monster monster = monstersInRoom[monsterNum - 1];
                p.Attack(monster);
                if (monster.Health <= 0)
                {
                    Console.WriteLine($"{monster.Name} defeated!");
                    monstersInRoom.Remove(monster);
                }
                else
                {
                    monster.Attack(p);
                    if (p.Health <= 0)
                    {
                        Console.WriteLine("You have been defeated! Game over.");
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        private void MoveRoom()
        {
            if (currentRoom == map.GetRoom("room1"))
            {
                currentRoom = map.GetRoom("room2");
                Console.WriteLine("You move to the next room.");
            }
            else
            {
                currentRoom = map.GetRoom("room1");
                Console.WriteLine("You return to the previous room.");
            }
        }

        private void ShowWeaponsWithLINQ()
        {
            var weapons = p.GetInventoryItems().OfType<Weapon>().ToList();
            if (weapons.Count == 0)
            {
                Console.WriteLine("You have no weapons.");
            }
            else
            {
                Console.WriteLine("Your weapons:");
                weapons.ForEach(w => Console.WriteLine($"- {w.Name} (Damage: {w.Damage})"));
            }
        }

        private void ShowStrongestMonsterWithLINQ()
        {
            if (monstersInRoom.Count == 0)
            {
                Console.WriteLine("No monsters in the room.");
                return;
            }
            var strongest = monstersInRoom.OrderByDescending(m => m.AttackPower).First();
            Console.WriteLine($"The strongest monster here is {strongest.Name} (Attack Power: {strongest.AttackPower}, HP: {strongest.Health})");
        }
    }
}
