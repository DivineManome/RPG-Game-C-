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
        protected int _goldDrop;
        public Enemy(string name, float maxHP, float atk, float defense, int goldDrop) : base(name, maxHP, atk, defense)
        {
            _superable = true;
            _goldDrop = goldDrop;
        }
        public bool Superable { get { return _superable; } set { _superable = value; } }
        public int GoldDrop { get { return _goldDrop; } set { _goldDrop = value; } }
        public virtual void DoSuperAttack(ref Player playerAttacking)
        {
            if (_superable)
            {
                _superable = false;
                if (_atk * 2 - playerAttacking.Defense <= 0)
                {
                    Console.WriteLine($"The enemy does 0 damage to you. Your HP remains at {playerAttacking.CurrentHP} HP");
                    return;
                }
                if (playerAttacking.CurrentHP - (_atk * 2 - playerAttacking.Defense) <= 0)
                {
                    playerAttacking.CurrentHP = 0;
                    Console.WriteLine($"The enemy uses a super attack!\nYour HP goes down to 0");
                    return;
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
}
