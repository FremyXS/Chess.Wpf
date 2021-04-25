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

namespace Chess_Game.WPF
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private SolidColorBrush[] BrushesList { get; } =
        {
            Brushes.Black, Brushes.White, Brushes.Silver, Brushes.LightGray, Brushes.LightBlue, Brushes.LightGray
        };
        private int sw { get; set; } = 1;
        public Settings()
        {
            InitializeComponent();
        }

        private void Correct()
        {
            if (sw < 0) sw = 6;
            else if (sw > 5) sw = 0;
        }
        private void ColorOneLeftClick(object sender, RoutedEventArgs e)
        {
            sw--;
            Correct();
            ColorOne.Background = BrushesList[sw];
        }
    }
}
