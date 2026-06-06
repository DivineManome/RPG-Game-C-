using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Town : Game
    {
        public Town(Player player) : base(player) { }
        public void EnterTown()
        {
            while (true)
            {
                Console.Write("You have selected to go to the town. Where would you like to go?\n1. Inn (Restore HP to max)\n2. Item Shop (Buy Consumable Items)\n3. Weapon Shop\n4. Armor Shop\n5. Hospital (Review Character stats & apperances)\n6. Exit\n> ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1: Inn(); break;
                        case 2: EnterItemShop(); break;
                        case 3: EnterWeaponShop(); break;
                        case 4: EnterArmorShop(); break;
                        case 5: Hospital(); break;
                        case 6: return;
                        default: Console.WriteLine("That number is not an option :("); break;
                    }
                }
                else
                {
                    Console.WriteLine("That character is not an option :(");
                }
            }
        }
        public void Inn()
        {
            Console.Clear();
            _currentPlayer.CurrentHP = _currentPlayer.MaxHP;
            Console.WriteLine($"You have successfully healed to max HP ({_currentPlayer.MaxHP})");
            Console.ReadKey();
            Console.Clear();
        }
        public void EnterItemShop()
        {
            Console.Clear();
            Console.WriteLine("You have entered the item shop!");
            ItemShop itemShop = new ItemShop();
            itemShop.DisplayShop();
            Console.ReadKey();
            Console.Clear();

        }
        public void EnterArmorShop()
        {
            Console.Clear();
            Console.WriteLine("You have entered the Armor shop!");
            ArmorShop armorShop = new ArmorShop();
            armorShop.DisplayShop();
            Console.ReadKey();
            Console.Clear();

        }
        public void EnterWeaponShop()
        {
            Console.Clear();
            Console.WriteLine("You have entered the Weapon shop!");
            WeaponShop weaponShop = new WeaponShop();
            weaponShop.DisplayShop();
            Console.ReadKey();
            Console.Clear();
            
        }
        public void Hospital()
        {
            Console.Clear();
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("|         CHARACTER INFO         |");
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine($"| Name       : {_currentPlayer.Name,-18}|");
            Console.WriteLine($"| Hair Colour: {_currentPlayer.HairColour,-18}|");
            Console.WriteLine($"| Gender     : {_currentPlayer.Gender,-18}|");
            Console.WriteLine($"| Age        : {_currentPlayer.Age,-18}|");
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine($"| Attack     : {_currentPlayer.Atk,-18}|");
            Console.WriteLine($"| Defense    : {_currentPlayer.Defense,-18}|");
            Console.WriteLine($"| HP         : {$"{_currentPlayer.CurrentHP}/{_currentPlayer.MaxHP}",-18}|");
            Console.WriteLine("+--------------------------------+");
            Console.ReadKey();
            Console.Clear();
        }   
    }
}
