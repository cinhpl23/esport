using esport.Business.Entites;
using GameFinder.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;

namespace esport.Business.Services
{
    public class GameService
    {
        private List<Game> _games = new List<Game>();

        public GameService() 
        {
            InitializeGames();
        }

        public void AddGame(Game game)
        {
            game.ID = _games.Count + 1;
            _games.Add(game);
        }

        private void InitializeGames()
        {
            _games.Add(new Game { ID = 1, Round="Taureau", Team="WarpZone", Player="ShadowFury", Score=1, Stats=10  });
            _games.Add(new Game { ID = 2, Round = "Taureau", Team = "PhoenixFury", Player = "NovaStrike", Score = 0, Stats = 8 });
        }

    }

}
