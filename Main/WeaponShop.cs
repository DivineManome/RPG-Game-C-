using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class WeaponShop
    {
        private List<Weapon> _weaponList;
        public WeaponShop()
        {
            _weaponList = new List<Weapon>
            {
                new Weapon("Wood Sword", 1, 5, 10),
                new Weapon("Bow", 1, 10, 30),
                new Weapon("Hammer", 1, 20, 100),
                new Weapon("Gun", 1, 50, 1000),
                new Weapon("Magic Sword", 1, 100, 2000),
                new Weapon("Demon Slayer", 1, 300, 5000),
            };
        }
        public void DisplayShop(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("Weapon Shop:");
                for (int i = 0; i < _weaponList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_weaponList[i].Name}: {_weaponList[i].Price}");
                }
                Console.Write("7. Exit\n> ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    if (option > 0 && option <= _weaponList.Count)
                    {
                        if (player.Gold >= _weaponList[option - 1].Price) { player.Gold -= _weaponList[option - 1].Price; player.AddItem(_weaponList[option - 1]); }
                        else { Console.WriteLine("Oops, you do not have enough gold to purchase this option :("); Console.ReadKey(); return; }
                        Console.Clear();
                        Console.Write($"You have successfully purchased [{_weaponList[option - 1].Name}].\nIt has been added to your inventory!");
                        Console.ReadKey();
                        return;
                    }
                    else if (option == 7)
                    {
                        return;
                    }
                }
                Console.Clear();
            }
        }
    }
}
