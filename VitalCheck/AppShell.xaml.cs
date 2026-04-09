using VitalCheck.View;

namespace VitalCheck
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(LoginView));
            Routing.RegisterRoute("inicio", typeof(MainPage));
            Routing.RegisterRoute("cadastro", typeof(CadastroView));
        }
    }
}
