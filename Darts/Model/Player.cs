using System.Collections.Generic;

namespace Darts.Model
{
    public class Player
    {
        public List<Score> ScoreList { get; private set; } 

        public Player(string name)
        {
            ScoreList = new List<Score>();
        }
    }
}