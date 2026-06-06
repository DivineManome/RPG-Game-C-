using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Yeti : Enemy
    {
        public Yeti(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
    public class TribeMember : Enemy
    {
        public TribeMember(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
    public class Golem : Enemy
    {
        public Golem(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
    public class Dragon : Enemy
    {
        public Dragon(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
    public class Giant : Enemy
    {
        public Giant(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
    }
}
