using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Spider : Enemy
    {
        public Spider(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
            int damage = 10;
            if (playerAttacking.CurrentHP <= damage) { damage = (int)playerAttacking.CurrentHP; }
            Console.WriteLine($"{_name} does {damage} to you and gets +5 defense for 1 turn");
            _tempDef = 5;
            playerAttacking.CurrentHP -= damage;
        }
    }
    public class Bandit : Enemy
    {
        public Bandit(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
            int goldCount = 50;
            if (playerAttacking.Gold <= goldCount) { goldCount = playerAttacking.Gold; }
            Console.WriteLine($"{_name} takes {goldCount} gold from you.");
        }
    }
    public class Goblin : Enemy
    {
        public Goblin(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
            Console.WriteLine($"{_name} gets +20 attack for 1 turn.");
            _tempAtk = 20;
        }
    }
    public class Cobra : Enemy
    {
        public Cobra(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
            Console.WriteLine($"{_name} gets +10 defense for 1 turn.");
            _tempDef = 20;
        }
    }
    public class Boar : Enemy
    {
        public Boar(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
            int damage = 10;
            if (playerAttacking.CurrentHP <= damage) { damage = (int)playerAttacking.CurrentHP; }
            Console.WriteLine($"{_name} does {damage} to you.");
            playerAttacking.CurrentHP -= damage;
        }
    }
}
