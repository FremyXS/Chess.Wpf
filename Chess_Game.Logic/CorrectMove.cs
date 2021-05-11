using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game.Logic
{
    public class CorrectMove
    {
        public static List<int> DiffY { get; private set; }
        public static List<int> DiffX { get; private set; }
        public static void GetMove(Roles figur)
        {
            DiffY = new List<int>();
            DiffX = new List<int>();

            switch (figur)
            {
                case Roles.King:
                    GetMoveKing();
                    break;
                case Roles.Queen:
                    GetMoveQueen();
                    break;
                case Roles.Rook:
                    GetMoveRook();
                    break;
                case Roles.Horse:
                    GetMoveHorse();
                    break;
                case Roles.Bishop:
                    GetMoveBishop();
                    break;
            }
        }
        private static void GetMoveKing()
        {
            DiffY.Add(1); DiffX.Add(1);
            DiffY.Add(0); DiffX.Add(1);
            DiffY.Add(1); DiffX.Add(0);
        }
        private static void GetMoveHorse()
        {
            DiffY.Add(1); DiffX.Add(2);
            DiffY.Add(2); DiffX.Add(1);
            DiffY.Add(0); DiffX.Add(0);
        }
        private static void GetMoveBishop()
        {
            for(var i = 1; i < 8; i++)
            {
                DiffY.Add(i); DiffX.Add(i);
            }
            for (var i = 1; i < 15; i++)
            {
                DiffY.Add(0); DiffX.Add(0);
            }
        }
        private static void GetMoveRook()
        {
            for (var i = 1; i < 8; i++)
            {
                DiffY.Add(0); DiffX.Add(0);
            }
            for (var i = 1; i < 8; i++)
            {
                DiffY.Add(i); DiffX.Add(0);
            }
            for (int i = 1; i < 8; i++)
            {
                DiffY.Add(0); DiffX.Add(i);
            }
        }
        private static void GetMoveQueen()
        { 
            for (var i = 1; i < 8; i++)
            {
                DiffY.Add(i); DiffX.Add(0);
            }
            for (var i = 1; i < 8; i++)
            {
                DiffY.Add(0); DiffX.Add(i);
            }
            for (var i = 1; i < 8; i++)
            {
                DiffY.Add(i); DiffX.Add(i);
            }
        }

    }
}
