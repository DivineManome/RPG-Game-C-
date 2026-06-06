using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Player : Character
    {
        private Gender _gender;
        private string _hairColour;
        private int _age;
        private int _gold;
        private List<Item> _items;
        public Player(Gender gender, string hairColour, int age, string name, float maxHP, float atk, float defense, int gold) : base(name, maxHP, atk, defense)
        {
            _gender = gender;
            _hairColour = hairColour;
            _age = age;
            _gold = gold;
            _items = new List<Item>
            {
                new Weapon("Sword", 1),
                new Consumable("Potion", 3),
                new Armor("Armor", 2),
            };
        }

        public int Age { get { return _age; } set { _age = value; } }
        public Gender Gender { get { return _gender; } set { _gender = value; } }
        public string HairColour { get { return _hairColour; } set { _hairColour = value; } }
        public int Gold { get { return _gold; } set { _gold = value; } }

        public void CheckInventory()
        {
            if (_items.Count == 0) { Console.WriteLine("You do not have any items at this moment"); Console.ReadKey(); Console.Clear(); return; }
            while (true)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    Console.WriteLine($"{_items[i].Name} ({_items[i].GetType().Name}): {_items[i].Quantity}x");
                }
                Console.Write("How would you like to sort this?\n1. Quality\n2. Name\n3. Item Type\n4. Exit\n> ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    if (option < 0 && option > 3)
                    {
                        Console.WriteLine("That number is not an option :("); Console.ReadKey();
                    }
                    else
                    {
                        switch (option)
                        {
                            case 1:
                                {
                                    _items.Sort((b, a) => a.Quantity.CompareTo(b.Quantity));
                                    break;
                                }
                            case 2:
                                {
                                    _items.Sort((a, b) => a.Name.CompareTo(b.Name));
                                    break;
                                }
                            case 3:
                                {
                                    _items.Sort((a, b) => a.GetType().Name.CompareTo(b.GetType().Name));
                                    break;
                                }
                            case 4:
                                {
                                    return;
                                }
                        }
                    }
                }
                Console.Clear();
            }    
        }
    }
}
