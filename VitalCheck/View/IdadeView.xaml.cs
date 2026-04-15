namespace VitalCheck.View;

public partial class IdadeView : ContentPage
{
	public IdadeView()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		//Adicionar logica do Banco de Dados

		await Shell.Current.GoToAsync("dashboard");
    }
}