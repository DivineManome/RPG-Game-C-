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

        public virtual void Ability()
        {

        }
    }

    public class HealPotion : Consumable
    {
        public HealPotion(string name, int quantity, int price) : base(name, quantity, price)
        {
        }

        public override void Ability()
        {

        }
    }
    public class AtkPotion : Consumable
    {
        public AtkPotion(string name, int quantity, int price) : base(name, quantity, price)
        {
        }

        public override void Ability()
        {

        }
    }
    public class DefensePotion : Consumable
    {
        public DefensePotion(string name, int quantity, int price) : base(name, quantity, price)
        {
        }

        public override void Ability()
        {

        }
    }
    public class Gernade : Consumable
    {
        public Gernade(string name, int quantity, int price) : base(name, quantity, price)
        {
        }

        public override void Ability()
        {

        }
    }
}
