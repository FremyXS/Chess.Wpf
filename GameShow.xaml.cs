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
            new Board();
            InitializeComponent();
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            Info.SaveInfo();
            var win = new MainWindow();
            win.Show();
        }

        private void FieldCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            fieldCanvas.Children.Clear();

            for (int i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    fieldCanvas.Children.Add(Board.Field[i, j].Rect);
                    fieldCanvas.Children.Add(Board.Field[i, j].FigureLabel);

                    Canvas.SetTop(Board.Field[i, j].Rect, i * 70);
                    Canvas.SetLeft(Board.Field[i, j].Rect, j * 70);
                    Canvas.SetTop(Board.Field[i, j].FigureLabel, i * 70);
                    Canvas.SetLeft(Board.Field[i, j].FigureLabel, j * 70);
                }
            }
            
        }


    }
}
