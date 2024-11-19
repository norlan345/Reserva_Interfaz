using Reserva_Interfaz.MVVM.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Windows.Input;
using System.Net.Http.Json;

namespace Reserva_Interfaz.MVVM.ViewModels;

public partial class ConfirmacionReservaViewModel : ObservableObject
{
    // Propiedad para almacenar las reservas
    private readonly HttpClient _httpClient;
    private readonly Page _page;

    public ICommand CrearCommand { get; }
    public ICommand EliminarCommand { get; }
    public ICommand EditarCommand { get; }
    public ICommand CancelarCommand { get; }

   
    public ObservableCollection<ConfirmacionReserva> Reservas { get; set; }

    public ConfirmacionReservaViewModel(Page page)
    {
        Reservas = new ObservableCollection<ConfirmacionReserva>();
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://10.0.2.2:5161"),
            DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer") }
        };
        _page = page;
        CargarCitasPendientesAsync();
    }

    private async Task CargarCitasPendientesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/Citas");
            if (response.IsSuccessStatusCode)
            {
                var productos = await response.Content.ReadFromJsonAsync<List<ConfirmacionReserva>>();
                Reservas.Clear();
                foreach (var prod in productos)
                {
                    Reservas.Add(prod);
                }
            }
            else
            {
                await _page.DisplayAlert("Error", "Error al obtener productos", "OK");
            }
        }
        catch (Exception ex)
        {
            await _page.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
    }

    [RelayCommand]
    private async Task AceptarReserva(string id)
    {
        var reserva = Reservas.FirstOrDefault(r => r.Id == id);
        if (reserva != null)
        {
            reserva.Estado = "Aceptado";
            await App.Current.MainPage.DisplayAlert("Confirmación", "Reserva aceptada", "OK");
        }
    }

    [RelayCommand]
    private async Task CancelarReserva(string id)
    {
        var reserva = Reservas.FirstOrDefault(r => r.Id == id);
        if (reserva != null)
        {
            reserva.Estado = "Rechazado";
            await App.Current.MainPage.DisplayAlert("Cancelación", "Reserva cancelada", "OK");
        }
    }
}

