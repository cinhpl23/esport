using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using esport.Business.Entites;
using esport.Business.Services;

namespace esport.InterfaceGraphique.ViewModels
{
    public class PlayerTeamViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly PlayerService _playerService = new PlayerService();
        private readonly TeamService _teamService = new TeamService();
        private int _idTeam;

        private string? _newPlayerName;
        public string NewPlayerName
        {
            get { return _newPlayerName!; }
            set
            {
                if (_newPlayerName != value)
                {
                    _newPlayerName = value;
                    OnPropertyChanged(nameof(NewPlayerName));
                }
            }
        }

        private string? _newPlayerPseudo;
        public string NewPlayerPseudo
        {
            get { return _newPlayerPseudo!; }
            set
            {
                if (_newPlayerPseudo != value)
                {
                    _newPlayerPseudo = value;
                    OnPropertyChanged(nameof(NewPlayerPseudo));
                }
            }
        }

        private string? _teamName;
        public string? TeamName
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

        public ObservableCollection<Player> Players { get; private set; }
        private ObservableCollection<Team> _teams;
        public ObservableCollection<Team> Teams
        {
            get { return _teams; }
            set
            {
                _teams = value;
                OnPropertyChanged(nameof(Teams));
            }
        }


        public ICommand AddPlayer { get; private set; }
        public ICommand AddNewPlayer { get; private set; }
        public ICommand AddTeam { get; private set; }

        public PlayerTeamViewModel()
        {
            int _idTeam = _teamService.GetTeams().Count + 1;
            Players = new ObservableCollection<Player>(_playerService.GetPlayersByTeamId(_idTeam));
            LoadTeamsAndPlayers();

            AddPlayer = new Command(ExecuteAddPlayer);
            AddNewPlayer = new Command(ExecuteAddNewPlayer);
            AddTeam = new Command<string>(ExecuteAddTeam);
        }

        private void LoadTeamsAndPlayers()
        {
            Teams = new ObservableCollection<Team>(_teamService.GetTeams());

            // Chargez les joueurs pour chaque équipe
            foreach (var team in Teams)
            {
                team.ListPlayer = new List<Player>(_playerService.GetPlayersByTeamId(team.Id));
            }
        }

        private void ExecuteAddPlayer()
        {
            // Afficher le formulaire pour ajouter un joueur
            SetAddPlayerFormVisibility(true);
        }

        private void ExecuteAddNewPlayer()
        {
            Player player = new Player
            {
                Name = NewPlayerName,
                Pseudo = NewPlayerPseudo,
                IdTeam = _idTeam
            };

            _playerService.AddPlayer(player);

            // Mettre à jour la liste des joueurs
            Players.Clear();
            foreach (var p in _playerService.GetPlayersByTeamId(_idTeam))
            {
                Players.Add(p);
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
            List<Player> teamPlayers = _playerService.GetPlayersByTeamId(_idTeam);
            Team team = new Team { Name = teamName, ListPlayer = teamPlayers, StatGame = 0 };
            _teamService.AddTeam(team);

            LoadTeamsAndPlayers();

            // Réinitialiser les champs
            Players = null;
            OnPropertyChanged(nameof(Players));
            TeamName = string.Empty;
            OnPropertyChanged(nameof(TeamName));
        }
    }

}