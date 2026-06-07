using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Equippment : Item
    {
        protected float _boost;
        public Equippment(string name, int quantity, int price, float boost) : base(name, quantity, price) { _boost = boost; }

        public float Boost { get { return _boost; } set { _boost = value; } }
    }

    public class Weapon : Equippment
    {
        public Weapon(string name, int quantity, int price, float boost) : base(name, quantity, price, boost) {}
    }
    public class Armor : Equippment
    {
        public Armor(string name, int quantity, int price, float boost) : base(name, quantity, price, boost) {}
    }
}
