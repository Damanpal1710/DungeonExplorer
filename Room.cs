namespace DungeonExplorer
{
public class Room
{
private string desc;

    // make new room
    public Room(string roomDescription)
    {
        desc = roomDescription;
    }

    public string GetDescription()
    {
        return desc;
    }
}
}