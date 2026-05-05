namespace VitalCheck.View;

public partial class DashboardView : ContentPage
{
	public DashboardView()
	{
		InitializeComponent();

	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        AtualizarEstadoCheckIn(temCheckIn: true);
        AjustarProgressBar(score: 75);
    }

    private void AtualizarEstadoCheckIn(bool temCheckIn)
    {
        CheckInContent.IsVisible = temCheckIn;
        EmptyCheckIn.IsVisible = !temCheckIn;
    }

    private void AjustarProgressBar(int score)
    {
        // Calcula largura proporcional ao container (~330px úteis)
        double maxWidth = 330;
        ProgressFill.WidthRequest = maxWidth * (score / 100.0);

        ProgressLabel.Text = score >= 90 ? "Incrível!" :
                             score >= 70 ? "Quase lá!" :
                             score >= 40 ? "Bom progresso" :
                             "Vamos começar!";
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AdicionarCheckIn());
    }
}