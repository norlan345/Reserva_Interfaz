using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva_Interfaz.MVVM.Models
{
    internal class ServicioDisponibleModel
    {
        public string? Id { get; set; }

        public decimal Precio { get; set; }


        public string? Servicio { get; set; }= string.Empty;

     
    }   
}
