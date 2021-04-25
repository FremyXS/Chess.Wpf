using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game.Logic
{   
    public enum Figures
    {
        Pawn, King, Queen, Rook, Horse, Bishop
    }    
    public enum Colors
    {
        White, Black
    }
    public class BoardModel
    {
        public static Role[,] Board { get; set; } 

        public static void GetStartBoard()
        {
            Board = new Role[8, 8];
            for(var i = 0; i<8; i++)
            {
                Board[1, i] = new Role(Figures.Pawn, Colors.Black);
                Board[6, i] = new Role(Figures.Pawn, Colors.White);

                if(i == 0 || i == 7)
                {
                    Board[0, i] = new Role(Figures.Rook, Colors.Black);
                    Board[7, i] = new Role(Figures.Rook, Colors.White);
                }
                else if(i == 1 || i == 6)
                {
                    Board[0, i] = new Role(Figures.Horse, Colors.Black);
                    Board[7, i] = new Role(Figures.Horse, Colors.White);
                }
                else if (i == 2 || i == 5)
                {
                    Board[0, i] = new Role(Figures.Bishop, Colors.Black);
                    Board[7, i] = new Role(Figures.Bishop, Colors.White);
                }
                else if (i == 3)
                {
                    Board[0, i] = new Role(Figures.Queen, Colors.Black);
                    Board[7, i] = new Role(Figures.Queen, Colors.White);
                }
                else
                {
                    Board[0, i] = new Role(Figures.King, Colors.Black);
                    Board[7, i] = new Role(Figures.King, Colors.White);
                }
            }


        }
    }
}
