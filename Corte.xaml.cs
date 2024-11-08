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
        private void OnCorteSelected(object sender, EventArgs e)
        {
            // Obtén el parámetro del comando que indica el tipo de corte y su precio
            var button = sender as Button;
            var corteInfo = button?.CommandParameter?.ToString();

            if (!string.IsNullOrEmpty(corteInfo))
            {
                // Aquí puedes mostrar una alerta o realizar otra acción con la información del corte seleccionado
                DisplayAlert("Corte Seleccionado", $"Has seleccionado: {corteInfo}", "OK");
            }
        }

    }
}
