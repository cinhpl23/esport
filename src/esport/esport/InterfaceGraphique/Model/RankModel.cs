using esport.InterfaceGraphique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RankFinder.Model
{
    public class RankModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Game { get; set; }
        public string TeamsOrPlayers { get; set; }
        public int Score { get; set; }
        public  Stats Stats { get; set; }
    }

    public class Stats
    {
        public int Stat1 { get; set; }
        public int Stat2 { get; set; }
    }

[JsonSerializable(typeof(List<RankModel>))]
    internal sealed partial class RankContext : JsonSerializerContext
    {

    }


}
