using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lex_ArenaFighter
{
    class Program
    {
        static bool isDrinking = true;

        public static bool IsDrinking { get => isDrinking; set => isDrinking = value; }

        static void Main(string[] args)
        {
            StoryMessage("Welcome to the bar you rowdy rascal.");
            StoryMessage("....");
            StoryMessage("Not very talkative.. Whats your name?\n");
            SystemMessage("Write your name:");
            Player player = new Player();
            StoryMessage("\nSit down at the bar " + player.Name + " and have a drink.");
            StoryMessage("You walk over to the bar and tries to get the bartenders attention.");
            Console.Clear();
            while (IsDrinking)
            {                
                Option(player);
                if (player.Health < 1)
                {
                    StoryMessage("You fight bad and you should feel bad. You passed out and got thrown out of the pub.\n");
                    PrintEndStats(player);
                    isDrinking = false;
                }
            }
        }

        public static void SystemMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void StoryMessage(string msg)
        {
            Console.WriteLine(msg);
            Console.ReadKey(true);
        }

        private static void Option(Player player)
        {
            PrintStats(player);
            SystemMessage("\nF. Look up a barfight.\n"
                          + "R. Retire and exit the bar.\n"
                          + "D. Order a drink to increase your health.");

            OptionResult(player);
        }

        private static void OptionResult(Player player)
        {
            ConsoleKeyInfo s = Console.ReadKey(true);
            if (s.KeyChar == 'f' || s.KeyChar == 'F')
            {
                CreateBattle(player);
            }
            else if (s.KeyChar == 'r' || s.KeyChar == 'R')
            {
                Retire(player);
            }
            else if (s.KeyChar == 'd' || s.KeyChar == 'D')
            {
                OrderDrink(player);
            }
            else 
            {
                StoryMessage("\nDude what? We dont serve that here.\n");
            }    
        }

        private static void OrderDrink(Player player)
        {
            const int HEALTH_INCREASE = 3;

            if (player.Currency > 0)
            {
                StoryMessage("You ordered a drink. It costed you 1 dollar and increased your health by " + HEALTH_INCREASE + ".\n");
                player.Currency -= 1;
                player.Health += HEALTH_INCREASE;
                if (player.Health > player.BaseHealth) player.Health = player.BaseHealth;
            }
            else
            {
                StoryMessage("The bartender laughs in your face as you couldn't afford it.\n");
            }
        }

        private static void CreateBattle(Player player)
        {
            Console.Clear();

            string[] fightmsg =
            {
                "You spot an ugly looking fella' in the corner.\nSince you're a butthole you decide to fight him for some reason",
                "You mutter something to yourself, but someone mistakes your comment about your drink as something bad about his mother.\nHe walks up to you. - U WOT M8!?"
            };

            Random rnd = new Random();
            int rndMessage = rnd.Next(fightmsg.Length);

            StoryMessage(fightmsg[rndMessage]);
            Console.Clear();
            Battle b = new Battle(player);
            b.Fight();
        }

        private static void Retire(Player player)
        {
            Console.Clear();
            Console.WriteLine("Retiring from the bar..\n");
            PrintEndStats(player);
            isDrinking = false;
        }

        private static void PrintStats(Player player)
        {
            Program.SystemMessage("Name: " + player.Name
                                + "\nHealth: " + player.Health + "/" + player.BaseHealth
                                + "\nDamage: " + player.Damage
                                + "\nWallet: " + player.Currency + "$.\n");

        }

        private static void PrintEndStats(Player player)
        {
            Program.SystemMessage("Name: " + player.Name
                                + "\nHealth: " + player.Health + "/" + player.BaseHealth
                                + "\nDamage: " + player.Damage
                                + "\nWallet: " + player.Currency + "$\n");
            
            foreach (string item in Battle.Log)
            {
                Program.SystemMessage(item);
            }

            Program.SystemMessage("\nYour points: " + player.Points + "\n");
            
            Console.ReadKey(true);

        }
    }
}
