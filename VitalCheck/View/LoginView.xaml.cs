using VitalCheck.ViewModels;

namespace VitalCheck.View;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}