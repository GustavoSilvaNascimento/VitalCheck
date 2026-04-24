using VitalCheck.ViewModels;

namespace VitalCheck.View;

public partial class CadastroView : ContentPage
{
    public CadastroView(CadastroViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}