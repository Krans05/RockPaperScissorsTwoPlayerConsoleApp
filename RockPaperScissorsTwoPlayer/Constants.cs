namespace RockPaperScissorsTwoPlayer
{
    public static class Constants
    {
        private static string _welcomeMessage = "Welcome to Rock,Paper,Scissors!\nChoose Player type:\n1)Human Player\t\t2)Computer Player\t\t3)Quit\t\t4)Clear Screen";
        private static string _chooseMessage = "Round 1\nPick your Choice:\n1)Rock\t\t2)Paper\t\t3)Scissors\t\t4)Quit";

        public enum PlayerMode
        {
            HumanPLayer = 1,
            Computer = 2,
            Quit = 3,
            Clear = 4
        };
        public enum Choice
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        };
        public static string WelcomeMessage { get { return _welcomeMessage; } }
        public static string ChooseMessage { get { return _chooseMessage; } }

        public static Choice GetWinningChoice(Choice choice1, Choice choice2)
        {
            Choice winningChoice;
            if (choice1 == Choice.Rock && choice2 == Choice.Scissors)
            {
                winningChoice = choice1;
            }
            else if (choice1 == Choice.Scissors && choice2 == Choice.Paper)
            {
                winningChoice = choice1;
            }
            else if (choice1 == Choice.Paper && choice2 == Choice.Rock)
            {
                winningChoice = choice1;
            }
            else
            {
                winningChoice = choice2;
            }
            return winningChoice;
        }
    }
}
