using VitalCheck.Services.Navigation;
using VitalCheck.View;


namespace VitalCheck
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService _navigationService;

        public AppShell(INavigationService navigationService)
        {
            InitializeComponent();
            RegisterRoutes();
            _navigationService = navigationService;
        }
        public void RegisterRoutes()
        {
            Routing.RegisterRoute("login", typeof(LoginView));
            Routing.RegisterRoute("Alimentacao", typeof(AlimentacaoView));
            Routing.RegisterRoute("Cadastro", typeof(CadastroView));
            Routing.RegisterRoute("Dashboard", typeof(DashboardView));
            Routing.RegisterRoute("Idade", typeof(IdadeView));
            Routing.RegisterRoute("Main", typeof(MainPage));
            Routing.RegisterRoute("PesoGenero", typeof(PesoGenero));
            Routing.RegisterRoute("Sono", typeof(SonoView));
            Routing.RegisterRoute("Treino", typeof(TreinoView));


        }

        protected override async void OnHandlerChanged()
        {
            base.OnHandlerChanged();
            if (Handler != null)
            {
                await _navigationService.InitializeAsync();
            }

        }
    }
}
