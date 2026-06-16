using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            _items = new List<Item>();
        }

        public int Age { get { return _age; } set { _age = value; } }
        public Gender Gender { get { return _gender; } set { _gender = value; } }
        public string HairColour { get { return _hairColour; } set { _hairColour = value; } }
        public int Gold { get { return _gold; } set { _gold = value; } }
        public Weapon CurrentWeapon { get { return _currentWeapon; } set { _currentWeapon = value; } }
        public Armor CurrentArmor { get { return _currentArmor; } set { _currentArmor = value; } }
        public List<Item> Items { get { return _items; } set { _items = value; } }
        public void CheckInventory()
        {
            if (_items.Count == 0) { Console.Write("You do not have any items at this moment..."); Console.ReadKey(); Console.Clear(); return; }
            while (true)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    Console.WriteLine($"{_items[i].Name} ({_items[i].GetType().Name}): {_items[i].Quantity}x");
                }
                Console.Write("How would you like to sort this?\n1. Quality\n2. Name\n3. Item Type\n4. Exit\n> ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    if (option > 0 && option < 5)
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
        public void UseItem(Enemy enemy)
        {
            if (_items.Count == 0) { Console.Write("You do not have any items at this moment..."); Console.ReadKey(); Console.Clear(); return; }
            List<int> numbers = new List<int>();
            int count = 1;
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i] is Consumable eq)
                {
                    numbers.Add(i);
                    Console.WriteLine($"{count}. {eq.Name} ({eq.GetType().Name}): {eq.Quantity}x");
                    count++;
                }
            }
            Console.Write("> ");
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                if (option > 0 && option <= numbers.Count)
                {
                    int itemIndex = numbers[option - 1];

                    if (_items[itemIndex] is Consumable eq)
                    {
                        Console.Write($"You have changed your current Armor to [{eq.Name}]");
                        if (_items[itemIndex].Quantity > 1)
                        {
                            _items[itemIndex].Quantity--;
                        }
                        else
                        {
                            _items.RemoveAt(itemIndex);
                        }
                        if (_currentArmor.Name != "")
                        {
                            Console.Write($" and [{_currentArmor.Name}] has been moved to your inventory!");
                            AddItem(_currentArmor);
                        }
                        else
                        {
                            Console.Write("!");
                        }
                        eq.Ability(this, enemy);
                    }
                }
            }
        }
        public void AddItem(Item item)
        {
            Item foundItem = _items.Find(c => c.Name == item.Name);

            if (foundItem != null)
            {
                foundItem.Quantity += item.Quantity;
            }
            else
            {
                _items.Add(item);
            }
        }
        public void ChangeCurrentEqippment()
        {
            if (_items.Count == 0) { Console.Write("You do not have any items at this moment..."); Console.ReadKey(); Console.Clear(); return; }
            List<int> numbers = new List<int>();
            int count = 1;
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i] is Equippment eq)
                {
                    numbers.Add(i);
                    Console.WriteLine($"{count}. {eq.Name} ({eq.GetType().Name} Boost +{eq.Boost}): {eq.Quantity}x");
                    count++;
                }
            }
            Console.Write("> ");
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                if (option > 0 && option <= numbers.Count)
                {
                    int itemIndex = numbers[option - 1];

                    if (_items[itemIndex] is Armor armor)
                    {
                        Console.Write($"You have changed your current Armor to [{armor.Name}]");
                        if (_items[itemIndex].Quantity > 1)
                        {
                            _items[itemIndex].Quantity--;
                        }
                        else
                        {
                            _items.RemoveAt(itemIndex);
                        }
                        if (_currentArmor.Name != "")
                        {
                            Console.Write($" and [{_currentArmor.Name}] has been moved to your inventory!");
                            AddItem(_currentArmor);
                        }
                        else
                        {
                            Console.Write("!");
                        }
                        _currentArmor = armor;
                    }
                    else if (_items[itemIndex] is Weapon weapon)
                    {
                        Console.Write($"You have changed your current Weapon to [{weapon.Name}]");
                        if (_items[itemIndex].Quantity > 1)
                        {
                            _items[itemIndex].Quantity--;
                        }
                        else
                        {
                            _items.RemoveAt(itemIndex);
                        }
                        if (_currentWeapon.Name != "")
                        {
                            Console.Write($" and [{_currentWeapon.Name}] has been moved to your inventory!");
                            AddItem(_currentWeapon);
                        }
                        else
                        {
                            Console.Write("!");
                        }
                        _currentWeapon = weapon;
                    }
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
