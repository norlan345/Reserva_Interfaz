namespace Reserva_Interfaz;

public partial class Reservacion : ContentPage
{
	public Reservacion()
	{
		InitializeComponent();
        fechaPicker.MinimumDate = DateTime.Now;  // Establecer fecha m�nima en c�digo subyacente
    }
    private async void OnBackToMenuClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Volver a la p�gina anterior (Men�)
    }
}