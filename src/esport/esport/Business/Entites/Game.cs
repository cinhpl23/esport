using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esport.Business.Entites
{
    public class Game
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Round { get; set; }
        public string Team { get; set; }
        public string Player { get; set; }
        public int Score { get; set; }
        public int Stats { get; set; }
    }


}
