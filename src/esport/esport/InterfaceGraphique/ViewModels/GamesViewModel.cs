using esport.Business.Entities;
using esport.Business.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Windows.Input;

namespace esport.InterfaceGraphique.ViewModels
{
    internal class GamesViewModel : INotifyPropertyChanged
    {
        private readonly TeamService _teamService;

        public ObservableCollection<Game> Game { get; private set; }

        public GamesViewModel()
        {
            _teamService = new TeamService();
            Game = new ObservableCollection<Game>(_gameservice.GetGames());
        }

        private ObservableCollection<Game> _games;
        public ObservableCollection<Game> _games;
        {
            get { return _games; }
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Game));
            }
        }

        private string _gamename;
        public string GameName
        {
            get { return _gamename; }
            set
            {
                _gamename = value;
                OnPropertyChanged(nameof(GameName));
            }
        }

        public ICommand AddGameCommand { get; }

        private void AddGame()
        {
            if (!string.IsNullOrWhiteSpace(GameName))
            {
                _teamService.AddTeam(GameName);
                Game.Add(new Game { Name = GameName });
                GameName = string.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }





}
