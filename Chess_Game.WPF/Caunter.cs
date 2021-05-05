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
using System.Windows.Controls.Primitives;

namespace Chess_Game.WPF
{
    public class Caunter
    {
        private static UniformGrid Counter { get; set; }
        public Caunter(UniformGrid counter)
        {
            Counter = counter;
            UpdateCounter();
        }
        public static void UpdateCounter()
        {
            Counter.Children.Clear();

            GetOnePlayer(BoardModel.PlayerOne);
            GetOnePlayer(BoardModel.PlayerTwo);
        }
        private static void GetOnePlayer(Player player)
        {
            Counter.Children.Add(GetNamePlayer(player));
            Counter.Children.Add(GetPointsPlayer(player));
        }
        private static Label GetNamePlayer(Player player)
        {
            var name = new Label
            {
                Content = player.Name
            };

            return name;

        }
        private static Label GetPointsPlayer(Player player)
        {
            var points = new Label
            {
                Content = player.CountPoints,
            };

            return points;
        }
    }
}
