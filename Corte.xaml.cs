using Microsoft.Maui.Controls;

namespace Reserva_Interfaz
{
    public partial class Corte : ContentPage
    {
        public Corte()
        {
            InitializeComponent();
        }

        private async void OnBackToMenuClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Volver a la página anterior (Menú)
        }
    }
}
