using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva_Interfaz.MVVM.Models
{
    internal class AgendarCitaModel
    {
        public string? Id { get; set; } // ID de la cita, puede ser generado automáticamente
        public string? NombreCliente { get; set; } = string.Empty; // Nombre del cliente
        public string? Servicio { get; set; } = string.Empty; // Tipo de servicio solicitado
        public DateTime FechaCita { get; set; }     
    }
}
