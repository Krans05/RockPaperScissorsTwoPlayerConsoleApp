using System;
using System.Collections.Generic;
using static RockPaperScissorsTwoPlayer.Constants;

namespace RockPaperScissorsTwoPlayer
{
    public class ComputerPlayer : Game
    {
        private readonly IConsole _console;
        public ComputerPlayer(IConsole console):base(console)
        {
            _console = console;
        }
        public override void Play(ref int playerFlag)
        {
            _console.WriteLine(ChooseMessage);
            var players = new List<Player>();
            _console.WriteLine("Enter your Name:"); var name = _console.ReadLine();
            _console.WriteLine("Enter your Choice:");
            Enum.TryParse(_console.ReadLine(), out Choice choice);
            players.Add(new Player() { Name = name, Choice = choice });
            players.Add(new Computer() { Name = "Computer" });
            DeclareWinner(players);
            playerFlag = 1;
        }
    }
}
