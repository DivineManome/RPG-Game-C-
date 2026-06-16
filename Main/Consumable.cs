using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Consumable : Item
    {
        public Consumable(string name, int quantity, int price) : base(name, quantity, price)
        {
        }

        public virtual void Ability(Player player, Enemy enemy)
        {

        }
    }

    public class HealPotion : Consumable
    {
        public HealPotion(string name, int quantity, int price) : base(name, quantity, price)
        {
        }

        public override void Ability(Player player, Enemy enemy)
        {
            player.CurrentHP += 50;
        }
    }
    public class AtkPotion : Consumable
    {
        public AtkPotion(string name, int quantity, int price) : base(name, quantity, price)
        {
        }

        public override void Ability(Player player, Enemy enemy)
        {
            player.TempAtk += 30;
        }
    }
    public class DefensePotion : Consumable
    {
        public DefensePotion(string name, int quantity, int price) : base(name, quantity, price)
        {
        }

        public override void Ability(Player player, Enemy enemy)
        {
            player.TempDef += 30;
        }
    }
    public class Gernade : Consumable
    {
        public Gernade(string name, int quantity, int price) : base(name, quantity, price)
        {
        }

        public override void Ability(Player player, Enemy enemy)
        {
            if (enemy.CurrentHP <= 15) { enemy.CurrentHP = 0; return; }
            enemy.CurrentHP -= 15;
        }
    }
}
