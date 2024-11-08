using Reserva_Interfaz.MVVM.ViewModel;

namespace Reserva_Interfaz;

public partial class EditarCita : ContentPage
{
	public EditarCita()
	{
		InitializeComponent();
        BindingContext = new AgendarCitaViewModel(this);
    }
}