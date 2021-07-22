using System;
using System.Collections.Generic;
using System.Linq;
using static RockPaperScissorsTwoPlayer.Constants;

namespace RockPaperScissorsTwoPlayer
{
    public abstract class Game
    {
        private readonly IConsole _console;
        public Game(IConsole console)
        {
            _console = console;
        }
        public abstract void Play(ref int playerFlag);

        public void DeclareWinner(List<Player> players)
        {
            bool quit = false;
            PlayMultipleRounds(ref quit, players);
            if (!quit)
            {
                var gameWinner = players.Find(p => p.Winner());
                _console.WriteLine("{0} won {1} out of 3 matches.\n{2} is the Winner, Congratulations!!!\n",
                    gameWinner.Name, gameWinner.Won, gameWinner.Name);
            }
        }

        private void PlayMultipleRounds(ref bool quit, List<Player> players)
        {
            int round = 1;
            bool endGame = true;
            while (round <= 3 && !quit)
            {
                _console.WriteLine("Round {0}", round);
                if (!endGame)
                    FetchPlayerChoice(players);
                quit = !ValidatePlayerChoice(players);
                if (quit) break;
                RoundWinner(ref round, out string winner, players);

                if (winner.Contains("Nobody"))
                {
                    _console.WriteLine("It's a Tie!");
                    if (players.Any(p => p.Winner())) 
                        round++;
                    else
                        endGame = false;
                }
                else
                {
                    _console.WriteLine("{0} won round {1}.\n", winner, round);
                    endGame = false;
                }
                round++;
            }
        }

        private void FetchPlayerChoice(List<Player> players)
        {
            if (players.OfType<Computer>().Any())
            {
                _console.WriteLine("Enter your Choice:");
                Enum.TryParse(_console.ReadLine(), out Choice choice);
                players.First().Choice = choice;
            }
            else
                foreach (var player in players)
                {
                    _console.WriteLine("Enter {0}'s Choice:", player.Name);
                    Enum.TryParse(_console.ReadLine(), out Choice choice);
                    player.Choice = choice;
                }
        }

        private bool ValidatePlayerChoice(List<Player> players)
        {
            if (players.Exists(p => (int)p.Choice == 4))
            {
                _console.WriteLine("One of the players chose to Quit!\n");
                return false;
            }
            while (!PlayerChoiceValid(players))
            {
                if (players.OfType<Computer>().Any())
                    _console.WriteLine("Invalid Choice! Try again.\n");
                else
                    _console.WriteLine("One of the players entered an invalid Choice! Try again.\n");
                FetchPlayerChoice(players);
            }
            return true;
        }

        private void RoundWinner(ref int round, out string winner, List<Player> players)
        {
            var player1 = players[0]; var player2 = players[1];
            var player2Choice = player2.Choice; // To fixate the Computer's Choice.
            _console.WriteLine("{0}'s Choice:{1}", player1.Name, player1.Choice);
            _console.WriteLine("{0}'s Choice:{1}", player2.Name, player2Choice);
            if (!(player1.Choice == player2Choice))
            {
                if (GetWinningChoice(player1.Choice, player2Choice) == player2Choice) 
                { 
                    player2.Won++; 
                    winner = player2.Name; 
                } 
                else 
                { 
                    player1.Won++; 
                    winner = player1.Name; 
                }
            }
            else
            {
                winner = "Nobody";
                round--;
            }
        }

        private bool PlayerChoiceValid(List<Player> players) => !players.Exists(p => (int)p.Choice < 1 || (int)p.Choice > 3);
    }
}
