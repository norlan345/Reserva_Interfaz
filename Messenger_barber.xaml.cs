namespace Reserva_Interfaz;

public partial class Messenger_barber : ContentPage
{
	public Messenger_barber()
	{
		InitializeComponent();
	}
    private async void OnBackToMenuClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Volver a la página anterior (Menú)
    }
}