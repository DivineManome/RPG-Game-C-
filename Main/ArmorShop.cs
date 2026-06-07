using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class ArmorShop
    {
        private List<Armor> _armorList;
        public ArmorShop()
        {
            _armorList = new List<Armor>
            {
                new Armor("Light Armor", 1, 5, 5),
                new Armor("Mediam Armor", 1, 20, 10),
                new Armor("Heavy Armor", 1, 50, 30),
                new Armor("Demon Armor", 1, 80, 60),
                new Armor("Heavenly Armor", 1, 100, 70),
                new Armor("Kings Crown", 1, 1000, 150),
            };
        }
        public void DisplayShop(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("Weapon Shop:");
                for (int i = 0; i < _armorList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_armorList[i].Name}: {_armorList[i].Price}");
                }
                Console.Write("7. Exit\n> ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    if (option > 0 && option <= _armorList.Count)
                    {
                        if (player.Gold >= _armorList[option - 1].Price) { player.Gold -= _armorList[option - 1].Price; player.AddItem(_armorList[option - 1]); }
                        else { Console.WriteLine("Oops, you do not have enough gold to purchase this option :("); Console.ReadKey(); return; }
                        Console.Clear();
                        Console.Write($"You have successfully purchased [{_armorList[option - 1].Name}].\nIt has been added to your inventory!");
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
