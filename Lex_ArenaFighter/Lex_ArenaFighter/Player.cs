using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lex_ArenaFighter
{
    class Player : Fighter
    {
        int points;
        int currency = 2;

        public Player() : base()
        {
            Name = SetName();
            PlayerBoost();
        }

        public void PlayerBoost()
        {
            const double PLAYER_MULTIPLIER = 1.2;

            this.Health = Convert.ToInt32(Health * PLAYER_MULTIPLIER);
            this.BaseHealth = Convert.ToInt32(BaseHealth * PLAYER_MULTIPLIER);
            this.Damage = Convert.ToInt32(Damage * PLAYER_MULTIPLIER);
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

        public int Points { get => points; private set => points = value; }
        public int Currency { get => currency;  set => currency = value; }

        public void IncreasePoints()
        {
            this.Points = this.Points + 1;
        }
    }
}
