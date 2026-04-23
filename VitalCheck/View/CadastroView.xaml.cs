using VitalCheck.Services.Users;
using VitalCheck.Model.Response;

namespace VitalCheck.View;

public partial class CadastroView : ContentPage
{
    private readonly IUserService _usuarioService;
    public CadastroView(IUserService usuarioService)
    {
        InitializeComponent();
        _usuarioService = usuarioService;
    }
    private async void OnLoginClicked(object sender, EventArgs e)
     {
        try
        {
            await Shell.Current.GoToAsync("Login");
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
            Usuario user=await _usuarioService.AddDb(usuario);
            if (user != null)
            {
                await DisplayAlert("Sucesso", $"Usuário {user.Nome} cadastrado com sucesso!", "OK");
            }
             else
            {
                await DisplayAlert("Erro", "Falha ao cadastrar usuário", "OK");
                return;
            }
            //Limpar campos
            NomeCompletoEntry.Text = "";
            EmailEntry.Text = "";
            SenhaEntry.Text = "";
            ConfirmarSenhaEntry.Text = "";

            await Shell.Current.GoToAsync("pesogenero", new Dictionary<string, object>
            {
                ["usuario"] = usuario
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro na Navegação", ex.Message, "OK");
        }
    }

}
