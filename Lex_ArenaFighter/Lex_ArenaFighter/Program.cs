using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lex_ArenaFighter
{
    class Program
    {
        //test after changes to gitignore
        static bool isDrinking = true;

        public static bool IsDrinking { get => isDrinking; set => isDrinking = value; }

        static void Main(string[] args)
        {
            StoryMessage("Welcome to the bar you rowdy rascal.");
            StoryMessage("....");
            StoryMessage("Not very talkative.. Whats your name?");
            Console.Clear();
            SystemMessage("Write your name:");
            Fighter player = new Fighter(true);
            Console.Clear();
            StoryMessage("Sit down at the bar " + player.Name + " and have a drink.");

            while (IsDrinking)
            {
                Option(player);
                if (player.Health < 1)
                {
                    StoryMessage("You fight bad and you should feel bad. You passed out and got thrown out of the pub.");
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

        public static void Option(Fighter player)
        {
            player.PrintCharacterInfo();
            SystemMessage("\nF. Look up a barfight.\n"
                          + "R. Retire and exit the bar.");
            OptionResult(player);
        }

        public static void OptionResult(Fighter player)
        {
            ConsoleKeyInfo s = Console.ReadKey(true);
            if (s.KeyChar == 'f' || s.KeyChar == 'F')
            {
                CreateBattle(player);
            }
            else if (s.KeyChar == 'r' || s.KeyChar == 'R')
            {
                Retire();
            }
            else if (s.KeyChar != 'r' || s.KeyChar != 'f' || s.KeyChar == 'f' || s.KeyChar == 'F')
            {
                StoryMessage("\nDude what? We dont serve that here.");
            }    
        }

        public static void CreateBattle(Fighter player)
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

        public static void Retire()
        {
            Console.Clear();
            Console.WriteLine("Retiring from the bar..");
            isDrinking = false;
        }
    }
}
