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
        public void EnterTown(ref Player player)
        {
            Console.Write("You have selected to go to the town. Where would you like to go?\n1. Inn (Restore HP to max)\n2. Item Shop (Buy Consumable Items)\n3. Weapon Shop\n4. Armor Shop\n5. Hospital (Review Character stats & apperances)\n6. Exit\n> ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1: Inn(ref player); return;
                        case 2: EnterItemShop(ref player); return;
                        case 3: EnterWeaponShop(ref player); return;
                        case 4: EnterArmorShop(ref player); return;
                        case 5: Hospital(ref player); return;
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
        public void Inn(ref Player player)
        {
            player.CurrentHP = player.MaxHP;
            Console.WriteLine("You have successfully healed to max HP");
        }
        public void EnterItemShop(ref Player player)
        {
            Console.WriteLine("You have entered the item shop!");
            ItemShop itemShop = new ItemShop();
            itemShop.DisplayShop();
            
        }
        public void EnterArmorShop(ref Player player)
        {
            Console.WriteLine("You have entered the Armor shop!");
            ArmorShop armorShop = new ArmorShop();
            armorShop.DisplayShop();
            
        }
        public void EnterWeaponShop(ref Player player)
        {
            Console.WriteLine("You have entered the Weapon shop!");
            WeaponShop weaponShop = new WeaponShop();
            weaponShop.DisplayShop();
            
        }
        public void Hospital(ref Player player)
        {
            Console.WriteLine($"Your Apperance/Stats\nName: {player.Name}\nHair Colour: {player.HairColour}\nGender: {player.Gender}\nAge: {player.Age}\n\nAttack: {player.Atk}\nDefense: {player.Defense}\nCurrent HP: {player.CurrentHP}\nMax HP: {player.MaxHP}");
        }
    }
}
