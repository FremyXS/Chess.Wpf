using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game.Logic
{
    public class Player
    {
        public string Name{ get;}

        public int CountFigures { get; set; } = 16;
        public int CountPoints { get; set; } = 0;
        public Player(string name)
        {
            Name = name;
        }
        public void DropFigure()
        {
            CountFigures--;
        }
        public void AddPoints(Roles role)
        {
            switch (role)
            {
                case Roles.King:
                    CountPoints += 100;
                    break;
                case Roles.Queen:
                    break;
                case Roles.Rook:
                    break;
                case Roles.Horse:
                    break;
                case Roles.Bishop:
                    break;
                case Roles.Pawn:
                    CountPoints += 10;
                    break;
                default:
                    break;
            }
        }
    }
}
