using esport.Views;

namespace esport
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnTeamsViewButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TeamView());
        }
        private async void OnPlayersViewButtonClicked(object sender, EventArgs e)        
        {
            await Navigation.PushAsync(new PlayersView());
        }

        private async void OnPlayerTeamViewButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayerTeamView());
        }
        
    }
}
