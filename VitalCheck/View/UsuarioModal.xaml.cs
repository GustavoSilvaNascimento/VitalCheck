namespace VitalCheck.View;

public partial class UsuarioModal : ContentPage
{
	public UsuarioModal()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}