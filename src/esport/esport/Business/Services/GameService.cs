using esport.Business.Entites;

namespace esport.Business.Services
{
    internal class GameService
    {
        private List<Game> games;
        public GameService()
        {
            games = new List<Game>();
        }

        public void AddGame(Game game)
        {
            games.Add(game);
        }
    }

}
