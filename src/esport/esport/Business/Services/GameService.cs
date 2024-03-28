using esport.Business.Entites;

namespace esport.Business.Services
{
    public class GameService
    {
        private List<Game> _games = new();

        public GameService()
        {
            InitializeGames();
        }

        private void InitializeGames()
        {
            _games.Add(new Game { ID = 1, Round = "Taureau", Team = "WarpZone", Player = "ShadowFury", Score = 1, Stats = 10 });
            _games.Add(new Game { ID = 2, Round = "Taureau", Team = "PhoenixFury", Player = "NovaStrike", Score = 0, Stats = 8 });
        }

    }

}
