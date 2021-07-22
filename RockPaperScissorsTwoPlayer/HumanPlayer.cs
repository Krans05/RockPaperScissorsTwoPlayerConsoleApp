using System;
using System.Collections.Generic;
using static RockPaperScissorsTwoPlayer.Constants;

namespace RockPaperScissorsTwoPlayer
{
    public class HumanPlayer:Game
    {
        private readonly IConsole _console;
        public HumanPlayer(IConsole console):base(console)
        {
            _console = console;
        }
        public override void Play(ref int playerFlag)
        {
            int playerCount = 2;            
            var players = new List<Player>();            
            _console.WriteLine(ChooseMessage);
            
            for (int i = 1; i <= playerCount; i++)
            {
                _console.WriteLine("Enter Player{0}'s Name:", i);
                string name = _console.ReadLine();
                _console.WriteLine("Enter {0}'s Choice:", name);
                Enum.TryParse(_console.ReadLine(), out Choice choice);
                players.Add(new Player() { Name = name, Choice = choice });
            }
            DeclareWinner(players);
            playerFlag = 1;
        }
    }
}
