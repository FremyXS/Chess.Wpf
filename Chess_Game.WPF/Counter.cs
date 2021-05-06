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
    public class Counter
    {
        private static UniformGrid CounterGrid { get; set; }
        public Counter(UniformGrid counter)
        {
            CounterGrid = counter;
            UpdateCounter();
        }
        public static void UpdateCounter()
        {
            CounterGrid.Children.Clear();

            GetOnePlayer(BoardModel.PlayerOne);
            GetOnePlayer(BoardModel.PlayerTwo);
        }
        private static void GetOnePlayer(Player player)
        {
            CounterGrid.Children.Add(GetNamePlayer(player));
            CounterGrid.Children.Add(GetPointsPlayer(player));
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
