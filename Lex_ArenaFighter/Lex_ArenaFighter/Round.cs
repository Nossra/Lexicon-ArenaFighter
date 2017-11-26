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
        Player player;
        Fighter opponent;

        public Round(Player player, Fighter opponent)
        {
            this.player = player;
            this.opponent = opponent;           
        }

        public void Attack()
        {
            Console.WriteLine("You rolled : " + player.ThrowDice() + ", while the opponent rolled: " + opponent.ThrowDice() + ".");
            if (opponent.Dice > player.Dice)
            {
                EnemyAttack();
            }
            else if (player.Dice > opponent.Dice)
            {
                PlayerAttack();
            }
            else if (player.Dice == opponent.Dice)
            {
                Console.WriteLine("You stare each other down and wait for a better opportunity\n");
            }
        }

        private void EnemyAttack()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your opponent hit you for " + opponent.Damage + "!");
            player.Health = player.Health - opponent.Damage;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Your health is reduced to " + player.Health + "/" + player.BaseHealth + "\n");
        }

        private void PlayerAttack()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You lashed out at the enemy and dealt " + player.Damage + " damage!");
            opponent.Health = opponent.Health - player.Damage;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("His health is reduced to " + opponent.Health + "/" + opponent.BaseHealth + "\n");
        }
    }
}
