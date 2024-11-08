using Reserva_Interfaz.MVVM.Models;
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Data;

namespace Reserva_Interfaz.MVVM.ViewModel
{
    public partial class AgendarCitaViewModel : ObservableObject
    {
        private readonly HttpClient _httpClient;
        private readonly Page _page;


        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private string nombreCliente;

        [ObservableProperty]
        private DateTime fechaCita = DateTime.Now;

        [ObservableProperty]
        private TimeSpan horaCita = DateTime.Now.TimeOfDay;

        [ObservableProperty]
        private bool corteCabello;

        [ObservableProperty]
        private bool corteCejas;

        [ObservableProperty]
        private bool limpiezaFacial;

        [ObservableProperty]
        private bool tintePelo;

       
        [ObservableProperty]
        private decimal total;

        public ICommand AgendarCitaCommand { get; }
        public ICommand EditarCitaCommand { get; }
        public ICommand EliminarCitaCommand { get; set; }

        public AgendarCitaViewModel(Page page)
        {
            _httpClient = new HttpClient();
            _page = page;

           
            AgendarCitaCommand = new AsyncRelayCommand(AgendarCitaAsync);
            EditarCitaCommand = new AsyncRelayCommand(EditarCitaAsync);
            EliminarCitaCommand = new AsyncRelayCommand(EliminarCitaAsync);

        }
        public bool IsCorteCabelloSelected { get; set; }
        public bool IsCorteCejasSelected { get; set; }
        public bool IsLimpiezaFacialSelected { get; set; }
        public bool IsTintePeloSelected { get; set; }




        public async Task AgendarCitaAsync()
        {
            // Crear la lista de servicios seleccionados y calcular el total
            var serviciosSeleccionados = new List<ServicioDisponibleModel>();
            decimal total = 0;

            if (IsCorteCabelloSelected)
            {
                serviciosSeleccionados.Add(new ServicioDisponibleModel { Servicio = "Corte de Cabello", Precio = 150 });
                total += 150;
            }
            if (IsCorteCejasSelected)
            {
                serviciosSeleccionados.Add(new ServicioDisponibleModel { Servicio = "Corte de Cejas", Precio = 50 });
                total += 50;
            }
            if (IsLimpiezaFacialSelected)
            {
                serviciosSeleccionados.Add(new ServicioDisponibleModel { Servicio = "Limpieza Facial", Precio = 200 });
                total += 200;
            }
            if (IsTintePeloSelected)
            {
                serviciosSeleccionados.Add(new ServicioDisponibleModel { Servicio = "Tinte de Pelo", Precio = 300 });
                total += 300;
            }

            var cita = new AgendarCitaModel
            {
                NombreCliente = NombreCliente,
                FechaCita = FechaCita.Date + HoraCita,
                ServiciosSeleccionados = serviciosSeleccionados,
                Total = total // Asigna el total calculado
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


        private async Task EditarCitaAsync()
        {
            var serviciosSeleccionados = new List<ServicioDisponibleModel>();
            decimal total = 0;

            if (CorteCabello)
            {
                serviciosSeleccionados.Add(new ServicioDisponibleModel { Servicio = "Corte de Cabello", Precio = 150 });
                total += 150;
            }
            if (CorteCejas)
            {
                serviciosSeleccionados.Add(new ServicioDisponibleModel { Servicio = "Corte de Cejas", Precio = 50 });
                total += 50;
            }
            if (LimpiezaFacial)
            {
                serviciosSeleccionados.Add(new ServicioDisponibleModel { Servicio = "Limpieza Facial", Precio = 200 });
                total += 200;
            }
            if (TintePelo)
            {
                serviciosSeleccionados.Add(new ServicioDisponibleModel { Servicio = "Tinte de Pelo", Precio = 300 });
                total += 300;
            }

            Total = total;

            var citaActualizada = new AgendarCitaModel
            {
               
                NombreCliente = NombreCliente,
                FechaCita = FechaCita.Date + HoraCita,
                ServiciosSeleccionados = serviciosSeleccionados,
                Total = total
            };

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"http://10.0.2.2:5002/api/Citas/{NombreCliente}", citaActualizada);

                if (response.IsSuccessStatusCode)
                {
                    await _page.DisplayAlert("Cita", "¡Cita actualizada con éxito!", "OK");
                }
                else
                {
                    await _page.DisplayAlert("Error", "Error al actualizar la cita", "OK");
                }
            }
            catch (Exception ex)
            {
                await _page.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }

        private async Task EliminarCitaAsync()
        {
            if (string.IsNullOrWhiteSpace(NombreCliente))
            {
                await _page.DisplayAlert("Error", "Debe proporcionar un ID de cita válido", "OK");
                return;
            }

            bool confirm = await _page.DisplayAlert("Confirmar", "¿Está seguro de que desea eliminar esta cita?", "Sí", "No");

            if (!confirm)
                return;

            try
            {
                var response = await _httpClient.DeleteAsync($"http://10.0.2.2:5002/api/Citas/{NombreCliente}");

                if (response.IsSuccessStatusCode)
                {
                    await _page.DisplayAlert("Cita", "¡Cita eliminada con éxito!", "OK");
                }
                else
                {
                    await _page.DisplayAlert("Error", "Error al eliminar la cita", "OK");
                }
            }
            catch (Exception ex)
            {
                await _page.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }


        //public async Task AgendarCitaAsync()
        //{
        //    // Crear la cita
        //    var cita = new AgendarCitaModel
        //    {
        //        NombreCliente = NombreCliente,
        //        Servicio = Servicio,
        //        FechaCita = FechaCita.Date + HoraCita
        //    };

        //    try
        //    {
        //        var response = await _httpClient.PostAsJsonAsync("http://10.0.2.2:5002/api/Citas/agendar_cita", cita);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            await _page.DisplayAlert("Cita", "¡Cita agendada con éxito!", "OK");
        //        }
        //        else
        //        {
        //            await _page.DisplayAlert("Error", "Error al agendar la cita", "OK");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await _page.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        //    }
        //}







        //public ICommand AgendarCitaCommand { get; }




        //[ObservableProperty]
        //private string nombreCliente;

        //[ObservableProperty]
        //private string servicio;

        //[ObservableProperty]
        //private DateTime fechaCita = DateTime.Now;

        //[ObservableProperty]
        //private TimeSpan horaCita = DateTime.Now.TimeOfDay; 

        //public AgendarCitaViewModel(Page page)
        //{
        //    _httpClient = new HttpClient();
        //    _page = page;


        //    AgendarCitaCommand = new AsyncRelayCommand(AgendarCitaAsync);
        //}


        //public async Task AgendarCitaAsync()
        //{
        //    var cita = new AgendarCitaModel
        //    {
        //        NombreCliente = NombreCliente,
        //        Servicio = Servicio,
        //        FechaCita = FechaCita.Date + HoraCita 
        //    };

        //    try
        //    {
        //        var response = await _httpClient.PostAsJsonAsync("http://10.0.2.2:5002/api/Citas/agendar_cita", cita);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            await _page.DisplayAlert("Cita", "¡Cita agendada con éxito!", "OK");
        //        }
        //        else
        //        {
        //            await _page.DisplayAlert("Error", "Error al agendar la cita", "OK");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await _page.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        //    }
        //}
    }
}
