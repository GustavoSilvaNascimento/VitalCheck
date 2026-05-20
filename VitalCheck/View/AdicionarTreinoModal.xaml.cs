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

        if (string.IsNullOrWhiteSpace(NomeTreinoEntry.Text))
        {
            await DisplayAlert("Erro", "Adicione um titulo ao seu treino!", "Ok");
            return;
        }
        var services = Application.Current?.Handler?.MauiContext?.Services;
        var db = services?.GetService<Services.DataBase.Create.IDataBaseService>();
        var settingsService = services?.GetService<Services.Settings.ISettingsService>();

        int userId = 0;
        if(settingsService != null)
        {
            var logId = await settingsService.GetUserIdAsync();
            userId = logId ?? 0;
        }


        var novoTreino = new Treino {
            IdUsuario = userId,
            Nome = NomeTreinoEntry.Text,
            Exercicio1 = Exercicio1Entry.Text,
            Exercicio2 = Exercicio2Entry.Text,
            Exercicio3 = Exercicio3Entry.Text,
            Exercicio4 = Exercicio4Entry.Text,
            Exercicio5 = Exercicio5Entry.Text,
            Exercicio6 = Exercicio6Entry.Text,
        };

        if (db != null)
        {
            await db.AddTreinoAsync(novoTreino);
        }

        _listaPrincipal.Add(novoTreino);

        await Navigation.PopModalAsync();
    }

    private async void Cancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}