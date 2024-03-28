using esport.Business.Entites;
using System.Text.Json;

namespace esport.Business.Services
{
    public class PlayerService
    {
        private List<Player> _players = new List<Player>();

        public PlayerService()
        {
            InitializePlayers();
        }

        public void AddPlayer(Player player)
        {
            player.Id = _players.Count + 1;
            _players.Add(player);
        }

        public List<Player> GetPlayersByTeamId(int teamId)
        {
            return _players.FindAll(player => player.IdTeam == teamId);
        }

        public List<Player> GetPlayers()
        {
            return _players;
        }

        private void InitializePlayers()
        {
            _players.Add(new Player { Id = 1, Name = "Alex Chen", Pseudo = "ShadowFury", IdTeam = 1, MatchWin = 10 });
            _players.Add(new Player { Id = 2, Name = "Emily Rodriguez", Pseudo = "NovaStrike", IdTeam = 1, MatchWin = 8 });
            _players.Add(new Player { Id = 3, Name = "Liam Johnson", Pseudo = "CyberWraith", IdTeam = 2, MatchWin = 12 });
            _players.Add(new Player { Id = 4, Name = "Sarah Lee", Pseudo = "PixelPulse", IdTeam = 2, MatchWin = 6 });
        }

    }
}