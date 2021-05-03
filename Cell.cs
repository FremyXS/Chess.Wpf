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
        public Logic.Figure Figure { get; set; } 
        public Label FigureLabel { get; set; }
        private int CoorX { get;}
        private int CoorY { get;}
        public Cell(int i, int j)
        {
            IsFilled = j % 2 == 0 ? i % 2 == 0 : i % 2 != 0;

            Rect = new Rectangle
            {
                Height = 70,
                Width = 70,
                Fill = IsFilled ? Settings.ColorOne : Settings.ColorTwo,
                Stroke = Brushes.Black,
            };

            Rect.MouseLeftButtonDown += Cell_MouseLeftButtonDown;

            CoorX = j; CoorY = i;

            Figure = BoardModel.Board[i, j] ?? null;                      

            FigureLabel = new Label
            {
                Content = BoardModel.Board[i, j]?.Role.ToString()[0],
                FontSize = 35,
                Foreground = Brushes.Blue,
            };

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
                    GetMoving();
                }
            }
        }
        private void GetMoving()
        {
            BoardModel.Board[CoorY, CoorX] = BoardModel.Board[Board.XY[0], Board.XY[1]];
            BoardModel.Board[Board.XY[0], Board.XY[1]] = null;

            Figure = Board.Field[Board.XY[0], Board.XY[1]].Figure;
            Board.Field[Board.XY[0], Board.XY[1]].Figure = null;

            FigureLabel.Content = Board.Field[Board.XY[0], Board.XY[1]].FigureLabel.Content;
            Board.Field[Board.XY[0], Board.XY[1]].FigureLabel.Content = null;

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
            int swtch = 0;
            for (var i = 0; i < CorrectMove.DiffX.Count; i++)
            {
                Correct(CoorY + (CorrectMove.DiffY[i] * x), CoorX + (CorrectMove.DiffX[i] * y), ref i, ref swtch);
            }
        }
        private void StepPawn(int startY, int step)
        {
            if (CoorY > 0 && CoorY < 7)
            {
                CorrectMovePawn(step);

                if (CoorY == startY)
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
        private void Correct(int diffY, int diffX, ref int i, ref int swtch)
        {
            if (diffY >= 0 && diffY < 8 && diffX >= 0 && diffX < 8)
            {
                if (Board.Field[diffY, diffX].Figure == null)
                {
                    Board.Field[diffY, diffX].Rect.Fill = Settings.ColorStep;
                    Board.Field[diffY, diffX].IsClick = true;
                    swtch++;
                }
                else
                {
                    if(Board.Field[diffY, diffX].Figure.Color == (Board.StepPlayer? Logic.Colors.Black : Logic.Colors.White))
                    {
                        Board.Field[diffY, diffX].Rect.Fill = Settings.ColorEnemy;
                        Board.Field[diffY, diffX].IsClick = true;
                        swtch++;
                    }

                    i += CorrectMove.DiffX.Count / 3 - swtch - 1;
                    swtch = 0;
                }
            }
        }
        private void DeleteIsClick()
        {
            foreach (var i in Board.Field)
            {
                if (i.IsClick)
                {
                    i.IsClick = false;
                    i.Rect.Fill = i.IsFilled ? Settings.ColorOne : Settings.ColorTwo;
                }
            }
        }
    }
}
