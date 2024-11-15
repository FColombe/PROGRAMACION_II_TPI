using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class ReservasActividade_service : IReservasActividade_service
    {
        private readonly IReservasActividade_repository _repo;

        public ReservasActividade_service(IReservasActividade_repository repo)
        {
            _repo = repo;
        }

        public async Task<List<Reserva_ActividadeDTO>> GetReservasActividades(int id)
        {
            return await _repo.GetReservasActividadesByUsuario(id);
        }

        public async Task<List<ReservasActividade>> GetReservasActividadesDeHoy(int id)
        {
            return await _repo.GetReservasActividadesDelDia(id);
        }
    }
}
