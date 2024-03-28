using esport.Business.Entites;

namespace esport.Business.Services
{
    public class PlayerService
    {
        private List<Player> _players = new List<Player>();

        public void AddPlayer(string name, string pseudo, int idTeam)
        {
            Player player = new Player
            {
                Id = _players.Count + 1,
                Name = name,
                Pseudo = pseudo,
                IdTeam = idTeam,
                MatchWin = 0
            };
            _players.Add(player);
        }

        public List<Player> GetPlayersByTeamId(int teamId)
        {
            return _players.FindAll(player => player.IdTeam == teamId);
        }

        public List<Player> GetAllPlayers()
        {
            return _players;
        }
    }
}