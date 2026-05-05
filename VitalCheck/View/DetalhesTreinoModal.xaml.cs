using VitalCheck.Model;

namespace VitalCheck.View;

public partial class DetalhesTreinoModal : ContentPage
{
	public DetalhesTreinoModal(Treino treinoSelecionado)
	{
		InitializeComponent();
		BindingContext = treinoSelecionado;
	}

    private async void Fechar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}