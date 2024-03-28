using esport.InterfaceGraphique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameFinder.Model
{
    public class GameModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Round { get; set; }
        public string Team { get; set; }
        public string Player { get; set; }
        public int Score { get; set; }
        public int Stats { get; set; }
    }

[JsonSerializable(typeof(List<GameModel>))]
    internal sealed partial class GameContext : JsonSerializerContext
    {

    }


}
