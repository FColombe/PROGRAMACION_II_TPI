using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class ServicioGastronomico_service : IServicioGastronomico_service
    {
        private readonly IServicioGastronomico_repository _repo;

        public ServicioGastronomico_service(IServicioGastronomico_repository repo)
        {
            _repo = repo;
        }

        public async Task<List<ServiciosGastronomico>> GetServiciosGastronomicos()
        {
            return await _repo.GetServiciosGastronomicos();
        }
    }
}
