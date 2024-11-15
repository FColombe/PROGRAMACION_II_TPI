using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class CodVestimenta_service : ICodVestimenta_service
    {
        private readonly ICodVestimenta_repository _repo;

        public CodVestimenta_service(ICodVestimenta_repository repo)
        {
            _repo = repo;
        }

        public async Task<bool> add(CodVestimenta codVestimenta)
        {
            return await _repo.add(codVestimenta);
        }

        public async Task<List<CodVestimenta>> GetCodigosVestimentas()
        {
            return await _repo.GetCodigosVestimentas();
        }
    }
}
