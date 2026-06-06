using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Item
    {
        protected string _name;
        protected int _quantity;
        public Item(string name, int quantity) { _name = name; _quantity = quantity; }
        public string Name { get { return _name; } set { _name = value; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
    }
}
