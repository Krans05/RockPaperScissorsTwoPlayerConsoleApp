using RockPaperScissorsTwoPlayer;

namespace TestRockPaperScissors
{
    public class TestConsoleWrapper : IConsole
    {
        private string[] names ;
        private string[] choices;
        private int playerCount;
        private string _message;
        private int _index;

        public string[] PlayerNames { get { return names; } set { names = value; } }
        public string[] PlayerChoices { get {return choices; } set { choices = value; } }
        public int PlayerCount { get { return playerCount; } set { playerCount = value; } }

        public string ReadLine()
        {
            if (_message.Contains("Name"))
                return GetNextValue(PlayerNames);
            else if (_message.Contains("number"))
                return PlayerCount.ToString();
            else if (_message.Contains("Choice"))
                return GetNextValue(PlayerChoices);
            else
                return string.Empty;
        }

        public void Write(string message)
        {

        }

        public void Write(string message, params object[] args)
        {

        }

        public void WriteLine(string message)
        {
            _message = message;
        }

        public void WriteLine(string message, params object[] args)
        {
            _message = message;
        }

        private string GetNextValue(string[] list)
        {
            if (_index < list.GetUpperBound(0))
                _index++;
            else
                _index = 0;
            return list[_index];
        }
    }
}
