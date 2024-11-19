using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva_Interfaz.MVVM.Models
{
    public class ConfirmacionReserva
    {
        public string? Id { get; set; }

        public string? NombreCliente { get; set; }

        public string? Servicio { get; set; }

        public DateTime FechaCita { get; set; }

        public decimal Total  {get; set; }
        public string Estado { get; set; } = "Pendiente"; // "Pendiente", "Aceptada", "Rechazada"
    }
}
