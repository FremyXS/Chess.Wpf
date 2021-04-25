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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chess_Game.Logic;

namespace Chess_Game.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewGameClick(object sender, RoutedEventArgs e)
        {

            BoardModel.GetStartBoard();
            var game = new InputNames();
            Close();
            game.Show();

        }

        private void ContinueClick(object sender, RoutedEventArgs e)
        {
            Info.LoadInfo();
            var game = new GameShow();
            Close();
            game.Show();
        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            var settings = new Settings();
            settings.Show();
        }
    }
}
