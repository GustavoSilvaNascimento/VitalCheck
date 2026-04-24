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
            if (await _usuarioService.GetByEmailAsync(email) != null) { 
                //Criar objeto
                var usuario = new Usuario
                {
                    Nome = nome,
                    Email = email,
                    Senha = senha
                };

                //Salvar no banco
                Usuario user = await _usuarioService.AddDb(usuario);
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

                UserToken userToken = await _usuarioService.CreateToken(user);
                string token = userToken.Token;
                await Shell.Current.GoToAsync("pesogenero", new Dictionary<string, object>
                {
                    ["Token"] = token
                });
            }else
             {
                await DisplayAlert("Erro", "Email já cadastrado", "OK");
                EmailEntry.Text = "";
                return;
             }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro na Navegação", ex.Message, "OK");
        }
    }

}
