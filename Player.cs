using System.Collections.Generic;

namespace DungeonExplorer
{
public class Player
{
// player properties
public string Name { get; private set; }
public int Health { get; private set; }
    private List<string> items = new List<string>();

    public Player(string playerName, int playerHealth)
    {
        // set name and health
        Name = playerName;
        Health = playerHealth;
    }

    public void PickUpItem(string newItem)
    {
        // check if item exists
        if (newItem != "")
        {
            items.Add(newItem);
        }
    }

    public string InventoryContents()
    {
        if (items.Count > 0)
        {
            return string.Join(", ", items);
        }
        else
        {
            // no items
            return "Nothing";
        }
    }
}
