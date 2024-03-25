using esport.Business.Entites;

namespace esport.Business.Services
{
    public class PlayerService
    {
        private Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public void AddPlayer(string name, string pseudo, int idTeam)
        {
            Player player = new Player()
            {
                Id = _players.Count + 1,
                Name = name,
                Pseudo = pseudo,
                IdTeam = idTeam,
                MatchWin = 0
            };
            _players.Add(player.Id, player);
        }

        public Player GetPlayer(int id)
        {
            return _players[id];
        }

        public Dictionary<int, Player> GetAllPlayers()
        {
            return _players;
        }

        public void RemovePlayer(Player player)
        {
            _players.Remove(player.Id);
        }
    }
}
