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
            foreach (var i in Directory.GetDirectories("data"))
            {
                SavesList.Add(new Saves(i.ToString(), this));
            }
        }

        private void playersBorder_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            playersStack.Children.Clear();

            foreach(var i in SavesList)
            {
                playersStack.Children.Add(i.Names);

            }
        }

    }
}
