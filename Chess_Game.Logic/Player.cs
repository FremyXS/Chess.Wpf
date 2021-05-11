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
        public int CountPoints { get; set; } = 0;
        public Player(string name)
        {
            Name = name;
        }
        public void AddPoints(Roles role)
        {
            switch (role)
            {
                case Roles.King:
                    CountPoints += 100;
                    break;
                case Roles.Queen:
                    CountPoints += 50;
                    break;
                case Roles.Rook:
                    CountPoints += 20;
                    break;
                case Roles.Horse:
                    CountPoints += 20;
                    break;
                case Roles.Bishop:
                    CountPoints += 20;
                    break;
                case Roles.Pawn:
                    CountPoints += 10;
                    break;
                default:
                    break;
            }
        }
        public void Win()
        {
            CountPoints += 200;
        }
    }
}
