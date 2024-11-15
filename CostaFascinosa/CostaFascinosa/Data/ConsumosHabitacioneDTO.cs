using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Data
{
    public class ConsumosHabitacioneDTO
    {
        //Popertis Maestro
        public int? IdConsumo { get; set; }
        public DateTime? Fecha { get; set; }

        //propertis Reservas Actividades
        public int? IdReserva {  get; set; }
        public int? IdActividad { get; set; }
        public string? Nombre { get; set; }
        public int? CantidadAct { get; set; }
        public decimal? CostoUnitario { get; set; }
        public DateTime? FechaReserva { get; set; }
        
        //Propertis Consumo Gastronómico
        public string? Servicio { get; set; }
        public List<ConsumoGastronomicoDTO> ConsumoGastro { get; set; } = new List<ConsumoGastronomicoDTO>();

    }
}
