using esport.Business.Entites;
using System.Collections.Generic;

namespace esport.Business.Services
{
    internal class TeamService
    {
        private readonly List<Team> _teams = new List<Team>();

        public void AddTeam(string name)
        {
            int id = _teams.Count + 1;
            Team team = new Team
            {
                Id = id,
                Name = name
            };
            _teams.Add(team);
        }

        public List<Team> GetTeams()
        {
            return _teams;
        }


    }
}
