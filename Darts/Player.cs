using System.Collections.Generic;

namespace Darts
{
    public class Player
    {
        public string Name { get; set; }
        public List<Score> ScoreList { get; set; } 

        public Player(string name)
        {
            Name = Name;
            ScoreList = new List<Score>();
        }
    }
}