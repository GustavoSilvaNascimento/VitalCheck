using System.Windows.Input;
using VitalCheck.Model.Response;
using VitalCheck.Services.Users;
using VitalCheck.Services.Settings;
namespace VitalCheck.ViewModels
{
    public class CadastroViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly ISettingsService _settingsService;

        public CadastroViewModel(
            IUserService userService,
            ISettingsService settingsService,
            IAuthService authService)
        {
            _userService = userService;
            _settingsService = settingsService;
            _authService = authService;

            CadastrarCommand =
                new Command(async () => await CadastrarAsync());

            LoginCommand =
                new Command(async () => await IrLoginAsync());
            
        }

        private string nome;
        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string senha;
        public string Senha
        {
            get => senha;
            set
            {
                senha = value;
                OnPropertyChanged();
            }
        }

        private string confirmarSenha;
        public string ConfirmarSenha
        {
            get => confirmarSenha;
            set
            {
                confirmarSenha = value;
                OnPropertyChanged();
            }
        }

        public ICommand CadastrarCommand { get; }
        public ICommand LoginCommand { get; }

        private async Task IrLoginAsync()
        {
            await Shell.Current.GoToAsync("Login");
        }

        private async Task CadastrarAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Nome) ||
                    string.IsNullOrWhiteSpace(Email) ||
                    string.IsNullOrWhiteSpace(Senha) ||
                    string.IsNullOrWhiteSpace(ConfirmarSenha))
                {
                    await Shell.Current.DisplayAlert(
                        "Erro",
                        "Preencha todos os campos.",
                        "OK");
                    return;
                }

                if (Senha != ConfirmarSenha)
                {
                    await Shell.Current.DisplayAlert(
                        "Erro",
                        "Senhas não conferem.",
                        "OK");
                    return;
                }

                var usuario = new Usuario
                {
                    Nome = Nome,
                    Email = Email.Trim().ToLower(),
                    Senha = Senha
                };

                var token =
                    await _authService.RegisterAsync(usuario);

                if (token == null)
                {
                    await Shell.Current.DisplayAlert(
                        "Erro",
                        "Email já cadastrado.",
                        "OK");
                    return;
                }

                await Shell.Current.GoToAsync("PesoGenero");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(
                    "Erro",
                    ex.Message,
                    "OK");
            }
        }
    }
}