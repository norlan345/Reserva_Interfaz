namespace Reserva_Interfaz;

public partial class Perfil : ContentPage
{
	public Perfil()
	{
		InitializeComponent();
	}
    private async void OnBackToMenuClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Volver a la página anterior (Menú)
    }
}