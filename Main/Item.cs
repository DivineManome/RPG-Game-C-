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
        protected int _price;
        public Item(string name, int quantity, int price) { _name = name; _quantity = quantity; _price = price; }
        public string Name { get { return _name; } set { _name = value; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }

        public int Price { get { return _price; } set { _price = value; } }
    }
}
