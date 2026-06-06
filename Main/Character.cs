using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Main
{
    public class Character
    {
        protected string _name;
        protected float _maxHP;
        protected float _currentHP;
        protected float _atk;
        protected float _defense;

        public Character(string name, float maxHP, float atk, float defense)
        {
            _name = name;
            _maxHP = maxHP;
            _currentHP = maxHP;
            _atk = atk;
            _defense = defense;
        }
        public string Name { get { return _name; } set { _name = value; } }
        public float MaxHP { get { return _maxHP; } set { _maxHP = value; } }
        public float CurrentHP { get { return _currentHP; } set { _currentHP = value; } }
        public float Atk { get { return _atk; } set { _atk = value; } }
        public float Defense { get { return _defense; } set { _defense = value; } }
        public void Display()
        {
            int digitCurrentHP = (int)(_currentHP % 10); // 3
            int digitMaxHP = (int)(_maxHP % 10); // 2
            int maxHPDisplay = 10 + Math.Abs(digitCurrentHP - digitMaxHP);
            Console.WriteLine("+----------------------+");
            Console.WriteLine($"| Name  : {_name,-13}|");
            Console.WriteLine($"| Attack   : {_atk,-10}|");
            Console.WriteLine($"| Defense : {_defense,-11}|");
            Console.WriteLine($"| HP      : {$"{_currentHP}/{_maxHP}",-11}|");
            Console.WriteLine("+----------------------+");
        }
        public float Attacks(Character enemyAttacked)
        {
            float damage = _atk - enemyAttacked.Defense;
            if (damage <= 0) { damage = 0; Console.WriteLine($"{_name} does {damage} damage to {enemyAttacked.Name}\n{enemyAttacked.Name} HP remains at {enemyAttacked.CurrentHP} HP"); return enemyAttacked.CurrentHP; }
            float newHP = enemyAttacked.CurrentHP - damage;
            if (newHP <= 0) { Console.WriteLine($"{_name} does {damage} damage to {enemyAttacked.Name}\n{enemyAttacked.Name} HP goes down to 0 HP"); return 0; }
            Console.WriteLine($"{_name} does {damage} damage to {enemyAttacked.Name}\n{enemyAttacked.Name} HP drops to {newHP} HP");
            return newHP;
        }
    }
}
