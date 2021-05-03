using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;

namespace Chess_Game.WPF
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private Brush[] BrushesList { get; } =
        {
            Brushes.Black, Brushes.White, Brushes.Silver, Brushes.LightGray, Brushes.LightBlue, 
            Brushes.LightGray, Brushes.RosyBrown, Brushes.Brown, Brushes.SandyBrown, Brushes.Green,
            Brushes.Red,
        };
        private int sw { get; set; } = 1;
        public SettingsWindow()
        {
            InitializeComponent();

            this.Loaded += SettingsWindow_Loaded;
            this.Closing += SettingsWindow_Closing;
        }

        private void SettingsWindow_Loaded(object sender, RoutedEventArgs e)
        {

            ColorOne.Background = Settings.ColorOne;
            ColorTwo.Background = Settings.ColorTwo;
            ColorStep.Background = Settings.ColorStep;
            ColorEnemy.Background = Settings.ColorEnemy;
        }

        private void SettingsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string serialized = JsonConvert.SerializeObject(new Brush[] { 
                ColorOne.Background, ColorTwo.Background, ColorStep.Background, ColorEnemy.Background },
                Formatting.Indented);

            File.WriteAllText("settings.txt", serialized);

            var menu = new MainWindow();
            menu.Show();           
        }
        
        private void Correct()
        {
            if (sw < 0) sw = BrushesList.Length-1;
            else if (sw > BrushesList.Length-1) sw = 0;
        }
        private void ColorOneLeftClick(object sender, RoutedEventArgs e)
        {
            sw--;
            Correct();
            ColorOne.Background = BrushesList[sw];
        }

        private void ColorOneRightClick(object sender, RoutedEventArgs e)
        {
            sw++;
            Correct();
            ColorOne.Background = BrushesList[sw];
        }

        private void ColorTwoLeftClick(object sender, RoutedEventArgs e)
        {
            sw--;
            Correct();
            ColorTwo.Background = BrushesList[sw];
        }

        private void ColorTwoRightClick(object sender, RoutedEventArgs e)
        {
            sw++;
            Correct();
            ColorTwo.Background = BrushesList[sw];
        }

        private void ColorStepLeftClick(object sender, RoutedEventArgs e)
        {
            sw--;
            Correct();
            ColorStep.Background = BrushesList[sw];
        }

        private void ColorStepRightClick(object sender, RoutedEventArgs e)
        {
            sw++;
            Correct();
            ColorStep.Background = BrushesList[sw];
        }

        private void ColorEnemyLeftClick(object sender, RoutedEventArgs e)
        {
            sw--;
            Correct();
            ColorEnemy.Background = BrushesList[sw];
        }

        private void ColorEnemyRightClick(object sender, RoutedEventArgs e)
        {
            sw++;
            Correct();
            ColorEnemy.Background = BrushesList[sw];
        }
    }
}
