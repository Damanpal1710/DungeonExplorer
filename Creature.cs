namespace DungeonExplorer
{
    public abstract class Creature : IDamageable
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }

        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }

        public virtual void Heal(int amount)
        {
            Health += amount;
        }

        public abstract void Attack(Creature target);
    }
}