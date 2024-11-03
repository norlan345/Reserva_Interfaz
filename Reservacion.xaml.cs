using Reserva_Interfaz.MVVM.ViewModel;

namespace Reserva_Interfaz;

public partial class Reservacion : ContentPage
{
	public Reservacion(string token)
    {
		InitializeComponent();
        fechaPicker.MinimumDate = DateTime.Now;  // Establecer fecha m�nima en c�digo subyacente
        BindingContext = new AgendarCitaViewModel(this);
    }
    private async void OnBackToMenuClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Volver a la p�gina anterior (Men�)
    }
}