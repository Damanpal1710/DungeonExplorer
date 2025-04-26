namespace DungeonExplorer
{
    public interface ICollectible
    {
        string Name { get; }
        void Collect(Player player);
    }
}