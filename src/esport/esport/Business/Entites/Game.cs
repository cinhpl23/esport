using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esport.Business.Entites
{
    internal class Game
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Match { get; set; }
        public List<string> Teams { get; set; }
        public List<string> Players { get; set; }
        public int Score { get; set; }
        public Dictionary<string, int> StatsGame { get; set; }
        public Game()
        {
            Teams = new List<string>();
            Players = new List<string>();
            StatsGame = new Dictionary<string, int>();
        }
    }
}
