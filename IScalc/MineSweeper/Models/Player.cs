using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Models
{
    public class Player
    {
        public string Name { get; set; }

        public string Difficulty { get; set; }

        public TimeSpan ClearTime { get; set; }

        public Player(string name, TimeSpan clearTime, string difficulty)
        {
            Name = name;

            Difficulty = difficulty;

            ClearTime = clearTime;
        }
    }
}
