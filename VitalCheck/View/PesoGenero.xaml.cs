using VitalCheck.Services.Auth;
using VitalCheck.Services.Navigation;
using VitalCheck.Services.Users;

namespace VitalCheck.View;

public partial class PesoGenero : ContentPage
{
    private readonly INavigationService _navigationService;
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    private string generoSelecionado = "Homem";

    public PesoGenero(
        INavigationService navigationService,
        IUserService userService,
        IAuthService authService)
    {
        InitializeComponent();

        _navigationService = navigationService;
        _userService = userService;
        _authService = authService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await VerificarLoginAsync();
    }

    private async Task VerificarLoginAsync()
    {
        bool logado = await _authService.IsLoggedAsync();

        if (!logado)
        {
            await _navigationService.NavigationAsync("///Main");
        }
    }

    private async void ImageButton_Clicked_1(
        object sender,
        EventArgs e)
    {
        try
        {
            var usuario =
                await _authService.GetCurrentUserAsync();

            if (usuario == null)
            {
                await DisplayAlert(
                    "Erro",
                    "Usuário não encontrado.",
                    "OK");
                return;
            }

            usuario.Genero = generoSelecionado;
            usuario.Altura = AlturaSlider.Value;
            usuario.Peso = PesoSlider.Value;

            await _userService.UpdateAsync(usuario);

            await Shell.Current.GoToAsync("idade");
        }
        catch (Exception ex)
        {
            await DisplayAlert(
                "Erro",
                ex.Message,
                "OK");
        }
    }

    private void TapGestureRecognizer_Homem(
        object sender,
        TappedEventArgs e)
    {
        generoSelecionado = "Homem";
        AtualizarCards();
    }

    private void TapGestureRecognizer_Mulher(
        object sender,
        TappedEventArgs e)
    {
        generoSelecionado = "Mulher";
        AtualizarCards();
    }

    private void AtualizarCards()
    {
        check_homem.IsVisible =
            generoSelecionado == "Homem";

        check_mulher.IsVisible =
            generoSelecionado == "Mulher";
    }
}