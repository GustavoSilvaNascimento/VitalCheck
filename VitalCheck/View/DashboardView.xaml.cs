using VitalCheck.ViewModel;
using VitalCheck.ViewModels;

namespace VitalCheck.View;

public partial class DashboardView : ContentPage
{
	public DashboardView(DashboardViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        AtualizarEstadoCheckIn(temCheckIn: true);

        var services = Application.Current?.Handler?.MauiContext?.Services;
        var db = services?.GetService<Services.DataBase.Create.IDataBaseService>();
        var settingsService = services?.GetService<Services.Settings.ISettingsService>();

        if(db != null && settingsService != null)
        {
            var userId = await settingsService.GetUserIdAsync();

            if (userId.HasValue)
            {
                var ultimoCheckIn = await db.GetUltimoCheckInAsync(userId.Value);

                if(ultimoCheckIn != null)
                {
                    AtualizarEstadoCheckIn(temCheckIn: true);

                    int notaDoDia = ultimoCheckIn.VitalScore();

                    AtualizarCards(
                        ultimoCheckIn.ScoreEnergia,
                        ultimoCheckIn.Sono,
                        ultimoCheckIn.Humor,
                        ultimoCheckIn.Atividade,
                        notaDoDia
                    );
                }
                else
                {
                    AtualizarEstadoCheckIn(temCheckIn: false);
                }
            }
        }
    }

    private void AtualizarEstadoCheckIn(bool temCheckIn)
    {
        CheckInContent.IsVisible = temCheckIn;
        EmptyCheckIn.IsVisible = !temCheckIn;
    }

    public void AtualizarCards(double energia, double sono, string humor, bool treino, int VitalScore)
    {
        EnergiaLabel.Text = $"{energia}";
        SonoLabel.Text = $"{sono}h";
        HumorLabel.Text = humor;
        TreinoLabel.Text = treino ? "Sim" : "Não";

        int scoreDoDia = VitalScore;
        ScoreLabel.Text = scoreDoDia.ToString();
        AjustarProgressBar(scoreDoDia);
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
        await Navigation.PushModalAsync(new AdicionarCheckIn(this));
    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {

    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new UsuarioModal());
    }
}