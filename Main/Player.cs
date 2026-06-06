using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Player : Character
    {
        private Gender _gender;
        private string _hairColour;
        private int _age;

        public Player(Gender gender, string hairColour, int age, string name, float maxHP, float atk, float defense) : base(name, maxHP, atk, defense)
        {
            _gender = gender;
            _hairColour = hairColour;
            _age = age;
        }

        public int Age { get { return _age; } set { _age = value; } }
        public Gender Gender { get { return _gender; } set { _gender = value; } }
        public string HairColour { get { return _hairColour; } set { _hairColour = value; } }
    }
}
