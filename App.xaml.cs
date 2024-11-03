using System.Globalization;

namespace Reserva_Interfaz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Configurar la cultura en español
            CultureInfo culture = new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            MainPage = new NavigationPage(new Login());
        }
    }
}
