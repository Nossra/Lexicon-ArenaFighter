using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lex_ArenaFighter
{
    class Battle
    {
        Player player;
        Fighter opponent;

        public Battle(Player player)
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
                    Lose();
                    fighting = false;
                }
                else if (opponent.Health <1)
                {
                    Win();
                    fighting = false;
                }
            }
        }    

        private void PrintFighters()
        {
            Program.SystemMessage("Player");
            Console.WriteLine("Name: " + player.Name
                            + "\nHP: " + player.Health + "/" + player.BaseHealth
                            + "\nDamage: " + player.Damage + "\n");

            Program.SystemMessage("Opponent");
            Console.WriteLine("Name: " + opponent.Name
                            + "\nHP: " + opponent.Health + "/" + opponent.BaseHealth
                            + "\nDamage: " + opponent.Damage + "\n");
                          
            Console.ReadKey(true);
            Console.Clear();
        }

        private void Lose()
        {
            Console.ForegroundColor = ConsoleColor.Red; ;
            Program.StoryMessage("You got rekt..");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void Win()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Program.StoryMessage("You won the fight!");
            Console.ForegroundColor = ConsoleColor.White;
            Program.StoryMessage("You gained a point!\nYou stole his wallet and found a dollar.");
            player.Currency += 1;
            player.IncreasePoints();
            Console.Clear();
        }
    }
}
