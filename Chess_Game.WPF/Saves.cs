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
        public TextBlock InfoText { get; }
        public string[] Players { get; }
        public Saves(string link, ContinueWindow cw)
        {
            Players = link.Split(new char[] { '\\', '_' });
            Cw = cw;
            InfoText = new TextBlock
            {
                Text = Players[1] + "\n" + "VS" + "\n" + Players[2],
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                FontSize = 35,
            };

            InfoText.MouseLeftButtonDown += Names_MouseLeftButtonDown;
        }

        private void Names_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Info.LoadGame(Players[1], Players[2]);
            Board.StepPlayer = Info.LoadStepPlayer(Players[1], Players[2]);
            var game = new GameShow();
            Board.GameIsOpen = true;
            Cw.Close();
            game.Show();
            
        }

    }
}
