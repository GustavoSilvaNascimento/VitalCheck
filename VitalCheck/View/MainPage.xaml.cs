using System;
using Microsoft.Maui.Controls;

namespace VitalCheck
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Manipulador de clique para o botão "Seta"
        // Exibe uma mensagem de alerta modal com um botão "OK".
        private async void OnSetaClicked(object sender, EventArgs e)
        {
            try
            {
                await DisplayAlert("Alerta", "Mensagem de alerta gerada.", "OK");
            }
            catch (Exception)
            {
                // Caso necessário, tratar/expor o erro conforme as convenções do projeto.
            }
        }
    }
}
