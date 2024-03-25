using AVFoundation;
using esport.Business.Services;
using esport.InterfaceGraphique.Models;
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
        private PlayerModel _selectedPlayer;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public ObservableCollection<PlayerModel> Players { get; set; }

        public PlayerModel SelectedPlayer
        {
            get => _selectedPlayer;
            set
            {
                if (_selectedPlayer != value)
                {
                    _selectedPlayer = value;
                    OnPropertyChanged(nameof(SelectedPlayer));
                }
            }
        }

        public ICommand AddPlayerCommand { get; private set; }
        public PlayerService playerService = new PlayerService();

        public MainViewModel()
        {
            Players = new ObservableCollection<PlayerModel>();

            int tmp = 1;

            AddPlayerCommand = new Command(PlayerService.AddPlayer(_nameEntry, _pseudoEntry, 1));
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}