namespace DungeonExplorer
{
    public abstract class Item : ICollectible
    {
        public string Name { get; protected set; }

        public Item(string name)
        {
            Name = name;
        }

        public abstract void Collect(Player player);
        public abstract void Use(Player player);
    }
}