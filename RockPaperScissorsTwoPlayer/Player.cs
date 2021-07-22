using static RockPaperScissorsTwoPlayer.Constants;

namespace RockPaperScissorsTwoPlayer
{
    public class Player
    {
        private string _name;
        private int _won;
        private Choice _choice;
        public string Name { get { return _name; } set { _name = value; } }
        public virtual Choice Choice { get { return _choice; } set { _choice = value; } }
        public int Won { get { return _won; } set { _won = value; } }
        public bool Winner()
        {
            bool win = false;
            if (Won >= 2) win = true;
            return win;
        }
    }
}
