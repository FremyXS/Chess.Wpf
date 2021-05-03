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
    /// <summary>
    /// Логика взаимодействия для InputNames.xaml
    /// </summary>
    public partial class InputNames : Window
    {
        public InputNames()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Board.PlayerOne = new Player(namePlayerOne.Text);
            Board.PlayerTwo = new Player(namePlayerTwo.Text);

            if(CheckName(Board.PlayerOne, namePlayerOne.Text) 
            && CheckName(Board.PlayerTwo, namePlayerTwo.Text))
            {
                var game = new GameShow();
                Close();
                game.Show();
            }
        }
        private bool CheckName(Player player, string namePlayer)
        {
            if (namePlayer.Length > 3)
            {
                player = new Player(namePlayerOne.Text);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
