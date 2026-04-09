namespace VitalCheck.View;

public partial class CadastroView : ContentPage
{
    public CadastroView()
    {
        InitializeComponent();
    }
    private async void OnLoginClicked(object sender, EventArgs e)
     {
        try
        {
            await Shell.Current.GoToAsync("login");
        }
        catch (Exception)
        {

        } 
     }
}
