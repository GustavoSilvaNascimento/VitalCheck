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

        // SALVAR NO BANCO DE DADOS!!!!

        // ex:
        // var novoCheckin = new CheckInModel { Sono = int.Parse(horasSono), ... };
        // dbContext.Add(novoCheckin);

        //checkin temporario q deve ser substituido qnd for colocar a logica do banco de dados
        var checkInTemporario = new CheckIn
        {
            ScoreEnergia = energiaDouble,
            Sono = horasSonoDouble,
            Humor = humorSelecionado,
            Atividade = treinouHoje
        };

        int notaDoDia = checkInTemporario.VitalScore();

        _dashboard.AtualizarCards(energiaDouble, horasSonoDouble, humorSelecionado, treinouHoje, notaDoDia);
        await Navigation.PopModalAsync();
    }

    private async void Cancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}