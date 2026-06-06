using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool EngageInBattle(Enemy enemy)
        {
            bool myTurn = true;
            while (true)
            {
                if (enemy.CurrentHP <= 0)
                {
                    Console.WriteLine("You win!");
                    Console.ReadKey();
                    return true;
                }
                if (_currentPlayer.CurrentHP <= 0)
                {
                    Console.WriteLine("You lose!");
                    Console.ReadKey();
                    return false;
                }
                _currentPlayer.Display();
                enemy.Display();
                if (myTurn)
                {
                    Console.Write("\nIt is your turn, what would you like to do?:\n1. Attack\n2. Items\n3. Flee\n> ");
                    if (int.TryParse(Console.ReadLine(), out int option))
                    {
                        switch (option)
                        {
                            case 1:
                                {
                                    Console.Clear();
                                    Console.WriteLine("You attack!");
                                    enemy.CurrentHP = _currentPlayer.Attacks(enemy);
                                    Console.ReadKey();
                                    myTurn = false;
                                    break;
                                }
                            case 2: Console.WriteLine("You open the Item Menu!"); Console.ReadKey(); myTurn = false; break; // items yet to be created
                            case 3:
                                {
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
                            default: Console.WriteLine("That number is not an option :("); Console.ReadKey(); break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("It the enemies turn...");
                    Console.ReadKey();
                    Console.Clear();
                    Random random = new Random();
                    int randomOption = random.Next(10);
                    if (randomOption <= 6)
                    {
                        Console.WriteLine("The enemy attacks");
                        _currentPlayer.CurrentHP = enemy.Attacks(_currentPlayer);
                        enemy.Superable = true;
                        Console.ReadKey();
                    }
                    else
                    {
                        enemy.DoSuperAttack(ref _currentPlayer);
                        Console.ReadKey();
                    }
                    myTurn = true;
                }
                Console.Clear();
            }
        }

        public void StartGame()
        {
            BossCastle bossCastle = new BossCastle(_currentPlayer);
            Forest forest = new Forest(_currentPlayer);
            Town town = new Town(_currentPlayer);
            Mountains mountains = new Mountains(_currentPlayer);
            _currentPlayer.CheckInventory();
            if (!bossCastle.EnterCastle())
            {
                Console.WriteLine("You lose 100 gold from losing");
                _currentPlayer.Gold -= 100;
            }
            mountains.EnterMountain();
            town.EnterTown();
            forest.EnterForest();
        }
    }
}
