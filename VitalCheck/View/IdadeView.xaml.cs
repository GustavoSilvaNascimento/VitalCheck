using VitalCheck.Services.Navigation;
using VitalCheck.Services.Users;

namespace VitalCheck.View;

[QueryProperty(nameof(Token), "Token")]
public partial class IdadeView : ContentPage
{
    #region Token
    public string Token
    {
        set => _token = value;
    }

    private string _token;
    #endregion
    private readonly INavigationService _navigationService;
    private readonly IUserService _userService;
    public IdadeView(INavigationService navigationService, IUserService userService)
	{
        _navigationService = navigationService;
        _userService = userService;
        if (string.IsNullOrEmpty(_token))
        {
            Console.WriteLine("Token não recebido.");
            _navigationService.NavigationAsync("///Main");
        }
        else { InitializeComponent(); }
    }

        private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		//Adicionar logica do Banco de Dados

		// Navegar para a aba principal (rota única definida em AppShell.xaml)
		await Shell.Current.GoToAsync("//dashboard_home");
	}
}