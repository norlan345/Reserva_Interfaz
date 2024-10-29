using Reserva_Interfaz.MVVM.ViewModel;

namespace Reserva_Interfaz;

public partial class Sign_up : ContentPage
{
	public Sign_up()
	{
		InitializeComponent();
        BindingContext = new UsuarioViewModel(this);
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Regresar a la p�gina anterior
    }
    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        await saveButton.ScaleTo(1.2, 100);

        // Vuelve el bot�n a su tama�o original
        await saveButton.ScaleTo(1.0, 100);
    }


    private void OnRoleSelected(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        if (picker != null)
        {
            // Obt�n el rol seleccionado
            string selectedRole = picker.SelectedItem.ToString();

            // Aqu� puedes agregar la l�gica que deseas ejecutar al seleccionar un rol
            // Por ejemplo, podr�as mostrar un mensaje o navegar a otra p�gina
            Console.WriteLine($"Rol seleccionado: {selectedRole}");
        }
    }
}