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
        public static void SaveInfo()
        {
            string serialized = JsonConvert.SerializeObject(BoardModel.Board, Formatting.Indented);
            File.WriteAllText("save1.txt", serialized);
        }
        public static void LoadInfo()
        {
            string txtInfo = File.ReadAllText("save1.txt").Replace("'", "\"");
            var tes = JsonConvert.DeserializeObject<Role[,]>(txtInfo);
            BoardModel.Board = tes;

        }
    }
}
