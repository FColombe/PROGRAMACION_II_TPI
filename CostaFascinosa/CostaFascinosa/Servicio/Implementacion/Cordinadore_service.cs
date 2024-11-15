using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using CostaFascinosa.Repositorio.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostaFascinosa.Repositorio.Interfaz;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class Cordinadore_service : ICordinadore_service
    {
        private readonly ICordinadore_repository _repo;

        public Cordinadore_service(ICordinadore_repository repo)
        {
            _repo = repo;
        }

        public async Task<List<Coordinadore>> GetCoordinadores()
        {
           return await _repo.GetCoordinadores();
        }
    }
}
