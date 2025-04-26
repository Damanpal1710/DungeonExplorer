using System;

namespace DungeonExplorer
{
    using System.Collections.Generic;
    using System.Linq;

    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"{item.Name} added to inventory.");
        }
        public List<Item> GetItems()
        {
            return items;
        }
        
        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public IEnumerable<Item> GetItemsByType<T>() where T : Item
        {
            return items.OfType<T>();
        }

        public string ListItems()
        {
            if (items.Count == 0) return "Nothing";
            return string.Join(", ", items.Select(i => i.Name));
        }
    }
}