using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Reserva_Interfaz.Converters;

public class EstadoBotonConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string estado)
        {
            return estado switch
            {
                "Pendiente" => true,
                "Aceptado" => false,
                "Rechazado" => false,
                _ => false
            };
        }

        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
