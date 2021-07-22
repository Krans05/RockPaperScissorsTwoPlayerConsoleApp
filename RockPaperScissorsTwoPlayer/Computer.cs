using System;
using static RockPaperScissorsTwoPlayer.Constants;

namespace RockPaperScissorsTwoPlayer
{
    class Computer : Player
    {
        public override Choice Choice 
        { 
            get { return RandomChoice(); } 
        }

        private Choice RandomChoice()
        {
            var choices = Enum.GetValues(typeof(Choice));
            Random random = new Random();
            Choice randomChoice = (Choice)choices.GetValue(random.Next(choices.Length));
            return randomChoice;
        }
    }
}
