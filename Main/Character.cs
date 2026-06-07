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
        protected Weapon _currentWeapon;
        protected Armor _currentArmor;

        public Character(string name, float maxHP, float atk, float defense)
        {
            _name = name;
            _maxHP = maxHP;
            _currentHP = maxHP;
            _atk = atk;
            _defense = defense;
            _currentArmor = new Armor("", 0, 0, 0);
            _currentWeapon = new Weapon("", 0, 0, 0);
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
            if (_currentWeapon.Name != "")
            {
                Console.WriteLine($"| {_currentWeapon.Name,-10}: {_currentWeapon.Boost,-9}|");
            }
            if (_currentArmor.Name != "")
            {
                Console.WriteLine($"| {_currentArmor.Name,-10}: {_currentArmor.Boost,-9}|");
            }
            Console.WriteLine("+----------------------+");
        }
        public float Attacks(Character enemyAttacked)
        {
            float damage = (_atk + _currentWeapon.Boost) - (enemyAttacked.Defense + enemyAttacked._currentArmor.Boost);
            if (damage <= 0) { damage = 0; }
            float newHP = enemyAttacked.CurrentHP - damage;
            if (newHP <= 0) { Console.Write($"{_name} does {damage} damage to {enemyAttacked.Name}\n{enemyAttacked.Name} HP goes down to 0 HP..."); return 0; }
            Console.WriteLine("+--------------------------------+");
            string attackText = $"[{_name}] attacks [{enemyAttacked.Name}]";
            Console.WriteLine($"| {attackText,-31}|");
            string hpText = $"{enemyAttacked.CurrentHP} -> {newHP}";
            Console.WriteLine($"| HP     : {hpText,-22}|");
            Console.Write("+--------------------------------+");
            return newHP;
        }
    }
}
