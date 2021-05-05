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

namespace Chess_Game.WPF
{
    /// <summary>
    /// Логика взаимодействия для ContinueWindow.xaml
    /// </summary>
    public partial class ContinueWindow : Window
    {
        private List<Saves> SavesList { get; set; } = new List<Saves>();
        public ContinueWindow()
        {
            this.Loaded += ContinueWindow_Loaded;
            InitializeComponent();

        }
        private void ContinueWindow_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var i in Directory.GetDirectories("data/Saves"))
            {
                SavesList.Add(new Saves(i.ToString(), this));
            }

            foreach (var i in SavesList)
            {
                var bor = new Border
                {
                    BorderThickness = new Thickness(2),
                    BorderBrush = Brushes.Black,
                    Padding = new Thickness(5),
                };
                bor.Child = i.InfoText;
                playersStack.Children.Add(bor);
            }
        }

    }
}
