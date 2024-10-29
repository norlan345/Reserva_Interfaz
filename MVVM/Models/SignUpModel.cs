using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva_Interfaz.MVVM.Models
{
    internal class SignUpModel
    {
       
        public string? Id { get; set; }

        public string? Nombre { get; set; } = string.Empty;

      
        public string? Contraseña { get; set; } = string.Empty;


        public string? ConfirmarContraseña { get; set; } = string.Empty;


        public string? Rol { get; set; } = "UsuarioModel";
    }
}
