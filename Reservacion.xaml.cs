using Reserva_Interfaz.MVVM.ViewModel;

namespace Reserva_Interfaz;

public partial class Reservacion : ContentPage
{
	public Reservacion()
    {
		InitializeComponent();
        fechaPicker.MinimumDate = DateTime.Now; 
        BindingContext = new AgendarCitaViewModel(this);
    }
    private async void OnBackToMenuClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); 
    }

    private void OnCalcularTotalClicked(object sender, EventArgs e)
    {
     
        if (BindingContext is AgendarCitaViewModel viewModel)
        {
            decimal total = 0;
            if (viewModel.IsCorteCabelloSelected) total += 150;
            if (viewModel.IsCorteCejasSelected) total += 50;
            if (viewModel.IsLimpiezaFacialSelected) total += 200;
            if (viewModel.IsTintePeloSelected) total += 300;

            viewModel.Total = total;
            totalLabel.Text = $"C${total}"; 
        }
    }

}