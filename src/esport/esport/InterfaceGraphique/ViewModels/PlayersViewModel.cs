using esport.Business.Entites;
using esport.Business.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace esport.InterfaceGraphique.ViewModels
{
    class PlayersViewModel
    {
        private string _nameEntry;
        private string _pseudoEntry;
        private string _teamEntry;
        private readonly PlayerService _playerService;
        private readonly TeamService _teamService;

        public string NameEntry
        {
            get => _nameEntry;
            set
            {
                if (_nameEntry != value)
                {
                    _nameEntry = value;
                    OnPropertyChanged(nameof(NameEntry));
                }
            }
        }

        public string PseudoEntry
        {
            get => _pseudoEntry;
            set
            {
                if (_pseudoEntry != value)
                {
                    _pseudoEntry = value;
                    OnPropertyChanged(nameof(PseudoEntry));
                }
            }
        }

        public string TeamEntry
        {
            get => _teamEntry;
            set
            {
                if (_teamEntry != value)
                {
                    _teamEntry = value;
                    OnPropertyChanged(nameof(TeamEntry));
                }
            }
        }

        public PlayersViewModel()
        {
            _playerService = new PlayerService();
            Players = new ObservableCollection<Player>(_playerService.GetAllPlayers());
            AddPlayerCommand = new Command(AddPlayer);
        }

        private ObservableCollection<Player> _Players;
        public ObservableCollection<Player> Players
        {
            get { return _Players; }
            set
            {
                _Players = value;
                OnPropertyChanged(nameof(Players));
            }
        }

        public ICommand AddPlayerCommand { get; }

        private void AddPlayer()
        {
            if (!string.IsNullOrWhiteSpace(_nameEntry) && !string.IsNullOrWhiteSpace(_pseudoEntry) && !string.IsNullOrWhiteSpace(_teamEntry))
            {

                var tmp = 1;

                _playerService.AddPlayer(_nameEntry, _pseudoEntry, tmp);
                Players.Add(new Player { Name = NameEntry, Pseudo = PseudoEntry, IdTeam = tmp, MatchWin = 0 });
                NameEntry = string.Empty;
            }
        }

        //private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    List<Business.Entites.Team> Teams = _teamService.GetTeams();
        //    foreach (var team in Teams)
        //    {
        //        myPicker.Items.Add(team.Name);
        //    }

        //    var selectedTeamName = myPicker.SelectedItem as string;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}