using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esport.InterfaceGraphique.Models
{
    public class Team
    { 
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ListPlayer { get; set; }
        public int StatGame { get; set; }
    }

}
