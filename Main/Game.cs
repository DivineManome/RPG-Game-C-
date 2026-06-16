using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Game
    {
        protected Player _currentPlayer;

        public Game(Player currentPlayer) 
        {
            _currentPlayer = currentPlayer;
        }
        public bool EngageInBattle(Enemy enemy, bool bossBattle)
        {
            bool myTurn = true;
            while (true)
            {
                if (enemy.CurrentHP <= 0)
                {
                    Console.WriteLine($"You win and you are rewarded {enemy.GoldDrop} gold!");
                    Console.ReadKey();
                    _currentPlayer.Gold += enemy.GoldDrop;
                    return true;
                }
                if (_currentPlayer.CurrentHP <= 0)
                {
                    if (!bossBattle)
                    {
                        Console.WriteLine($"You lose and half of your gold was taken! ({_currentPlayer.Gold /= 2})");
                        Console.ReadKey();
                        _currentPlayer.Gold /= 2;
                    }
                    Console.Write($"Your health restored to full ({_currentPlayer.MaxHP})...");
                    _currentPlayer.CurrentHP = _currentPlayer.MaxHP;
                    return false;
                }
                _currentPlayer.Display();
                enemy.Display();
                if (myTurn)
                {
                    Console.WriteLine("\nIt is your turn, what would you like to do?:\n1. Attack\n2. Items");
                    if (!bossBattle) { Console.WriteLine("3. Flee"); }
                    Console.Write("> ");
                    if (int.TryParse(Console.ReadLine(), out int option))
                    {
                        switch (option)
                        {
                            case 1:
                                {
                                    Console.Clear();
                                    enemy.CurrentHP = _currentPlayer.Attacks(enemy);
                                    enemy.TempDef = 0;
                                    _currentPlayer.TempAtk = 0;
                                    Console.ReadKey();
                                    myTurn = false;
                                    break;
                                }
                            case 2: Console.Clear(); _currentPlayer.UseItem(enemy); myTurn = false; break;
                            case 3:
                                {
                                    if (bossBattle) { break; }
                                    Random randomNum = new Random();
                                    int fleeChance = randomNum.Next(1, 10);
                                    Console.Clear();
                                    Console.WriteLine("You try to flee!");
                                    Console.ReadKey();
                                    if (fleeChance <= 4)
                                    {
                                        Console.WriteLine("You fleed!");
                                        return false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You failed to flee!");
                                        Console.ReadKey();
                                    }
                                    myTurn = false;
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    Console.Write("It the enemies turn...");
                    Console.ReadKey();
                    Console.Clear();
                    Random random = new Random();
                    int randomOption = random.Next(10);
                    if (randomOption <= 6)
                    {
                        _currentPlayer.CurrentHP = enemy.Attacks(_currentPlayer);
                        _currentPlayer.TempDef = 0;
                        enemy.TempAtk = 0;
                        enemy.Superable = true;
                        Console.ReadKey();
                    }
                    else
                    {
                        enemy.DoSuperAttack(ref _currentPlayer);
                        _currentPlayer.TempDef = 0;
                        enemy.TempAtk = 0;
                        Console.ReadKey();
                    }
                    myTurn = true;
                }
                Console.Clear();
            }
        }

        public void StartGame()
        {
            SaveSystem saveSystem = new SaveSystem();
            BossCastle bossCastle = new BossCastle(_currentPlayer);
            Forest forest = new Forest(_currentPlayer);
            Town town = new Town(_currentPlayer);
            Mountains mountains = new Mountains(_currentPlayer);
            while (true)
            {
                Console.Write($"Main map:\n1. Town\n2. Forest\n3. Mountain\n4. Boss Castle (300 gold required)\n5. Check Inventory\n6. Change Equippment\n7. Save Game\n8. Load Game\n9. Exit Game\n> ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    if (option > 0 && option <= 9)
                    {
                        switch (option)
                        {
                            case 1: Console.Clear(); town.EnterTown(); break;
                            case 2: Console.Clear(); forest.EnterForest(); Console.ReadKey(); break;
                            case 3: Console.Clear(); mountains.EnterMountain(); Console.ReadKey(); break;
                            case 4:
                                {
                                    Console.Clear();
                                    if (_currentPlayer.Gold < 300)
                                    {
                                        Console.Write("You do not have enough gold to pay the penalty price. (300)...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    if (!bossCastle.EnterCastle())
                                    {
                                        Console.Write("\n300 gold is taken from losing...");
                                        Console.ReadKey();
                                        _currentPlayer.Gold -= 300;
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.Write("You have completed the game! "); _currentPlayer.Gold += 1000; Console.ReadKey(); break;
                                    }
                                }
                            case 5: Console.Clear(); _currentPlayer.CheckInventory(); break;
                            case 6: Console.Clear(); _currentPlayer.ChangeCurrentEqippment(); break;
                            case 7: Console.Clear(); SaveSystem.Save(_currentPlayer); Console.ReadKey(); break;
                            case 8:
                                {
                                    Console.Clear(); 
                                    if (SaveSystem.Load(_currentPlayer) != _currentPlayer)
                                    {
                                        bossCastle._currentPlayer = SaveSystem.Load(_currentPlayer);
                                        forest._currentPlayer = SaveSystem.Load(_currentPlayer);
                                        town._currentPlayer = SaveSystem.Load(_currentPlayer);
                                        Console.Write("Game Loaded!");
                                    }
                                    Console.ReadKey(); 
                                    break;
                                }
                            case 9: return;
                        }
                    }
                }
                Console.Clear();
            }
        }
    }
}
