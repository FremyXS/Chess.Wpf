using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChessGame_WPF_
{
    /// <summary>
    /// Логика взаимодействия для NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        public NewGameWindow()
        {
            InitializeComponent();
        }

        private bool isFilled;
        private double cellSize;
        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            fieldCanvas.Children.Clear();

            BoardModel.GetIntialBoard();

            cellSize = fieldCanvas.ActualWidth / 8;

            for (int i = 0; i < 8; i++)
            {
                for(var j = 0; j < 8; j++)
                {
                    GetCell(i, j);

                    GetFigure(i, j);
                }

            }
            
        }
        private void GetCell(int i, int j)
        {
            isFilled = j % 2 == 0 ? i % 2 == 0 : i % 2 != 0;

            var cell = new Rectangle();

            cell.Height = cellSize;
            cell.Width = cellSize;
            cell.Fill = isFilled ? Brushes.Black : Brushes.Brown;
            cell.Stroke = Brushes.Black;

            fieldCanvas.Children.Add(cell);

            Canvas.SetTop(cell, i * cellSize);
            Canvas.SetLeft(cell, j * cellSize);
        }
        private void GetFigure(int i, int j)
        {
            var figure = new TextBlock();

            if (BoardModel.arrayBoard[i, j] != null)
            {
                figure.Text = BoardModel.arrayBoard[i, j];
            }

            figure.Foreground = Brushes.White;

            figure.FontSize = 35;

            fieldCanvas.Children.Add(figure);

            Canvas.SetTop(figure, i * cellSize);
            Canvas.SetLeft(figure, j * cellSize);
        }
    }
}
