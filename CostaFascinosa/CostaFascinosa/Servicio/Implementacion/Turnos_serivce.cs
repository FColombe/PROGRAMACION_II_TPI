using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class Turnos_serivce : ITurno_service
    {
        private readonly ITurno_repository _repo;

        public Turnos_serivce(ITurno_repository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Add(Turno turno)
        {
            return await _repo.Add(turno);
        }

        public async Task<List<Turno>> GetAll()
        {
            return await _repo.GetAll();
        }
    }
}
