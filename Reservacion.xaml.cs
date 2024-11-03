using Reserva_Interfaz.MVVM.ViewModel;

namespace Reserva_Interfaz;

public partial class Reservacion : ContentPage
{
	public Reservacion(string token)
    {
		InitializeComponent();
        fechaPicker.MinimumDate = DateTime.Now;  // Establecer fecha mínima en código subyacente
        BindingContext = new AgendarCitaViewModel(this);
    }
    private async void OnBackToMenuClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Volver a la página anterior (Menú)
    }
}