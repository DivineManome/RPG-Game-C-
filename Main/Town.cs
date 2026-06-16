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
        private ItemShop _itemShop;
        private ArmorShop _armorShop;
        private WeaponShop _weaponShop;
        public Town(Player player) : base(player)
        {
            _itemShop = new ItemShop();
            _armorShop = new ArmorShop();
            _weaponShop = new WeaponShop();
        }
        public void EnterTown()
        {
            while (true)
            {
                Console.Write("You have selected to go to the town. Where would you like to go?\n1. Inn (Restore HP to max)\n2. Item Shop (Buy Consumable Items)\n3. Weapon Shop\n4. Armor Shop\n5. Review Character stats & apperances\n6. Exit\n> ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1: Inn(); break;
                        case 2: EnterItemShop(); break;
                        case 3: EnterWeaponShop(); break;
                        case 4: EnterArmorShop(); break;
                        case 5: StatCheck(); break;
                        case 6: return;
                    }
                }
                else
                {
                    Console.WriteLine("That character is not an option :(");
                }
                Console.Clear();
            }
        }
        public void Inn()
        {
            Console.Clear();
            _currentPlayer.CurrentHP = _currentPlayer.MaxHP;
            Console.Write($"You have successfully restored your HP to max! ({_currentPlayer.MaxHP})");
            Console.ReadKey();
            Console.Clear();
        }
        public void EnterItemShop()
        {
            Console.Clear();
            _itemShop.DisplayShop(ref _currentPlayer);
            Console.Clear();

        }
        public void EnterArmorShop()
        {
            Console.Clear();
            _armorShop.DisplayShop(ref _currentPlayer);
            Console.Clear();

        }
        public void EnterWeaponShop()
        {
            Console.Clear();
            _weaponShop.DisplayShop(ref _currentPlayer);
            Console.Clear();
            
        }
        public void StatCheck()
        {
            Console.Clear();
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("|         CHARACTER INFO         |");
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine($"| Name       : {_currentPlayer.Name,-18}|");
            Console.WriteLine($"| Hair Colour: {_currentPlayer.HairColour,-18}|");
            Console.WriteLine($"| Gender     : {_currentPlayer.Gender,-18}|");
            Console.WriteLine($"| Age        : {_currentPlayer.Age,-18}|");
            Console.WriteLine($"| Gold       : {_currentPlayer.Gold,-18}|");
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine($"| Attack     : {_currentPlayer.Atk,-18}|");
            Console.WriteLine($"| Defense    : {_currentPlayer.Defense,-18}|");
            Console.WriteLine($"| HP         : {$"{_currentPlayer.CurrentHP}/{_currentPlayer.MaxHP}",-18}|");
            if (_currentPlayer.CurrentWeapon.Name != "")
            {
                Console.WriteLine($"| {_currentPlayer.CurrentWeapon.Name,-11}: {_currentPlayer.CurrentWeapon.Boost,-18}|");
            }
            if (_currentPlayer.CurrentArmor.Name != "")
            {
                Console.WriteLine($"| {_currentPlayer.CurrentArmor.Name,-11}: {_currentPlayer.CurrentArmor.Boost,-18}|");
            }
            Console.Write("+--------------------------------+");
            Console.ReadKey();
            Console.Clear();
        }   
    }
}
