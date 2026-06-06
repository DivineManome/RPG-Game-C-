using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Consumable : Item
    {
        public Consumable(string name, int quantity) : base(name, quantity)
        {
        }
    }
}
