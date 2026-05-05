namespace VitalCheck.View;

public partial class AdicionarCheckIn : ContentPage
{
	public AdicionarCheckIn()
	{
		InitializeComponent();
	}

    private async void Salvar_Clicked(object sender, EventArgs e) 
	{
        string horasSono = SonoHorasEntry.Text;
        string energia = EnergiaEntry.Text;

        string humorSelecionado = HumorPicker.SelectedItem as string;

        bool treinouHoje = TreinoSimRadioButton.IsChecked;

        if (string.IsNullOrWhiteSpace(horasSono) ||
            string.IsNullOrWhiteSpace(energia) ||
            humorSelecionado == null)
        {
            await DisplayAlert("Aviso", "Por favor, preencha todos os campos.", "OK");
            return;
        }

        // SALVAR NO BANCO DE DADOS!!!!

        // ex:
        // var novoCheckin = new CheckInModel { Sono = int.Parse(horasSono), ... };
        // dbContext.Add(novoCheckin);

        await Navigation.PopModalAsync();
    }

    private async void Cancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}