using VitalCheck.Services.Navigation;
using VitalCheck.Services.Users;

namespace VitalCheck.View;

[QueryProperty(nameof(Token), "Token")]
public partial class IdadeView : ContentPage
{
    #region Token
    private string? _token;
    
    public string? Token
    {
        set => _token = value;
    }

    #endregion
    private readonly INavigationService _navigationService;
    private readonly IUserService _userService;
    public IdadeView(INavigationService navigationService, IUserService userService)
	{
        InitializeComponent();
        _navigationService = navigationService;
        _userService = userService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (string.IsNullOrEmpty(_token))
        {
            Console.WriteLine("Token não recebido.");
            _navigationService.NavigationAsync("///Main");
        }
    }

        private async void ImageButton_Clicked(object sender, EventArgs e)
	{
        //Adicionar logica do Banco de Dados

        // Navegar para a aba principal (rota única definida em AppShell.xaml)
        await Shell.Current.GoToAsync("///dashboard_home");
    }
}