using Microsoft.Maui.Controls;

namespace Reserva_Interfaz
{
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private async void OnCorteButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Corte());
        }

        private async void OnPerfilButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Perfil());
        }

        private async void OnReservacionButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Reservacion());
        }

        private async void OnMessengerBarberButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Messenger_barber());
        }
    }
}
