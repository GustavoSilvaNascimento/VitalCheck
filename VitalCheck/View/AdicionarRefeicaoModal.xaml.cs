namespace VitalCheck.View;

public partial class AdicionarRefeicaoModal : ContentPage
{
	public AdicionarRefeicaoModal()
	{
		InitializeComponent();
	}

    private void Salvar_Clicked(object sender, EventArgs e)
    {

    }

    private async void Cancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}