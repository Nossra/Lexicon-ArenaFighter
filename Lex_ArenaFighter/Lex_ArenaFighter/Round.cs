using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lex_ArenaFighter
{
    class Round
    {
        Random rnd = new Random();
        Fighter player;
        Fighter opponent;

        public Round(Fighter player, Fighter opponent)
        {
            this.player = player;
            this.opponent = opponent;           
        }

        public void Attack()
        {
            if (opponent.ThrowDice() > player.ThrowDice())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your opponent hit you for " + opponent.Damage + "!");
                player.Health = player.Health - opponent.Damage;
                Console.WriteLine("Your health is reduced to " + player.Health + "/" + player.BaseHealth);
                Console.WriteLine();
            }
            else if (player.ThrowDice() > opponent.ThrowDice())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You lashed out at the enemy and dealt " + player.Damage + " damage!");
                opponent.Health = opponent.Health - player.Damage;
                Console.WriteLine("His health is reduced to " + opponent.Health + "/" + opponent.BaseHealth);
                Console.WriteLine();
            }
            else if (player.ThrowDice() == opponent.ThrowDice())
            {
                Console.WriteLine("You stare each other down and wait for a better opportunity\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintLog()
        {

        }

    }
}
