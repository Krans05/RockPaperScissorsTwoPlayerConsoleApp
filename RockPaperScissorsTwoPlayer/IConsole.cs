namespace RockPaperScissorsTwoPlayer
{
    public interface IConsole
    {
        void Write(string message);
        void Write(string message, params object[] args);
        void WriteLine(string message);
        void WriteLine(string message, params object[] args);
        string ReadLine();
    }
}
