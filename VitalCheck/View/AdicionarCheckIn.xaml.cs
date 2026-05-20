using VitalCheck.Model;

namespace VitalCheck.View;

public partial class AdicionarCheckIn : ContentPage
{
    private DashboardView _dashboard;
    public AdicionarCheckIn(DashboardView dashboard)
	{
		InitializeComponent();
        _dashboard = dashboard;
    }

    private async void Salvar_Clicked(object sender, EventArgs e) 
	{
        string horasSono = SonoHorasEntry.Text;
        string energia = EnergiaEntry.Text;

        string humorSelecionado = HumorPicker.SelectedItem as string;

        bool treinouHoje = TreinoSimRadioButton.IsChecked;

        if (!double.TryParse(horasSono, out double horasSonoDouble))
        {
            await DisplayAlert("Erro", "Por favor, digite um número válido para as horas de sono.", "OK");
            return;
        }

        if (!double.TryParse(energia, out double energiaDouble))
        {
            await DisplayAlert("Erro", "Por favor, digite um número válido para a energia", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(humorSelecionado))
        {
            await DisplayAlert("Aviso", "Por favor, preencha todos os campos.", "OK");
            return;
        }

        var services = Application.Current?.Handler?.MauiContext?.Services;
        var db = services?.GetService<Services.DataBase.Create.IDataBaseService>();
        var settingsService = services?.GetService<Services.Settings.ISettingsService>();

        //Buscando o ID do usuario logado
        int userId = 0;
        if(settingsService != null)
        {
            var logId = await settingsService.GetUserIdAsync();
            userId = logId ?? 0;
        }

        // criar e salvar checkin no banco
        var novoCheckIn = new CheckIn
        {
            IdUsuario = userId,
            ScoreEnergia = energiaDouble,
            Sono = horasSonoDouble,
            Humor = humorSelecionado,
            Atividade = treinouHoje,
            Data = DateTime.Now
        };

        
        if (db != null)
        {
            await db.AddCheckInAsync(novoCheckIn);
        }

        int notaDoDia = novoCheckIn.VitalScore();

        _dashboard.AtualizarCards(energiaDouble, horasSonoDouble, humorSelecionado, treinouHoje, notaDoDia);
        await Navigation.PopModalAsync();
    }

    private async void Cancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}