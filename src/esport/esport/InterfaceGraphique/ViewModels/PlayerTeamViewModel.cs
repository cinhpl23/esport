using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using esport.Business.Entites;
using esport.Business.Services;

namespace esport.InterfaceGraphique.ViewModels
{
    public class PlayerTeamViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly PlayerService _playerService = new PlayerService();
        private readonly TeamService _teamService = new TeamService();
        private int teamId = 1;

        private string _teamName;
        public string TeamName
        {
            get { return _teamName; }
            set
            {
                if (_teamName != value)
                {
                    _teamName = value;
                    OnPropertyChanged(nameof(TeamName));
                }
            }
        }

        private string _newPlayerName;
        public string NewPlayerName
        {
            get { return _newPlayerName; }
            set
            {
                if (_newPlayerName != value)
                {
                    _newPlayerName = value;
                    OnPropertyChanged(nameof(NewPlayerName));
                }
            }
        }

        private string _newPlayerPseudo;
        public string NewPlayerPseudo
        {
            get { return _newPlayerPseudo; }
            set
            {
                if (_newPlayerPseudo != value)
                {
                    _newPlayerPseudo = value;
                    OnPropertyChanged(nameof(NewPlayerPseudo));
                }
            }
        }

        public ObservableCollection<Player> Players { get; set; }

        public ICommand AddPlayer { get; private set; }
        public ICommand AddNewPlayer { get; private set; }
        public ICommand AddTeam { get; private set; }

        public PlayerTeamViewModel()
        {
            Players = new ObservableCollection<Player>();

            AddPlayer = new Command(ExecuteAddPlayer);
            AddNewPlayer = new Command(ExecuteAddNewPlayer);
            AddTeam = new Command<string>(ExecuteAddTeam);
        }

        private void ExecuteAddPlayer()
        {
            // Afficher le formulaire pour ajouter un joueur
            SetAddPlayerFormVisibility(true);
        }

        private void ExecuteAddNewPlayer()
        {
            _playerService.AddPlayer(NewPlayerName, NewPlayerPseudo, teamId);

            // Mettre à jour la liste des joueurs
            Players.Clear();
            foreach (var player in _playerService.GetPlayersByTeamId(teamId))
            {
                Players.Add(player);
            }

            // Cacher le formulaire après ajout
            SetAddPlayerFormVisibility(false);

            // Réinitialiser les valeurs
            NewPlayerName = string.Empty;
            NewPlayerPseudo = string.Empty;
        }

        private void SetAddPlayerFormVisibility(bool isVisible)
        {
            IsAddPlayerFormVisible = isVisible;
        }

        private bool _isAddPlayerFormVisible;
        public bool IsAddPlayerFormVisible
        {
            get { return _isAddPlayerFormVisible; }
            set
            {
                if (_isAddPlayerFormVisible != value)
                {
                    _isAddPlayerFormVisible = value;
                    OnPropertyChanged(nameof(IsAddPlayerFormVisible));
                }
            }
        }

        private void ExecuteAddTeam(string teamName)
        {
            _teamService.AddTeam(teamName);
        }
    }
}