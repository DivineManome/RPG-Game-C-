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
        }
        public void EnterMountain()
        {
            Random random = new Random();
            int reward = random.Next(2);
            if (reward == 0)
            {
                Console.WriteLine("You found a reward.\n");
            }
            else
            {
                Enemy encounteredEnemy = _enemies[random.Next(5)];
                encounteredEnemy.MaxHP = random.Next(200, 301);
                encounteredEnemy.CurrentHP = encounteredEnemy.MaxHP;
                encounteredEnemy.Atk = random.Next(20, 31);
                encounteredEnemy.Defense = random.Next(7, 11);
                encounteredEnemy.GoldDrop = random.Next(300, 351);
                bool ifWin = EngageInBattle(encounteredEnemy);
                if (ifWin)
                {
                    Console.WriteLine($"You are rewarded {encounteredEnemy.GoldDrop} gold for killing {encounteredEnemy.Name}!");
                }
            }
        }
    }
}
