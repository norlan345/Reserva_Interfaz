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
            // Aqu� va la l�gica para verificar el inicio de sesi�n, por ejemplo:
            // string username = usernameEntry.Text;
            // string password = passwordEntry.Text;
            // Validar credenciales...

            // Si las credenciales son v�lidas, navega al men�
            await Navigation.PushAsync(new Menu());
        }
        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            // Navegar a la p�gina de registro
            await Navigation.PushAsync(new Sign_up());
        }
    }
}
