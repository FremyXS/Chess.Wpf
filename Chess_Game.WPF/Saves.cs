using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;
using Chess_Game.Logic;

namespace Chess_Game.WPF
{
    public class Saves
    {
        private ContinueWindow Cw { get; set; }
        private string Link { get; set; }
        public TextBlock Names { get; }
        public Saves(string link, ContinueWindow cw)
        {
            Cw = cw;
            Link = link;
            Names = new TextBlock
            {
                Text = link.Split(new char[] { '\\' })[1],
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                FontSize = 35,
            };

            Names.MouseLeftButtonDown += Names_MouseLeftButtonDown;
        }

        private void Names_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Info.LoadGame(Names.Text.Split(new char[] { '_'})[0], Names.Text.Split(new char[] { '_' })[1]);
            var game = new GameShow();
            Cw.Close();
            game.Show();
            
        }

    }
}
