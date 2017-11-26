using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lex_ArenaFighter
{
    class Battle
    {
        Fighter player;
        Fighter opponent;

        public Battle(Fighter player)
        {
            this.player = player;
            opponent = new Fighter();
            PrintFighters();
        }

        public void Fight()
        {
            bool fighting = true;
            Console.Clear();
            while (fighting)
            {
                Round r = new Round(player, opponent);
                r.Attack();
                Console.ReadKey(true);

                if (player.Health <1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;;
                    Program.StoryMessage("You got rekt..");
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;

                    fighting = false;
                }
                else if (opponent.Health <1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;;
                    Program.StoryMessage("You won the fight!");
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;

                    fighting = false;
                }
            }
        }    

        public void PrintFighters()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Name: " + player.Name
                            + "\nHP: " + player.Health + "/" + player.BaseHealth
                            + "\nDamage: " + player.Damage);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nName: " + opponent.Name
                            + "\nHP: " + opponent.Health + "/" + opponent.BaseHealth
                            + "\nDamage: " + opponent.Damage + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
