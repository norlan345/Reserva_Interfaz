using System;
using Microsoft.Maui.Controls;
using Reserva_Interfaz.MVVM.ViewModel;

namespace Reserva_Interfaz
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            BindingContext = new UsuarioViewModel(this);
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Aqu� va la l�gica para verificar el inicio de sesi�n, por ejemplo:
            // string username = usernameEntry.Text;
            // string password = passwordEntry.Text;
            // Validar credenciales...

            // Si las credenciales son v�lidas, navega al men�

        }
        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sign_up());
        }

    }
}
