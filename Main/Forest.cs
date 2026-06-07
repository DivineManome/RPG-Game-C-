using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Forest : Game
    {
        private List<Enemy> _enemies;
        private List<Item> _itemTypes;
        public Forest(Player player) : base(player)
        {
            _enemies = new List<Enemy>
            {
                new Goblin("Goblin", 0,0,0,0),
                new Boar("Boar", 0,0,0,0),
                new Cobra("Cobra", 0,0,0,0),
                new Spider("Spider", 0,0,0,0),
                new Bandit("Bandit", 0,0,0,0)
            };

            _itemTypes = new List<Item>
            {
                new HealPotion("Heal Potion", 1, 100),
                new Gernade("Gernade", 1, 150),
            };
        }
        public void EnterForest()
        {
            Console.Write("You enter the forest and you encounter...");
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
                encounteredEnemy.MaxHP = random.Next(80, 101);
                encounteredEnemy.CurrentHP = encounteredEnemy.MaxHP;
                encounteredEnemy.Atk = random.Next(5, 11);
                encounteredEnemy.Defense = random.Next(1, 6);
                encounteredEnemy.GoldDrop = random.Next(100, 151);
                Console.Write($"A {encounteredEnemy.Name}! engaging in battle...");
                Console.ReadKey();
                Console.Clear();
                EngageInBattle(encounteredEnemy, false);
            }
        }
    }
}