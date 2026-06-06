using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Enemy : Character
    {
        protected bool _superable;
        public Enemy(string name, float maxHP, float atk, float defense) : base(name, maxHP, atk, defense)
        {
            _superable = true;
        }
        public bool Superable { get { return _superable; } set { _superable = value; } }
        public virtual void DoSuperAttack(ref Player playerAttacking)
        {
            if (_superable)
            {
                _superable = false;
                if (_atk * 2 - playerAttacking.Defense <= 0)
                {
                    Console.WriteLine($"The enemy does 0 damage to you. Your HP remains at {playerAttacking.CurrentHP} HP");
                }
                if (playerAttacking.CurrentHP - (_atk * 2 - playerAttacking.Defense) <= 0)
                {
                    playerAttacking.CurrentHP = 0;
                }
                Console.WriteLine($"The enemy uses a super attack!\nThey do {_atk * 2 - playerAttacking.Defense} damage to you");
                playerAttacking.CurrentHP -= (_atk * 2 - playerAttacking.Defense);
            }
            else
            {
                _superable = true;
                Console.WriteLine($"{Name} cannot use the super attack, it is on cool down.");
            }
        }
    }

    public class Spider : Enemy
    {
        public Spider(string name, float currentHP, float atk, float defense) : base(name, currentHP, atk, defense)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
    public class Bandit : Enemy
    {
        public Bandit(string name, float currentHP, float atk, float defense) : base(name, currentHP, atk, defense)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
    public class Goblin : Enemy
    {
        public Goblin(string name, float currentHP, float atk, float defense) : base(name, currentHP, atk, defense)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
    public class Cobra : Enemy
    {
        public Cobra(string name, float currentHP, float atk, float defense) : base(name, currentHP, atk, defense)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
    public class Boar : Enemy
    {
        public Boar(string name, float currentHP, float atk, float defense) : base(name, currentHP, atk, defense)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
}
