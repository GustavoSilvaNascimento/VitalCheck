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

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {

    }

    private async void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AdicionarTreinoModal(MeusTreinos));
    }
}