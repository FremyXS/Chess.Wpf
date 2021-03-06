using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Chess_Game.Logic
{
    public class Info
    {
        public static void SaveGame(string namePlayerOne, string namePlayerTwo)
        {
            Directory.CreateDirectory($"data/Saves/{namePlayerOne}_{namePlayerTwo}");
            string serialized = JsonConvert.SerializeObject(BoardModel.Board, Formatting.Indented);
            File.WriteAllText($"data/Saves/{namePlayerOne}_{namePlayerTwo}/board.txt", serialized);
        }
        public static void LoadGame(string nameOne, string nameTwo)
        {
            string txtInfo = File.ReadAllText($"data/Saves/{nameOne}_{nameTwo}/board.txt");
            var tes = JsonConvert.DeserializeObject<Figure[,]>(txtInfo);
            BoardModel.Board = tes;

            BoardModel.PlayerOne = LoadPlayers(nameOne, nameTwo);
            BoardModel.PlayerTwo = LoadPlayers(nameOne, nameTwo, "playerTwo");
        }
        public static void SaveStepPlayer(bool stepPlayer, string namePlayerOne, string namePlayerTwo)
        {
            string step = JsonConvert.SerializeObject(stepPlayer, Formatting.Indented);
            File.WriteAllText($"data/Saves/{namePlayerOne}_{namePlayerTwo}/step.txt", step);
        }
        public static bool LoadStepPlayer(string nameOne, string nameTwo)
        {
            string txtInfo = File.ReadAllText($"data/Saves/{nameOne}_{nameTwo}/step.txt");
            var tes = JsonConvert.DeserializeObject<bool>(txtInfo);
            return tes;
        }
        public static void SavePlayers(Player playerOne, Player playerTwo)
        {
            string platerOneInfo = JsonConvert.SerializeObject(playerOne, Formatting.Indented);
            File.WriteAllText($"data/Saves/{playerOne.Name}_{playerTwo.Name}/playerOne.txt", platerOneInfo);

            string platerTwoInfo = JsonConvert.SerializeObject(playerTwo, Formatting.Indented);
            File.WriteAllText($"data/Saves/{playerOne.Name}_{playerTwo.Name}/playerTwo.txt", platerTwoInfo);
        }
        private static Player LoadPlayers(string nameOne, string nameTwo, string name = "playerOne")
        {
            string txtInfo = File.ReadAllText($"data/Saves/{nameOne}_{nameTwo}/{name}.txt");
            var tes = JsonConvert.DeserializeObject<Player>(txtInfo);

            return tes;
        }
        
    }
}
