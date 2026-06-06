using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class BossEnemy : Enemy
    {
        public BossEnemy(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public virtual void DoUltimateAttack(ref Player playerAttacking)
        {
        }
    }
    public class SkeletonKing : BossEnemy
    {
        public SkeletonKing(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
        public override void DoUltimateAttack(ref Player playerAttacking)
        {
        }
    }
    public class DemonLord : BossEnemy
    {
        public DemonLord(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
        public override void DoUltimateAttack(ref Player playerAttacking)
        {
        }
    }
    public class FallenAngel : BossEnemy
    {
        public FallenAngel(string name, float currentHP, float atk, float defense, int goldDrop) : base(name, currentHP, atk, defense, goldDrop)
        {
        }
        public override void DoSuperAttack(ref Player playerAttacking)
        {
        }
        public override void DoUltimateAttack(ref Player playerAttacking)
        {
        }
    }
}
