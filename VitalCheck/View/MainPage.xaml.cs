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
        private async void OnSetaClicked(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync("cadastro");
            }
            catch (Exception)
            {

            }
        }
    }
}
