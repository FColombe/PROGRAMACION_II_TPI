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
    public class Tematica_service : ITematica_service
    {
        private readonly ITematica_repository _repo;

        public Tematica_service(ITematica_repository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Add(Tematica tematica)
        {
            return await _repo.Add(tematica);
        }

        public async Task<List<Tematica>> GetTematicas()
        {
            return await _repo.GetTematicas();
        }
    }
}
