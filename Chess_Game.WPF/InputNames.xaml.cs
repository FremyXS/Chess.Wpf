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
            if(CheckName(namePlayerOne.Text) 
            && CheckName(namePlayerTwo.Text))
            {
                BoardModel.PlayerOne = new Player(namePlayerOne.Text);
                BoardModel.PlayerTwo = new Player(namePlayerTwo.Text);

                Board.GameIsOpen = true;
                Board.StepPlayer = true;
                BoardModel.GetStartBoard();

                var game = new GameShow();
                Close();
                game.Show();
            }
        }
        private bool CheckName(string namePlayer)
        {
            if (namePlayer.Length > 2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
