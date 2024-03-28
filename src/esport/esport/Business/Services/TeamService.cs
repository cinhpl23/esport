using esport.Business.Entites;

namespace esport.Business.Services
{
    public class TeamService
    {
        private List<Team> _teams = new List<Team>();

        public TeamService()
        {
            InitializeTeams();
        }

        public void AddTeam(Team team)
        {
            team.Id = _teams.Count + 1;
            _teams.Add(team);
        }

        public Team GetTeamById(int teamId)
        {
            return _teams.Find(team => team.Id == teamId)!;
        }

        public List<Team> GetTeams()
        {
            return _teams;
        }

        private void InitializeTeams()
        {
            _teams.Add(new Team { Id = 1, Name = "PhoenixFury", StatGame = 20 });
            _teams.Add(new Team { Id = 2, Name = "WarpZone", StatGame = 18 });
        }
    }
}
