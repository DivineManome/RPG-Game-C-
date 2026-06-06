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
        }
    }
    public class Bandit : Enemy
    {
        public Bandit(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
    public class Goblin : Enemy
    {
        public Goblin(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
    public class Cobra : Enemy
    {
        public Cobra(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
    public class Boar : Enemy
    {
        public Boar(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
}
