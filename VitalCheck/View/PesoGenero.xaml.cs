namespace VitalCheck.View;

using Microsoft.Maui.Graphics;

public partial class PesoGenero : ContentPage
{
    private string generoSelecionado = "Homem";
	public PesoGenero()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        try 
        {
            string genero = generoSelecionado;
            double altura = AlturaSlider.Value;
            double peso = PesoSlider.Value;

            //Adicionar logica do banco de dados

            await Shell.Current.GoToAsync("idade");

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro na Navegação", ex.Message, "OK");
        }
    }

    private void TapGestureRecognizer_Homem(object sender, TappedEventArgs e)
    {
        if (generoSelecionado != "Homem") 
        {
            generoSelecionado = "Homem";
            AtualizarCards();
        }
    }

    private void TapGestureRecognizer_Mulher(object sender, TappedEventArgs e)
    {
        if(generoSelecionado != "Mulher") 
        {
            generoSelecionado = "Mulher";
            AtualizarCards();
        }
    }

    private void AtualizarCards()
    {
        if(generoSelecionado == "Homem")
        {
            check_homem.IsVisible = true;

            check_mulher.IsVisible = false;
        }

        else if (generoSelecionado == "Mulher") {
            check_mulher.IsVisible = true;

            check_homem.IsVisible = false;
        }

    }
}