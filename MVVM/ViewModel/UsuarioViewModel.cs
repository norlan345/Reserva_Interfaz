using Reserva_Interfaz.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Reserva_Interfaz;


namespace Reserva_Interfaz.MVVM.ViewModel
{
    public partial class UsuarioViewModel : ObservableObject
    {

        private readonly HttpClient _httpClient;
        private readonly Page _page; // Referencia a la página para la navegación y alertas

        // Comandos que estarán vinculados a botones en la UI
        public ICommand RegisterCommand { get; }
        public ICommand LoginCommand { get; }

        // Constructor de la clase
        public UsuarioViewModel(Page page)
        {
            _httpClient = new HttpClient();
            _page = page; // Asignar la página

            // Crear los comandos
            RegisterCommand = new Command(async () => await RegisterAsync());
            LoginCommand = new Command(async () => await LoginAsync());
        }

        // Propiedades vinculadas a los campos de entrada de usuario y contraseñadsadadadasdasdsadsadsadsadsa
        [ObservableProperty]
        private string nombre;
        [ObservableProperty]
        private string contraseña;


        [ObservableProperty]
        private string rol;


        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private string confirmarcontraseña;

        public async Task RegisterAsync()
        {
            var user = new UsuarioModel
            {
                Nombre = Nombre,
                Contraseña = Contraseña,
             
               
            }; 

            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://10.0.2.2:5002/api/Auth/signup", user);


                if (response.IsSuccessStatusCode)
                {
                    await _page.DisplayAlert("Registro", "¡Registro exitoso!", "OK");
 
                    // Redirigir a la página de login
                    await _page.Navigation.PushAsync(new Login());
                }
                else
                {
                    await _page.DisplayAlert("Error", "Error en el registro", "OK");
                }
            }
            catch (Exception ex)
            {
                await _page.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }


        // Método para el login del usuario
        public async Task LoginAsync()
        {
            var user = new UsuarioModel
            {
                Nombre = Nombre,
                Contraseña = Contraseña
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://10.0.2.2:5002/api/Auth/login", user);


                if (response.IsSuccessStatusCode)

                {
                  
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var tokenObj = JsonSerializer.Deserialize<TokenResponse>(jsonResponse);
                    var token = tokenObj.Token; 

                   

                    try
                    {
                        await _page.Navigation.PushAsync(new Menu(token));
                    }
                    catch (Exception ex)
                    {
                        await _page.DisplayAlert("Error", $"Ocurrió un error al cargar la vista de estudiantes: {ex.Message}", "OK");
                    }
                }
                else
                {
                    await _page.DisplayAlert("Error", "Credenciales Incorrectas", "OK");
                }

            }
            catch (Exception ex)
            {
                await _page.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }
    }
}
