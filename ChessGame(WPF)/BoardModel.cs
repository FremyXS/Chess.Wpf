using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame_WPF_
{
    public class BoardModel
    {
        public static string[,] arrayBoard = new string[8, 8];
        private static string[] arrayFigures = { "Pawn", "King", "Queen", "Rook", "Horse", "Bishop" };

        public static void GetIntialBoard()
        {
            for (int i = 6; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 6)
                    {
                        arrayBoard[i, j] = arrayFigures[0][0].ToString();
                    }
                    else
                    {
                        if (j == 1 || j == 6)
                            arrayBoard[i, j] = arrayFigures[4][0].ToString();
                        else if (j == 2 || j == 5)
                            arrayBoard[i, j] = arrayFigures[5][0].ToString();
                        else if (j == 0 || j == 7)
                            arrayBoard[i, j] = arrayFigures[3][0].ToString();
                        else if (j == 3)
                            arrayBoard[i, j] = arrayFigures[1][0].ToString();
                        else if (j == 4)
                            arrayBoard[i, j] = arrayFigures[2][0].ToString();
                    }
                }
            }
        }
    }
}
