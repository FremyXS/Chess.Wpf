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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chess_Game.Logic;
using Newtonsoft.Json;

namespace Chess_Game.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer Player { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string txtInfo = File.ReadAllText("data/settings.txt");
            var tes = JsonConvert.DeserializeObject<Brush[]>(txtInfo);

            Settings.ColorOne = tes[0];
            Settings.ColorTwo = tes[1];
            Settings.ColorStep = tes[2];
            Settings.ColorEnemy = tes[3];

            Player = new MediaPlayer();
            Player.Open(new Uri("data/Music/home.mp3", UriKind.Relative));
            Player.Play();
        }

        private void NewGameClick(object sender, RoutedEventArgs e)
        {
            var inputNames = new InputNames();
            Close();
            inputNames.Show();
        }

        private void ContinueClick(object sender, RoutedEventArgs e)
        {
            var cont = new ContinueWindow();
            Close();
            cont.Show();
        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            var settings = new SettingsWindow();
            Close();
            settings.Show();
        }

        private void RatingClick(object sender, RoutedEventArgs e)
        {
            var rating = new RatingWindow();
            Close();
            rating.Show();
        }
    }
}
