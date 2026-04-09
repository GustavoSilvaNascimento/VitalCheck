namespace VitalCheck;
using VitalCheck.Data.SqLite;

    public partial class App : Application
    {
        public App(SqLiteDataBase database)
        {
            
            InitializeComponent();
            Task.Run(async () => await database.InitAsync());

    }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
            
        }
    }
