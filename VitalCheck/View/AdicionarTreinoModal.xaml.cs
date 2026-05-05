namespace VitalCheck.View;

public partial class AdicionarTreinoModal : ContentPage
{
	public AdicionarTreinoModal()
	{
		InitializeComponent();
	}

    private async void Salvar_Clicked(object sender, EventArgs e)
    {
        string nomeTreino = NomeTreinoEntry.Text;
        string exercicio1 = Exercicio1Entry.Text;
        string exercicio2 = Exercicio2Entry.Text;
        string exercicio3 = Exercicio3Entry.Text;
        string exercicio4 = Exercicio4Entry.Text;
        string exercicio5 = Exercicio5Entry.Text;
        string exercicio6 = Exercicio6Entry.Text;

        await Navigation.PopModalAsync();
    }

    private async void Cancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}