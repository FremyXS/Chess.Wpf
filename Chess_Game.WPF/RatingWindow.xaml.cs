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
using System.IO;
using Chess_Game.Logic;
using Newtonsoft.Json;

namespace Chess_Game.WPF
{
    /// <summary>
    /// Логика взаимодействия для RatingWindow.xaml
    /// </summary>
    public partial class RatingWindow : Window
    {
        private List<Player> Players { get; set; } = new List<Player>();
        private Player[] TopPlayers { get; set; } = new Player[5];
        public RatingWindow()
        {
            InitializeComponent();
            this.Loaded += RatingWindow_Loaded;
            this.Closing += RatingWindow_Closing;
        }

        private void RatingWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var menu = new MainWindow();
            menu.Show();
        }

        private void RatingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var i in Directory.GetDirectories("data/Saves"))
            {
                string txtInfo = File.ReadAllText(i.ToString() + "/playerOne.txt");
                Players.Add(JsonConvert.DeserializeObject<Player>(txtInfo));
                txtInfo = File.ReadAllText(i.ToString() + "/playerTwo.txt");
                Players.Add(JsonConvert.DeserializeObject<Player>(txtInfo));
            }
            SetTop();

            foreach(var i in TopPlayers)
            {
                var text = new TextBlock
                {
                    Text = i.Name + "\n" + i.CountPoints,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    FontSize = 35
                };
                var bor = new Border
                {
                    BorderThickness = new Thickness(2),
                    BorderBrush = Brushes.Black,
                    Padding = new Thickness(5),
                };
                bor.Child = text;

                topList.Children.Add(bor);
            }
        }
        private void SetTop()
        {
            foreach(var i in Players)
            {
                IsMore(i);
            }
        }
        private void IsMore(Player player)
        {
            for(var i = 0; i < TopPlayers.Length; i++)
            {
                if(TopPlayers[i] is null)
                {
                    TopPlayers[i] = player;
                    break;
                }
                else if (player.CountPoints > TopPlayers[i].CountPoints)
                {
                    Offset(i);
                    TopPlayers[i] = player;
                    break;
                }

            }
        }
        private void Offset(int ind)
        {

            for(var i = TopPlayers.Length-1; i > ind; i--)
            {
                TopPlayers[i] = TopPlayers[i - 1];
            }
        }
        
    }
}
