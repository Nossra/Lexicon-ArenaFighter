using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lex_ArenaFighter
{
    class Fighter
    {

        //test
        static Random rnd = new Random();

        int health = rnd.Next(4) + 7;
        int baseHealth;
        int damage = rnd.Next(3) + 3;
        string name;
        int dice;
        string[] computerNames = { "Adam", "Håkan", "Bernt", "Sture", "Stefan" };
        bool isPlayer;        

        public Fighter()
        {
            Name = computerNames[rnd.Next(computerNames.Length)];
            isPlayer = false;
            BaseHealth = Health;
        }

        public Fighter(bool isPlayer) : this()
        {
            this.Name = SetName();
            this.isPlayer = isPlayer;
            PlayerBoost();
        }

        public void PlayerBoost()
        {
            const double PLAYER_MULTIPLIER = 1.2;

            this.Health = Convert.ToInt32(Health * PLAYER_MULTIPLIER);
            this.BaseHealth = Convert.ToInt32(BaseHealth * PLAYER_MULTIPLIER);
            this.Damage = Convert.ToInt32(Damage * PLAYER_MULTIPLIER);
        }

        public int Health {
            get => health;
            set
            {
                health = value;
                if (value < 1) health = 0;
            }
        }
        public int BaseHealth { get => baseHealth; private set => baseHealth = value; }
        public int Damage { get => damage; private set => damage = value; }
        public string Name { get => name; private set => name = value; }

        public int ThrowDice()
        {
            dice = rnd.Next(6) + 1;
            return dice;
        }

        public string SetName()
        {
            bool settingName = true;

            while (settingName)
            {
                Name = Console.ReadLine();
                if (!CheckNameLength())
                {
                    Console.WriteLine("Name is too long! Try again:");
                }
                else if (!CheckAllowedCharacters())
                {
                    Console.WriteLine("Your name can only hold normal alphabetic characters! Try again:");
                }
                else
                {
                    settingName = false;
                    return Name;
                }
            }
            return Name;
        }

        private bool CheckAllowedCharacters()
        {
            string allowedChars = "abcdefghijklmnopqrstuvwxyzåäöABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ";

            foreach (char nameInput in Name)
            {
                if (!allowedChars.Contains(nameInput.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckNameLength()
        {
            if (Name.Length > 10)
            {
                return false;
            }
            return true;
        }

        public void PrintCharacterInfo()
        {
            Console.Clear();
            Program.SystemMessage("Name: " + this.name
                                + "\nHealth: " + this.health + "/" + this.baseHealth
                                + "\nDamage: " + this.damage);
        }
    }
}
