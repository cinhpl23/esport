using esport.Business.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esport.Business.Services
{
    internal class TeamService
    {
        private Dictionary<int, Team> _teams = new Dictionary<int, Team>();

        public void AddTeam(int id, string name)
        {
            Team team = new()
            {
                Id = id,
                Name = name
            };
            _teams.Add(id, team);
        }

        public Team GetTeam(int id) 
        { 
            if (_teams.ContainsKey(id))
            {
                return _teams[id];
            }
            else
            {
                return null;
            }
        }
    }
}
