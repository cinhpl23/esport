using esport.Business.Entites;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// A faire car non fonctionnel
namespace esport.InterfaceGraphique.ViewModels
{
    public class RankViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Game> _games;
        public ObservableCollection<Game> Games
        {
            get => _games;
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
            }
        }

        public RankViewModel()
        {
            Games = new ObservableCollection<Game>();
        }

        public RankViewModel(ObservableCollection<Game> games)
        {
            Games = games;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
