using VitalCheck.Model;
using VitalCheck.Services;

namespace VitalCheck.View;

public partial class LoginView : ContentPage
{

    private readonly UsuarioService _usuarioService;
	public LoginView(UsuarioService usuarioService)
	{
		InitializeComponent();
        _usuarioService = usuarioService;
    }
	
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        try 
        {
            string email = EmailEntry.Text;
            string senha = SenhaEntry.Text;

            if (string.IsNullOrWhiteSpace(email) || 
                string.IsNullOrWhiteSpace(senha)) 
            {
                await DisplayAlert("Erro.", "Preencha todos os campos.", "Ok");
                return;
            }

            Usuario usuarioLogado = await _usuarioService.GetByEmailAndSenhaAsync(email, senha);

            if(usuarioLogado != null)
            {
                await Shell.Current.GoToAsync("//dashboard");
            } else
            {
                await DisplayAlert("Erro", "Login ou senha incorretos.", "Ok");
            }


        } catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro insperado: {ex.Message}", "Ok");
        }
    }

    private async void OnCadastroClicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("cadastro");
        }
        catch (Exception) {
            
        }
    }
}