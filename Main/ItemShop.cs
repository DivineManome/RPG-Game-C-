using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class ItemShop
    {
        private List<Consumable> _consumables;
        public ItemShop()
        {
            _consumables = new List<Consumable>
            {
                new HealPotion("Heal Potion", 1, 100),
                new Gernade("Gernade", 1, 150),
                new DefensePotion("Defense Potion", 1, 250),
                new AtkPotion("Attack Potion", 1, 300),
            };
        }
        public void DisplayShop(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("Item Shop:");
                for (int i = 0; i < _consumables.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_consumables[i].Name}: {_consumables[i].Price}");
                }
                Console.Write("5. Exit\n> ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    if (option > 0 && option <= _consumables.Count)
                    {
                        if (player.Gold >= _consumables[option - 1].Price) { player.Gold -= _consumables[option - 1].Price; player.AddItem(_consumables[option - 1]); }
                        else { Console.WriteLine("Oops, you do not have enough gold to purchase this option :("); Console.ReadKey(); return; }
                        Console.Clear();
                        Console.Write($"You have successfully purchased [{_consumables[option - 1].Name}].\nIt has been added to your inventory!");
                        Console.ReadKey();
                        return;
                    }
                    else if (option == 5)
                    {
                        return;
                    }
                }
                Console.Clear();
            }
        }
    }
}
