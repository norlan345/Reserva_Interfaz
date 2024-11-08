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
            await Navigation.PopAsync(); // Volver a la p�gina anterior (Men�)
        }

        // M�todo que maneja el evento cuando se selecciona un corte
        private void OnCorteSelected(object sender, EventArgs e)
        {
            // Obt�n el par�metro del comando que indica el tipo de corte y su precio
            var button = sender as Button;
            var corteInfo = button?.CommandParameter?.ToString();

            if (!string.IsNullOrEmpty(corteInfo))
            {
                // Aqu� puedes mostrar una alerta o realizar otra acci�n con la informaci�n del corte seleccionado
                DisplayAlert("Corte Seleccionado", $"Has seleccionado: {corteInfo}", "OK");
            }
        }

    }
}
