namespace VitalCheck.View;

using Microsoft.Maui.Graphics;
using VitalCheck.Model.Response;
using VitalCheck.Services.Users;

[QueryProperty(nameof(Token), "Token")]
public partial class PesoGenero : ContentPage
{
    #region token
    public string Token
    {
        set
        {
            _token = Uri.UnescapeDataString(value); // importante!
            Console.WriteLine(_token);
        }
    }

    private string _token;
    #endregion
    private readonly INavigationService _navigationService;
    private readonly IUserService _userService;
    private string generoSelecionado = "Homem";
    public PesoGenero(INavigationService navigationService, IUserService userService)
    {
        _navigationService = navigationService;
        _userService = userService;
        if (string.IsNullOrEmpty(_token))
        {
            Console.WriteLine("Token não recebido.");
            _navigationService.NavigationAsync("///Main");
        }
        else {InitializeComponent();}
         

    }


    private async void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        try 
        {
            string genero = generoSelecionado;
            double altura = AlturaSlider.Value;
            double peso = PesoSlider.Value;

            Usuario usuario= await _userService.GetByTokenAsync(_token);
            usuario.Genero = genero;
            usuario.Altura = altura;
            usuario.Peso = peso;
            await _userService.UpdateTokenAsync(usuario, _token);

            await Shell.Current.GoToAsync("idade");

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro na Navegação", ex.Message, "OK");
        }
    }

    private void TapGestureRecognizer_Homem(object sender, TappedEventArgs e)
    {
        if (generoSelecionado != "Homem") 
        {
            generoSelecionado = "Homem";
            AtualizarCards();
        }
    }

    private void TapGestureRecognizer_Mulher(object sender, TappedEventArgs e)
    {
        if(generoSelecionado != "Mulher") 
        {
            generoSelecionado = "Mulher";
            AtualizarCards();
        }
    }

    private void AtualizarCards()
    {
        if(generoSelecionado == "Homem")
        {
            check_homem.IsVisible = true;

            check_mulher.IsVisible = false;
        }

        else if (generoSelecionado == "Mulher") {
            check_mulher.IsVisible = true;

            check_homem.IsVisible = false;
        }

    }
}