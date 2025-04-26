using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        private Inventory inventory = new Inventory();

        public Player(string name, int health) : base(name, health)
        {
        }

        public void PickUpItem(Item item)
        {
            inventory.AddItem(item);
        }

        public string InventoryContents()
        {
            return inventory.ListItems();
        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} attacks {target.Name}.");
            target.TakeDamage(10);
        }

        public override void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} healed by {amount} points.");
        }
        public List<Item> GetInventoryItems()
        {
            return inventory.GetItems();
        }

    }
}
