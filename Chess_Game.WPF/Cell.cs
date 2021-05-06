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
    public class Cell
    {
        private bool IsClick { get; set; } = false;
        private bool IsFilled { get;}
        public Rectangle Rect { get; set; }
        private Logic.Figure Figure { get; set; } 
        public Label FigureLabel { get; set; }
        private int CoorX { get;}
        private int CoorY { get;}
        public Image image { get; set; }
        public Cell(int coorX, int coorY)
        {
            CoorX = coorY; 
            CoorY = coorX;

            IsFilled = CoorY % 2 == 0 ? CoorX % 2 == 0 : CoorX % 2 != 0;

            Rect = new Rectangle
            {
                Fill = IsFilled ? Settings.ColorOne : Settings.ColorTwo,
                Stroke = Brushes.Black,
            };                                 

            Figure = BoardModel.Board[coorX, coorY] ?? null;

            image = new Image
            {
                Source = BoardModel.Board[coorX, coorY]!=null?
                    BitmapFrame.Create(new Uri(Board.GetImage(Figure.Role, Figure.Color) , UriKind.Relative)) : null,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            Rect.MouseLeftButtonDown += Cell_MouseLeftButtonDown;
            image.MouseLeftButtonDown += Cell_MouseLeftButtonDown;

        }

        private void Cell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (Board.StepPlayer)
                OneStep(Logic.Colors.White, Logic.Colors.Black);
            else
                OneStep(Logic.Colors.Black, Logic.Colors.White);

        }
        private void OneStep(Logic.Colors color, Logic.Colors antiColor)
        {
            if (!Board.IsClick)
            {
                if (!IsClick && Figure != null && Figure.Color == color)
                {
                    Rect.Fill = Settings.ColorStep;
                    Board.IsClick = true;
                    IsClick = true;
                    Board.XY[0] = CoorY;
                    Board.XY[1] = CoorX;
                    GetClickCells();
                }
            }
            else
            {
                if (IsClick && Figure == null)
                {
                    GetMoving();
                }
                else if (IsClick && Figure != null && Figure.Color == color)
                {
                    Rect.Fill = IsFilled ? Settings.ColorOne : Settings.ColorTwo;
                    Board.IsClick = false;
                    IsClick = false;
                    DeleteIsClick();
                }
                else if (IsClick && Figure != null && Figure.Color == antiColor)
                {
                    if (Board.StepPlayer) 
                        BoardModel.PlayerOne.AddPoints(Figure.Role);
                    else 
                        BoardModel.PlayerTwo.AddPoints(Figure.Role);

                    Logic.Figure dedFigure = Figure;

                    GetMoving();

                    CheckWin(dedFigure);

                    Counter.UpdateCounter();

                }
            }
        }
        private void GetMoving()
        {
            BoardModel.Board[CoorY, CoorX] = BoardModel.Board[Board.XY[0], Board.XY[1]];
            BoardModel.Board[Board.XY[0], Board.XY[1]] = null;

            Figure = Board.Field[Board.XY[0], Board.XY[1]].Figure;
            Board.Field[Board.XY[0], Board.XY[1]].Figure = null;

            image.Source = Board.Field[Board.XY[0], Board.XY[1]].image.Source;
            Board.Field[Board.XY[0], Board.XY[1]].image.Source = null;

            Board.Field[Board.XY[0], Board.XY[1]].IsClick = false;
            Board.IsClick = false;
            Board.Field[Board.XY[0], Board.XY[1]].Rect.Fill =
                Board.Field[Board.XY[0], Board.XY[1]].IsFilled ? Settings.ColorOne : Settings.ColorTwo;

            DeleteIsClick();

            Board.StepPlayer = !Board.StepPlayer;
        }
        private void GetClickCells()
        {
            if (Figure.Role == Roles.Pawn)
            {
                ThisPawn();
            }
            else
            {
                CorrectMove.GetMove(Figure.Role);
                ThisOtherFigures(1, 1);
                ThisOtherFigures(-1, -1);
                ThisOtherFigures(1, -1);
                ThisOtherFigures(-1, 1);
            }
        }
        private void ThisPawn()
        {
            if(Figure.Color == Logic.Colors.Black)
                StepPawn(1, 1);
            else
                StepPawn(6, -1);
        }

        private void ThisOtherFigures(int x, int y)
        {
            int transfer = 0;
            for (var i = 0; i < CorrectMove.DiffX.Count; i++)
            {
                Correct(CoorY + (CorrectMove.DiffY[i] * x), CoorX + (CorrectMove.DiffX[i] * y), ref i, ref transfer);
            }
        }
        private void StepPawn(int startY, int step)
        {
            if (CoorY > 0 && CoorY < 7)
            {
                CorrectMovePawn(step);

                if (CoorY == startY && Board.Field[CoorY + step, CoorX].Figure == null)
                {
                    CorrectMovePawn(step*2);
                }

                IsEnemy(CoorY + step, CoorX+step);
                IsEnemy(CoorY + step, CoorX - step);

            }
        }
        private void CorrectMovePawn(int step)
        {
            if (Board.Field[CoorY + step, CoorX].Figure == null)
            {
                Board.Field[CoorY + step, CoorX].Rect.Fill = Settings.ColorStep;
                Board.Field[CoorY + step, CoorX].IsClick = true;
            }
        }
        private void IsEnemy(int diffY, int diffX)
        {
            if (diffX > -1 && diffX < 8)
            {
                if (Board.Field[diffY, diffX].Figure != null 
                && Board.Field[diffY, diffX].Figure.Color == (Board.StepPlayer ? Logic.Colors.Black : Logic.Colors.White))
                {
                    Board.Field[diffY, diffX].IsClick = true;
                    Board.Field[diffY, diffX].Rect.Fill = Settings.ColorEnemy;
                }
            }
        }
        private void Correct(int diffY, int diffX, ref int i, ref int transfer)
        {
            if (diffY >= 0 && diffY < 8 && diffX >= 0 && diffX < 8)
            {
                if (Board.Field[diffY, diffX].Figure == null)
                {
                    Board.Field[diffY, diffX].Rect.Fill = Settings.ColorStep;
                    Board.Field[diffY, diffX].IsClick = true;
                    transfer++;
                }
                else
                {
                    if(Board.Field[diffY, diffX].Figure.Color == (Board.StepPlayer? Logic.Colors.Black : Logic.Colors.White))
                    {
                        Board.Field[diffY, diffX].Rect.Fill = Settings.ColorEnemy;
                        Board.Field[diffY, diffX].IsClick = true;
                    }

                    i += CorrectMove.DiffX.Count / 3 - transfer - 1;
                    transfer = 0;
                }
            }
        }
        private void DeleteIsClick()
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
        private void CheckWin(Logic.Figure figure)
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
        private void GetWin(Player player)
        {
            player.Win();

            MessageBox.Show($"Победил игрок:{player.Name}");

            BoardModel.GetStartBoard();
            Board.GetBoard();
            WpfDrawer.GrawCanvas();
        }
    }
}
