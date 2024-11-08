using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva_Interfaz.MVVM.Models
{
    internal class AgendarCitaModel
    {
        public string? Id { get; set; } 
        public string? NombreCliente { get; set; } = string.Empty; 
        public List<ServicioDisponibleModel> ServiciosSeleccionados { get; set; } = new List<ServicioDisponibleModel>(); 
        public DateTime FechaCita { get; set; }     

        public decimal Total { get; set; }
    }
}
