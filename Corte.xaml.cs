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

        // Método que maneja el evento cuando se selecciona un corte
        private async void OnCorteSelected(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Reservacion());
        }

    }
}
