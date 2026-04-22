        
using VitalCheck.Services.Navigation;

namespace VitalCheck;

    public partial class App : Application
    {
        private readonly INavigationService _navigationService;

        public App(INavigationService navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell(_navigationService));
        }
    }

