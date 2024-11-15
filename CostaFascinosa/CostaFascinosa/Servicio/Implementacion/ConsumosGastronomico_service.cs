using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class ConsumosGastronomico_service : IConsumosGastronomico_service
    {
        private readonly IConsumosGastronomico_repository _repository;

        public ConsumosGastronomico_service(IConsumosGastronomico_repository repository)
        {
            _repository = repository;
        }

        public async Task<List<ConsumosGastronomico>> GetConsumosGastroByUsuario(int id)
        {
            return await _repository.GetConsumosGastronomicosByUsuario(id);
        }

        public async Task<List<ConsumoGastronomicoDTO>> GetConsumosGastronomicosTotales(int id)
        {
            return await _repository.GetTotalesConsumosGastronómicos(id);
        }
    }
}
