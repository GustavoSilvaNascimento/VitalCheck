namespace VitalCheck.View;

public partial class TreinoView : ContentPage
{
	public TreinoView()
	{
		InitializeComponent();
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

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {

    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {

    }
}