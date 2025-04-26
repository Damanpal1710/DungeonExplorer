using System;

namespace DungeonExplorer
{
    public class Weapon : Item
    {
        public int Damage { get; private set; }

        public Weapon(string name, int damage) : base(name)
        {
            Damage = damage;
        }

        public override void Collect(Player player)
        {
            player.PickUpItem(this);
            Console.WriteLine($"{Name} added to inventory.");
        }

        public override void Use(Player player)
        {
            Console.WriteLine($"Using weapon {Name} to attack.");
        }
    }
}