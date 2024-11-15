using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Data
{
    public class Reserva_ActividadeDTO
    {
        public int idReservaAct { get; set; }
        public int idUsuario {  get; set; }
        public string? NombreActividad { get; set; }
       
        public DateTime? FechaReserva { get; set; }
        
        public string? TurnoA {  get; set; }

        public string? ZonaA { get; set; }
        public int? Piso { get; set; }

        public int? CantidadReserva { get; set; }   

        public decimal? Costo {  get; set; }

      

    }
}
