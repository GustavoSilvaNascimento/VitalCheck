
using VitalCheck.Services.DataBase.Create;
using VitalCheck.Services.Navigation;

namespace VitalCheck;

public partial class App : Application
{
    private readonly INavigationService _navigationService;
    private readonly IDataBaseService _db;

    public App(INavigationService navigationService, IDataBaseService db)
    {
        InitializeComponent();
        _navigationService = navigationService;
        _db = db;
        Task.Run(async () =>
        {
            await _db.InitAsync();
        });
       
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell(_navigationService));
    }
}

