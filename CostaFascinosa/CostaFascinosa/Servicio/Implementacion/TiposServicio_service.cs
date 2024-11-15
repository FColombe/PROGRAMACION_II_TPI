using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class TiposServicio_service : ITiposServicio_service
    {
        private readonly ITiposServicio_repository _repository;

        public TiposServicio_service(ITiposServicio_repository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Add(TiposServicio tipoServicio)
        {
            return await _repository.Add(tipoServicio);
        }

        public async Task<List<TiposServicio>> GetTiposServicios()
        {
            return await _repository.GetTiposServicios();
        }
    }
}
