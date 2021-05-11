using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Chess_Game.Logic;

namespace Chess_Game.WPF
{
    public static class Board
    {
        public static bool GameIsOpen { get; set; } = false;
        public static bool StepPlayer { get; set; } = true; 
        public static bool IsClick { get; set; } = false;
        public static Cell[,] Field { get; set; } = new Cell[8, 8];
        public static int[] XY { get; set; } = new int[2];
        public static void GetBoard()
        {
            for (var i = 0; i < 8; i++)
            {
                for(var j = 0; j < 8; j++)
                {
                    Field[i, j] = new Cell(i, j);
                }
            }
        }
        public static void CheckWin(Logic.Figure figure)
        {
            if (figure.Role == Roles.King)
            {
                if (figure.Color == Logic.Colors.White)
                {
                    GetWin(BoardModel.PlayerTwo);
                }
                else
                {
                    GetWin(BoardModel.PlayerOne);
                }
            }
        }
       private static void GetWin(Player player)
        {
            player.Win();

            MessageBox.Show($"Победил игрок:{player.Name}");

            BoardModel.GetStartBoard();
            GetBoard();
            WpfDrawer.GrawCanvas();
        }
        public static void DeleteIsClick()
        {
            foreach (var cell in Board.Field)
            {
                if (cell.IsClick)
                {
                    cell.IsClick = false;
                    cell.Rect.Fill = cell.IsFilled ? Settings.ColorOne : Settings.ColorTwo;
                }
            }
        }
        public static string GetImage(Roles role, Logic.Colors color)
            =>$"data/Figures/{role}/{color}.png";

    }
    

}
