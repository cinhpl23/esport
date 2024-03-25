using esport.InterfaceGraphique.ViewModels;

namespace esport.Views
{
    public partial class TeamView : ContentPage
    {
        public TeamView()
        {
            InitializeComponent();
            BindingContext = new TeamViewModel();
        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}