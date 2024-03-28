using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esport.Business.Entites
{
    // myDeserializedClass = JsonConvert.DeserializeObject<List<Rank>>(myJsonResponse);
    public class Rank
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Game { get; set; }
        public string Team { get; set; }
        public string Player { get; set; }
        public int Score { get; set; }
        public string Stats { get; set; }
    }


}
