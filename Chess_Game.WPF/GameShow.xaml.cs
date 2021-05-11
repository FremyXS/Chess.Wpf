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
            new WpfDrawer(fieldCanvas);
            new Counter(counterGrid);

            this.Closing += MainWindow_Closing;
        }


        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            Info.SaveGame(BoardModel.PlayerOne.Name, BoardModel.PlayerTwo.Name);
            Info.SavePlayers(BoardModel.PlayerOne, BoardModel.PlayerTwo);
            Info.SaveStepPlayer(Board.StepPlayer, BoardModel.PlayerOne.Name, BoardModel.PlayerTwo.Name);
            Board.GameIsOpen = false;
            var win = new MainWindow();
            win.Show();
        }

        private void FieldCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            WpfDrawer.GrawCanvas();
           
        }

    }
}
