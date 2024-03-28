using esport.Views;

namespace esport
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPlayerTeamViewButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayerTeamView());
        }

        private async void OnRankViewButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RankView());
        }
    }
}
