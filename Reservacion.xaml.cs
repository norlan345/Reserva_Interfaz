namespace Reserva_Interfaz;

public partial class Reservacion : ContentPage
{
	public Reservacion()
	{
		InitializeComponent();
        fechaPicker.MinimumDate = DateTime.Now;  // Establecer fecha mínima en código subyacente
    }
    private async void OnBackToMenuClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Volver a la página anterior (Menú)
    }
}