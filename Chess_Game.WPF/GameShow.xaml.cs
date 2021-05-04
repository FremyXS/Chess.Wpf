using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// <summary>
    /// Логика взаимодействия для GameShow.xaml
    /// </summary>
    public partial class GameShow : Window
    {
        public GameShow()
        {
            Board.GetBoard();
            InitializeComponent();
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            Info.SaveGame(BoardModel.PlayerOne.Name, BoardModel.PlayerTwo.Name);
            Info.SavePlayers(BoardModel.PlayerOne, BoardModel.PlayerTwo);
            var win = new MainWindow();
            win.Show();
        }

        private void FieldCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double height = fieldCanvas.ActualHeight / 9;

            fieldCanvas.Children.Clear();

            for (int i = 0; i < 8; i++)
            {
                var lab = new Label { Content = $"{i + 1}", FontSize=height/3 };

                Placement(
                    lab,
                    i * height + (height / 6),
                    (fieldCanvas.ActualWidth - fieldCanvas.ActualHeight) / 2
                );

                for (var j = 0; j < 8; j++)
                {
                    Board.Field[i, j].Rect.Height = height;
                    Board.Field[i, j].Rect.Width = height;
                    Board.Field[i, j].FigureLabel.FontSize = height / 2;
                    fieldCanvas.Children.Add(Board.Field[i, j].Rect);
                    fieldCanvas.Children.Add(Board.Field[i, j].FigureLabel);

                    Canvas.SetTop(Board.Field[i, j].Rect, (i) * height );
                    Canvas.SetLeft(Board.Field[i, j].Rect, (j+1) * height + (fieldCanvas.ActualWidth - fieldCanvas.ActualHeight)/2);
                    Canvas.SetTop(Board.Field[i, j].FigureLabel, (i) * height);
                    Canvas.SetLeft(Board.Field[i, j].FigureLabel, (j+1) * height + (fieldCanvas.ActualWidth - fieldCanvas.ActualHeight) / 2);
                                      
                }
            }

            for(var i = 'A'; i <= 'H'; i++)
            {
                var lab = new Label { Content = i.ToString(), FontSize = height / 3 };
                Placement(
                    lab,
                    8 * height,
                    (i - 'A' + 1) * height + (fieldCanvas.ActualWidth - fieldCanvas.ActualHeight) / 2
                );
            }
            
        }
        private void Placement(Label lab, double x, double y)
        {            
            fieldCanvas.Children.Add(lab);
            Canvas.SetTop(lab, x);
            Canvas.SetLeft(lab, y);
        }


    }
}
