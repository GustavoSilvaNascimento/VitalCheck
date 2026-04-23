using VitalCheck.Model.Response;
using VitalCheck.Services.Users;

namespace VitalCheck.View;

public partial class LoginView : ContentPage
{

    private readonly UserService _usuarioService;
	public LoginView(UserService usuarioService)
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
                await Shell.Current.GoToAsync("//dashboard_home");
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
            await Shell.Current.GoToAsync("Cadastro");
        }
        catch (Exception) {
            
        }
    }
}