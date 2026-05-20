using System.Collections.ObjectModel;
using VitalCheck.Model;

namespace VitalCheck.View;

public partial class TreinoView : ContentPage
{
    public ObservableCollection<Treino> MeusTreinos { get; set; } = new ObservableCollection<Treino>();
    public TreinoView()
	{
		InitializeComponent();

        ListaTreinos.ItemsSource = MeusTreinos;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CarregarTreinosAsync();
    }

    private async Task CarregarTreinosAsync()
    {
        var services = Application.Current?.Handler?.MauiContext?.Services;
        var db = services?.GetService<Services.DataBase.Create.IDataBaseService>();
        var settingsService = services?.GetService<Services.Settings.ISettingsService>();

        if(db != null && settingsService != null)
        {
            var userId = await settingsService.GetUserIdAsync();

            if (userId.HasValue)
            {
                var treinosDoBanco = await db.GetTodosTreinosAsync(userId.Value);

                MeusTreinos.Clear();

                if(treinosDoBanco != null)
                {
                    foreach(var treino in treinosDoBanco)
                    {
                        MeusTreinos.Add(treino);
                    }
                }
            }
        }
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("//dashboard_home");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro insperado: {ex.Message}", "Ok");
        }
    }

    private async void Treino_Tapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Treino treinoClicado) {
            await Navigation.PushModalAsync(new DetalhesTreinoModal(treinoClicado));
        }
    }

    private async void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AdicionarTreinoModal(MeusTreinos));
    }

}