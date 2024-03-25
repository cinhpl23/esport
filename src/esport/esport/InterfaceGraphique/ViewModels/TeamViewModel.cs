using esport.Business.Entites;
using esport.Business.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace esport.InterfaceGraphique.ViewModels
{
    internal class TeamViewModel : INotifyPropertyChanged
    {
        private readonly TeamService _teamService;

        public TeamViewModel()
        {
            _teamService = new TeamService();
            Teams = new ObservableCollection<Team>(_teamService.GetTeams());
            AddTeamCommand = new Command(AddTeam);
        }

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

        private string _teamName;
        public string TeamName
        {
            get { return _teamName; }
            set
            {
                _teamName = value;
                OnPropertyChanged(nameof(TeamName));
            }
        }

        public ICommand AddTeamCommand { get; }

        private void AddTeam()
        {
            if (!string.IsNullOrWhiteSpace(TeamName))
            {
                _teamService.AddTeam(TeamName);
                Teams.Add(new Team { Name = TeamName });
                TeamName = string.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
