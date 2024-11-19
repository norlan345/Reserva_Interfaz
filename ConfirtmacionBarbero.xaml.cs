using Reserva_Interfaz.MVVM.ViewModels;
using System.Collections.ObjectModel;

namespace Reserva_Interfaz;

public partial class ConfirtmacionBarbero : ContentPage
{
  

    public ConfirtmacionBarbero()
    {
        InitializeComponent();
        BindingContext = new ConfirmacionReservaViewModel(this);
    }
}
