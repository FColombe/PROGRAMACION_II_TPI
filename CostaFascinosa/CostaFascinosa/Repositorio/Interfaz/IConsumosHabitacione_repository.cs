using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Repositorio.Interfaz
{
    public interface IConsumosHabitacione_repository
    {
        Task<bool> Add(ConsumosHabitacione consumo);        
        Task<decimal?> ObtenerTotalConsumosYReservas(int idUsuario);
        Task<List<ConsumosHabitacioneDTO>> Get(int id);
        Task<bool> Delete(int id);

    }
}
