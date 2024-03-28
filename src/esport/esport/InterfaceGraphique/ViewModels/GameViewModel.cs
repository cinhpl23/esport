using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using esport.InterfaceGraphique.Models;
using GameFinder.Model;

namespace esport.InterfaceGraphique.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<GameModel> _games;
        public ObservableCollection<GameModel> Games
        {
            get => _games;
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
            }
        }

        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Round {  get; set; }
        public string Team { get; set; }
        public string Player { get; set; }
        public int Score { get; set; }
        public int Stats { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Ajoute une partie à la liste
        public ICommand AddGameCommand { get; }

        public GameViewModel()
        {
            Games = new ObservableCollection<GameModel>
            {
                new GameModel { ID = 1, Round="Taureau", Team="WarpZone", Player="ShadowFury", Score=1, Stats=10 },
                new GameModel { ID = 2, Round = "Taureau", Team = "PhoenixFury", Player = "NovaStrike", Score= 0, Stats = 8 }
            };

            AddGameCommand = new Command(AddGame);
        }

        private void AddGame()
        {
            var newGame = new GameModel
            {
                ID = ID,
                Date = Date,
                Round = Round,
                Team = SelectedTeam?.Name,
                Player = SelectedPlayer?.Pseudo,
                Score = Score,
                Stats = Stats
            };

            Games.Add(newGame);
        }

        // Afficher les équipes et les joueurs dans la sélection de l'ajout d'une partie
        private PlayerModel _selectedPlayer;
        public PlayerModel SelectedPlayer
        {
            get { return _selectedPlayer; }
            set
            {
                if (_selectedPlayer != value)
                {
                    _selectedPlayer = value;
                    OnPropertyChanged();
                }
            }
        }

        private TeamModel _selectedTeam;
        public TeamModel SelectedTeam
        {
            get { return _selectedTeam; }
            set
            {
                if (_selectedTeam != value)
                {
                    _selectedTeam = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
