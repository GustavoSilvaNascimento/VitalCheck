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

		// Navegar para a aba principal (rota única definida em AppShell.xaml)
		await Shell.Current.GoToAsync("//dashboard_home");
	}
}