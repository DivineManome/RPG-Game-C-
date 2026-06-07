using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Mountains : Game
    {
        private List<Enemy> _enemies;
        private List<Item> _itemTypes;
        public Mountains(Player player) : base(player)
        {
            _enemies = new List<Enemy>
            {
                new Yeti("Yeti", 0,0,0,0),
                new TribeMember("Tribe Member", 0,0,0,0),
                new Golem("Golem", 0,0,0,0),
                new Dragon("Dragon", 0,0,0,0),
                new Giant("Giant", 0,0,0,0)
            };

            _itemTypes = new List<Item>
            {
                new AtkPotion("Attack Potion", 1, 300),
                new DefensePotion("Defense Potion", 1, 250),
            };
        }
        public void EnterMountain()
        {
            Console.Write("You enter the mountain and you encounter...");
            Console.ReadKey();
            Console.Clear();
            Random random = new Random();
            int reward = random.Next(2);
            if (reward == 0)
            {
                int randomReward = random.Next(2);
                _currentPlayer.AddItem(_itemTypes[randomReward]);
                Console.Write($"You found a {_itemTypes[randomReward].Name}!");
            }
            else
            {
                Enemy encounteredEnemy = _enemies[random.Next(5)];
                encounteredEnemy.MaxHP = random.Next(200, 301);
                encounteredEnemy.CurrentHP = encounteredEnemy.MaxHP;
                encounteredEnemy.Atk = random.Next(20, 31);
                encounteredEnemy.Defense = random.Next(7, 11);
                encounteredEnemy.GoldDrop = random.Next(300, 351);
                Console.Write($"A {encounteredEnemy.Name}! engaging in battle...");
                Console.ReadKey();
                Console.Clear();
                EngageInBattle(encounteredEnemy, false);
            }
        }
    }
}
