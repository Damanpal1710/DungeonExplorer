using System.Collections.Generic;

namespace DungeonExplorer
{
public class Room
{
private string desc;

private List<Item> items = new List<Item>();
    // make new room
    public Room(string roomDescription)
    {
        desc = roomDescription;
    }

    public string GetDescription()
    {
        return desc;
    }
    public void AddItem(Item item) => items.Add(item);
    public void RemoveItem(Item item) => items.Remove(item);
    public List<Item> GetItems() => items;
}
}