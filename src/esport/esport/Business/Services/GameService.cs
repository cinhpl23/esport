using esport.Business.Entities;

namespace esport.Business.Services
{
    internal class GameService
    {
        private List<Match> games;
        public GameService()
        {
            games = new List<Match>();
        }

        public void AddMatch(Match match)
        {
            games.Add(match);
        }
    }

}
