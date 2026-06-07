using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class BossCastle : Game
    {
        private List<Enemy> _enemyType1;
        private List<Enemy> _enemyType2;
        private List<BossEnemy> _bossEnemy;
        public BossCastle(Player player) : base(player)
        {
            _enemyType1 = new List<Enemy>
            {
                new Goblin("Goblin", 0,0,0,0),
                new Boar("Boar", 0,0,0,0),
                new Cobra("Cobra", 0,0,0,0),
                new Spider("Spider", 0,0,0,0),
                new Bandit("Bandit", 0,0,0,0)
            };
            _enemyType2 = new List<Enemy>
            {
                new Yeti("Yeti", 0,0,0,0),
                new TribeMember("Tribe Member", 0,0,0,0),
                new Golem("Golem", 0,0,0,0),
                new Dragon("Dragon", 0,0,0,0),
                new Giant("Giant", 0,0,0,0)
            };
            _bossEnemy = new List<BossEnemy>
            {
                new SkeletonKing("Skeleton King", 0,0,0,0),
                new DemonLord("Demon Lord", 0,0,0,0),
                new FallenAngel("Fallen Angel", 0,0,0,0),
            };
        }
        public bool EnterCastle()
        {
            Console.Write("You enter the castle and you encounter...");
            Console.ReadKey();
            Console.Clear();
            Random random = new Random();
            Enemy firstEnemy = _enemyType1[random.Next(5)];
            firstEnemy.MaxHP = random.Next(80, 101);
            firstEnemy.CurrentHP = firstEnemy.MaxHP;
            firstEnemy.Atk = random.Next(5, 11);
            firstEnemy.Defense = random.Next(1, 6);
            Console.Write($"A {firstEnemy.Name}! engaging in battle...");
            Console.ReadKey();
            Console.Clear();
            bool ifWin = EngageInBattle(firstEnemy, true);
            if (!ifWin)
            {
                return false;
            }
            Console.Clear();
            Console.Write($"You move onto the next level...");
            Console.ReadKey();
            Console.Clear();
            Enemy secondEnemy = _enemyType2[random.Next(5)];
            secondEnemy.MaxHP = random.Next(200, 301);
            secondEnemy.CurrentHP = secondEnemy.MaxHP;
            secondEnemy.Atk = random.Next(20, 31);
            secondEnemy.Defense = random.Next(7, 11);
            Console.Write("You enter the second room and you encounter...");
            Console.ReadKey();
            Console.Clear();
            Console.Write($"A {secondEnemy.Name}! engaging in battle...");
            Console.ReadKey();
            Console.Clear();
            ifWin = EngageInBattle(secondEnemy, true);
            if (!ifWin)
            {
                return false;
            }
            Console.Clear();
            Console.Write($"You move onto the next level...");
            Console.ReadKey();
            Console.Clear();
            BossEnemy bossEnemy = _bossEnemy[random.Next(3)];
            bossEnemy.MaxHP = random.Next(1400, 1501);
            bossEnemy.CurrentHP = bossEnemy.MaxHP;
            bossEnemy.Atk = random.Next(100, 121);
            bossEnemy.Defense = random.Next(20, 31);
            Console.Write("You enter the boss room and you encounter...");
            Console.ReadKey();
            Console.Clear();
            Console.Write($"{bossEnemy.Name}! engaging in battle...");
            Console.ReadKey();
            Console.Clear();
            ifWin = EngageInBattle(bossEnemy, true);
            if (!ifWin)
            {
                return false;
            }
            Console.Clear();
            Console.Write($"You completed the castle, you are rewarded with 1000 gold!");
            Console.ReadKey();
            Console.Clear();
            return true;
        }
    }
}
