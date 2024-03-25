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
    }
}
