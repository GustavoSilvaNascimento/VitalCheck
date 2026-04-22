using VitalCheck.model.Response;
using VitalCheck.Model;
using VitalCheck.Services;
using VitalCheck.Services.Users;

namespace VitalCheck.View;

public partial class CadastroView : ContentPage
{
    private readonly UserService _usuarioService;
    public CadastroView(UserService usuarioService)
    {
        InitializeComponent();
        _usuarioService = usuarioService;
    }
    private async void OnLoginClicked(object sender, EventArgs e)
     {
        try
        {
            await Shell.Current.GoToAsync("login");
        }
        catch (Exception)
        {

        } 
     }
    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        try
        {
            string nome = NomeCompletoEntry.Text;
            string email = EmailEntry.Text;
            string senha = SenhaEntry.Text;
            string confirmarSenha = ConfirmarSenhaEntry.Text;

            if (string.IsNullOrWhiteSpace(nome) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(senha))
            {
                await DisplayAlert("Erro", "Preencha todos os campos", "OK");
                return;
            }

            if (senha != confirmarSenha)
            {
                await DisplayAlert("Erro", "Senhas não conferem", "OK");
                return;
            }

            

            //Criar objeto
            var usuario = new Usuario
            {
                Nome = nome,
                Email = email,
                Senha = senha
            };

            //Salvar no banco
            await _usuarioService.InsertAsync(usuario);

            await DisplayAlert("Sucesso", "Usuário cadastrado!", "OK");

            //Limpar campos
            NomeCompletoEntry.Text = "";
            EmailEntry.Text = "";
            SenhaEntry.Text = "";
            ConfirmarSenhaEntry.Text = "";

            await Shell.Current.GoToAsync("pesogenero");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro na Navegação", ex.Message, "OK");
        }
    }

}
