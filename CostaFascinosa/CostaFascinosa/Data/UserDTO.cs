using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Data
{
    public class UserDTO
    {
        public int IdUsuario {  get; set; } 
        public string UserName { get; set; } = string.Empty;
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? NroHabitacion { get; set; }
        public string? ZonaHab { get; set; }
        public string? EstadoUser { get; set; }
        public DateTime? fech_abordo { get; set; }
        public DateTime? fech_desbordo { get; set; }

    }
}
