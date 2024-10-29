using System;
using Microsoft.Maui.Controls;

namespace Reserva_Interfaz
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Aquí va la lógica para verificar el inicio de sesión, por ejemplo:
            // string username = usernameEntry.Text;
            // string password = passwordEntry.Text;
            // Validar credenciales...

            // Si las credenciales son válidas, navega al menú
            await Navigation.PushAsync(new Menu());
        }
        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            // Navegar a la página de registro
            await Navigation.PushAsync(new Sign_up());
        }
    }
}
