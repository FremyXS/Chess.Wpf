using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game.Logic
{   
    public enum Roles
    {
       King, Queen, Rook, Horse, Bishop, Pawn
    }    
    public enum Colors
    {
        White, Black
    }
    public class BoardModel
    {
        public static Figure[,] Board { get; set; }
        public static Player PlayerOne { get; set; }
        public static Player PlayerTwo { get; set; }

        public static void GetStartBoard()
        {
            Board = new Figure[8, 8];
            for(var i = 0; i<8; i++)
            {
                Board[1, i] = new Figure(Roles.Pawn, Colors.Black);
                Board[6, i] = new Figure(Roles.Pawn, Colors.White);

                if(i == 0 || i == 7)
                {
                    Board[0, i] = new Figure(Roles.Rook, Colors.Black);
                    Board[7, i] = new Figure(Roles.Rook, Colors.White);
                }
                else if(i == 1 || i == 6)
                {
                    Board[0, i] = new Figure(Roles.Horse, Colors.Black);
                    Board[7, i] = new Figure(Roles.Horse, Colors.White);
                }
                else if (i == 2 || i == 5)
                {
                    Board[0, i] = new Figure(Roles.Bishop, Colors.Black);
                    Board[7, i] = new Figure(Roles.Bishop, Colors.White);
                }
                else if (i == 3)
                {
                    Board[0, i] = new Figure(Roles.Queen, Colors.Black);
                    Board[7, i] = new Figure(Roles.Queen, Colors.White);
                }
                else
                {
                    Board[0, i] = new Figure(Roles.King, Colors.Black);
                    Board[7, i] = new Figure(Roles.King, Colors.White);
                }
            }


        }
    }
}
