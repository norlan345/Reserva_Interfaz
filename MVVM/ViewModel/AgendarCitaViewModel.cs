using Reserva_Interfaz.MVVM.Models;
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace Reserva_Interfaz.MVVM.ViewModel
{
    public partial class AgendarCitaViewModel : ObservableObject
    {
        private readonly HttpClient _httpClient;
        private readonly Page _page;

        // Comandos para la interfaz
        public ICommand AgendarCitaCommand { get; }

     

        // Propiedades observables para la cita
        [ObservableProperty]
        private string nombreCliente;

        [ObservableProperty]
        private string servicio;

        [ObservableProperty]
        private DateTime fechaCita = DateTime.Now;

        [ObservableProperty]
        private TimeSpan horaCita = DateTime.Now.TimeOfDay; // Nueva propiedad para la hora

        public AgendarCitaViewModel(Page page)
        {
            _httpClient = new HttpClient();
            _page = page;

            // Inicializar el comando
            AgendarCitaCommand = new AsyncRelayCommand(AgendarCitaAsync);
        }

        // Método para agendar una cita
        public async Task AgendarCitaAsync()
        {
            var cita = new AgendarCitaModel
            {
                NombreCliente = NombreCliente,
                Servicio = Servicio,
                FechaCita = FechaCita.Date + HoraCita // Combina fecha y hora
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://10.0.2.2:5002/api/Citas/agendar_cita", cita);

                if (response.IsSuccessStatusCode)
                {
                    await _page.DisplayAlert("Cita", "¡Cita agendada con éxito!", "OK");
                }
                else
                {
                    await _page.DisplayAlert("Error", "Error al agendar la cita", "OK");
                }
            }
            catch (Exception ex)
            {
                await _page.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }
    }
}
