using CostaFascinosa.Data;
using CostaFascinosa.Repositorio.Interfaz;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class PreferenciaAlimenticia_service : IPreferenciaAlimenticia_service
    {
        private readonly IPreferenciaAlimenticia _repo;

        public PreferenciaAlimenticia_service(IPreferenciaAlimenticia repo)
        {
            _repo = repo;
        }

        public async Task<bool> Add(PreferenciasAlimenticia pref)
        {
            return await _repo.Add(pref);
        }

        public async Task<List<PreferenciasAlimenticia>> GetPreferenciasAlimenticias()
        {
            return await _repo.GetPrefAlimenticia();
        }
    }
}
