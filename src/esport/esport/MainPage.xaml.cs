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

    }

}
