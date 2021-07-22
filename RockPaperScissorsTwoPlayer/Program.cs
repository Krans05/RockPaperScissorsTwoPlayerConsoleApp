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
                Enum.TryParse(Console.ReadLine(), out PlayerMode playerMode);
                if (playerMode == PlayerMode.Quit) break;
                Start(playerMode);
            }
        }

        private static void Start(PlayerMode playerType)
        {
            int playerFlag = 0;
            var console = new ConsoleWrapper(); var computerPlayer = new ComputerPlayer(console);
            var humanPlayer = new HumanPlayer(console);
            switch (playerType)
            {
                case PlayerMode.HumanPLayer:
                    {
                        humanPlayer.Play(ref playerFlag);
                        break;
                    }
                case PlayerMode.Computer:
                    {
                        computerPlayer.Play(ref playerFlag);
                        break;
                    }
                case PlayerMode.Quit:
                    {
                        Environment.Exit(-1);
                        break;
                    };
                case PlayerMode.Clear:
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
