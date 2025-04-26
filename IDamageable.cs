namespace DungeonExplorer
{
    public interface IDamageable
    {
        void TakeDamage(int amount);
        void Heal(int amount);
        int Health { get; }
    }
}