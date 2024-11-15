using CostaFascinosa.Data;
using CostaFascinosa.Repositorio.Implementacion;
using CostaFascinosa.Repositorio.Interfaz;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class ConsumosHabitacione_service : IConsumosHabitacione_service
    {
        private readonly IConsumosHabitacione_repository _repo;

        public ConsumosHabitacione_service(IConsumosHabitacione_repository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Add(ConsumosHabitacione consumo)
        {
            return await _repo.Add(consumo);
        }

        public async Task<List<ConsumosHabitacioneDTO>> GetConsumosHabitaciones(int id)
        {
            return await _repo.Get(id);
        }
        public async Task<decimal?> ObtenerTotalConsumosYReservas(int idUsuario)
        {
            return await _repo.ObtenerTotalConsumosYReservas(idUsuario);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);  
        }


    }
}
