using System.Collections.ObjectModel;
using VitalCheck.Model;

namespace VitalCheck.View;

public partial class AdicionarTreinoModal : ContentPage
{
    private ObservableCollection<Treino> _listaPrincipal;
    public AdicionarTreinoModal(ObservableCollection<Treino> lista)
	{
		InitializeComponent();
        _listaPrincipal = lista;
    }

    private async void Salvar_Clicked(object sender, EventArgs e)
    {

        var novoTreino = new Treino {
            Nome = NomeTreinoEntry.Text,
            Exercicio1 = Exercicio1Entry.Text,
            Exercicio2 = Exercicio2Entry.Text,
            Exercicio3 = Exercicio3Entry.Text,
            Exercicio4 = Exercicio4Entry.Text,
            Exercicio5 = Exercicio5Entry.Text,
            Exercicio6 = Exercicio6Entry.Text,
        };

        _listaPrincipal.Add(novoTreino);

        await Navigation.PopModalAsync();
    }

    private async void Cancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}