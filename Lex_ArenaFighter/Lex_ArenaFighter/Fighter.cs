using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lex_ArenaFighter
{
    class Fighter
    {
        static Random rnd = new Random();

        int health = rnd.Next(4) + 7;
        int baseHealth;
        int damage = rnd.Next(3) + 3;
        string name;
        int dice;
        string[] computerNames = { "Adam", "Håkan", "Bernt", "Sture", "Stefan", "Bengt-Arne", "Evert", "Svert", "Bert", "Erolf", "Ingvar", "Lasse" };


        public Fighter()
        {
            Name = computerNames[rnd.Next(computerNames.Length)];
            BaseHealth = Health;
        }

        public int Health {
            get => health;
            set
            {
                health = value;
                if (value < 1) health = 0;                
            }
        }
        public int BaseHealth { get => baseHealth; protected set => baseHealth = value; }
        public int Damage { get => damage; protected set => damage = value; }
        public string Name { get => name; protected set => name = value; }
        public int Dice { get => dice; private set => dice = value; }

        public int ThrowDice()
        {
            Dice = rnd.Next(6) + 1;
            return Dice;
        }

       
    }
}
