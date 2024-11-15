using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IConsumosHabitacione_service
    {
        Task<List<ConsumosHabitacioneDTO>> GetConsumosHabitaciones(int id);
        Task<bool> Add(ConsumosHabitacione consumo);
        Task<decimal?> ObtenerTotalConsumosYReservas(int idUsuario);
        Task<bool> Delete(int id);
    }
}
