using System;
using static RockPaperScissorsTwoPlayer.Constants;

namespace RockPaperScissorsTwoPlayer
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(WelcomeMessage);
            while (true)
            {
                Enum.TryParse(Console.ReadLine(), out PlayerType playerType);
                if (playerType == PlayerType.Quit) break;
                Start(playerType);
            }
        }

        private static void Start(PlayerType playerType)
        {
            int playerFlag = 0;
            var console = new ConsoleWrapper(); var computerPlayer = new ComputerPlayer(console);
            var humanPlayer = new HumanPlayer(console);
            switch (playerType)
            {
                case PlayerType.HumanPLayer:
                    {
                        humanPlayer.Play(ref playerFlag);
                        break;
                    }
                case PlayerType.Computer:
                    {
                        computerPlayer.Play(ref playerFlag);
                        break;
                    }
                case PlayerType.Quit:
                    {
                        Environment.Exit(-1);
                        break;
                    };
                case PlayerType.Clear:
                    {
                        Console.Clear();
                        playerFlag = 1;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Choice!");
                        break;
                    }
            }
            if (playerFlag != 0)
                Console.WriteLine(WelcomeMessage);
        }
    }
}
