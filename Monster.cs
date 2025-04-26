using System;

namespace DungeonExplorer
{
    public class Monster : Creature
    {
        public int AttackPower { get; private set; }

        public Monster(string name, int health, int attackPower) : base(name, health)
        {
            AttackPower = attackPower;
        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} for {AttackPower} damage.");
            target.TakeDamage(AttackPower);
        }
    }
}