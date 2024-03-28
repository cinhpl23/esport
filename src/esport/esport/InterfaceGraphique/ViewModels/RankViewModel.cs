using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using esport.Business.Entites;
using esport.Business.Services;
using esport.InterfaceGraphique.Models;

namespace esport.InterfaceGraphique.ViewModels
{
    public class RankViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Rank> _rank;
        public ObservableCollection<Rank> Rank
        {
            get => _rank;
            set
            {
                _rank = value;
                OnPropertyChanged(nameof(Rank));
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

        private string _game;
        public string Game
        {
            get => _game;
            set
            {
                _game = value;
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

        public ICommand AddRankCommand { get; }

        public RankViewModel()
        {
            AddRankCommand = new Command(AddRank);
        }

        private async void AddRank()
        {
            var newRank = new Rank
            {
                ID = ID,
                Date = Date,
                Game = Game,
                Team = Team,
                Player = Player,
                Score = Score,
                Stats = Stats.ToString() 
            };

            await new RankService().AddRank(newRank);

            ID = 0;
            Date = DateTime.Now;
            Game = string.Empty;
            Team = string.Empty;
            Player = string.Empty;
            Score = 0;
            Stats = 0;

        }
    }

}