using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game.Logic
{
    public class Player
    {
        private string Name { get; set; }
        public int CountFigures { get; }

        public Player(string name)
        {
            Name = name;
            CountFigures = 16;
        }

    } 
}
