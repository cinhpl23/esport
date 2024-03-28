using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using esport.Business.Entites;
using esport.Business.Services;
using esport.InterfaceGraphique.Models;

namespace esport.InterfaceGraphique.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Game> _game;
        public ObservableCollection<Game> Game
        {
            get => _game;
            set
            {
                _game = value;
                OnPropertyChanged(nameof(Game));
            }
        }

        private int _id;
        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private string _round;
        public string Round
        {
            get => _round;
            set
            {
                _round = value;
                OnPropertyChanged();
            }
        }

        private string _team;
        public string Team
        {
            get => _team;
            set
            {
                _team = value;
                OnPropertyChanged();
            }
        }

        private string _player;
        public string Player
        {
            get => _player;
            set
            {
                _player = value;
                OnPropertyChanged();
            }
        }

        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        private int _stats;
        public int Stats
        {
            get => _stats;
            set
            {
                _stats = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand AddGameCommand { get; }

        public GameViewModel()
        {
            AddGameCommand = new Command(AddGame);
        }

        private async void AddGame()
        {
            var newGame = new Game
            {
                ID = ID,
                Date = Date,
                Round = Round,
                Team = Team,
                Player = Player,
                Score = Score,
                Stats = Stats 
            };

        }
    }

}