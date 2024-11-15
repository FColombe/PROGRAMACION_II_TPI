using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class ReservasServicio_service : IReservasServicio_service
    {
        private readonly IReservasServicio_repository _repository;

        public ReservasServicio_service(IReservasServicio_repository repository)
        {
            _repository = repository;
        }

        public async Task<bool> add(ReservasServicio reservaServicio)
        {
            return await _repository.add(reservaServicio);
        }

        public async Task<List<ReservaServicioDTO>> GetReservasServicio(int id)
        {
            return await _repository.GetReservasServicio(id);
        }

        public async Task<List<ReservasServicio>> GetReservasServicioDate(int id)
        {
            return await _repository.GetReservasServicioDate(id);
        }

        public async Task<List<ReservasServicio>> GetReservasServicios()
        {
            return await _repository.GetReservasServicios();
        }

        public async Task<bool> Delete(int id)
        {
            return await (_repository.Delete(id));
        }
    }
}
