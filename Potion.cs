using System;

namespace DungeonExplorer
{
    public class Potion : Item
    {
        public int HealAmount { get; private set; }

        public Potion(string name, int healAmount) : base(name)
        {
            HealAmount = healAmount;
        }

        public override void Collect(Player player)
        {
            player.PickUpItem(this);
            Console.WriteLine($"{Name} added to inventory.");
        }

        public override void Use(Player player)
        {
            player.Heal(HealAmount);
            Console.WriteLine($"{Name} used. Healed {HealAmount} HP.");
        }
    }
}