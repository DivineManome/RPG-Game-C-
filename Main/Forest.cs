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
        public Forest(Player player) : base(player)
        {
            _enemies = new List<Enemy>
            {
                new Goblin("Goblin", 0,0,0),
                new Boar("Boar", 0,0,0),
                new Cobra("Boar", 0,0,0),
                new Spider("Boar", 0,0,0),
                new Bandit("Boar", 0,0,0)
            };
        }
        public void EnterForest()
        {
            Random random = new Random();
            int reward = random.Next(2);
            if (reward == 0)
            {
                Console.WriteLine("You found a reward.\n");
            }
            else
            {
                float hp = random.Next(80, 101);
                Enemy encounteredEnemy = _enemies[random.Next(5)];
                encounteredEnemy.MaxHP = random.Next(80, 101);
                encounteredEnemy.CurrentHP = encounteredEnemy.MaxHP;
                encounteredEnemy.Atk = random.Next(5, 11);
                encounteredEnemy.Defense = random.Next(1, 6);
                EngageInBattle(encounteredEnemy);
            }
        }
    }
}