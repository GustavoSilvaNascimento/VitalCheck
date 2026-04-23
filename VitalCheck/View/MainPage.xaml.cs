using VitalCheck.Services.Navigation;

namespace VitalCheck
{
    public partial class MainPage : ContentPage
    {   
        
        public MainPage()
        {
            InitializeComponent();
            

        }
        private async void OnSetaClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Cadastro");

        }
    }
}
