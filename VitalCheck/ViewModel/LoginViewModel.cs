using System.Windows.Input;
using VitalCheck.Model.Response;
using VitalCheck.Services.Auth;

namespace VitalCheck.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;

            LoginCommand =
                new Command(async () => await LoginAsync());

            CadastroCommand =
                new Command(async () => await IrCadastroAsync());
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

        public ICommand LoginCommand { get; }
        public ICommand CadastroCommand { get; }

        private async Task LoginAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Email) ||
                    string.IsNullOrWhiteSpace(Senha))
                {
                    await Shell.Current.DisplayAlert(
                        "Erro",
                        "Preencha todos os campos.",
                        "OK");
                    return;
                }

                var token = await _authService
                    .LoginAsync(Email, Senha);

                if (token != null)
                {
                    await Shell.Current.GoToAsync(
                        "//dashboard_home");
                }
                else
                {
                    await Shell.Current.DisplayAlert(
                        "Erro",
                        "Login ou senha incorretos.",
                        "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(
                    "Erro",
                    ex.Message,
                    "OK");
            }
        }

        private async Task IrCadastroAsync()
        {
            await Shell.Current.GoToAsync("Cadastro");
        }
    }
}