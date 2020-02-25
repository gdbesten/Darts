using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Darts.Model
{
    public class Player
    {
        private string _name;
        public List<Score> ScoreList { get; private set; } 

        public Player(string name)
        {
            ScoreList = new List<Score>();
            _name = name;
        }

        public string GetPlayerName()
        {
            return _name;
        }

        public void SetPlayerName(string namePlayer)
        {
            _name = namePlayer;
        }
    }
}